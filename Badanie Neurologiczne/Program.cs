using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Badanie_Neurologiczne
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (ApplicationRunningHelper.AlreadyRunning())
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Istrib.Sound.Example.WinForms.MainForm());
            Application.Run(new Form1());

        }
    }
}
