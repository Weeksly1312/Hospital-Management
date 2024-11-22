using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Hosp
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();

            //displayTE();
            //displayAE();
            //displayIE();
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            //displayTE();
            //displayAE();
            //displayIE();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
