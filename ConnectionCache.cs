using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDBGUI
{
    internal class ConnectionCache
    {
        private string CacheLocation = Environment.ExpandEnvironmentVariables("%APPDATA%\\libdbgui.cache");
        private Dictionary<string, ConnectionData> m_connectionData = new Dictionary<string, ConnectionData>();

        public Dictionary<string, ConnectionData> ConnectionData
        {
            get { return m_connectionData; } 
        }

        public ConnectionCache() { }

        public bool Load()
        {
            Debug.Assert(m_connectionData.Count == 0, "Load has already been called once");
            try
            {

                FileStream cacheFile = File.Open(CacheLocation, FileMode.OpenOrCreate);

                StreamReader reader = new StreamReader(cacheFile);

                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    if (values.Length != 5)
                        throw new FileLoadException($"Invalid connection string: {line}");

                    ConnectionData data = new ConnectionData()
                    {
                        IpAddress = values[1],
                        Port = int.Parse(values[2]),
                        UserName = values[3],
                        LastAccessDate = DateTime.Parse(values[4])
                    };

                    m_connectionData.Add(values[0], data);
                }



                cacheFile.Close();
            } catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Failed to open connection cache:\n {ex.Message}",
                                "Connection Cache",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;

        }

        public void UpdateAccess(string name)
        {
            m_connectionData[name].LastAccessDate = DateTime.Now;
        }

        public void addEntry(string name, ConnectionData cd)
        {
            cd.LastAccessDate = DateTime.Now;
            m_connectionData.Add(name, cd); 
        }

        /// <summary>
        /// Flush the Dictionary to the cache file.
        /// Format: name,ip,port,username
        /// </summary>
        public void flush()
        {
            try
            {
                FileStream cacheFile = File.Open(CacheLocation, FileMode.OpenOrCreate);
                // todo: optimize
                foreach(KeyValuePair<string, ConnectionData> kvp in m_connectionData)
                {
                    ConnectionData cur = kvp.Value;
                    string output = $"{kvp.Key},{cur.IpAddress},{cur.Port},{cur.UserName},{cur.LastAccessDate.ToString()}\n";

                    byte[] binOutput = new UTF8Encoding().GetBytes(output);
                    cacheFile.Write(binOutput, 0, binOutput.Length);   
                }
                cacheFile.Flush();
                cacheFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open connection cache:\n {ex.Message}",
                                "Connection Cache",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
