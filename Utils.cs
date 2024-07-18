using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDBGUI
{
    internal class Utils
    {
        public static void ShowError(string message, string caption)
        {
            MessageBox.Show(
                message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error
            );
        }

    }
}
