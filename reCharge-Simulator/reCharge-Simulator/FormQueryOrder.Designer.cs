namespace auto
{
    partial class FormQueryOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.tbxPhoneNo = new System.Windows.Forms.TextBox();
            this.tbxOrderId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.QueryOrderBtn = new System.Windows.Forms.Button();
            this.dgvOrderShow = new System.Windows.Forms.DataGridView();
            this.order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vender_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vender_order_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.face_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submit_recharge_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notify_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notify_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notify_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.province_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fail_reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.features = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxPage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelPage = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderShow)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.tbxPhoneNo);
            this.panel1.Controls.Add(this.tbxOrderId);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.QueryOrderBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1428, 60);
            this.panel1.TabIndex = 0;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpEnd.Location = new System.Drawing.Point(320, 16);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(151, 21);
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.Checked = false;
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(77, 16);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(161, 21);
            this.dtpStart.TabIndex = 0;
            // 
            // tbxPhoneNo
            // 
            this.tbxPhoneNo.Location = new System.Drawing.Point(779, 16);
            this.tbxPhoneNo.Name = "tbxPhoneNo";
            this.tbxPhoneNo.Size = new System.Drawing.Size(133, 21);
            this.tbxPhoneNo.TabIndex = 3;
            // 
            // tbxOrderId
            // 
            this.tbxOrderId.Location = new System.Drawing.Point(546, 16);
            this.tbxOrderId.Name = "tbxOrderId";
            this.tbxOrderId.Size = new System.Drawing.Size(174, 21);
            this.tbxOrderId.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(726, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "手机号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "订单号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束时间:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "开始时间:";
            // 
            // QueryOrderBtn
            // 
            this.QueryOrderBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QueryOrderBtn.ForeColor = System.Drawing.Color.Blue;
            this.QueryOrderBtn.Location = new System.Drawing.Point(980, 10);
            this.QueryOrderBtn.Name = "QueryOrderBtn";
            this.QueryOrderBtn.Size = new System.Drawing.Size(80, 42);
            this.QueryOrderBtn.TabIndex = 4;
            this.QueryOrderBtn.Text = "查 询";
            this.QueryOrderBtn.UseVisualStyleBackColor = true;
            this.QueryOrderBtn.Click += new System.EventHandler(this.QueryOrderBtn_Click);
            // 
            // dgvOrderShow
            // 
            this.dgvOrderShow.AllowUserToAddRows = false;
            this.dgvOrderShow.AllowUserToDeleteRows = false;
            this.dgvOrderShow.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvOrderShow.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrderShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderShow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvOrderShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order_id,
            this.vender_id,
            this.vender_order_no,
            this.phone_no,
            this.face_price,
            this.order_status,
            this.created,
            this.submit_recharge_time,
            this.notify_status,
            this.notify_count,
            this.notify_time,
            this.provider,
            this.province_code,
            this.city_code,
            this.fail_reason,
            this.features});
            this.dgvOrderShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderShow.Location = new System.Drawing.Point(0, 60);
            this.dgvOrderShow.Name = "dgvOrderShow";
            this.dgvOrderShow.ReadOnly = true;
            this.dgvOrderShow.RowTemplate.Height = 23;
            this.dgvOrderShow.Size = new System.Drawing.Size(1428, 522);
            this.dgvOrderShow.TabIndex = 3;
            // 
            // order_id
            // 
            this.order_id.DataPropertyName = "order_id";
            this.order_id.FillWeight = 82.35355F;
            this.order_id.HeaderText = "订单号";
            this.order_id.Name = "order_id";
            this.order_id.ReadOnly = true;
            // 
            // vender_id
            // 
            this.vender_id.DataPropertyName = "vender_id";
            this.vender_id.FillWeight = 82.35355F;
            this.vender_id.HeaderText = "供应商";
            this.vender_id.Name = "vender_id";
            this.vender_id.ReadOnly = true;
            // 
            // vender_order_no
            // 
            this.vender_order_no.DataPropertyName = "vender_order_no";
            this.vender_order_no.FillWeight = 133.8245F;
            this.vender_order_no.HeaderText = "供应商订单号";
            this.vender_order_no.Name = "vender_order_no";
            this.vender_order_no.ReadOnly = true;
            // 
            // phone_no
            // 
            this.phone_no.DataPropertyName = "phone_no";
            this.phone_no.FillWeight = 82.35355F;
            this.phone_no.HeaderText = "号码";
            this.phone_no.Name = "phone_no";
            this.phone_no.ReadOnly = true;
            // 
            // face_price
            // 
            this.face_price.DataPropertyName = "face_price";
            this.face_price.FillWeight = 61.76516F;
            this.face_price.HeaderText = "面值";
            this.face_price.Name = "face_price";
            this.face_price.ReadOnly = true;
            // 
            // order_status
            // 
            this.order_status.DataPropertyName = "order_status";
            this.order_status.FillWeight = 82.35355F;
            this.order_status.HeaderText = "订单状态";
            this.order_status.Name = "order_status";
            this.order_status.ReadOnly = true;
            // 
            // created
            // 
            this.created.DataPropertyName = "created";
            this.created.FillWeight = 123.5303F;
            this.created.HeaderText = "订单录入时间";
            this.created.Name = "created";
            this.created.ReadOnly = true;
            // 
            // submit_recharge_time
            // 
            this.submit_recharge_time.DataPropertyName = "submit_recharge_time";
            this.submit_recharge_time.FillWeight = 123.5303F;
            this.submit_recharge_time.HeaderText = "提交充值时间";
            this.submit_recharge_time.Name = "submit_recharge_time";
            this.submit_recharge_time.ReadOnly = true;
            // 
            // notify_status
            // 
            this.notify_status.DataPropertyName = "notify_status";
            this.notify_status.FillWeight = 82.35355F;
            this.notify_status.HeaderText = "通知状态";
            this.notify_status.Name = "notify_status";
            this.notify_status.ReadOnly = true;
            // 
            // notify_count
            // 
            this.notify_count.DataPropertyName = "notify_count";
            this.notify_count.FillWeight = 82.35355F;
            this.notify_count.HeaderText = "通知次数";
            this.notify_count.Name = "notify_count";
            this.notify_count.ReadOnly = true;
            // 
            // notify_time
            // 
            this.notify_time.DataPropertyName = "notify_time";
            this.notify_time.FillWeight = 123.5303F;
            this.notify_time.HeaderText = "最后通知时间";
            this.notify_time.Name = "notify_time";
            this.notify_time.ReadOnly = true;
            // 
            // provider
            // 
            this.provider.DataPropertyName = "provider";
            this.provider.FillWeight = 82.35355F;
            this.provider.HeaderText = "运营商";
            this.provider.Name = "provider";
            this.provider.ReadOnly = true;
            // 
            // province_code
            // 
            this.province_code.DataPropertyName = "province_code";
            this.province_code.FillWeight = 61.76516F;
            this.province_code.HeaderText = "省份";
            this.province_code.Name = "province_code";
            this.province_code.ReadOnly = true;
            // 
            // city_code
            // 
            this.city_code.DataPropertyName = "city_code";
            this.city_code.FillWeight = 61.76516F;
            this.city_code.HeaderText = "城市";
            this.city_code.Name = "city_code";
            this.city_code.ReadOnly = true;
            // 
            // fail_reason
            // 
            this.fail_reason.DataPropertyName = "fail_reason";
            this.fail_reason.FillWeight = 144.1187F;
            this.fail_reason.HeaderText = "充值失败原因";
            this.fail_reason.Name = "fail_reason";
            this.fail_reason.ReadOnly = true;
            // 
            // features
            // 
            this.features.DataPropertyName = "features";
            this.features.FillWeight = 59.69543F;
            this.features.HeaderText = "备注";
            this.features.Name = "features";
            this.features.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.tbxPage);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.labelPage);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 545);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1428, 37);
            this.panel2.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(945, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "条";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(853, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "每页";
            // 
            // tbxPage
            // 
            this.tbxPage.Location = new System.Drawing.Point(888, 7);
            this.tbxPage.Name = "tbxPage";
            this.tbxPage.Size = new System.Drawing.Size(51, 21);
            this.tbxPage.TabIndex = 4;
            this.tbxPage.Text = "50";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(978, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "总条数：0";
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(645, 12);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(23, 12);
            this.labelPage.TabIndex = 2;
            this.labelPage.Text = "1/1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(698, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "下一页";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(536, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "上一页";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormQueryOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1428, 582);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvOrderShow);
            this.Controls.Add(this.panel1);
            this.Name = "FormQueryOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查单";
            this.Load += new System.EventHandler(this.FormQueryOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderShow)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button QueryOrderBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPhoneNo;
        private System.Windows.Forms.TextBox tbxOrderId;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DataGridView dgvOrderShow;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxPage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn vender_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn vender_order_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn face_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn created;
        private System.Windows.Forms.DataGridViewTextBoxColumn submit_recharge_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn notify_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn notify_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn notify_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn provider;
        private System.Windows.Forms.DataGridViewTextBoxColumn province_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn city_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn fail_reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn features;
    }
}