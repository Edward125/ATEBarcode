using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SBBarcode
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {

                //p.CamIndex = Convert.ToInt16(args[0]);
                p.ArgStr = args[0].ToUpper();
                try
                {
                    p.RunType = p.RunTypeFlag.Auto;
                    p.WriteLog("Auto Run");
                }
                catch (Exception ex)
                {

                    p.WriteLog("Cam Index Error." + ex.Message);
                }

             

            }
            else
            {
                p.RunType = p.RunTypeFlag.Manual;
                p.WriteLog("Manual Run.");
                
            }
            Application.Run(new frmMain());
        }
    }
}
