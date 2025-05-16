using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dRd
{
    public partial class DetectionPhase : Form
    {
        public DetectionPhase()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            D_1_FundusUpload obj = new D_1_FundusUpload();

            obj.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Graphical obj = new Graphical();
            obj.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Homepage obj = new Homepage();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
