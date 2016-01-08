namespace AutoSend
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.webBrowserLogin = new System.Windows.Forms.WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnRegex = new System.Windows.Forms.Button();
            this.acceptOrderInterfaceBtn = new System.Windows.Forms.Button();
            this.submitOrderBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.queryOrderStatusBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.queryOrderBtn = new System.Windows.Forms.Button();
            this.statusNotifyBtn = new System.Windows.Forms.Button();
            this.tbxLastRunTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.Black;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbLog.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbLog.ForeColor = System.Drawing.Color.LightGray;
            this.rtbLog.HideSelection = false;
            this.rtbLog.Location = new System.Drawing.Point(130, 465);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(1010, 117);
            this.rtbLog.TabIndex = 3;
            this.rtbLog.Text = "";
            // 
            // webBrowserLogin
            // 
            this.webBrowserLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserLogin.Location = new System.Drawing.Point(130, 3);
            this.webBrowserLogin.Margin = new System.Windows.Forms.Padding(1);
            this.webBrowserLogin.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserLogin.Name = "webBrowserLogin";
            this.webBrowserLogin.Size = new System.Drawing.Size(1010, 459);
            this.webBrowserLogin.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(130, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1010, 3);
            this.splitter1.TabIndex = 25;
            this.splitter1.TabStop = false;
            // 
            // btnRegex
            // 
            this.btnRegex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegex.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegex.Location = new System.Drawing.Point(12, 305);
            this.btnRegex.Name = "btnRegex";
            this.btnRegex.Size = new System.Drawing.Size(100, 29);
            this.btnRegex.TabIndex = 5;
            this.btnRegex.Text = "参数设置";
            this.btnRegex.UseVisualStyleBackColor = true;
            this.btnRegex.Click += new System.EventHandler(this.btnRegex_Click);
            // 
            // acceptOrderInterfaceBtn
            // 
            this.acceptOrderInterfaceBtn.Location = new System.Drawing.Point(12, 14);
            this.acceptOrderInterfaceBtn.Name = "acceptOrderInterfaceBtn";
            this.acceptOrderInterfaceBtn.Size = new System.Drawing.Size(100, 34);
            this.acceptOrderInterfaceBtn.TabIndex = 0;
            this.acceptOrderInterfaceBtn.Text = "开启收单接口";
            this.acceptOrderInterfaceBtn.UseVisualStyleBackColor = true;
            this.acceptOrderInterfaceBtn.Click += new System.EventHandler(this.acceptOrderInterfaceBtn_Click);
            // 
            // submitOrderBtn
            // 
            this.submitOrderBtn.Location = new System.Drawing.Point(12, 56);
            this.submitOrderBtn.Name = "submitOrderBtn";
            this.submitOrderBtn.Size = new System.Drawing.Size(100, 34);
            this.submitOrderBtn.TabIndex = 1;
            this.submitOrderBtn.Text = "开启自动提单";
            this.submitOrderBtn.UseVisualStyleBackColor = true;
            this.submitOrderBtn.Click += new System.EventHandler(this.submitOrderBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.queryOrderBtn);
            this.panel2.Controls.Add(this.btnRegex);
            this.panel2.Controls.Add(this.tbxLastRunTime);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.queryOrderStatusBtn);
            this.panel2.Controls.Add(this.statusNotifyBtn);
            this.panel2.Controls.Add(this.submitOrderBtn);
            this.panel2.Controls.Add(this.acceptOrderInterfaceBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(130, 582);
            this.panel2.TabIndex = 24;
            // 
            // queryOrderStatusBtn
            // 
            this.queryOrderStatusBtn.Location = new System.Drawing.Point(12, 98);
            this.queryOrderStatusBtn.Name = "queryOrderStatusBtn";
            this.queryOrderStatusBtn.Size = new System.Drawing.Size(100, 34);
            this.queryOrderStatusBtn.TabIndex = 49;
            this.queryOrderStatusBtn.Text = "开启订单查询";
            this.queryOrderStatusBtn.UseVisualStyleBackColor = true;
            this.queryOrderStatusBtn.Click += new System.EventHandler(this.queryOrderStatusBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 347);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 48;
            this.button2.Text = "校验登录";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // queryOrderBtn
            // 
            this.queryOrderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.queryOrderBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.queryOrderBtn.Location = new System.Drawing.Point(12, 263);
            this.queryOrderBtn.Name = "queryOrderBtn";
            this.queryOrderBtn.Size = new System.Drawing.Size(100, 29);
            this.queryOrderBtn.TabIndex = 4;
            this.queryOrderBtn.Text = "订单查询";
            this.queryOrderBtn.UseVisualStyleBackColor = true;
            this.queryOrderBtn.Click += new System.EventHandler(this.queryOrderBtn_Click);
            // 
            // statusNotifyBtn
            // 
            this.statusNotifyBtn.Location = new System.Drawing.Point(12, 140);
            this.statusNotifyBtn.Name = "statusNotifyBtn";
            this.statusNotifyBtn.Size = new System.Drawing.Size(100, 34);
            this.statusNotifyBtn.TabIndex = 2;
            this.statusNotifyBtn.Text = "开启状态通知";
            this.statusNotifyBtn.UseVisualStyleBackColor = true;
            this.statusNotifyBtn.Click += new System.EventHandler(this.statusNotifyBtn_Click);
            // 
            // tbxLastRunTime
            // 
            this.tbxLastRunTime.BackColor = System.Drawing.Color.White;
            this.tbxLastRunTime.Location = new System.Drawing.Point(4, 231);
            this.tbxLastRunTime.Name = "tbxLastRunTime";
            this.tbxLastRunTime.ReadOnly = true;
            this.tbxLastRunTime.Size = new System.Drawing.Size(123, 21);
            this.tbxLastRunTime.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "最后一次扫描时间：";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(130, 462);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1010, 3);
            this.splitter2.TabIndex = 26;
            this.splitter2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1140, 582);
            this.Controls.Add(this.webBrowserLogin);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "京东优惠券充值V1.0.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox rtbLog;
        public System.Windows.Forms.WebBrowser webBrowserLogin;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnRegex;
        private System.Windows.Forms.Button acceptOrderInterfaceBtn;
        private System.Windows.Forms.Button submitOrderBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button queryOrderBtn;
        private System.Windows.Forms.Button statusNotifyBtn;
        private System.Windows.Forms.TextBox tbxLastRunTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button queryOrderStatusBtn;



    }
}

