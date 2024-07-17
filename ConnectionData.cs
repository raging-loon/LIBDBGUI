using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDBGUI
{
    public class ConnectionData
    {
        public string IpAddress         = "Invalid IP";
        public int    Port              = -1;
        public string UserName          = "Invalid User Name";
        public DateTime LastAccessDate;
    }
}
