using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using smartMain.CLS;
using smartMain;

namespace testc
{
    public partial class Form2 : Form
    {

        private string s구분 = "1";
        private string s테이블명;

        public Form2()
        {
            InitializeComponent();
        }

        private void butclose_Click(object sender, EventArgs e)
        {
                
                Form1 showForm1 = new Form1();
                showForm1.Show();
        }

        private void bindData(string condition)
        {
            if (this.s구분 == "3" || this.s구분 == "4")
            {
                this.bindData2(condition);
            }
            else
            {
                this.GridRecord.RowCount = 0;
                this.GridRecord.DataSource = (object)null;
                try
                {
                    DataTable dataTable = new wnDm().fn_분류코드_List(this.s테이블명, condition, Common.p_strConn);
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        this.GridRecord.RowCount = dataTable.Rows.Count;
                        for (int index = 0; index < dataTable.Rows.Count; ++index)
                        {
                            this.GridRecord.Rows[index].Cells[0].Value = (object)dataTable.Rows[index]["코드"].ToString();
                            this.GridRecord.Rows[index].Cells[1].Value = (object)dataTable.Rows[index]["명칭"].ToString();
                            this.GridRecord.Rows[index].Cells[2].Value = (object)dataTable.Rows[index]["비고"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                }
            }
        }
        private void bindData2(string condition)
        {
            this.GridRecord.RowCount = 0;
            this.GridRecord.DataSource = (object)null;
            try
            {
                DataTable dataTable = new wnDm().fn_분류코드2_List(this.s테이블명, condition, Common.p_strConn);
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                this.GridRecord.RowCount = dataTable.Rows.Count;
                for (int index = 0; index < dataTable.Rows.Count; ++index)
                {
                    this.GridRecord.Rows[index].Cells[0].Value = (object)dataTable.Rows[index]["코드"].ToString();
                    this.GridRecord.Rows[index].Cells[1].Value = (object)dataTable.Rows[index]["명칭"].ToString();
                    this.GridRecord.Rows[index].Cells[2].Value = (object)dataTable.Rows[index]["비고"].ToString();
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }
    }
}
