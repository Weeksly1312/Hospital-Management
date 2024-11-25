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

        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

           
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void dashboard_TE_Click(object sender, EventArgs e)
        {

        }
    }
}
