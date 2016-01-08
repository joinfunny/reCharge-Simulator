using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AutoSend
{
    public class Config
    {
        public static String StartUpPath = Application.StartupPath + "\\";
        public static System.Net.CookieContainer WebBrowserCookie;
        public static System.Net.CookieContainer WebBrowserCookieOrder;
        public static string Machine = "";
        public static string url = "";
        public static string acceptOrderInterfaceUrl = "";
        public static string venderId = "";
        public static string notifyUrl = "";
        public static string md5Key = "";
        public static string connectString = null;
        public static String ConnectString
        {
            get
            {
                if (connectString == null)
                {               
                   //本地
                   connectString = "server=192.168.0.2,7860;DataBase=ChargeUnion;uid=sa;pwd=sa;Provider=SQLOLEDB";
                }
                return connectString;
            }
        }
    }
}
