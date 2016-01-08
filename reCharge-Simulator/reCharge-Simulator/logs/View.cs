using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AutoSend
{
    public class View
    {
        public static MainForm frm;
        public static void write(String message)
        {
            String time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String mes = time + "： " + message + "\n";
            
             //如果当前的文本和以前的文本之和　大于文本框的最大长度，进行清空
            if (frm.rtbLog.TextLength + mes.Length >= frm.rtbLog.MaxLength)
                frm.rtbLog.Text = "";

          //  frm.rtbLog.AppendText(mes);
            frm.WirtelogTh(mes);
        }
    }
}
