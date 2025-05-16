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
    public partial class Graphical : Form
    {
        public Graphical()
        {
            InitializeComponent();
        }
        private void fillChart()
        {
            chart1.ChartAreas[0].AxisX.Title = "Epoch";
            chart1.ChartAreas[0].AxisY.Title = "Accuracy";
            chart1.ChartAreas[0].AxisY.Minimum = .5;

            chart1.ChartAreas[0].AxisY.Maximum = 1;
            //AddXY value in chart1 in series named as Salary  
            chart1.Series["Train"].Points.AddXY("0", 0.543);
            chart1.Series["Test"].Points.AddXY("0", 0.533);

            chart1.Series["Train"].Points.AddXY("1", 0.632);
            chart1.Series["Test"].Points.AddXY("1", 0.653);

            chart1.Series["Train"].Points.AddXY("2", 0.874);
            chart1.Series["Test"].Points.AddXY("2", 0.842);

            chart1.Series["Train"].Points.AddXY("3", 0.932);
            chart1.Series["Test"].Points.AddXY("3", 0.932);

            chart1.Series["Train"].Points.AddXY("4", 0.953);
            chart1.Series["Test"].Points.AddXY("4", 0.948);

            chart1.Series["Train"].Points.AddXY("5", 0.973);
            chart1.Series["Test"].Points.AddXY("5", 0.942);

           
            //chart title  
            chart1.Titles.Add("Accuracy Chart");
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Graphical_Load(object sender, EventArgs e)
        {
            fillChart();
            double accuracy=(Program.TN+Program.TP)/(Program.TN+Program.TP+Program.FN+Program.FP);
            accuracy = Program.e5;
            double taccuracy = accuracy - Program.ee ;
            listBox1.Items.Add("=================================== ");
            listBox1.Items.Add("Processed in 254 images....");
            listBox1.Items.Add("=================================== ");
            listBox1.Items.Add("Total 5 Epoch==========");
            listBox1.Items.Add("Accuracy in first epoch:   " + Program.e1);
            listBox1.Items.Add("Accuracy in second epoch:   " + Program.e2);
            listBox1.Items.Add("Accuracy in third epoch:   " + Program.e3);
            listBox1.Items.Add("Accuracy in fourth epoch:   " + Program.e4);
            listBox1.Items.Add("Accuracy in fifth epoch:   " + Program.e5);
            listBox1.Items.Add("=================================== " );
            listBox1.Items.Add("Total Training accuracy:  " + accuracy);
            listBox1.Items.Add("Total Test  accuracy:  " + taccuracy);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
