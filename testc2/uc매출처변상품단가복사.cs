using smartMain;
using smartMain.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testc2
{
    public partial class uc매출처변상품단가복사 : Form
    {
        public TextBox txt명칭;
        public TextBox txtS거래처코드;
        private string srchCode = "";
        private ComboBox cmbS사입품;

        public uc매출처변상품단가복사()
        {
            InitializeComponent();
            Common.p_strConn = "DATA SOURCE = 218.38.14.33,14332"
                + ";INITIAL CATALOG = test"
                + ";PERSIST SECURITY INFO = false;USER ID = sa"
                + ";PASSWORD = ##wkdxj123;";
        }

        private void butSearch_Click(object sender, EventArgs e) => this.bindData(this.makeSearchCondition());



        private void init_Text()
        {
            this.txt코드.Text = "";
            this.txt명칭.Text = "";
        }




        private string makeSearchCondition()
        {
            StringBuilder stringBuilder = new StringBuilder();
            switch (this.txtS거래처코드.Text)
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and a.거래처코드 = '" + this.txtS거래처코드.Text + "' ");
                    break;
            }
            switch (this.cmbS사입품.SelectedIndex)
            {
                case 1:
                    stringBuilder.Append(" and isnull(b.사입품, 'N') = 'N' ");
                    break;
                case 2:
                    stringBuilder.Append(" and isnull(b.사입품, 'N') = 'Y' ");
                    break;
                default:
                    stringBuilder.Append("");
                    break;
            }
            return stringBuilder.ToString();
        }
        private void bindData(string condition)
        {
            this.GridRecord.RowCount = 0;
            this.GridRecord.DataSource = (object)null;
            this.init_Text();
            this.srchCode = this.txtS거래처코드.Text;
            if (this.txtS거래처코드.Text == "")
                return;
            try
            {
                DataTable dataTable = new wnDm().fn_매출단가표_List(condition, Common.p_strConn);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.GridRecord.RowCount = dataTable.Rows.Count;
                    for (int index = 0; index < dataTable.Rows.Count; ++index)
                    {
                        this.GridRecord.Rows[index].Cells[0].Value = (object)dataTable.Rows[index]["상품코드"].ToString();
                        this.GridRecord.Rows[index].Cells[1].Value = (object)dataTable.Rows[index]["상품명"].ToString();
                        this.GridRecord.Rows[index].Cells[2].Value = (object)dataTable.Rows[index]["규격"].ToString();
                        Decimal num;
                        if (Common.p_strBox == "2")
                        {
                            DataGridViewCell cell = this.GridRecord.Rows[index].Cells[3];
                            num = Decimal.Parse(dataTable.Rows[index]["박스단가"].ToString());
                            string str = num.ToString(Common.p_strFormatUnit);
                            cell.Value = (object)str;
                        }
                        else
                        {
                            DataGridViewCell cell = this.GridRecord.Rows[index].Cells[3];
                            num = Decimal.Parse(dataTable.Rows[index]["낱개단가"].ToString());
                            string str = num.ToString(Common.p_strFormatUnit);
                            cell.Value = (object)str;
                        }
                        DataGridViewCell cell1 = this.GridRecord.Rows[index].Cells[5];
                        num = Decimal.Parse(dataTable.Rows[index]["박스입고단가"].ToString());
                        string str1 = num.ToString(Common.p_strFormatUnit);
                        cell1.Value = (object)str1;
                        DataGridViewCell cell2 = this.GridRecord.Rows[index].Cells[6];
                        num = Decimal.Parse(dataTable.Rows[index]["낱개입고단가"].ToString());
                        string str2 = num.ToString(Common.p_strFormatUnit);
                        cell2.Value = (object)str2;
                    }
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }
    }
}
