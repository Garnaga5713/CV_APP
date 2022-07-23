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
            Application.Run(new Tech_Pos());
           //  Application.Run(new Form1("junior", "c#/.net","Petrov A. O.", "petrov@gmail.com", "Univer QWE in Asd \ncourses in asdasd company\n qwe certification in asdqwe conpany", "1 year in zxc company as trainee .net dev\n 6 month in asd company as Junior .net dev", "B1-Intermediate", "C#\nSQL\nHTML\nCSS\nJS\n"));
           

        }
    }
}
