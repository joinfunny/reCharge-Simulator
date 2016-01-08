using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using System.Web.Security;
using System.Data;
using System.Data.OleDb;

namespace AutoSend
{
    class Share
    {
        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetGetCookieEx(
        string url,
        string cookieName,
        StringBuilder cookieData,
        ref int size,
        int flags,
        IntPtr pReserved);
        private const int INTERNET_COOKIE_HTTPONLY = 0x00002000;
        public static string GetCookie(string url)
        {
            int size = 512;
            StringBuilder sb = new StringBuilder(size);
            if (!InternetGetCookieEx(url, null, sb, ref size, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero))
            {
                if (size < 0)
                {
                    return null;
                }
                sb = new StringBuilder(size);
                if (!InternetGetCookieEx(url, null, sb, ref size, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero))
                {
                    return null;
                }
            }
            return sb.ToString();
        }

        public static String MD5(String value)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(value, "MD5");
        }

        public static String ExceptionToStringForLog(Exception exp)
        {
            StringBuilder message = new StringBuilder("出现异常：\n");
            message.Append("<><><><><><><><><><><><>ERROR<><><><><><><><><><><><><><><><>\n");
            message.Append("TYPE: " + exp.GetType() + "\n");
            message.Append("MSG:" + exp.Message + "\n");
            message.Append("TRACE :" + exp.StackTrace + "\n");
            if (exp.InnerException != null)
            {
                Exception eInner = exp.InnerException;
                message.Append("内部异常为：\n");
                message.Append("TYPE: " + eInner.GetType() + "\n");
                message.Append("MSG:" + eInner.Message + "\n");
                message.Append("TRACE :" + eInner.StackTrace + "\n");
            }
            message.Append("<><><><><><><><><><><><>ERROR<><><><><><><><><><><><><><><><><><>\n\n");
            return message.ToString();
        }
        public static String ExceptionToStringForView(Exception exp)
        {
            return exp.Message;
        }
        public static String AddRadomTime(String url)
        {
            DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            String time = "t=" + (DateTime.UtcNow - Jan1st1970).TotalMilliseconds.ToString("0");
            if (url.IndexOf("?") > 0)
            {
                return url + "&" + time;
            }
            else
            {
                return url + "?" + time;
            }
        }
       
        public static string getPage_GET(String url)
        {
            url = AddRadomTime(url);
            HttpWebResponse res = null;
            string strResult = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
                req.ContentType = "application/x-www-form-urlencoded";
                req.KeepAlive = true;
                req.CookieContainer = Config.WebBrowserCookie;
                req.Referer = "http://chongzhi.jd.com/order/order_place.action?skuId=1000517964&mobile=15110203208&entry=4";
                res = (HttpWebResponse)req.GetResponse();
                Stream ReceiveStream = res.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("GB2312");
                StreamReader sr = new StreamReader(ReceiveStream, encode);
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    strResult += str;
                    count = sr.Read(read, 0, 256);
                }
            }
            catch (Exception e)
            {
                strResult = e.ToString();
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }
            return strResult;
        }


        public static string getPageInterFace(String url, String paramList)
        {
            url = AddRadomTime(url);
            HttpWebResponse res = null;
            string strResult = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.KeepAlive = true;
                req.ContentType = "application/x-www-form-urlencoded";
                StringBuilder UrlEncoded = new StringBuilder();
                Char[] reserved = { '?', '=', '&' };
                byte[] SomeBytes = null;

                if (paramList != null)
                {
                    int i = 0, j;
                    while (i < paramList.Length)
                    {
                        j = paramList.IndexOfAny(reserved, i);
                        if (j == -1)
                        {
                            UrlEncoded.Append(System.Web.HttpUtility.UrlEncode(paramList.Substring(i, paramList.Length - i), Encoding.GetEncoding("GB2312")));
                            break;
                        }
                        UrlEncoded.Append(System.Web.HttpUtility.UrlEncode(paramList.Substring(i, j - i), Encoding.GetEncoding("GB2312")));
                        UrlEncoded.Append(paramList.Substring(j, 1));
                        i = j + 1;
                    }
                    SomeBytes = Encoding.Default.GetBytes(UrlEncoded.ToString());
                    req.ContentLength = SomeBytes.Length;
                    Stream newStream = req.GetRequestStream();
                    newStream.Write(SomeBytes, 0, SomeBytes.Length);
                    newStream.Close();
                }
                else
                {
                    req.ContentLength = 0;
                }

                res = (HttpWebResponse)req.GetResponse();

                Stream ReceiveStream = res.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("GB2312");
                StreamReader sr = new StreamReader(ReceiveStream, encode);
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    strResult += str;
                    count = sr.Read(read, 0, 256);
                }
            }
            catch (Exception e)
            {
                strResult = e.ToString();
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }

            return strResult;
        }

        public static string getPage(String url, String paramList, string refer)
        {
            url = AddRadomTime(url);
            HttpWebResponse res = null;
            string strResult = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.KeepAlive = true;
                req.ContentType = "application/x-www-form-urlencoded";
                req.Referer = refer;
                req.CookieContainer = Config.WebBrowserCookie;
                StringBuilder UrlEncoded = new StringBuilder();
                Char[] reserved = { '?', '=', '&' };
                byte[] SomeBytes = null;

                if (paramList != null)
                {
                    int i = 0, j;
                    while (i < paramList.Length)
                    {
                        j = paramList.IndexOfAny(reserved, i);
                        if (j == -1)
                        {
                            UrlEncoded.Append(System.Web.HttpUtility.UrlEncode(paramList.Substring(i, paramList.Length - i), Encoding.GetEncoding("GB2312")));
                            break;
                        }
                        UrlEncoded.Append(System.Web.HttpUtility.UrlEncode(paramList.Substring(i, j - i), Encoding.GetEncoding("GB2312")));
                        UrlEncoded.Append(paramList.Substring(j, 1));
                        i = j + 1;
                    }
                    SomeBytes = Encoding.Default.GetBytes(UrlEncoded.ToString());
                    req.ContentLength = SomeBytes.Length;
                    Stream newStream = req.GetRequestStream();
                    newStream.Write(SomeBytes, 0, SomeBytes.Length);
                    newStream.Close();
                }
                else
                {
                    req.ContentLength = 0;
                }

                res = (HttpWebResponse)req.GetResponse();

                Stream ReceiveStream = res.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("GB2312");
                StreamReader sr = new StreamReader(ReceiveStream, encode);
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    strResult += str;
                    count = sr.Read(read, 0, 256);
                }
            }
            catch (Exception e)
            {
                strResult = e.ToString();
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }

            return strResult;
        }

        public static string getPageOrder(String url, String paramList, string refer)
        {
            url = AddRadomTime(url);
            HttpWebResponse res = null;
            string strResult = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.KeepAlive = true;
                req.ContentType = "application/x-www-form-urlencoded";
                req.Referer = refer;
                req.CookieContainer = Config.WebBrowserCookieOrder;
                StringBuilder UrlEncoded = new StringBuilder();
                Char[] reserved = { '?', '=', '&' };
                byte[] SomeBytes = null;

                if (paramList != null)
                {
                    int i = 0, j;
                    while (i < paramList.Length)
                    {
                        j = paramList.IndexOfAny(reserved, i);
                        if (j == -1)
                        {
                            UrlEncoded.Append(System.Web.HttpUtility.UrlEncode(paramList.Substring(i, paramList.Length - i), Encoding.GetEncoding("GB2312")));
                            break;
                        }
                        UrlEncoded.Append(System.Web.HttpUtility.UrlEncode(paramList.Substring(i, j - i), Encoding.GetEncoding("GB2312")));
                        UrlEncoded.Append(paramList.Substring(j, 1));
                        i = j + 1;
                    }
                    SomeBytes = Encoding.Default.GetBytes(UrlEncoded.ToString());
                    req.ContentLength = SomeBytes.Length;
                    Stream newStream = req.GetRequestStream();
                    newStream.Write(SomeBytes, 0, SomeBytes.Length);
                    newStream.Close();
                }
                else
                {
                    req.ContentLength = 0;
                }

                res = (HttpWebResponse)req.GetResponse();

                Stream ReceiveStream = res.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("GB2312");
                StreamReader sr = new StreamReader(ReceiveStream, encode);
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    strResult += str;
                    count = sr.Read(read, 0, 256);
                }
            }
            catch (Exception e)
            {
                strResult = e.ToString();
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }

            return strResult;
        }

        public static string PostDataGBK(string url, string content, string referer)
        {

            string result = "";
            try
            {

                Encoding encoding = Encoding.GetEncoding("GBK");
                byte[] postdata = encoding.GetBytes(content);

                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "POST";
                myRequest.ContentType = "multipart/form-data";
                myRequest.KeepAlive = false;
                myRequest.CookieContainer = Config.WebBrowserCookie;
                myRequest.ContentLength = postdata.Length;
                myRequest.Referer = referer;
                Stream newStream = myRequest.GetRequestStream();

                // 发送数据
                newStream.Write(postdata, 0, postdata.Length);
                newStream.Close();

                // 得到响应数据
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                result = reader.ReadToEnd();//得到结果 
            }
            catch (WebException ex)
            {
                try
                {
                    WebResponse wr = ex.Response;
                    StreamReader sr = new StreamReader(wr.GetResponseStream());
                    result = sr.ReadToEnd();
                }
                catch (Exception ex2)
                {
                    //log.Error(Share.ExceptionToStringForLog(ex));
                }
            }
            catch (Exception ex)
            {
                //log.Error(Share.ExceptionToStringForLog(ex));
            }
            return result;
        }

        public static void SetAppValue(string AppKey, string AppValue)
        {
            System.Xml.XmlDocument xDoc = new XmlDocument();

            //此处配置文件在程序目录下
            xDoc.Load(Application.StartupPath + "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe.config");
            XmlNode xNode;
            XmlElement xElem1;
            XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//appSettings");
            xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
            if (xElem1 != null)
            {
                xElem1.SetAttribute("value", AppValue);
            }
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("key", AppKey);
                xElem2.SetAttribute("value", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(Application.StartupPath + "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe.config");
        }

        public static string DESto(string str)
        {
            byte[] DESKey = { 1, 30, 114, 120, 110, 24, 27, 45 };
            byte[] DESIV = { 175, 45, 40, 110, 45, 41, 112, 113 };
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            MemoryStream objMS = new MemoryStream();
            CryptoStream objCtyptoStream = new CryptoStream(objMS, objDES.CreateEncryptor(DESKey, DESIV), CryptoStreamMode.Write);
            StreamWriter objStreamWriter = new StreamWriter(objCtyptoStream);
            objStreamWriter.Write(str);
            objStreamWriter.Flush();
            objCtyptoStream.FlushFinalBlock();
            objMS.Flush();
            return Convert.ToBase64String(objMS.GetBuffer(), 0, (int)objMS.Length);
        }

        public static string DESForm(string str)
        {
            byte[] DESKey = { 1, 30, 114, 120, 110, 24, 27, 45 };
            byte[] DESIV = { 175, 45, 40, 110, 45, 41, 112, 113 };
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            byte[] input = Convert.FromBase64String(str);
            MemoryStream objMs = new MemoryStream(input);
            CryptoStream objCryptoStream = new CryptoStream(objMs, objDES.CreateDecryptor(DESKey, DESIV), CryptoStreamMode.Read);
            StreamReader objStreamReader = new StreamReader(objCryptoStream);
            return objStreamReader.ReadToEnd();
        }

        public static string Hash(string Content)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(Content, "MD5").ToLower();
        }

        public static string Encrypt(String key, string Value)
        {
            //构造一个对称算法
            SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            mCSP.Key = Convert.FromBase64String(key);
            mCSP.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };// Convert.FromBase64String(sIV);
            //指定加密的运算模式
            mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
            //mCSP.Mode = System.Security.Cryptography.CipherMode.CBC;
            //获取或设置加密算法的填充模式
            mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);
            // byt = Encoding.GetEncoding("GB2312").GetBytes(Value);
            byt = Encoding.UTF8.GetBytes(Value);
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(String key, string str)
        {
            SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();
            mCSP.Key = Convert.FromBase64String(key);
            mCSP.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };// Convert.FromBase64String(sIV);
            //指定加密的运算模式
            mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
            // mCSP.Mode = System.Security.Cryptography.CipherMode.CBC;
            //获取或设置加密算法的填充模式
            mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ICryptoTransform ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
            //   DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            byte[] input = Convert.FromBase64String(str);
            MemoryStream objMs = new MemoryStream(input);
            CryptoStream objCryptoStream = new CryptoStream(objMs, ct, CryptoStreamMode.Read);
            StreamReader objStreamReader = new StreamReader(objCryptoStream);
            return objStreamReader.ReadToEnd();
        }
        public static void UpdateCookieContainerOrder(String cookie, String url)
        {

            String[] cooks = cookie.Split(';');
            int index = url.IndexOf("?");
            if (index > 0)
            {
                url = url.Substring(0, index);
            }


            CookieContainer cookieCon = new CookieContainer();
            for (int i = 0; i < cooks.Length; i++)
            {
                String temp = cooks[i];
                String name = temp.Substring(0, temp.IndexOf("=")).Trim();
                String value = temp.Substring(temp.IndexOf("=") + 1).Trim();

                Cookie cook = new Cookie(name, value);
                cookieCon.Add(new Uri(url), cook);

            }
            Config.WebBrowserCookieOrder = cookieCon;
        }


        public static void UpdateCookieContainer(String cookie, String url)
        {

            String[] cooks = cookie.Split(';');
            int index = url.IndexOf("?");
            if (index > 0)
            {
                url = url.Substring(0, index);
            }


            CookieContainer cookieCon = new CookieContainer();
            for (int i = 0; i < cooks.Length; i++)
            {
                String temp = cooks[i];
                String name = temp.Substring(0, temp.IndexOf("=")).Trim();
                String value = temp.Substring(temp.IndexOf("=") + 1).Trim();

                Cookie cook = new Cookie(name, value);
                cookieCon.Add(new Uri(url), cook);

            }
            Config.WebBrowserCookie = cookieCon;
        }

        public static DataTable ExcelToDataSet(string filename)
        {
            DataTable dt = new DataTable();
            string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                            "Extended Properties=Excel 8.0;" +
                            "data source=" + filename;
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = " SELECT * FROM [Sheet1$]";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            myCommand.Fill(dt);
            myConn.Close();
            return dt;
        }
        public static Boolean updateExcel(string filename, String orderId, String jdOrderId, String jdInTime,String orderStatus)
        {
            try
            {
                //修改第一行Name的值为张三  
                string sqlStr = "update [Sheet1$] set 京东订单号=@jdOrderId,订单状态=@orderStatus,充值时间=@jdInTime WHERE 系统订单号=@orderId";
                string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                               "Extended Properties=Excel 8.0;" +
                               "data source=" + filename;
                OleDbConnection myConn = new OleDbConnection(strCon);
                myConn.Open();
                OleDbCommand rcmd = new OleDbCommand();
                rcmd.Connection = myConn;
                rcmd.CommandText = sqlStr;
                rcmd.CommandType = CommandType.Text;
                rcmd.Parameters.AddWithValue("@jdOrderId", jdOrderId);
                rcmd.Parameters.AddWithValue("@orderStatus", orderStatus);
                rcmd.Parameters.AddWithValue("@jdInTime", jdInTime);
                rcmd.Parameters.AddWithValue("@orderId", orderId);
                rcmd.ExecuteNonQuery();
                myConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string getValue(string start, string end, string html)
        {
            try
            {
                String stringTemp = html.Substring(html.IndexOf(start) + start.Length);
                String result = stringTemp.Substring(0, stringTemp.IndexOf(end)).Trim();
                return result;
            }
            catch(Exception ex)
            {
                return "";
            }
        }

        public static bool getMacherStr(string telephone, string orderTelephone)
        {
            String startStr = telephone.Substring(0, 3);
            String endStr = telephone.Substring(7,4);
            if (orderTelephone.StartsWith(startStr) && orderTelephone.EndsWith(endStr))
            {
                return true;
            }
            return false;
        }
    }
}
