using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace AutoSend
{
    public partial class FormSet : Form
    {
        public FormSet()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.tbxUrl.Text.Trim() == "")
            {
                MessageBox.Show("Url地址不能为空！");
                tbxUrl.Focus();
                return;
            }
            if (this.tbxMachine.Text.Trim() == "")
            {
                MessageBox.Show("支付密码不能为空！");
                tbxMachine.Focus();
                return;
            }
            if (this.tbxAcceptOrderInterfaceUrl.Text.Trim() == "")
            {
                MessageBox.Show("监听地址不能为空！");
                tbxMachine.Focus();
                return;
            }
            if (this.tbxVenderId.Text.Trim() == "")
            {
                MessageBox.Show("供应商venderId不能为空！");
                tbxMachine.Focus();
                return;
            }
            if (this.tbxMd5Key.Text.Trim() == "")
            {
                MessageBox.Show("密钥不能为空！");
                tbxMachine.Focus();
                return;
            }
            if (this.tbxNotifyUrl.Text.Trim() == "")
            {
                MessageBox.Show("回调通知地址不能为空！");
                tbxMachine.Focus();
                return;
            }
            
            //保存参数
            Share.SetAppValue("url", tbxUrl.Text.Trim());
            Share.SetAppValue("acceptOrderInterfaceUrl", tbxAcceptOrderInterfaceUrl.Text.Trim());
            Share.SetAppValue("Machine", Share.DESto(tbxMachine.Text.Trim()));
            Share.SetAppValue("venderId", tbxVenderId.Text.Trim());
            Share.SetAppValue("notifyUrl", tbxNotifyUrl.Text.Trim());
            Share.SetAppValue("md5Key", Share.DESto(tbxMd5Key.Text.Trim()));
            MessageBox.Show("保存成功！重新打开程序后配置生效");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormSet_Load(object sender, EventArgs e)
        {            
            //初始加载
            this.tbxUrl.Text = ConfigurationManager.AppSettings["url"].Trim();
            this.tbxAcceptOrderInterfaceUrl.Text = ConfigurationManager.AppSettings["acceptOrderInterfaceUrl"].Trim();
            this.tbxVenderId.Text = ConfigurationManager.AppSettings["venderId"].Trim();
            this.tbxNotifyUrl.Text = ConfigurationManager.AppSettings["notifyUrl"].Trim();
            try
            {
                if (ConfigurationManager.AppSettings["Machine"].Trim() != "")
                {
                    tbxMachine.Text = Share.DESForm(ConfigurationManager.AppSettings["Machine"]);
                }
            }
            catch (Exception ex)
            {
                tbxMachine.Text = "";
            }
            try
            {
                if (ConfigurationManager.AppSettings["md5Key"].Trim() != "")
                {
                    tbxMd5Key.Text = Share.DESForm(ConfigurationManager.AppSettings["md5Key"]);
                }
            }
            catch (Exception ex)
            {
                tbxMd5Key.Text = "";
            }
        }
    }
}
