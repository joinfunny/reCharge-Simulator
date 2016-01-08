using AutoSend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace auto
{
    public partial class FormQueryOrder : Form
    {
        public FormQueryOrder()
        {
            InitializeComponent();
        }

        int pageSize = 3;
        int pageIndex = 1;
        private void QueryOrderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                pageIndex = 1;
                query();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误", ex.Message);
            }
        }

        private void FormQueryOrder_Load(object sender, EventArgs e)
        {
            dgvOrderShow.AutoGenerateColumns = false;
            dtpStart.Value = dtpStart.Value.AddDays(-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pageIndex = pageIndex - 1;
            query();
        }

        private void query()
        {
            try
            {
                pageSize = Int32.Parse(tbxPage.Text.Trim());
                StateHandle handle = new StateHandle();
                int totalRows = handle.totalRows(dtpStart.Text.Trim(), dtpEnd.Text.Trim(), tbxOrderId.Text.Trim(), tbxPhoneNo.Text.Trim());
                int totalPage = totalRows % pageSize >= 1 ? totalRows / pageSize + 1 : totalRows / pageSize;
                if (pageIndex < 1)
                {
                    pageIndex = 1;
                }
                if (pageIndex > totalPage) 
                {
                    pageIndex = totalPage;
                }
                label5.Text = "总条数：" + totalRows;
                labelPage.Text = pageIndex.ToString() + "/" + totalPage;
                DataTable dt = handle.selectOrderList(dtpStart.Text.Trim(), dtpEnd.Text.Trim(), tbxOrderId.Text.Trim(), tbxPhoneNo.Text.Trim(), pageIndex, pageSize);
                dgvOrderShow.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误", ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pageIndex = pageIndex + 1;
            query();

        }
    }
}
