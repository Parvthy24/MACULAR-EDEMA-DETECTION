using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace dRd
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static string funduspath = "";
        public static string dfunduspath = "";
        public static Bitmap resized;
        public static Bitmap cropped;
        public static Bitmap gaussian;
        public static Bitmap hflip;
        public static Bitmap vflip;
        public static Bitmap a1;
        public static Bitmap a2;
        public static Bitmap a3;
        public static Bitmap a4;
        public static double ee = 0.0271;
        public static string exudates="false";
        public static string hemorrages ="false";
        public static string cottonwool ="false";
        public static string aneurysm ="false";
        public static Bitmap ex;
        public static Bitmap he;
        public static Bitmap co;
        public static Bitmap an;
        public static String data1 = "";
        public static double TN = 0;
        public static double TP = 0;
        public static double FN = 0;
        public static double FP = 0;
        public static double e1 = 0.543;
        public static double e2 = 0.632;
        public static double e3 = 0.932;
        public static double e4 = 0.953;
        public static double e5 = 0.973;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Homepage());
        }
    }
}
