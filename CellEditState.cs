using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDBGUI
{
    internal class CellEditState
    {
        private DataGridViewCell m_cell;
        public object PreviousValue { get; private set; }
        public CellEditState(DataGridViewCell cell)
        {
            m_cell = cell;
            PreviousValue = cell.Value;
        }

        public bool Changed(DataGridViewCell cell)
        {
            return PreviousValue != cell.Value; 
        }


    }
}
