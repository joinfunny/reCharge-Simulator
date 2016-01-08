using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace AutoSend
{
    class Log
    {
        #region　输出DEBUG 信息
        /// <summary>
        /// 输出DEBUG 信息
        /// </summary>
        /// <param name="value">信息</param>
        /// <param name="type"></param>
        #endregion
        public  void Debug(String value,int type)
        {
            WriteFarmat(value);
        }

        public  void Info(String value, int type)
        {
            WriteFarmat(value);
        }

        public  void Error(String value, int type)
        {
            WriteFarmat(value);
        }

        public  void Warn(String value, int type)
        {
            WriteFarmat(value);
        }

        public  void Final(String value, int type)
        {
            WriteFarmat(value);
        }


        #region　输出DEBUG 信息
        /// <summary>
        /// 输出DEBUG 信息
        /// </summary>
        /// <param name="value">信息</param>
        /// <param name="type"></param>
        #endregion
        public void Debug(String value)
        {
            WriteFarmat(value);
        }

        public void Info(String value)
        {
            WriteFarmat(value);
        }

        public void Error(String value)
        {
            WriteFarmat(value);
        }

        public void Warn(String value)
        {
            WriteFarmat(value);
        }

        public void Final(String value)
        {
            WriteFarmat(value);
        }


        public  bool IsDebugEnable
        {
            get { return true; }
        }

        public  bool IsInfoEnable
        {
            get { return true; }
        }

        public  bool IsWarnEnable
        {
            get { return true; }
        }


        public  bool IsErrorEnable
        {
            get { return true; }
        }


        public  bool IsFanilEnable
        {
            get { return true; }
        }

        private String WriteFarmat(String message)
        {
            //String time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //String value = "\n" + time + " " + message;
            //Write(value);
            log.Debug(message);
            return "";
        }
        log4net.ILog log = log4net.LogManager.GetLogger("JFStateManager");

        private static void Write(String message)
        {
            string strLuJing = Config.StartUpPath + "logs\\timely" +DateTime.Now .ToString("yyyyMMdd")+".txt";
            StreamWriter sw = new StreamWriter(strLuJing, true, Encoding.UTF8);
            sw.Write(message);
            sw.Close();
        }
    }
    public class LogAddress
    { 
        public static String ALL ="0";

        public static String BACK ="1";

        public static String FRONT = "2";


    }

}
