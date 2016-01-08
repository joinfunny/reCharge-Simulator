namespace AutoSend
{
    partial class FormSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSet));
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxMachine = new System.Windows.Forms.TextBox();
            this.tbxUrl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxNotifyUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxVenderId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxAcceptOrderInterfaceUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxMd5Key = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(297, 353);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "支付密码：";
            // 
            // tbxMachine
            // 
            this.tbxMachine.Location = new System.Drawing.Point(148, 83);
            this.tbxMachine.Name = "tbxMachine";
            this.tbxMachine.Size = new System.Drawing.Size(183, 21);
            this.tbxMachine.TabIndex = 1;
            this.tbxMachine.UseSystemPasswordChar = true;
            // 
            // tbxUrl
            // 
            this.tbxUrl.Location = new System.Drawing.Point(148, 42);
            this.tbxUrl.Name = "tbxUrl";
            this.tbxUrl.Size = new System.Drawing.Size(400, 21);
            this.tbxUrl.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "Url地址：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxMd5Key);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbxNotifyUrl);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbxVenderId);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbxAcceptOrderInterfaceUrl);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbxUrl);
            this.groupBox2.Controls.Add(this.tbxMachine);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(38, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(604, 306);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "参数设置";
            // 
            // tbxNotifyUrl
            // 
            this.tbxNotifyUrl.Location = new System.Drawing.Point(148, 239);
            this.tbxNotifyUrl.Name = "tbxNotifyUrl";
            this.tbxNotifyUrl.Size = new System.Drawing.Size(400, 21);
            this.tbxNotifyUrl.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "回调通知地址：";
            // 
            // tbxVenderId
            // 
            this.tbxVenderId.Location = new System.Drawing.Point(148, 164);
            this.tbxVenderId.Name = "tbxVenderId";
            this.tbxVenderId.Size = new System.Drawing.Size(183, 21);
            this.tbxVenderId.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "供应商venderId：";
            // 
            // tbxAcceptOrderInterfaceUrl
            // 
            this.tbxAcceptOrderInterfaceUrl.Location = new System.Drawing.Point(148, 121);
            this.tbxAcceptOrderInterfaceUrl.Name = "tbxAcceptOrderInterfaceUrl";
            this.tbxAcceptOrderInterfaceUrl.Size = new System.Drawing.Size(400, 21);
            this.tbxAcceptOrderInterfaceUrl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "监听地址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "密钥：";
            // 
            // tbxMd5Key
            // 
            this.tbxMd5Key.Location = new System.Drawing.Point(148, 204);
            this.tbxMd5Key.Name = "tbxMd5Key";
            this.tbxMd5Key.Size = new System.Drawing.Size(400, 21);
            this.tbxMd5Key.TabIndex = 4;
            this.tbxMd5Key.UseSystemPasswordChar = true;
            // 
            // FormSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(694, 400);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.FormSet_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxMachine;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxUrl;
        private System.Windows.Forms.TextBox tbxAcceptOrderInterfaceUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxNotifyUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxVenderId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxMd5Key;
        private System.Windows.Forms.Label label5;
    }
}