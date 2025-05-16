using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dRd
{
    public partial class BasePage : Form
    {
        public BasePage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            T_1_FundusUpload obj = new T_1_FundusUpload();
            
            obj.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            D_1_FundusUpload obj = new D_1_FundusUpload();
            
            obj.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
