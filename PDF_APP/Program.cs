using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF_APP
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1("junior", "c#/.net", "a@a.com", "Univer\nCourse1\nCourse2", "Educ1\nEduc2", "Comp1\ncomp2","A1", "C#\nsql"));
        }
    }
}
