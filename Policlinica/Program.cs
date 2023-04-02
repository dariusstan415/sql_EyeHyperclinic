using System;
using System.Windows.Forms;

namespace Policlinica
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
            //new LoginMenu().Show();
            Application.Run(new LoginMenu());
            //Application.Run();
        }
    }
}
