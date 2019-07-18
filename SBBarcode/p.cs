using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edward;
using System.IO;
using System.Windows.Forms;

namespace SBBarcode
{
    class p
    {

        public enum RunTypeFlag
        {
            Manual,
            Auto
        }


        public static  RunTypeFlag RunType;
        public static int CamIndex = 0;

        public static string IniFile = Application.StartupPath +@"\SysConfig.ini";

        public static string SNFolder =Application.StartupPath + @"\SN";
        public static string LeftAHWID = "";
        public static string LeftBHWID = "";
        public static string RightAHWID = "";
        public static string RightBHWID = "";
        public static string LeftASN = @"\LA";
        public static string LeftBSN = @"\LB";
        public static string RightASN = @"\RA";
        public static string RightBSN = @"\RB";

        public static string ArgStr = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="msg"></param>
        public static void WriteLog(string filename, string msg)
        {
            StreamWriter sw = new StreamWriter(filename, false);
            sw.WriteLine(msg);
            sw.Close();

        }

        public static void WriteLog(string msg)
        {
            StreamWriter sw = new StreamWriter("Log.txt", true);
            string it = DateTime.Now.ToString("yyyyMMddHHmmss") + "->" + msg;
            sw.WriteLine(it);
            sw.Close();
        }

    }
}
