using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoSend
{
    static class Program
    {
        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Config.connectString = "Data Source=OrderCache.db";

            MainForm frm = new MainForm();
            View.frm = frm;
            Application.Run(frm);
        }
    }
}
