using System;
using System.Windows.Forms;

namespace Latite
{
    static class Latite
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LatiteForm());
        }
    }
}
