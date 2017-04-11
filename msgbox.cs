using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodosNumericos
{
    public static class msgbox
    {
        public static void error(string mscord)
        {
            MessageBox.Show(mscord, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
