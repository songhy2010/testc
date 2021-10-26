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
using System.Data.SqlClient;

namespace testc
{
    public partial class Form2 : Form
    {

        private string s구분 = "1";
        private string s테이블명 = "P_거래처유형";
        private bool bData = false;
        private SplitContainer spCont;
        public Form2()
        {
            InitializeComponent();

            Common.p_strConn = "DATA SOURCE = 218.38.14.33,14332"
                + ";INITIAL CATALOG = test"
                + ";PERSIST SECURITY INFO = false;USER ID = sa"
                + ";PASSWORD = ##wkdxj123;";
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


        private void init_InputBox(bool bNew)
        {
           
            if (bNew)
            {
                
                this.textBox1.Enabled = true;
            }
            else
            {
                
                this.textBox1.Enabled = false;
            }
        }

        private string makeSearchCondition()
        {
            StringBuilder stringBuilder = new StringBuilder();
            switch (this.textBox4.Text)
            {
                case "":
                    stringBuilder.Append("");
                    break;
                default:
                    stringBuilder.Append(" and a.명칭 like '" + this.textBox4.Text + "%' ");
                    break;
            }
            return stringBuilder.ToString();
        }



        private void butSearch_Click(object sender, EventArgs e)
        {
            this.init_InputBox(true);
            this.bindData(this.makeSearchCondition());


        }



        private bool validate_InputBox()
        {
            bool flag = true;
            try
            {
                if (this.textBox1.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 코드 ] 을 입력하세요.");
                    return false;
                }
                if (this.textBox2.Text == "")
                {
                    int num = (int)MessageBox.Show("[ 명칭 ] 을 입력하세요.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                int num = (int)MessageBox.Show("입력 데이터 확인 중에 오류가 있습니다.");
            }
            return flag;
        }

       


        private bool get_Dup_Check(string sNew, string sOld)
        {
            if (this.s구분 == "3" || this.s구분 == "4")
                return this.get_Dup_Check2(sNew, sOld);
            try
            {
                if (!(sNew != sOld))
                    return false;
                DataTable dataTable = new wnDm().fn_분류코드_Detail(this.s테이블명, sNew, Common.p_strConn);
                return dataTable != null && dataTable.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                return true;
            }
        }
        private bool get_Dup_Check2(string sNew, string sOld)
        {
            try
            {
                if (!(sNew != sOld))
                    return false;
                DataTable dataTable = new wnDm().fn_분류코드2_Detail(this.s테이블명, sNew, Common.p_strConn);
                return dataTable != null && dataTable.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                return true;
            }
        }



        private void butSave_Click(object sender, EventArgs e)
        {
            this.butSave.Enabled = false;
            if (this.bData ? this.updatePost() : this.insertPost())
            {
                this.init_InputBox(true);
                MessageBox.Show("저장완료");
                /*if (this.spCont.Visible)
                    this.bindData(this.makeSearchCondition());*/

            }
            this.butSave.Enabled = true;
        }

        private bool insertPost()
        {
            if (!this.validate_InputBox())
                return false;
            bool flag = false;
            try
            {
                wnAdo wnAdo = new wnAdo();
                if (this.get_Dup_Check(this.textBox1.Text, ""))
                {
                    int num = (int)MessageBox.Show("이미 존재하는 코드입니다. [ " + this.textBox1.Text + " ]");
                    return flag;
                }
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("declare @strKey nvarchar(3) ");
                stringBuilder.AppendLine("set @strKey = '" + this.textBox1.Text + "' ");
                stringBuilder.AppendLine("insert into " + this.s테이블명 + " (  ");
                stringBuilder.AppendLine("     사업자번호                  ");
                if (this.s구분 != "3" && this.s구분 != "4")
                    stringBuilder.AppendLine("     , 지점코드 ");
                stringBuilder.AppendLine("     , 코드                      ");
                stringBuilder.AppendLine("     , 명칭                      ");
                stringBuilder.AppendLine("     , 비고                      ");
                stringBuilder.AppendLine(" ) values ( ");
                stringBuilder.AppendLine("     '" + Common.p_strCompID + "' ");
                if (this.s구분 != "3" && this.s구분 != "4")
                    stringBuilder.AppendLine("     , '" + Common.p_strSpotCode + "' ");
                stringBuilder.AppendLine("     , @strKey                   ");
                stringBuilder.AppendLine("     , @명칭                     ");
                stringBuilder.AppendLine("     , @비고                     ");
                stringBuilder.AppendLine(" )  ");
                SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
                sCommand.Parameters.AddWithValue("@명칭", (object)this.textBox2.Text);
                sCommand.Parameters.AddWithValue("@비고", (object)this.textBox3.Text);
                
                flag = wnAdo.SqlCommandEtc(sCommand, "Insert_" + this.s테이블명 + "_Table", Common.p_strConn) > 0;
                if (!flag)
                {
                    int num1 = (int)MessageBox.Show("저장insert 중에 오류가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                int num = (int)MessageBox.Show("데이터베이스에 문제가 발생했습니다.");
            }
            return flag;
        }

        

        private bool updatePost()
        {
            if (!this.validate_InputBox())
                return false;
            bool flag = false;
            try
            {
                wnAdo wnAdo = new wnAdo();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("update " + this.s테이블명 + " set     ");
                stringBuilder.AppendLine("     명칭 = @명칭                ");
                stringBuilder.AppendLine("     , 비고 = @비고              ");
                stringBuilder.AppendLine(" where 사업자번호 = '" + Common.p_strCompID + "' ");
                if (this.s구분 != "3" && this.s구분 != "4")
                    stringBuilder.AppendLine("     and 지점코드 = '" + Common.p_strSpotCode + "' ");
                stringBuilder.AppendLine("     and 코드 = @p1              ");
                SqlCommand sCommand = new SqlCommand(stringBuilder.ToString());
                sCommand.Parameters.AddWithValue("@p1", (object)this.textBox1.Text);
                sCommand.Parameters.AddWithValue("@명칭", (object)this.textBox2.Text);
                sCommand.Parameters.AddWithValue("@비고", (object)this.textBox3.Text);
                flag = wnAdo.SqlCommandEtc(sCommand, "Save_" + this.s테이블명 + "_Table", Common.p_strConn) > 0;
                if (!flag)
                {
                    int num = (int)MessageBox.Show("저장update 중에 오류가 발생했습니다.");
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
                int num = (int)MessageBox.Show("데이터베이스에 문제가 발생했습니다.");
            }
            return flag;
        }
    }
}
