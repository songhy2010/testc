// Decompiled with JetBrains decompiler
// Type: smartMain.CLS.wnGConstant
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe




using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace smartMain.CLS
{
    public class wnGConstant
    {
        public const bool debug = false;
        private const int WM_IME_CONTROL = 643;
        private string strQuery;
        private SqlConnection adoConnection = new SqlConnection();
        private SqlCommand adoCommand = new SqlCommand();
        private SqlDataAdapter adoAdapter = new SqlDataAdapter();
        private System.Data.DataTable adoTable = new System.Data.DataTable();
        private DataRow adoRow;
        private object TextNumber;

        [DllImport("imm32.dll")]
        private static extern IntPtr ImmGetDefaultIMEWnd(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(
          IntPtr hWnd,
          uint Msg,
          IntPtr wParam,
          IntPtr IParam);

        public int GetIME()
        {
            Process process = ((IEnumerable<Process>)Process.GetProcessesByName("smartMain")).FirstOrDefault<Process>();
            if (process == null)
                return -1;
            return wnGConstant.SendMessage(wnGConstant.ImmGetDefaultIMEWnd(process.MainWindowHandle), 643U, new IntPtr(5), new IntPtr(0)).ToInt32() != 0 ? 1 : 0;
        }

        
       

       

       

     

       

      

     

        public void init_RowText(DataGridView dgv, int nRow)
        {
            dgv.Rows[nRow].Cells[0].Value = (object)false;
            dgv.Rows[nRow].Cells[2].Value = (object)"";
            dgv.Rows[nRow].Cells[3].Value = (object)"";
            dgv.Rows[nRow].Cells[4].Value = (object)"";
            dgv.Rows[nRow].Cells[5].Value = (object)"";
            dgv.Rows[nRow].Cells[6].Value = (object)"";
            dgv.Rows[nRow].Cells[17].Value = (object)"1";
            dgv.Rows[nRow].Cells[8].Value = (object)"0";
            dgv.Rows[nRow].Cells[9].Value = (object)"0";
            dgv.Rows[nRow].Cells[10].Value = (object)"0";
            dgv.Rows[nRow].Cells[11].Value = (object)"0";
            dgv.Rows[nRow].Cells[12].Value = (object)"0";
            dgv.Rows[nRow].Cells[13].Value = (object)"0";
            dgv.Rows[nRow].Cells[14].Value = (object)"0";
            dgv.Rows[nRow].Cells[15].Value = (object)"0";
            dgv.Rows[nRow].Cells[16].Value = (object)"0";
            dgv.Rows[nRow].Cells[18].Value = (object)"0";
            dgv.Rows[nRow].Cells[19].Value = (object)"0";
            dgv.Rows[nRow].Cells[20].Value = (object)"0";
            dgv.Rows[nRow].Cells[21].Value = (object)"";
            dgv.Rows[nRow].Cells[22].Value = (object)"0";
            dgv.Rows[nRow].Cells[23].Value = (object)"0";
            dgv.Rows[nRow].Cells[24].Value = (object)"";
            dgv.Rows[nRow].Cells[25].Value = (object)"0";
            dgv.Rows[nRow].Cells[26].Value = (object)"0";
            dgv.Rows[nRow].Cells[27].Value = (object)"0";
            dgv.Rows[nRow].Cells[28].Value = (object)"0";
        }

     

        public void get_Prod_Info_창고이동(DataGridView dgv, int nRow, string sCode)
        {
            try
            {
                System.Data.DataTable dataTable = new wnDm().fn_상품_Detail(sCode, Common.p_strConn);
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                dgv.Rows[nRow].Cells[5].Value = (object)dataTable.Rows[0]["상품명"].ToString();
                dgv.Rows[nRow].Cells[6].Value = (object)dataTable.Rows[0]["규격"].ToString();
                dgv.Rows[nRow].Cells[13].Value = (object)Decimal.Parse(dataTable.Rows[0]["박스판매단가"].ToString()).ToString(Common.p_strFormatUnit);
                dgv.Rows[nRow].Cells[14].Value = (object)Decimal.Parse(dataTable.Rows[0]["낱개판매단가"].ToString()).ToString(Common.p_strFormatUnit);
                dgv.Rows[nRow].Cells[15].Value = (object)"0";
                dgv.Rows[nRow].Cells[22].Value = (object)dataTable.Rows[0]["입수수량"].ToString();
                dgv.Rows[nRow].Cells[23].Value = (object)dataTable.Rows[0]["중간입수수량"].ToString();
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        public void get_Prod_Info_Code(DataGridView dgv, int nRow, string sCode)
        {
            try
            {
                System.Data.DataTable dataTable = new wnDm().fn_상품_Detail(sCode, Common.p_strConn);
                if (dataTable != null && dataTable.Rows.Count > 0)
                    dgv.Rows[nRow].Cells[5].Value = (object)dataTable.Rows[0]["상품명"].ToString();
                else
                    dgv.Rows[nRow].Cells[5].Value = (object)"";
            }
            catch (Exception ex)
            {
                dgv.Rows[nRow].Cells[5].Value = (object)"";
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        public void get_Prod_Info_Old_매출(
          DataGridView dgv,
          int nRow,
          string sCust,
          string sCode,
          string s거래구분)
        {
            try
            {
                wnDm wnDm = new wnDm();
                System.Data.DataTable dataTable = !(s거래구분 == "1") ? wnDm.fn_매출행사단가표_Last(sCust, sCode, Common.p_strConn) : wnDm.fn_매출단가표_Last(sCust, sCode, Common.p_strConn);
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                dgv.Rows[nRow].Cells[21].Value = (object)dataTable.Rows[0]["매출일자"].ToString();
                DataGridViewCell cell1 = dgv.Rows[nRow].Cells[13];
                Decimal num = Decimal.Parse(dataTable.Rows[0]["박스단가"].ToString());
                string str1 = num.ToString(Common.p_strFormatUnit);
                cell1.Value = (object)str1;
                DataGridViewCell cell2 = dgv.Rows[nRow].Cells[14];
                num = Decimal.Parse(dataTable.Rows[0]["낱개단가"].ToString());
                string str2 = num.ToString(Common.p_strFormatUnit);
                cell2.Value = (object)str2;
            }
            catch (Exception ex)
            {
                dgv.Rows[nRow].Cells[13].Value = (object)"0";
                dgv.Rows[nRow].Cells[14].Value = (object)"0";
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        public void get_Prod_Info_Old_매입(
          DataGridView dgv,
          int nRow,
          string sCust,
          string sCode,
          string s거래구분)
        {
            try
            {
                System.Data.DataTable dataTable = new wnDm().fn_매입단가표_Last(sCust, sCode, Common.p_strConn);
                if (dataTable == null || dataTable.Rows.Count <= 0)
                    return;
                dgv.Rows[nRow].Cells[13].Value = (object)Decimal.Parse(dataTable.Rows[0]["박스단가"].ToString()).ToString(Common.p_strFormatUnit);
                dgv.Rows[nRow].Cells[14].Value = (object)Decimal.Parse(dataTable.Rows[0]["낱개단가"].ToString()).ToString(Common.p_strFormatUnit);
            }
            catch (Exception ex)
            {
                dgv.Rows[nRow].Cells[13].Value = (object)"0";
                dgv.Rows[nRow].Cells[14].Value = (object)"0";
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
        }

        public void Calc_Price(DataGridView dgv, int nRow, string s거래처부가세코드)
        {
            dgv.Rows[nRow].Cells[12].Value = (object)"0";
            dgv.Rows[nRow].Cells[15].Value = (object)"0";
            if (Common.p_strBox == "1")
            {
                dgv.Rows[nRow].Cells[9].Value = (object)"0";
                dgv.Rows[nRow].Cells[10].Value = (object)"0";
            }
            if (Common.p_strBox == "2")
            {
                dgv.Rows[nRow].Cells[10].Value = (object)"0";
                dgv.Rows[nRow].Cells[11].Value = (object)"0";
            }
            dgv.Rows[nRow].Cells[28].Value = (object)"0";
            string s1 = ((string)dgv.Rows[nRow].Cells[22].Value ?? "").Replace(",", "");
            string s2 = ((string)dgv.Rows[nRow].Cells[23].Value ?? "").Replace(",", "");
            string s3 = ((string)dgv.Rows[nRow].Cells[9].Value ?? "").Replace(",", "");
            string s4 = ((string)dgv.Rows[nRow].Cells[10].Value ?? "").Replace(",", "");
            string s5 = ((string)dgv.Rows[nRow].Cells[11].Value ?? "").Replace(",", "");
            string s6 = ((string)dgv.Rows[nRow].Cells[13].Value ?? "").Replace(",", "");
            string s7 = ((string)dgv.Rows[nRow].Cells[14].Value ?? "").Replace(",", "");
            if (Common.p_strBox == "2")
            {
                dgv.Rows[nRow].Cells[12].Value = (object)(Decimal.Parse((string)dgv.Rows[nRow].Cells[12].Value ?? "") + Decimal.Parse(s3)).ToString(Common.p_strFormatAmount);
            }
            else
            {
                if (s3 != "" && s1 != "")
                    dgv.Rows[nRow].Cells[12].Value = (object)(Decimal.Parse((string)dgv.Rows[nRow].Cells[12].Value ?? "") + Decimal.Parse(s3) * Decimal.Parse(s1)).ToString(Common.p_strFormatAmount);
                if (s4 != "" && s2 != "")
                    dgv.Rows[nRow].Cells[12].Value = (object)(Decimal.Parse((string)dgv.Rows[nRow].Cells[12].Value ?? "") + Decimal.Parse(s4) * Decimal.Parse(s2)).ToString(Common.p_strFormatAmount);
                if (s5 != "")
                    dgv.Rows[nRow].Cells[12].Value = (object)(Decimal.Parse((string)dgv.Rows[nRow].Cells[12].Value ?? "") + Decimal.Parse(s5)).ToString(Common.p_strFormatAmount);
            }
            string s8 = ((string)dgv.Rows[nRow].Cells[12].Value ?? "").Replace(",", "");
            if (Common.p_strBox == "2")
            {
                dgv.Rows[nRow].Cells[15].Value = (object)(Decimal.Parse(s3) * Decimal.Parse(s6)).ToString("#,0");
                dgv.Rows[nRow].Cells[8].Value = dgv.Rows[nRow].Cells[15].Value;
            }
            else
            {
                dgv.Rows[nRow].Cells[15].Value = (object)(Decimal.Parse(s8) * Decimal.Parse(s7)).ToString("#,0");
                if (s1 != "" && s8 != "")
                {
                    Decimal num1 = 0M;
                    Decimal num2 = 0M;
                    if (int.Parse(s1) > 0)
                    {
                        num1 = Math.Truncate(Decimal.Parse(s8) / Decimal.Parse(s1));
                        num2 = Decimal.Parse(s8) % Decimal.Parse(s1);
                    }
                    dgv.Rows[nRow].Cells[8].Value = (object)this.Numb_Comma_Special_Zero(num1.ToString() + "." + num2.ToString());
                }
            }
            string s9 = ((string)dgv.Rows[nRow].Cells[16].Value ?? "").Replace(",", "");
            if (s9 != "" && s1 != "")
                dgv.Rows[nRow].Cells[28].Value = (object)(Decimal.Parse((string)dgv.Rows[nRow].Cells[28].Value ?? "") + Decimal.Parse(s9)).ToString(Common.p_strFormatAmount);
            string s10 = ((string)dgv.Rows[nRow].Cells[28].Value ?? "").Replace(",", "");
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            string s11 = ((string)dgv.Rows[nRow].Cells[15].Value ?? "").Replace(",", "");
            double num6 = 0.0;
            if (s11 != "")
            {
                double num7 = double.Parse(s11);
                if (Common.p_strBox == "2")
                {
                    string s12 = ((string)dgv.Rows[nRow].Cells[18].Value ?? "").Replace(",", "");
                    num6 = (double.Parse(s3) + double.Parse(s9)) * double.Parse(s12);
                }
                else
                {
                    string s13 = ((string)dgv.Rows[nRow].Cells[19].Value ?? "").Replace(",", "");
                    num6 = (double.Parse(s8) + double.Parse(s10)) * double.Parse(s13);
                }
                if (((string)dgv.Rows[nRow].Cells[24].Value ?? "") == "2")
                {
                    num5 = 0.0;
                    num3 = num7;
                    num4 = num7;
                }
                else if (s거래처부가세코드 == "0")
                {
                    num5 = Math.Round(num7 * 0.1, 0, MidpointRounding.AwayFromZero);
                    num3 = num7;
                    num4 = num5 + num3;
                }
                else
                {
                    num4 = num7;
                    num3 = Math.Round(num7 / 1.1, 0, MidpointRounding.AwayFromZero);
                    num5 = num4 - num3;
                }
            }
            if (num4 != 0.0)
                dgv.Rows[nRow].Cells[20].Value = (object)((num4 - num6) / num4 * 100.0).ToString("#,0.##");
            else
                dgv.Rows[nRow].Cells[20].Value = (object)"0";
            dgv.Rows[nRow].Cells[25].Value = (object)num3.ToString();
            dgv.Rows[nRow].Cells[26].Value = (object)num5.ToString();
            dgv.Rows[nRow].Cells[27].Value = (object)num4.ToString();
        }

        public void Calc_Amount(DataGridView dgv, int nRow)
        {
            dgv.Rows[nRow].Cells[12].Value = (object)"0";
            dgv.Rows[nRow].Cells[15].Value = (object)"0";
            if (Common.p_strBox == "1")
            {
                dgv.Rows[nRow].Cells[9].Value = (object)"0";
                dgv.Rows[nRow].Cells[10].Value = (object)"0";
            }
            if (Common.p_strBox == "2")
            {
                dgv.Rows[nRow].Cells[10].Value = (object)"0";
                dgv.Rows[nRow].Cells[11].Value = (object)"0";
            }
            string s1 = ((string)dgv.Rows[nRow].Cells[22].Value ?? "").Replace(",", "");
            string s2 = ((string)dgv.Rows[nRow].Cells[23].Value ?? "").Replace(",", "");
            string s3 = ((string)dgv.Rows[nRow].Cells[9].Value ?? "").Replace(",", "");
            string s4 = ((string)dgv.Rows[nRow].Cells[10].Value ?? "").Replace(",", "");
            string s5 = ((string)dgv.Rows[nRow].Cells[11].Value ?? "").Replace(",", "");
            string s6 = ((string)dgv.Rows[nRow].Cells[13].Value ?? "").Replace(",", "");
            string s7 = ((string)dgv.Rows[nRow].Cells[14].Value ?? "").Replace(",", "");
            if (Common.p_strBox == "2")
            {
                dgv.Rows[nRow].Cells[12].Value = (object)(Decimal.Parse((string)dgv.Rows[nRow].Cells[12].Value ?? "") + Decimal.Parse(s3)).ToString(Common.p_strFormatAmount);
            }
            else
            {
                if (s3 != "" && s1 != "")
                    dgv.Rows[nRow].Cells[12].Value = (object)(Decimal.Parse((string)dgv.Rows[nRow].Cells[12].Value ?? "") + Decimal.Parse(s3) * Decimal.Parse(s1)).ToString(Common.p_strFormatAmount);
                if (s4 != "" && s2 != "")
                    dgv.Rows[nRow].Cells[12].Value = (object)(Decimal.Parse((string)dgv.Rows[nRow].Cells[12].Value ?? "") + Decimal.Parse(s4) * Decimal.Parse(s2)).ToString(Common.p_strFormatAmount);
                if (s5 != "")
                    dgv.Rows[nRow].Cells[12].Value = (object)(Decimal.Parse((string)dgv.Rows[nRow].Cells[12].Value ?? "") + Decimal.Parse(s5)).ToString(Common.p_strFormatAmount);
            }
            string s8 = ((string)dgv.Rows[nRow].Cells[12].Value ?? "").Replace(",", "");
            if (Common.p_strBox == "2")
            {
                dgv.Rows[nRow].Cells[15].Value = (object)(Decimal.Parse(s3) * Decimal.Parse(s6)).ToString("#,0");
                dgv.Rows[nRow].Cells[8].Value = dgv.Rows[nRow].Cells[15].Value;
            }
            else
            {
                dgv.Rows[nRow].Cells[15].Value = (object)(Decimal.Parse(s8) * Decimal.Parse(s7)).ToString("#,0");
                if (s1 != "" && s8 != "")
                {
                    Decimal num1 = 0M;
                    Decimal num2 = 0M;
                    if (int.Parse(s1) > 0)
                    {
                        num1 = Math.Truncate(Decimal.Parse(s8) / Decimal.Parse(s1));
                        num2 = Decimal.Parse(s8) % Decimal.Parse(s1);
                    }
                    dgv.Rows[nRow].Cells[8].Value = (object)this.Numb_Comma_Special_Zero(num1.ToString() + "." + num2.ToString());
                }
            }
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            string s9 = ((string)dgv.Rows[nRow].Cells[15].Value ?? "").Replace(",", "");
            if (s9 != "")
            {
                double num6 = double.Parse(s9);
                num5 = 0.0;
                num3 = num6;
                num4 = num6;
            }
            dgv.Rows[nRow].Cells[25].Value = (object)num3.ToString();
            dgv.Rows[nRow].Cells[26].Value = (object)num5.ToString();
            dgv.Rows[nRow].Cells[27].Value = (object)num4.ToString();
        }

        public void set_ListBox_거래처(
          ref System.Data.DataTable adoTab,
          string sGubun,
          string sActiveYN,
          System.Windows.Forms.ListBox cmbHidden)
        {
            string str = "select a.거래처코드 " + "   , 거래처명 + ', ' + 대표자명 + ', ' + 거래처담당자 + ', ' + 주소 as 거래처긴명칭" + " from T_거래처정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' and a.거래처구분 in " + sGubun + " ";
            string query = !(Common.p_AutoCust == "Y") ? str + " and a.사용여부 = '_' " : str + " and a.사용여부 in " + sActiveYN + " ";
            adoTab = this.RunTable(query, Common.p_strConn);
            DataRow row = adoTab.NewRow();
            row[0] = (object)"";
            row[1] = (object)"";
            adoTab.Rows.InsertAt(row, 0);
            cmbHidden.DisplayMember = "거래처긴명칭";
            cmbHidden.ValueMember = "거래처코드";
            cmbHidden.DataSource = (object)adoTab;
            cmbHidden.TabStop = false;
        }

        public void set_ListBox_거래처_계산서여부(
          ref System.Data.DataTable adoTab,
          string sGubun,
          string sActiveYN,
          System.Windows.Forms.ListBox cmbHidden)
        {
            string query = "select a.거래처코드 " + "   , 거래처명 + ', ' + 대표자명 + ', ' + 거래처담당자 + ', ' + 주소 as 거래처긴명칭" + " from T_거래처정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' and a.거래처구분 in " + sGubun + " " + " and a.사용여부 in " + sActiveYN + " " + " and a.계산서여부 = 'Y' ";
            adoTab = this.RunTable(query, Common.p_strConn);
            DataRow row = adoTab.NewRow();
            row[0] = (object)"";
            row[1] = (object)"";
            adoTab.Rows.InsertAt(row, 0);
            cmbHidden.DisplayMember = "거래처긴명칭";
            cmbHidden.ValueMember = "거래처코드";
            cmbHidden.DataSource = (object)adoTab;
            cmbHidden.TabStop = false;
        }

        public void set_ListBox_상품(ref System.Data.DataTable adoTab, System.Windows.Forms.ListBox cmbHidden)
        {
            string str = "select a.상품코드 " + " , a.상품명 " + "      + (case when a.규격 <> '' then ', ' + a.규격 else '' end) as 상품상세명 " + " from T_상품정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' ";
            string query = !(Common.p_AutoProd == "Y") ? str + " and a.사용여부 = '_' " : str + " and a.사용여부 = '0' ";
            adoTab = this.RunTable(query, Common.p_strConn);
            DataRow row = adoTab.NewRow();
            row[0] = (object)"";
            row[1] = (object)"";
            adoTab.Rows.InsertAt(row, 0);
            cmbHidden.DisplayMember = "상품상세명";
            cmbHidden.ValueMember = "상품코드";
            cmbHidden.DataSource = (object)adoTab;
            cmbHidden.TabStop = false;
        }

        public void set_ListBox_장비(ref System.Data.DataTable adoTab, System.Windows.Forms.ListBox cmbHidden)
        {
            string query = "select a.장비코드 " + "   , 장비명 + ', ' + 규격 as 장비긴명칭" + " from T_장비정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' ";
            adoTab = this.RunTable(query, Common.p_strConn);
            DataRow row = adoTab.NewRow();
            row[0] = (object)"";
            row[1] = (object)"";
            adoTab.Rows.InsertAt(row, 0);
            cmbHidden.DisplayMember = "장비긴명칭";
            cmbHidden.ValueMember = "장비코드";
            cmbHidden.DataSource = (object)adoTab;
            cmbHidden.TabStop = false;
        }

        public void set_Combo_거래처(ref System.Data.DataTable adoTab, ComboBox cmbHidden)
        {
            string query = "select a.거래처코드 " + "   , 거래처명 + ', ' + 대표자명 + ', ' + 거래처담당자 + ', ' + 주소 as 거래처긴명칭" + " from T_거래처정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' and a.거래처구분 in ('1', '3') " + " and a.사용여부 = '0' ";
            adoTab = this.RunTable(query, Common.p_strConn);
            DataRow row = adoTab.NewRow();
            row[0] = (object)"";
            row[1] = (object)"";
            adoTab.Rows.InsertAt(row, 0);
            cmbHidden.DisplayMember = "거래처긴명칭";
            cmbHidden.ValueMember = "거래처코드";
            cmbHidden.DataSource = (object)adoTab;
            cmbHidden.TabStop = false;
        }

        public void set_Combo_상품(ref System.Data.DataTable adoTab, ComboBox cmbHidden)
        {
            string query = "select a.상품코드 " + " , a.상품명 " + "      + (case when a.규격 <> '' then ', ' + a.규격 else '' end) as 상품상세명 " + " from T_상품정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' " + " and a.사용여부 = '0' ";
            adoTab = this.RunTable(query, Common.p_strConn);
            DataRow row = adoTab.NewRow();
            row[0] = (object)"";
            row[1] = (object)"";
            adoTab.Rows.InsertAt(row, 0);
            cmbHidden.DisplayMember = "상품상세명";
            cmbHidden.ValueMember = "상품코드";
            cmbHidden.DataSource = (object)adoTab;
            cmbHidden.TabStop = false;
        }

        public void set_ListBox_계정과목(ref System.Data.DataTable adoTab, System.Windows.Forms.ListBox cmbHidden)
        {
            string query = "select a.코드, a.명칭 " + " from P_계정 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' ";
            adoTab = this.RunTable(query, Common.p_strConn);
            DataRow row = adoTab.NewRow();
            row[0] = (object)"";
            row[1] = (object)"";
            adoTab.Rows.InsertAt(row, 0);
            cmbHidden.DisplayMember = "명칭";
            cmbHidden.ValueMember = "코드";
            cmbHidden.DataSource = (object)adoTab;
            cmbHidden.TabStop = false;
        }

        public string get_전체_박스환산(Decimal nVal, Decimal nAmt)
        {
            string str = "0";
            Decimal num = 1M;
            if (nAmt > 0M)
            {
                if (nVal < 0M)
                    num = -1M;
                nVal = Math.Abs(nVal);
                nVal /= nAmt;
                nVal = Math.Floor(nVal);
                str = (num * nVal).ToString();
            }
            return str;
        }

        public string get_전체_중간환산(Decimal nVal, Decimal nAmt, Decimal nMidAmt)
        {
            string str = "0";
            Decimal num1 = 1M;
            Decimal num2 = 0M;
            if (nAmt > 0M && Math.Abs(nVal) >= nAmt)
                num2 = Math.Floor(Math.Abs(nVal) / nAmt);
            if (nMidAmt > 0M && Math.Abs(nVal) - num2 * nAmt >= nMidAmt)
            {
                if (nVal < 0M)
                    num1 = -1M;
                nVal = Math.Abs(nVal) - num2 * nAmt;
                nVal /= nMidAmt;
                nVal = Math.Floor(nVal);
                str = (num1 * nVal).ToString();
            }
            return str;
        }

        public string get_전체_낱개환산(Decimal nVal, Decimal nAmt, Decimal nMidAmt)
        {
            Decimal num1 = 1M;
            Decimal num2 = 0M;
            Decimal num3 = 0M;
            if (nAmt > 0M && Math.Abs(nVal) >= nAmt)
                num2 = Math.Floor(Math.Abs(nVal) / nAmt);
            if (nMidAmt > 0M && Math.Abs(nVal) - num2 * nAmt >= nMidAmt)
                num3 = Math.Floor((Math.Abs(nVal) - num2 * nAmt) / nMidAmt);
            if (nVal < 0M)
                num1 = -1M;
            nVal = Math.Abs(nVal) - num2 * nAmt - num3 * nMidAmt;
            return (num1 * nVal).ToString();
        }

        public string Numb_Comma_Zero(string strVal, string sGubun)
        {
            string str = "0";
            if (Common.p_strBox == "2")
            {
                if (strVal != "0")
                {
                    if (strVal.IndexOf('.') >= 0)
                    {
                        string[] strArray = strVal.Split('.');
                        if (strArray[0] != "")
                        {
                            str = Decimal.Parse(strArray[0]).ToString("#,0");
                            if (strArray[1] != "")
                                str = str + "." + strArray[1];
                        }
                    }
                    else
                        str = Decimal.Parse(strVal).ToString("#,0");
                }
            }
            else
                str = !(sGubun == "AMT") ? this.NumbDisplay_Zero(Decimal.Parse(strVal), Common.p_strFormatUnit) : this.NumbDisplay_Zero(Decimal.Parse(strVal), Common.p_strFormatAmount);
            return str;
        }

        public string NumbDisplay_Zero(Decimal nVal, string sFormat)
        {
            string str = "0";
            if (nVal != 0M)
                str = nVal.ToString(sFormat);
            return str;
        }

        public string Numb_Comma(string strVal, string sGubun)
        {
            string str = "";
            if (Common.p_strBox == "2")
            {
                if (strVal != "0")
                {
                    if (strVal.IndexOf('.') >= 0)
                    {
                        string[] strArray = strVal.Split('.');
                        if (strArray[0] != "")
                        {
                            str = Decimal.Parse(strArray[0]).ToString("#,0");
                            if (strArray[1] != "")
                                str = str + "." + strArray[1];
                        }
                    }
                    else
                        str = Decimal.Parse(strVal).ToString("#,0");
                }
            }
            else
                str = !(sGubun == "AMT") ? this.NumbDisplay(Decimal.Parse(strVal), Common.p_strFormatUnit) : this.NumbDisplay(Decimal.Parse(strVal), Common.p_strFormatAmount);
            return str;
        }

        public string Numb_Comma_Special(string strVal)
        {
            string str = "";
            if (strVal != "0")
            {
                if (strVal.IndexOf('.') >= 0)
                {
                    string[] strArray = strVal.Split('.');
                    if (strArray[0] != "")
                    {
                        str = Decimal.Parse(strArray[0]).ToString("#,0");
                        if (strArray[1] != "")
                            str = str + "." + strArray[1];
                    }
                }
                else
                    str = Decimal.Parse(strVal).ToString("#,0");
            }
            return str;
        }

        public string Numb_Comma_Special_Zero(string strVal) => strVal;

        public string NumbDisplay(Decimal nVal, string sFormat)
        {
            string str = "";
            if (nVal != 0M)
                str = nVal.ToString(sFormat);
            return str;
        }

        public bool isNum(string sValue)
        {
            bool flag;
            try
            {
                Decimal.Parse(sValue);
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public void set_Grid_By_수량입력방식(DataGridView grd, int nCol_명칭, int nCol_규격)
        {
            for (int index = 0; index < grd.Columns.Count; ++index)
            {
                string toolTipText = grd.Columns[index].HeaderCell.ToolTipText;
                grd.Columns[index].HeaderCell.ToolTipText = "";
                switch (toolTipText)
                {
                    case "박스":
                        if (Common.p_strBox == "1")
                        {
                            if (nCol_명칭 >= 0)
                                grd.Columns[nCol_명칭].Width += grd.Columns[index].Width;
                            grd.Columns[index].Visible = false;
                        }
                        if (Common.p_strBox == "2")
                            grd.Columns[index].HeaderText = "수량";
                        if (Common.p_strEgg == "Y")
                        {
                            grd.Columns[index].HeaderText = Common.p_strEgg박스;
                            break;
                        }
                        break;
                    case "중간":
                        if (Common.p_strBox == "1" || Common.p_strBox == "2")
                        {
                            if (nCol_명칭 >= 0)
                                grd.Columns[nCol_명칭].Width += grd.Columns[index].Width;
                            grd.Columns[index].Visible = false;
                        }
                        if (Common.p_strEgg == "Y")
                        {
                            grd.Columns[index].Visible = false;
                            break;
                        }
                        break;
                    case "낱개":
                        if (Common.p_strBox == "2")
                        {
                            if (nCol_규격 >= 0)
                                grd.Columns[nCol_규격].Width += grd.Columns[index].Width;
                            grd.Columns[index].Visible = false;
                        }
                        if (Common.p_strBox == "1")
                            grd.Columns[index].HeaderText = "수량";
                        if (Common.p_strEgg == "Y")
                        {
                            grd.Columns[index].HeaderText = Common.p_strEgg낱개;
                            break;
                        }
                        break;
                    case "총수량":
                        if (Common.p_strBox == "1" || Common.p_strBox == "2")
                        {
                            if (nCol_명칭 >= 0)
                                grd.Columns[nCol_명칭].Width += grd.Columns[index].Width;
                            grd.Columns[index].Visible = false;
                            break;
                        }
                        break;
                }
            }
        }

        public void set_Grid_By_수량입력방식2(DataGridView grd, int nCol_명칭, int nCol_규격)
        {
            for (int index = 0; index < grd.Columns.Count; ++index)
            {
                string toolTipText = grd.Columns[index].HeaderCell.ToolTipText;
                grd.Columns[index].HeaderCell.ToolTipText = "";
                switch (toolTipText)
                {
                    case "표시박스":
                        if (Common.p_strBox == "1")
                        {
                            grd.Columns[index].HeaderText = "박스";
                            break;
                        }
                        if (nCol_규격 >= 0)
                            grd.Columns[nCol_규격].Width += grd.Columns[index].Width;
                        grd.Columns[index].Visible = false;
                        break;
                    case "박스":
                        if (Common.p_strBox == "1")
                        {
                            if (nCol_명칭 >= 0)
                                grd.Columns[nCol_명칭].Width += grd.Columns[index].Width;
                            grd.Columns[index].Visible = false;
                        }
                        if (Common.p_strBox == "2")
                            grd.Columns[index].HeaderText = "수량";
                        if (Common.p_strEgg == "Y")
                        {
                            grd.Columns[index].HeaderText = Common.p_strEgg박스;
                            break;
                        }
                        break;
                    case "중간":
                        if (Common.p_strBox == "1" || Common.p_strBox == "2")
                        {
                            if (nCol_명칭 >= 0)
                                grd.Columns[nCol_명칭].Width += grd.Columns[index].Width;
                            grd.Columns[index].Visible = false;
                        }
                        if (Common.p_strEgg == "Y")
                        {
                            grd.Columns[index].Visible = false;
                            break;
                        }
                        break;
                    case "낱개":
                        if (Common.p_strBox == "2")
                        {
                            if (nCol_규격 >= 0)
                                grd.Columns[nCol_규격].Width += grd.Columns[index].Width;
                            grd.Columns[index].Visible = false;
                        }
                        if (Common.p_strBox == "1")
                            grd.Columns[index].HeaderText = "수량";
                        if (Common.p_strEgg == "Y")
                        {
                            grd.Columns[index].HeaderText = Common.p_strEgg낱개;
                            break;
                        }
                        break;
                    case "총수량":
                        if (Common.p_strBox == "1" || Common.p_strBox == "2")
                        {
                            if (nCol_명칭 >= 0)
                                grd.Columns[nCol_명칭].Width += grd.Columns[index].Width;
                            grd.Columns[index].Visible = false;
                            break;
                        }
                        break;
                    case "박스단가":
                        if (Common.p_strBox == "1")
                        {
                            if (nCol_명칭 >= 0)
                                grd.Columns[nCol_명칭].Width += grd.Columns[index].Width;
                            grd.Columns[index].Visible = false;
                        }
                        if (Common.p_strBox == "2")
                            grd.Columns[index].HeaderText = "단가";
                        if (Common.p_strBox == "3")
                        {
                            grd.Columns[index].HeaderText = "박스단가";
                            break;
                        }
                        break;
                    case "낱개단가":
                        if (Common.p_strBox == "1")
                            grd.Columns[index].HeaderText = "단가";
                        if (Common.p_strBox == "2")
                        {
                            if (nCol_명칭 >= 0)
                                grd.Columns[nCol_명칭].Width += grd.Columns[index].Width;
                            grd.Columns[index].Visible = false;
                        }
                        if (Common.p_strBox == "3")
                        {
                            grd.Columns[index].HeaderText = "낱개단가";
                            break;
                        }
                        break;
                }
            }
        }

        public void set_Grid_By_수량입력방식(DataGridView grd)
        {
            for (int index = 0; index < grd.Columns.Count; ++index)
            {
                string toolTipText = grd.Columns[index].ToolTipText;
                if (toolTipText.IndexOf("표시박스") >= 0)
                {
                    if (Common.p_strBox == "1")
                    {
                        grd.Columns[index].Visible = true;
                        if (Common.p_BoxAmtYN != "Y")
                            grd.Columns[index].Visible = false;
                    }
                    if (Common.p_strBox == "2" || Common.p_strBox == "3")
                        grd.Columns[index].Visible = false;
                }
                if (toolTipText.IndexOf("박스수량") >= 0)
                {
                    if (Common.p_strBox == "1")
                        grd.Columns[index].Visible = false;
                    if (Common.p_strBox == "2")
                        grd.Columns[index].HeaderText = "수량";
                    if (Common.p_strEgg == "Y")
                        grd.Columns[index].HeaderText = Common.p_strEgg박스;
                }
                if (toolTipText.IndexOf("중간수량") >= 0 && (Common.p_strBox == "1" || Common.p_strBox == "2"))
                    grd.Columns[index].Visible = false;
                if (toolTipText.IndexOf("낱개수량") >= 0)
                {
                    if (Common.p_strBox == "1")
                        grd.Columns[index].HeaderText = "수량";
                    if (Common.p_strBox == "2")
                        grd.Columns[index].Visible = false;
                }
                if (toolTipText.IndexOf("박스단가") >= 0)
                {
                    if (Common.p_strBox == "1")
                        grd.Columns[index].Visible = false;
                    if (Common.p_strBox == "2")
                        grd.Columns[index].HeaderText = "단가";
                    if (Common.p_strBox == "3")
                        grd.Columns[index].ReadOnly = true;
                    if (Common.p_strUnitMod != "Y")
                        grd.Columns[index].ReadOnly = true;
                }
                if (toolTipText.IndexOf("낱개단가") >= 0)
                {
                    if (Common.p_strBox == "1")
                        grd.Columns[index].HeaderText = "단가";
                    if (Common.p_strBox == "2")
                        grd.Columns[index].Visible = false;
                    if (Common.p_strUnitMod != "Y")
                        grd.Columns[index].ReadOnly = true;
                }
                if (toolTipText.IndexOf("총수량") >= 0 && (Common.p_strBox == "1" || Common.p_strBox == "2"))
                    grd.Columns[index].Visible = false;
                if (toolTipText.IndexOf("금액") >= 0)
                {
                    if (Common.p_MaeChoolMoney != "Y")
                        grd.Columns[index].ReadOnly = true;
                    else
                        grd.Columns[index].ReadOnly = false;
                }
            }
        }

        public void set_Grid_By_수량입력방식_Color(DataGridView grd, int nRow)
        {
            for (int index = 0; index < grd.Columns.Count; ++index)
            {
                if (grd.Columns[index].ReadOnly)
                {
                    grd.Rows[nRow].Cells[index].Style.BackColor = ColorTranslator.FromHtml("#f0efeb");
                    grd.Rows[nRow].Cells[index].Style.SelectionBackColor = ColorTranslator.FromHtml("#cddafd");
                }
            }
        }

        public void set_Grid_By_수량입력방식_Color_창고이동(DataGridView grd, int nRow)
        {
            for (int index = 0; index < grd.Columns.Count; ++index)
            {
                if (grd.Columns[index].ReadOnly)
                {
                    grd.Rows[nRow].Cells[index].Style.BackColor = ColorTranslator.FromHtml("#f0efeb");
                    grd.Rows[nRow].Cells[index].Style.SelectionBackColor = ColorTranslator.FromHtml("#cddafd");
                }
            }
        }

        public bool check_NumText(Form frm, string sName, string sMsg)
        {
            if (Common.p_strEgg == "Y")
            {
                sMsg = sMsg.Replace("박스", Common.p_strEgg박스);
                sMsg = sMsg.Replace("낱개", Common.p_strEgg낱개);
            }
            bool flag = true;
            try
            {
                Control[] controlArray = frm.Controls.Find("txt" + sName, true);
                if (controlArray[0].Text == "")
                {
                    int num = (int)MessageBox.Show("[ " + sMsg + " ] 을 입력하세요.");
                    flag = false;
                }
                else if (!this.isNum(controlArray[0].Text))
                {
                    int num = (int)MessageBox.Show("[ " + sMsg + " ] 에 숫자만 입력하세요.");
                    flag = false;
                }
            }
            catch
            {
                int num = (int)MessageBox.Show("[ " + sMsg + " ] 에 알수 없는 문제가 있습니다.");
                flag = false;
            }
            return flag;
        }

        public bool check_NumText(UserControl frm, string sName, string sMsg)
        {
            bool flag = true;
            try
            {
                Control[] controlArray = frm.Controls.Find("txt" + sName, true);
                if (controlArray[0].Text == "")
                {
                    int num = (int)MessageBox.Show("[ " + sMsg + " ] 을 입력하세요.");
                    flag = false;
                }
                else if (!this.isNum(controlArray[0].Text))
                {
                    int num = (int)MessageBox.Show("[ " + sMsg + " ] 에 숫자만 입력하세요.");
                    flag = false;
                }
            }
            catch
            {
                int num = (int)MessageBox.Show("[ " + sMsg + " ] 에 알수 없는 문제가 있습니다.");
                flag = false;
            }
            return flag;
        }

        public void setCombo_업체용_일반조건(
          DataGridViewComboBoxColumn cmb,
          string sCode,
          string sName,
          string sTable,
          string sWhere,
          string sOrder,
          string sGubun)
        {
            cmb.DisplayMember = sName;
            cmb.ValueMember = sCode;
            string sQuery = "select " + sCode + ", " + sName + " from " + sTable + " where 사업자번호 = '" + Common.p_strCompID + "' and 지점코드 = '" + Common.p_strSpotCode + "' " + sWhere + sOrder;
            switch (sGubun)
            {
                case "ALL":
                    this.ComboBox_Read_ALL(cmb, sQuery, Common.p_strConn);
                    break;
                case "NoBLANK":
                    this.ComboBox_Read_NoBlank(cmb, sQuery, Common.p_strConn);
                    break;
                default:
                    this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
                    break;
            }
        }

        public void setCombo_업체용_일반(
          ComboBox cmb,
          string sCode,
          string sName,
          string sTable,
          string sGubun)
        {
            cmb.DisplayMember = sName;
            cmb.ValueMember = sCode;
            string sQuery = "select " + sCode + ", " + sName + " from " + sTable + " where 사업자번호 = '" + Common.p_strCompID + "' and 지점코드 = '" + Common.p_strSpotCode + "' ";
            switch (sGubun)
            {
                case "ALL":
                    this.ComboBox_Read_ALL(cmb, sQuery, Common.p_strConn);
                    break;
                case "NoBLANK":
                    this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
                    break;
                default:
                    this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
                    break;
            }
        }

        public void setCombo_업체용_일반조건(
          ComboBox cmb,
          string sCode,
          string sName,
          string sTable,
          string sWhere,
          string sOrder,
          string sGubun)
        {
            cmb.DisplayMember = sName;
            cmb.ValueMember = sCode;
            string sQuery = "select " + sCode + ", " + sName + " from " + sTable + " where 사업자번호 = '" + Common.p_strCompID + "' and 지점코드 = '" + Common.p_strSpotCode + "' " + sWhere + sOrder;
            switch (sGubun)
            {
                case "ALL":
                    this.ComboBox_Read_ALL(cmb, sQuery, Common.p_strConn);
                    break;
                case "NoBLANK":
                    this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
                    break;
                default:
                    this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
                    break;
            }
        }

        public void setCombo_업체용코드(ComboBox cmb, string sTable, string sGubun)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string sQuery = "select 코드, 명칭 from " + sTable + " where 사업자번호 = '" + Common.p_strCompID + "' and 지점코드 = '" + Common.p_strSpotCode + "' ";
            switch (sGubun)
            {
                case "ALL":
                    this.ComboBox_Read_ALL(cmb, sQuery, Common.p_strConn);
                    break;
                case "NoBLANK":
                    this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
                    break;
                default:
                    this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
                    break;
            }
        }

        public void setGridCombo_업체용코드(DataGridViewComboBoxColumn cmb, string sTable, string sGubun)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string sQuery = "select 코드, 명칭 from " + sTable + " where 사업자번호 = '" + Common.p_strCompID + "' and 지점코드 = '" + Common.p_strSpotCode + "' ";
            switch (sGubun)
            {
                case "ALL":
                    this.ComboBox_Read_ALL(cmb, sQuery, Common.p_strConn);
                    break;
                case "NoBLANK":
                    this.ComboBox_Read_NoBlank(cmb, sQuery, Common.p_strConn);
                    break;
                default:
                    this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
                    break;
            }
        }

        public void setCombo_업체용코드_상품관련(ComboBox cmb, string sTable, string sGubun)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string sQuery = "select 코드, 명칭 from " + sTable + " where 사업자번호 = '" + Common.p_strCompID + "' and 지점코드 = '0' ";
            switch (sGubun)
            {
                case "ALL":
                    this.ComboBox_Read_ALL(cmb, sQuery, Common.p_strConn);
                    break;
                case "NoBLANK":
                    this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
                    break;
                default:
                    this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
                    break;
            }
        }

        public void setCombo_배송차량_코드(string sSpot, ComboBox cmb, string sTable, string sGubun)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string sQuery = "select 코드, 명칭 from " + sTable + " where 사업자번호 = '" + Common.p_strCompID + "' and 지점코드 = '" + sSpot + "' ";
            switch (sGubun)
            {
                case "ALL":
                    this.ComboBox_Read_ALL(cmb, sQuery, Common.p_strConn);
                    break;
                case "NoBLANK":
                    this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
                    break;
                default:
                    this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
                    break;
            }
        }

        public void setCombo_업체용코드(
          ComboBox cmb,
          string sTable,
          string sGubun,
          string sBlankName,
          string sBlankName2)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string sQuery = "select 코드, 명칭 from " + sTable + " where 사업자번호 = '" + Common.p_strCompID + "' and 지점코드 = '" + Common.p_strSpotCode + "' ";
            switch (sGubun)
            {
                case "NoBLANK":
                    this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
                    break;
                default:
                    this.ComboBox_Read(cmb, sQuery, sBlankName, sBlankName2, Common.p_strConn);
                    break;
            }
        }

        public void setCombo_공용코드_옵션(ComboBox cmb, string sTable, string sNum, string sGubun)
        {
            cmb.DisplayMember = "명칭" + sNum;
            cmb.ValueMember = "코드";
            string sQuery = "select 코드, 명칭" + sNum + " from " + sTable + " where 1=1 ";
            switch (sGubun)
            {
                case "ALL":
                    this.ComboBox_Read_ALL(cmb, sQuery, Common.p_strConn);
                    break;
                case "NoBLANK":
                    this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
                    break;
                default:
                    this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
                    break;
            }
        }

        public void setGridCombo_공용코드(DataGridViewComboBoxColumn cmb, string sTable, string sGubun)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string sQuery = "select 코드, 명칭 from " + sTable + " where 1=1 ";
            switch (sGubun)
            {
                case "ALL":
                    this.ComboBox_Read_ALL(cmb, sQuery, Common.p_strConn);
                    break;
                case "NoBLANK":
                    this.ComboBox_Read_NoBlank(cmb, sQuery, Common.p_strConn);
                    break;
                default:
                    this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
                    break;
            }
        }

        public void setGridCombo_공용코드(
          DataGridViewComboBoxColumn cmb,
          string sTable,
          string sWhere,
          string sGubun)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string sQuery = "select 코드, 명칭 from " + sTable + " where 1=1 " + sWhere;
            switch (sGubun)
            {
                case "ALL":
                    this.ComboBox_Read_ALL(cmb, sQuery, Common.p_strConn);
                    break;
                case "NoBLANK":
                    this.ComboBox_Read_NoBlank(cmb, sQuery, Common.p_strConn);
                    break;
                default:
                    this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
                    break;
            }
        }

        public void setCombo_공용코드(ComboBox cmb, string sTable, string sGubun)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string sQuery = "select 코드, 명칭 from " + sTable + " where 1=1 ";
            switch (sGubun)
            {
                case "ALL":
                    this.ComboBox_Read_ALL(cmb, sQuery, Common.p_strConn);
                    break;
                case "NoBLANK":
                    this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
                    break;
                default:
                    this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
                    break;
            }
        }

        public void set_매출일자(DateTimePicker dtp)
        {
            try
            {
                this.adoTable = this.RunTable("select getdate() ", Common.p_strConnMain);
                if (this.adoTable == null)
                    return;
                DateTime dateTime = DateTime.Parse(this.adoTable.Rows[0][0].ToString());
                if (Common.p_AutoSaleTime == "")
                    dtp.Text = dateTime.ToString("yyyy-MM-dd");
                else if (int.Parse(dateTime.ToString("HH")) >= int.Parse(Common.p_AutoSaleTime))
                    dtp.Text = dateTime.AddDays(1.0).ToString("yyyy-MM-dd");
                else
                    dtp.Text = dateTime.ToString("yyyy-MM-dd");
            }
            catch
            {
                dtp.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public void set_공용일자(DateTimePicker dtp)
        {
            try
            {
                this.adoTable = this.RunTable("select getdate() ", Common.p_strConnMain);
                if (this.adoTable == null)
                    return;
                dtp.Text = DateTime.Parse(this.adoTable.Rows[0][0].ToString()).ToString("yyyy-MM-dd");
            }
            catch
            {
                dtp.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        

        public void set_공용일자일시(DateTimePicker dtp)
        {
            try
            {
                this.adoTable = this.RunTable("select getdate() ", Common.p_strConnMain);
                if (this.adoTable == null)
                    return;
                dtp.Text = DateTime.Parse(this.adoTable.Rows[0][0].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                dtp.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        public void set_공용시각(DateTimePicker dtp)
        {
            try
            {
                this.adoTable = this.RunTable("select getdate() ", Common.p_strConnMain);
                if (this.adoTable == null)
                    return;
                dtp.Text = DateTime.Parse(this.adoTable.Rows[0][0].ToString()).ToString("HH:mm:ss");
            }
            catch
            {
                dtp.Text = DateTime.Now.ToString("HH:mm:ss");
            }
        }

        public void set_공용일자(System.Windows.Forms.Label dtp)
        {
            try
            {
                this.adoTable = this.RunTable("select getdate() ", Common.p_strConnMain);
                if (this.adoTable == null)
                    return;
                dtp.Text = DateTime.Parse(this.adoTable.Rows[0][0].ToString()).ToString("yyyy-MM-dd");
            }
            catch
            {
                dtp.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public void set_공용시각(System.Windows.Forms.Label dtp)
        {
            try
            {
                this.adoTable = this.RunTable("select getdate() ", Common.p_strConnMain);
                if (this.adoTable == null)
                    return;
                dtp.Text = DateTime.Parse(this.adoTable.Rows[0][0].ToString()).ToString("HH:mm:ss");
            }
            catch
            {
                dtp.Text = DateTime.Now.ToString("HH:mm:ss");
            }
        }

        public void setCombo_출고차수(ComboBox cmb)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string sQuery = " select '1' as 코드, '1차' as 명칭 " + " union all " + " select '2' as 코드, '2차' as 명칭 " + " union all " + " select '3' as 코드, '3차' as 명칭 ";
            this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_중상처(ComboBox cmb)
        {
            cmb.DisplayMember = "대표자명";
            cmb.ValueMember = "거래처코드";
            string sQuery = "select a.거래처코드 " + " , a.대표자명 " + " from T_거래처정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' and isnull(a.중상여부, '0') = '1' " + " order by a.거래처코드 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_중상처_상호(ComboBox cmb)
        {
            cmb.DisplayMember = "거래처명";
            cmb.ValueMember = "거래처코드";
            string sQuery = "select a.거래처코드 " + " , a.거래처명 " + " from T_거래처정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' and isnull(a.중상여부, '0') = '1' " + " order by a.거래처코드 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_사원번호_여부(ComboBox cmb)
        {
            cmb.DisplayMember = "사용자상세명";
            cmb.ValueMember = "사원번호";
            string str = "select a.사원번호 " + " , a.사용자명 + (case when a.퇴사여부 = 'Y' then ' ■퇴사' else '' end) as 사용자상세명 " + " from T_사용자정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' ";
            if (Common.p_strUserAdmin != "Y" && Common.p_strResultAll != "Y")
                str = str + "   and a.사원번호 = '" + Common.p_strUserNo + "' ";
            string sQuery = str + " order by a.사원번호 asc ";
            if (Common.p_strUserAdmin != "Y" && Common.p_strResultAll != "Y")
                this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
            else
                this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_사원번호_여부(ComboBox cmb, bool bExist_only)
        {
            cmb.DisplayMember = "사용자상세명";
            cmb.ValueMember = "사원번호";
            string str = "select a.사원번호 " + " , a.사용자명 + (case when a.퇴사여부 = 'Y' then ' ■퇴사' else '' end) as 사용자상세명 " + " from T_사용자정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' ";
            if (Common.p_strUserAdmin != "Y" && Common.p_strResultAll != "Y")
                str = str + "   and a.사원번호 = '" + Common.p_strUserNo + "' ";
            if (bExist_only)
                str += " and isnull(a.퇴사여부, 'N') <> 'Y' ";
            string sQuery = str + " order by a.사원번호 asc ";
            if (Common.p_strUserAdmin != "Y" && Common.p_strResultAll != "Y")
                this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
            else
                this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_사원번호별_창고(ComboBox cmb)
        {
            cmb.DisplayMember = "창고명";
            cmb.ValueMember = "창고코드";
            string str = "select a.창고코드 " + " , b.명칭 as 창고명 " + " from T_사용자정보 a " + "   left outer join P_창고 b on b.사업자번호 = a.사업자번호 and b.지점코드 = a.지점코드 and b.코드 = a.창고코드 " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' ";
            if (Common.p_strUserAdmin != "Y" && Common.p_strResultAll != "Y")
                str = str + "   and a.사원번호 = '" + Common.p_strUserNo + "' ";
            string sQuery = str + " order by a.사원번호 asc ";
            if (Common.p_strUserAdmin != "Y" && Common.p_strResultAll != "Y")
                this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
            else
                this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_사원번호_여부_상호명(ComboBox cmb)
        {
            cmb.DisplayMember = "상호명";
            cmb.ValueMember = "사원번호";
            string sQuery = "select a.사원번호 " + " , case when isnull(b.상호명, '') = '' then '" + Common.p_strCompName + "' else b.상호명 end as 상호명 " + " from T_사용자정보 a " + "   left outer join T_사용자사업자 b on b.사업자번호 = a.사업자번호 and b.지점코드 = a.지점코드 and b.사원번호 = a.사원번호 " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' " + " order by a.사원번호 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_사원번호_여부_창고(ComboBox cmb)
        {
            cmb.DisplayMember = "창고명";
            cmb.ValueMember = "창고코드";
            string sQuery = "select a.창고코드 " + " , b.명칭 as 창고명 " + " from T_사용자정보 a " + "   left outer join P_창고 b on b.사업자번호 = a.사업자번호 and b.지점코드 = '" + Common.p_strSpotCode + "' and b.코드 = a.창고코드 " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' " + " order by a.사원번호 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_사원번호(ComboBox cmb, bool bExist_only)
        {
            cmb.DisplayMember = "사용자명";
            cmb.ValueMember = "사원번호";
            string str = "select a.사원번호 " + " , a.사용자명 " + " from T_사용자정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' ";
            if (bExist_only)
                str += " and isnull(a.퇴사여부, 'N') <> 'Y' ";
            string sQuery = str + " order by a.사원번호 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_사원번호_창고(ComboBox cmb, bool bExist_only)
        {
            cmb.DisplayMember = "창고명";
            cmb.ValueMember = "창고코드";
            string str = "select a.창고코드 " + " , b.명칭 as 창고명 " + " from T_사용자정보 a " + "   left outer join P_창고 b on b.사업자번호 = a.사업자번호 and b.지점코드 = '" + Common.p_strSpotCode + "' and b.코드 = a.창고코드 " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' ";
            if (bExist_only)
                str += " and isnull(a.퇴사여부, 'N') <> 'Y' ";
            string sQuery = str + " order by a.사원번호 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_상품_규격_여부(ComboBox cmb)
        {
            cmb.DisplayMember = "상품상세명";
            cmb.ValueMember = "상품코드";
            string sQuery = "select a.상품코드 " + " , a.상품명 " + "      + (case when a.규격 <> '' then ' ▷' + a.규격 else '' end) " + "      + (case when a.사용여부 = '1' then ' ■' + b.명칭 when a.사용여부 = '2' then ' ★' + b.명칭 else '' end) as 상품상세명 " + " from T_상품정보 a " + "      left outer join C_상품여부 b on b.코드 = a.사용여부 " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' " + " order by a.상품코드 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_상품_규격(ComboBox cmb, bool bNew)
        {
            cmb.DisplayMember = "상품상세명";
            cmb.ValueMember = "상품코드";
            string str = "select a.상품코드 " + " , a.상품명 " + "      + (case when a.규격 <> '' then ' ▷' + a.규격 else '' end) as 상품상세명 " + " from T_상품정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' ";
            if (bNew)
                str += " and a.사용여부 = '0' ";
            string sQuery = str + " order by a.상품코드 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_상품(ComboBox cmb, bool bNew)
        {
            cmb.DisplayMember = "상품명";
            cmb.ValueMember = "상품코드";
            string str = "select a.상품코드 " + " , a.상품명 " + " from T_상품정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' ";
            if (bNew)
                str += " and a.사용여부 = '0' ";
            string sQuery = str + " order by a.상품코드 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_매출처(ComboBox cmb, bool bNew)
        {
            cmb.DisplayMember = "거래처명";
            cmb.ValueMember = "거래처코드";
            string str = "select a.거래처코드 " + " , a.거래처명 " + " from T_거래처정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' and a.거래처구분 in ('1', '3') ";
            if (bNew)
                str += " and a.사용여부 = '0' ";
            string sQuery = str + " order by a.거래처코드 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_매출처_Long(ComboBox cmb, bool bNew)
        {
            cmb.DisplayMember = "거래처긴명칭";
            cmb.ValueMember = "거래처코드";
            string str = "select a.거래처코드 " + "   , a.거래처명 + ', ' + a.대표자명 + ', ' + a.거래처담당자 + ', ' + a.주소 as 거래처긴명칭" + " from T_거래처정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' and a.거래처구분 in ('1', '3') ";
            if (bNew)
                str += " and a.사용여부 = '0' ";
            string sQuery = str + " order by a.거래처코드 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_매입처(ComboBox cmb, bool bNew)
        {
            cmb.DisplayMember = "거래처명";
            cmb.ValueMember = "거래처코드";
            string str = "select a.거래처코드 " + " , a.거래처명 " + " from T_거래처정보 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' and a.거래처구분 = '2' ";
            if (bNew)
                str += " and a.사용여부 = '0' ";
            string sQuery = str + " order by a.거래처코드 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_매출처_여부(ComboBox cmb)
        {
            cmb.DisplayMember = "거래처상세명";
            cmb.ValueMember = "거래처코드";
            string sQuery = "select a.거래처코드 " + " , a.거래처명 " + "      + (case when a.사용여부 = '1' then ' ■' + b.명칭 when a.사용여부 = '2' then ' ★' + b.명칭 else '' end) as 거래처상세명 " + " from T_거래처정보 a " + "      left outer join C_거래처여부 b on b.코드 = a.사용여부 " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' and a.거래처구분 in ('1', '3') " + " order by a.거래처코드 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_매입처_여부(ComboBox cmb)
        {
            cmb.DisplayMember = "거래처상세명";
            cmb.ValueMember = "거래처코드";
            string sQuery = "select a.거래처코드 " + " , a.거래처명 " + "      + (case when a.사용여부 = '1' then ' ■' + b.명칭 when a.사용여부 = '2' then ' ★' + b.명칭 else '' end) as 거래처상세명 " + " from T_거래처정보 a " + "      left outer join C_거래처여부 b on b.코드 = a.사용여부 " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' and a.거래처구분 = '2' " + " order by a.거래처코드 asc ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_창고(ComboBox cmb)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string str = "select a.코드 " + " , a.명칭 " + " from P_창고 a " + " where a.사업자번호 = '" + Common.p_strCompID + "' and a.지점코드 = '" + Common.p_strSpotCode + "' " + "   and a.코드 <> '999' ";
            if (Common.p_strUserAdmin != "Y" && Common.p_strResultAll != "Y")
                str = str + "   and a.코드 in (select 창고코드 from T_사용자정보 where 사업자번호 = '" + Common.p_strCompID + "' and 지점코드 = '" + Common.p_strSpotCode + "' and 사원번호 = '" + Common.p_strUserNo + "') ";
            string sQuery = str + " order by a.코드 asc ";
            if (Common.p_strUserAdmin != "Y" && Common.p_strResultAll != "Y")
                this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
            else
                this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_계산서여부(ComboBox cmb)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string sQuery = "select 'N' as 코드, '미발행' as 명칭 " + " union all select 'Y' as 코드, '발행' as 명칭 ";
            this.ComboBox_Read(cmb, sQuery, Common.p_strConn);
        }

        public void setCombo_매입이벤트단가(ComboBox cmb)
        {
            cmb.DisplayMember = "명칭";
            cmb.ValueMember = "코드";
            string sQuery = "" + " select '' as 코드, '(최종단가)' as 명칭 " + " union all " + " select '_F_' as 코드, '(마스터단가)' as 명칭 ";
            this.ComboBox_Read_NoBlank((ComboBox)cmb, sQuery, Common.p_strConn);
        }

        public bool DB_Open(string sConn)
        {
            if (this.adoConnection.State == ConnectionState.Open)
                return true;
            if (string.IsNullOrEmpty(sConn))
                return false;
            this.adoConnection.ConnectionString = sConn;
            try
            {
                this.adoConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString(), "에러발생", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public System.Data.DataTable RunTable(string query, string sDBConStr)
        {
            if (!this.DB_Open(sDBConStr))
                return (System.Data.DataTable)null;
            System.Data.DataTable dataTable = new System.Data.DataTable();
            this.adoCommand = this.adoConnection.CreateCommand();
            try
            {
                this.adoCommand.CommandType = CommandType.Text;
                this.adoCommand.CommandText = query;
                this.adoAdapter.SelectCommand = this.adoCommand;
                this.adoAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString(), "에러발생", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.adoConnection.Close();
            }
            return dataTable;
        }

        public void ComboBox_Read(ComboBox sCombo, string sQuery, string sDBConStr)
        {
            if (sQuery.Trim().Length > 10)
                this.strQuery = sQuery.Trim();
            this.adoTable = this.RunTable(this.strQuery, sDBConStr);
            this.adoRow = this.adoTable.NewRow();
            this.adoRow[0] = (object)"";
            this.adoRow[1] = (object)"";
            this.adoTable.Rows.InsertAt(this.adoRow, 0);
            sCombo.DataSource = (object)this.adoTable;
        }

        public void ComboBox_Read(
          ComboBox sCombo,
          string sQuery,
          string sBlankName,
          string sBlankName2,
          string sDBConStr)
        {
            if (sQuery.Trim().Length > 10)
                this.strQuery = sQuery.Trim();
            this.adoTable = this.RunTable(this.strQuery, sDBConStr);
            if (sBlankName2 != "")
            {
                this.adoRow = this.adoTable.NewRow();
                this.adoRow[0] = (object)"_F_";
                this.adoRow[1] = (object)sBlankName2;
                this.adoTable.Rows.InsertAt(this.adoRow, 0);
            }
            if (sBlankName != "")
            {
                this.adoRow = this.adoTable.NewRow();
                this.adoRow[0] = (object)"";
                this.adoRow[1] = (object)sBlankName;
                this.adoTable.Rows.InsertAt(this.adoRow, 0);
            }
            sCombo.DataSource = (object)this.adoTable;
        }

        public void ComboBox_Read_NoBlank(ComboBox sCombo, string sQuery, string sDBConStr)
        {
            if (sQuery.Trim().Length > 10)
                this.strQuery = sQuery.Trim();
            this.adoTable = this.RunTable(this.strQuery, sDBConStr);
            sCombo.DataSource = (object)this.adoTable;
        }

        public void ComboBox_Read_ALL(ComboBox sCombo, string sQuery, string sDBConStr)
        {
            if (sQuery.Trim().Length > 10)
                this.strQuery = sQuery.Trim();
            this.adoTable = this.RunTable(this.strQuery, sDBConStr);
            this.adoRow = this.adoTable.NewRow();
            this.adoRow[0] = (object)"";
            this.adoRow[1] = (object)"(전체)";
            this.adoTable.Rows.InsertAt(this.adoRow, 0);
            sCombo.DataSource = (object)this.adoTable;
        }

        public void ComboBox_Read(DataGridViewComboBoxColumn sCombo, string sQuery, string sDBConStr)
        {
            if (sQuery.Trim().Length > 10)
                this.strQuery = sQuery.Trim();
            this.adoTable = this.RunTable(this.strQuery, sDBConStr);
            this.adoRow = this.adoTable.NewRow();
            this.adoRow[0] = (object)"";
            this.adoRow[1] = (object)"";
            this.adoTable.Rows.InsertAt(this.adoRow, 0);
            sCombo.DataSource = (object)this.adoTable;
        }

        public void ComboBox_Read(
          DataGridViewComboBoxColumn sCombo,
          string sQuery,
          string sBlankName,
          string sDBConStr)
        {
            if (sQuery.Trim().Length > 10)
                this.strQuery = sQuery.Trim();
            this.adoTable = this.RunTable(this.strQuery, sDBConStr);
            this.adoRow = this.adoTable.NewRow();
            this.adoRow[0] = (object)"";
            this.adoRow[1] = (object)sBlankName;
            this.adoTable.Rows.InsertAt(this.adoRow, 0);
            sCombo.DataSource = (object)this.adoTable;
        }

        public void ComboBox_Read_NoBlank(
          DataGridViewComboBoxColumn sCombo,
          string sQuery,
          string sDBConStr)
        {
            if (sQuery.Trim().Length > 10)
                this.strQuery = sQuery.Trim();
            this.adoTable = this.RunTable(this.strQuery, sDBConStr);
            sCombo.DataSource = (object)this.adoTable;
        }

        public void ComboBox_Read_ALL(
          DataGridViewComboBoxColumn sCombo,
          string sQuery,
          string sDBConStr)
        {
            if (sQuery.Trim().Length > 10)
                this.strQuery = sQuery.Trim();
            this.adoTable = this.RunTable(this.strQuery, sDBConStr);
            this.adoRow = this.adoTable.NewRow();
            this.adoRow[0] = (object)"";
            this.adoRow[1] = (object)"(전체)";
            this.adoTable.Rows.InsertAt(this.adoRow, 0);
            sCombo.DataSource = (object)this.adoTable;
        }

       

        public Image ConvertByteToImage(byte[] pByte)
        {
            MemoryStream memoryStream = new MemoryStream();
            Image image = (Image)null;
            try
            {
                memoryStream.Position = 0L;
                memoryStream.Write(pByte, 0, pByte.Length);
                image = Image.FromStream((Stream)memoryStream);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return image;
        }

        public byte[] ConvertImageToByte(Bitmap img, string sFileExt)
        {
            Bitmap bitmap = new Bitmap((Image)img);
            byte[] buffer = new byte[0];
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                switch (sFileExt.ToLower())
                {
                    case "jpeg":
                        bitmap.Save((Stream)memoryStream, ImageFormat.Jpeg);
                        break;
                    case "bmp":
                        bitmap.Save((Stream)memoryStream, ImageFormat.Bmp);
                        break;
                    case "emf":
                        bitmap.Save((Stream)memoryStream, ImageFormat.Emf);
                        break;
                    case "exif":
                        bitmap.Save((Stream)memoryStream, ImageFormat.Exif);
                        break;
                    case "gif":
                        bitmap.Save((Stream)memoryStream, ImageFormat.Gif);
                        break;
                    case "icon":
                        bitmap.Save((Stream)memoryStream, ImageFormat.Icon);
                        break;
                    case "memorybmp":
                        bitmap.Save((Stream)memoryStream, ImageFormat.MemoryBmp);
                        break;
                    case "png":
                        bitmap.Save((Stream)memoryStream, ImageFormat.Png);
                        break;
                    case "tiff":
                        bitmap.Save((Stream)memoryStream, ImageFormat.Tiff);
                        break;
                    case "wmf":
                        bitmap.Save((Stream)memoryStream, ImageFormat.Wmf);
                        break;
                }
                buffer = new byte[memoryStream.Length];
                memoryStream.Position = 0L;
                memoryStream.Read(buffer, 0, (int)memoryStream.Length);
                memoryStream.Close();
            }
            catch (Exception ex)
            {
            }
            return buffer;
        }

        public void convert_to_CSV_XLS(DataGridView dGV, string filename)
        {
            try
            {
                File.Delete(filename);
                File.Delete(filename + ".csv");
                DataGridViewCheckBoxColumn viewCheckBoxColumn = new DataGridViewCheckBoxColumn();
                StringBuilder stringBuilder = new StringBuilder();
                string str = "";
                for (int index = 0; index < dGV.Columns.Count; ++index)
                {
                    if (dGV.Columns[index].Visible && dGV.Columns[index].CellType != viewCheckBoxColumn.CellType)
                        str = str.ToString() + "\"" + Convert.ToString(dGV.Columns[index].HeaderText) + "\"" + CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                }
                stringBuilder.Append(str + "\r\n");
                for (int index1 = 0; index1 < dGV.RowCount; ++index1)
                {
                    for (int index2 = 0; index2 < dGV.Columns.Count; ++index2)
                    {
                        if (dGV.Columns[index2].Visible && dGV.Columns[index2].CellType != viewCheckBoxColumn.CellType)
                        {
                            if (dGV[index2, index1] is DataGridViewImageCell)
                                stringBuilder.AppendFormat("\"{0}\"", (object)Convert.ToString(dGV.Rows[index1].Cells[index2].Tag));
                            else
                                stringBuilder.AppendFormat("\"{0}\"", (object)Convert.ToString(dGV.Rows[index1].Cells[index2].Value));
                            stringBuilder.Append(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                        }
                    }
                    stringBuilder.Append("\r\n");
                }
                byte[] bytes = Encoding.GetEncoding(949).GetBytes(stringBuilder.ToString());
                FileStream fileStream = new FileStream(filename + ".csv", FileMode.CreateNew);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)fileStream);
                binaryWriter.Write(bytes, 0, bytes.Length);
                binaryWriter.Flush();
                binaryWriter.Close();
                fileStream.Close();
                object FieldInfo = (object)new int[30, 2]
                {
          {
            1,
            2
          },
          {
            2,
            2
          },
          {
            3,
            2
          },
          {
            4,
            2
          },
          {
            5,
            2
          },
          {
            6,
            2
          },
          {
            7,
            2
          },
          {
            8,
            2
          },
          {
            9,
            2
          },
          {
            10,
            2
          },
          {
            11,
            2
          },
          {
            12,
            2
          },
          {
            13,
            2
          },
          {
            14,
            2
          },
          {
            15,
            2
          },
          {
            16,
            2
          },
          {
            17,
            2
          },
          {
            18,
            2
          },
          {
            19,
            2
          },
          {
            20,
            2
          },
          {
            21,
            2
          },
          {
            22,
            2
          },
          {
            23,
            2
          },
          {
            24,
            2
          },
          {
            25,
            2
          },
          {
            26,
            2
          },
          {
            27,
            2
          },
          {
            28,
            2
          },
          {
            29,
            2
          },
          {
            30,
            2
          }
                };
                
            }
            catch
            {
                int num = (int)MessageBox.Show("저장될 파일이 열렸는지 확인하세요.");
            }
        }

     

        public void Run_Excel(string fileName) => Process.Start(new ProcessStartInfo()
        {
            FileName = "EXCEL.EXE",
            Arguments = fileName
        });

        public string maxValue_Check(string sqlQuery)
        {
            string str = "";
            try
            {
                this.adoTable = this.RunTable(sqlQuery, Common.p_strConn);
                if (this.adoTable != null)
                {
                    if (this.adoTable.Rows.Count > 0)
                        str = this.adoTable.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                str = "";
            }
            return str;
        }

        public Decimal get_거래처별_잔고(string sCust, string sDay, string sInOut)
        {
            Decimal num1 = 0M;
            try
            {
                wnDm wnDm = new wnDm();
                System.Data.DataTable dataTable = !(sInOut == "매출기준") ? wnDm.fn_거래처잔고_Summary(" '2', '3' ", sCust, sDay, Common.p_strConn) : wnDm.fn_거래처잔고_Summary(" '1', '3' ", sCust, sDay, Common.p_strConn);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    if ((dataTable.Rows[0]["현재잔고"].ToString() ?? "") == "")
                        dataTable.Rows[0]["현재잔고"] = (object)"0";
                    Decimal num2 = Decimal.Parse(dataTable.Rows[0]["현재잔고"].ToString());
                    num1 = !(sInOut == "매출기준") ? num2 - Decimal.Parse(dataTable.Rows[0]["매입액"].ToString()) + Decimal.Parse(dataTable.Rows[0]["매입반품액"].ToString()) + Decimal.Parse(dataTable.Rows[0]["지급액"].ToString()) + Decimal.Parse(dataTable.Rows[0]["매출액"].ToString()) - Decimal.Parse(dataTable.Rows[0]["반품액"].ToString()) - Decimal.Parse(dataTable.Rows[0]["수금액"].ToString()) : num2 - Decimal.Parse(dataTable.Rows[0]["매출액"].ToString()) + Decimal.Parse(dataTable.Rows[0]["반품액"].ToString()) + Decimal.Parse(dataTable.Rows[0]["수금액"].ToString()) + Decimal.Parse(dataTable.Rows[0]["매입액"].ToString()) - Decimal.Parse(dataTable.Rows[0]["매입반품액"].ToString()) - Decimal.Parse(dataTable.Rows[0]["지급액"].ToString());
                }
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
            return num1;
        }

        public Decimal get_상품별_재고(string sWare, string sProd, string sDay)
        {
            Decimal num = 0M;
            try
            {
                System.Data.DataTable dataTable = new wnDm().fn_상품창고별재고_Summary(sWare, sProd, sDay, Common.p_strConn);
                if (dataTable != null && dataTable.Rows.Count > 0)
                    num = Decimal.Parse(dataTable.Rows[0]["현재고"].ToString());
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
            return num;
        }

        public string get_상품별_재고표시(string sWare, string sProd, string sDay)
        {
            string str = "0";
            try
            {
                System.Data.DataTable dataTable = new wnDm().fn_상품창고별재고_Summary(sWare, sProd, sDay, Common.p_strConn);
                if (dataTable != null && dataTable.Rows.Count > 0)
                    str = dataTable.Rows[0]["현재고표시"].ToString();
            }
            catch (Exception ex)
            {
                wnLog.writeLog(100, ex.Message + " - " + ex.ToString());
            }
            return str;
        }

        public bool isValidBizNo(string biz_no)
        {
            biz_no = biz_no.Replace("-", "");
            if (biz_no.Length != 10)
                return false;
            int num = 0;
            int[] numArray1 = new int[10];
            int[] numArray2 = new int[9]
            {
        1,
        3,
        7,
        1,
        3,
        7,
        1,
        3,
        5
            };
            for (int index = 0; index < 10; ++index)
                numArray1[index] = Convert.ToInt32(biz_no[index].ToString());
            for (int index = 0; index < 9; ++index)
                num += numArray1[index] * numArray2[index];
            return (10 - (num + numArray1[8] * 5 / 10) % 10) % 10 == numArray1[9];
        }

       

        private static void ReleaseExcel(object obj)
        {
            try
            {
                if (obj == null)
                    return;
                Marshal.FinalReleaseComObject(obj);
                obj = (object)null;
            }
            catch (Exception ex)
            {
                obj = (object)null;
                throw ex;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        

        public DataGridView Copy_DataGirdView(
          DataGridView grd,
          int nStartRow,
          int nEndRow,
          int nFile_Rows)
        {
            DataGridView dataGridView = new DataGridView();
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            foreach (DataGridViewBand column in (BaseCollection)grd.Columns)
            {
                DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)column.Clone();
                dataGridView.Columns.Add(dataGridViewColumn);
            }
            dataGridView.RowCount = nFile_Rows;
            int index1 = 0;
            for (int index2 = nStartRow; index2 < nEndRow; ++index2)
            {
                for (int index3 = 0; index3 < grd.Columns.Count; ++index3)
                {
                    if (grd.Rows[index2].Cells[index3].Value != null)
                    {
                        try
                        {
                            dataGridView.Rows[index1].Cells[index3].Value = grd.Rows[index2].Cells[index3].Value;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                ++index1;
            }
            return dataGridView;
        }
    }
}
