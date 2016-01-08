using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using auto;



namespace AutoSend
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //窗体加载
        private void MainForm_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            try
            {
                Config.Machine = Share.DESForm(ConfigurationManager.AppSettings["Machine"]);
                Config.acceptOrderInterfaceUrl = ConfigurationManager.AppSettings["acceptOrderInterfaceUrl"];
                Config.url = ConfigurationManager.AppSettings["url"];
                Config.venderId = ConfigurationManager.AppSettings["venderId"];
                Config.notifyUrl = ConfigurationManager.AppSettings["notifyUrl"];
                Config.md5Key = Share.DESForm(ConfigurationManager.AppSettings["md5Key"]);
                webBrowserLogin.ScriptErrorsSuppressed = true;
                this.webBrowserLogin.Navigate(Config.url);
                View.write("程序初始化完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("检查到参数信息未设置或设置错误，请重新设置!");
                FormSet frm = new FormSet();
                frm.ShowDialog();
                MessageBox.Show("您重新设置了参数信息，重新打开软件使配置生效!");
                this.Close();
                return;
            }
        }
        Log log = new Log();


        private void btnRegex_Click(object sender, EventArgs e)
        {
            FormSet frm = new FormSet();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("您重新设置了参数信息，重新打开软件使配置生效!");
                this.Close();
            }
        }

        #region 程序关闭时的事件
        /// <summary>
        /// 程序关闭时的事件,主要防止一条记录没有处理完时被结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #endregion
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 要等程结束才能停止
            if (acceptOrderThread != null && acceptOrderThread.IsAlive || SubmitChargeThread != null && SubmitChargeThread.IsAlive || statusNotifyThread != null && statusNotifyThread.IsAlive || queryOrderStatusThread != null && queryOrderStatusThread.IsAlive)
            {
                MessageBox.Show("程序正在运行，请结束后，再进行关闭!");
                e.Cancel = true;
                return;
            }
        }

        public void WirtelogTh(String msg)
        {
            this.rtbLog.Invoke(new EventHandler(delegate
            {
                if (rtbLog.TextLength + msg.Length >= rtbLog.MaxLength)
                    rtbLog.Text = "";
                rtbLog.AppendText(msg);
            }));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String result = Share.getPage_GET("http://order.jd.com/center/list.action?r=" + new Random().Next(1, 999999999));
            log.Debug("保持连接结果:" + result);
        }

        String startOrderStr = "开启收单接口";
        String endOrderStr = "结束收单接口";
        Thread acceptOrderThread;
        bool startMark = false;
        HttpListener httpListenner = new HttpListener();
        private void acceptOrderInterfaceBtn_Click(object sender, EventArgs e)
        {
            // 当程序要结束时，进行判断当时时的状态
            if (this.acceptOrderInterfaceBtn.Text == endOrderStr || this.acceptOrderInterfaceBtn.Text == "结束中")
            {
                startMark = false;
                if (httpListenner != null && httpListenner.IsListening)
                {
                    //httpListenner.Stop();
                    httpListenner.Close();
                }
                if (acceptOrderThread != null && acceptOrderThread.IsAlive)
                {
                    acceptOrderThread.Abort();
                    acceptOrderThread = null;
                }
                this.acceptOrderInterfaceBtn.Text = startOrderStr;
                log.Debug("收单程序结束运行");
                View.write("收单程序结束运行");
            }
            else
            {
                if (!HttpListener.IsSupported)
                {
                    throw new System.InvalidOperationException("版本太低");
                }
                this.acceptOrderInterfaceBtn.Text = endOrderStr;
                startMark = true;
                httpListenner = new HttpListener();
                httpListenner.AuthenticationSchemes = AuthenticationSchemes.Anonymous;//指定身份验证 Anonymous匿名访问
                httpListenner.Prefixes.Add(Config.acceptOrderInterfaceUrl);
                httpListenner.Start();
                log.Debug("收单接口程序启动成功！");
                View.write("收单接口程序启动成功！");
                acceptOrderThread = new Thread(new ThreadStart(delegate
                {
                    try
                    {
                        loop(httpListenner);
                    }
                    catch (Exception ex)
                    {
                        log.Debug("收单接口异常:" + ex);
                    }
                }));
                acceptOrderThread.Start();
            }
        }

        private void loop(HttpListener httpListenner)
        {
            while (startMark)
            {
                HttpListenerRequest request = null;
                HttpListenerResponse response = null;
                StreamWriter writer = null;
                try
                {
                    HttpListenerContext context = httpListenner.GetContext();
                    request = context.Request;
                    //分析插入订单
                    StateHandle handle = new StateHandle();
                    OrderInfo phoneInfo = new OrderInfo();
                    phoneInfo.vender_id = request.QueryString["venderId"];
                    phoneInfo.order_id = request.QueryString["orderId"];
                    phoneInfo.face_price = request.QueryString["facePrice"];
                    phoneInfo.phone_no = request.QueryString["phoneNo"];
                    phoneInfo.provider = request.QueryString["provider"];
                    phoneInfo.province_code = request.QueryString["provinceCode"];
                    phoneInfo.city_code = request.QueryString["cityCode"];
                    phoneInfo.order_status = "0";
                    String inTime = request.QueryString["inTime"];
                    String sign = request.QueryString["sign"];
                    StringBuilder sb = new StringBuilder();
                    sb.Append("venderId=").Append(phoneInfo.vender_id)
                    .Append("&orderId=").Append(phoneInfo.order_id)
                    .Append("&phoneNo=").Append(phoneInfo.phone_no)
                    .Append("&facePrice=").Append(phoneInfo.face_price)
                    .Append("&provider=").Append(phoneInfo.provider)
                    .Append("&provinceCode=").Append(phoneInfo.province_code)
                    .Append("&cityCode=").Append(phoneInfo.city_code)
                    .Append("&inTime=").Append(inTime)
                    .Append("&key=").Append(Config.md5Key);
                    String _sign = Share.MD5(sb.ToString()).ToLower();
                    String res = "";
                    if (phoneInfo.vender_id == null || "".Equals(phoneInfo.vender_id) || phoneInfo.order_id == null || "".Equals(phoneInfo.order_id)
                        || phoneInfo.face_price == null || "".Equals(phoneInfo.face_price) || phoneInfo.phone_no == null || "".Equals(phoneInfo.phone_no)
                        || inTime == null || "".Equals(inTime) || sign == null || "".Equals(sign)
                        )
                    {
                        res = "000001";
                    }
                    else if (!_sign.Equals(sign))
                    {
                        res = "000005";
                    }
                    else
                    {
                        //验证时间戳（略）

                        //验证订单号
                        int count = handle.selectCountByOrderId(phoneInfo);
                        if (count <= 0)
                        {
                            int insertCount = handle.insertOrderService(phoneInfo);
                            if (insertCount > 0)
                            {
                                res = "000000";
                            }
                            else
                            {
                                res = "000003";
                            }
                        }
                        else
                        {
                            res = "000004";
                        }
                    }
                    response = context.Response;
                    response.StatusCode = 200;
                    writer = new StreamWriter(response.OutputStream);
                    writer.Write(res);
                    writer.Close();
                    response.Close();
                    View.write("收单接口orderId:" + phoneInfo.order_id + "，录入结果:" + res);
                    log.Debug("收单接口orderId:" + phoneInfo.order_id + "，录入结果:" + res);
                }
                catch (Exception ex)
                {
                    log.Debug("收单接口异常:" + ex);
                }
                finally
                {
                    try
                    {
                        if (writer != null)
                        {
                            writer.Close();
                        }
                        if (response != null)
                        {
                            response.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Debug("收单接口异常:" + ex);
                        View.write("收单接口异常:" + ex);
                    }
                }
            }
        }

        Thread SubmitChargeThread;
        String submitOrderStart = "开启自动提单";
        String submitOrderEnd = "结束自动提单";
        private void submitOrderBtn_Click(object sender, EventArgs e)
        {
            // 当程序要结束时，进行判断当时时的状态
            if (this.submitOrderBtn.Text == submitOrderEnd || this.submitOrderBtn.Text == "结束中")
            {
                if (SubmitChargeThread != null && SubmitChargeThread.IsAlive)
                {
                    SubmitChargeThread.Abort();
                    SubmitChargeThread = null;
                }
                this.submitOrderBtn.Text = submitOrderStart;
                log.Debug("自动提单程序结束运行");
                View.write("自动提单程序结束运行");
            }
            else
            {
                try
                {
                    #region 记录日志
                    log.Debug("自动提单程序准备开始");
                    View.write("自动提单程序准备开始");
                    #endregion
                    this.submitOrderBtn.Text = submitOrderEnd;
                    timer1.Enabled = true;
                    String cookie = Share.GetCookie(webBrowserLogin.Url.ToString());
                    Share.UpdateCookieContainer(cookie, "http://chongzhi.jd.com");
                    Share.UpdateCookieContainerOrder(cookie, "http://order.jd.com");
                    SubmitChargeThread = new Thread(new ThreadStart(submitCharge));
                    SubmitChargeThread.ApartmentState = ApartmentState.STA;
                    SubmitChargeThread.Start();
                    #region 记录日志
                    log.Debug("自动提单程序已经开始自动运行");
                    View.write("自动提单程序已经开始自动运行");
                    #endregion
                }
                catch (Exception exp)
                {
                    log.Error(Share.ExceptionToStringForLog(exp));
                    MessageBox.Show(Share.ExceptionToStringForView(exp));
                }
            }
        }

        private void submitCharge()
        {
            while (true)
            {
                try
                {
                    this.tbxLastRunTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    StateHandle handle = new StateHandle();
                    OrderInfo phoneInfo = handle.submitOrderService(this);
                    if (phoneInfo == null)
                    {
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Thread.Sleep(2000);
                    }
                }
                catch (Exception ex)
                {
                    View.write(Share.ExceptionToStringForView(ex));
                    log.Debug(Share.ExceptionToStringForView(ex));
                    Thread.Sleep(2000);//异常时休息
                }
            }
        }

        Thread queryOrderStatusThread;
        String queryOrderStatusStart = "开启订单查询";
        String queryOrderStatusEnd = "结束订单查询";
        private void queryOrderStatusBtn_Click(object sender, EventArgs e)
        {
            // 当程序要结束时，进行判断当时时的状态
            if (this.queryOrderStatusBtn.Text == queryOrderStatusEnd || this.queryOrderStatusBtn.Text == "结束中")
            {
                if (queryOrderStatusThread != null && queryOrderStatusThread.IsAlive)
                {
                    queryOrderStatusThread.Abort();
                    queryOrderStatusThread = null;
                }
                this.queryOrderStatusBtn.Text = queryOrderStatusStart;
                log.Debug("订单查询序结束运行");
                View.write("订单查询程序结束运行");
            }
            else
            {
                try
                {
                    #region 记录日志
                    log.Debug("订单查询程序准备开始");
                    View.write("订单查询程序准备开始");
                    #endregion
                    this.queryOrderStatusBtn.Text = queryOrderStatusEnd;
                    queryOrderStatusThread = new Thread(new ThreadStart(queryOrderStatus));
                    queryOrderStatusThread.ApartmentState = ApartmentState.STA;
                    queryOrderStatusThread.Start();
                    #region 记录日志
                    log.Debug("订单查询程序已经开始自动运行");
                    View.write("订单查询程序已经开始自动运行");
                    #endregion
                }
                catch (Exception exp)
                {
                    log.Error(Share.ExceptionToStringForLog(exp));
                    MessageBox.Show(Share.ExceptionToStringForView(exp));
                }
            }
        }

        Thread statusNotifyThread;
        String statusNotifyStart = "开启状态通知";
        String statusNotifyEnd = "结束状态通知";
        private void statusNotifyBtn_Click(object sender, EventArgs e)
        {
            // 当程序要结束时，进行判断当时时的状态
            if (this.statusNotifyBtn.Text == statusNotifyEnd || this.statusNotifyBtn.Text == "结束中")
            {
                if (statusNotifyThread != null && statusNotifyThread.IsAlive)
                {
                    statusNotifyThread.Abort();
                    statusNotifyThread = null;
                }
                this.statusNotifyBtn.Text = statusNotifyStart;
                log.Debug("状态通知程序结束运行");
                View.write("状态通知程序结束运行");
            }
            else
            {
                try
                {
                    #region 记录日志
                    log.Debug("状态通知程序准备开始");
                    View.write("状态通知程序准备开始");
                    #endregion
                    this.statusNotifyBtn.Text = statusNotifyEnd;
                    statusNotifyThread = new Thread(new ThreadStart(statusNotify));
                    statusNotifyThread.ApartmentState = ApartmentState.STA;
                    statusNotifyThread.Start();
                    #region 记录日志
                    log.Debug("状态通知程序已经开始自动运行");
                    View.write("状态通知程序已经开始自动运行");
                    #endregion
                }
                catch (Exception exp)
                {
                    log.Error(Share.ExceptionToStringForLog(exp));
                    MessageBox.Show(Share.ExceptionToStringForView(exp));
                }
            }
        }

        private void queryOrderStatus()
        {
            while (true)
            {
                try
                {
                    StateHandle handle = new StateHandle();
                    List<OrderInfo> phoneInfoList = handle.queryOrderStatus(this);
                    if (phoneInfoList == null || phoneInfoList.Count <=0)
                    {
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Thread.Sleep(2000);
                    }
                }
                catch (Exception ex)
                {
                    View.write(Share.ExceptionToStringForView(ex));
                    log.Debug(Share.ExceptionToStringForView(ex));
                    Thread.Sleep(1000);//异常时休息
                }
            }
        }

        private void statusNotify()
        {
            while (true)
            {
                try
                {
                    StateHandle handle = new StateHandle();
                    List<OrderInfo> phoneInfoList = handle.statusNotify(this);
                    if (phoneInfoList == null || phoneInfoList.Count <= 0)
                    {
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Thread.Sleep(2000);
                    }
                }
                catch (Exception ex)
                {
                    View.write(Share.ExceptionToStringForView(ex));
                    log.Debug(Share.ExceptionToStringForView(ex));
                    Thread.Sleep(1000);//异常时休息
                }
            }
        }

        private void queryOrderBtn_Click(object sender, EventArgs e)
        {
            FormQueryOrder frm = new FormQueryOrder();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          String  youHuiQuanJson = Share.getPage("http://chongzhi.jd.com/json/order/searchp_searchDxqInfo.action", "ISP=" + 2 + "&jdPrice=" + 98.00, "");
          MessageBox.Show(youHuiQuanJson);
        }
    }
}

