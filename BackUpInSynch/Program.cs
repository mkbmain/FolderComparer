using System;
using System.IO;
using System.Windows.Forms;
using BackUpInSynch.FormsAndControls.MainForm;

namespace BackUpInSynch
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}