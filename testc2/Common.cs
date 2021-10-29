// Decompiled with JetBrains decompiler
// Type: smartMain.Common
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace smartMain
{
    public class Common
    {
        public static string p_strProgName = "장터지기";
        public static string p_strVer = "";
        public static string p_strRoot = "";
        public static string p_strRootName = "";
        public static int nStatus_LANG = 0;
        public static string p_strIPaddress = "";
        public static string p_strMacAddr = "";
        public static string p_strMacSerial = "";
        public static string p_strUserNo = "";
        public static string p_strUserID = "";
        public static string p_strUserPW = "";
        public static string p_strUserName = "";
        public static string p_strUserAdmin = "";
        public static string p_strCompNo = "";
        public static string p_strCompID = "";
        public static string p_strCompName = "";
        public static string p_strCEO = "";
        public static string p_strUptae = "";
        public static string p_strJong = "";
        public static string p_strZip = "";
        public static string p_strAddr1 = "";
        public static string p_strAddr2 = "";
        public static string p_strEmail = "";
        public static string p_strTel = "";
        public static string p_strFax = "";
        public static string p_strHome = "";
        public static string p_PopSheetPrint = "";
        public static string p_PopPresPrint = "";
        public static string p_PopBuyPrint = "";
        public static string p_PageSize = "";
        public static string p_AutoCust = "N";
        public static string p_AutoProd = "N";
        public static string p_AutoCustCode = "";
        public static string p_AutoProdCode = "";
        public static string p_AutoCustLength = "";
        public static string p_AutoProdLength = "";
        public static string p_SheetBarcode = "";
        public static string p_SheetBarcodeOnly = "";
        public static string p_SheetVAT = "";
        public static string p_SheetSpecial = "";
        public static string p_SheetNo = "";
        public static string p_SheetNoSel = "";
        public static bool p_SheetResMoney = true;
        public static string p_InternetXLS = "";
        public static string p_MaeChoolMoney = "";
        public static string p_AutoSaleTime = "";
        public static string p_SaleNoDupl = "";
        public static string p_CalcVAT = "";
        public static string p_ProdUnitAll = "";
        public static string p_ViewVisitor = "";
        public static string p_NewLastSheet = "";
        public static string p_ProdAmtYN = "";
        public static string p_BankNo = "";
        public static string p_MoneyYN = "";
        public static string p_BoxAmtYN = "";
        public static string p_OnlyEaUnitYN = "";
        public static string p_strSpotYN = "N";
        public static string p_strSpotCode = "0";
        public static string p_strFormatAmount = "#,0";
        public static string p_strFlag_Amount = "N";
        public static string p_strFormatUnit = "#,0";
        public static string p_strFlag_Unit = "N";
        public static string p_strEgg = "N";
        public static string p_strNoVAT = "N";
        public static string p_strBox = "3";
        public static string p_strBoxMiddle = "N";
        public static string p_strConn = "";
        public static string p_strEgg박스 = "판";
        public static string p_strEgg중간 = " ";
        public static string p_strEgg낱개 = "알";
        public static string p_strEgg서비스 = "서비스";
        public static string p_strTaxProd = "";
        public static string p_Refresh = "0";
        public static string p_Menu01 = "Y";
        public static string p_Menu02 = "Y";
        public static string p_Menu03 = "Y";
        public static string p_Menu04 = "Y";
        public static string p_Menu05 = "Y";
        public static string p_Menu06 = "Y";
        public static string p_Menu07 = "Y";
        public static string p_Menu08 = "Y";
        public static string p_Menu09 = "Y";
        public static string p_strViewInnPrice = "N";
        public static string p_strVisitAll = "N";
        public static string p_strResultAll = "N";
        public static string p_strUnitMod = "N";
        public static string p_strDayMod = "N";
        public static string p_strDayModPrev = "N";
        public static string p_strDayModNext = "N";
        public static string p_strConnMain = "DATA SOURCE = 218.38.14.33,14332;INITIAL CATALOG = smartSales_Public;PERSIST SECURITY INFO = false;USER ID = smartuser;PASSWORD = wkdxj2017!@;";
        public static string p_strConnOld = "DATA SOURCE = 218.38.14.34,14332;INITIAL CATALOG = {구디비};PERSIST SECURITY INFO = false;USER ID = smuser;PASSWORD = wkdxj2017!@;";

        public static bool isNum(string txt)
        {
            txt.Trim();
            return Regex.IsMatch(txt.Trim(), "^[0-9]+$");
        }

        public static bool isNumFloat(string txt)
        {
            txt.Trim();
            try
            {
                float.Parse(txt.Trim());
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static string GetKeyStringbyKeys(Keys keys)
        {
            switch (keys)
            {
                case Keys.Back:
                    return "{BKSP}";
                case Keys.Tab:
                    return "{TAB}";
                case Keys.Return:
                    return "~";
                case Keys.Pause:
                    return "{BREAK}";
                case Keys.Capital:
                    return "{CAPSLOCK}";
                case Keys.Escape:
                    return "{ESC}";
                case Keys.Prior:
                    return "{PGUP}";
                case Keys.Next:
                    return "{PGDN}";
                case Keys.End:
                    return "{END}";
                case Keys.Home:
                    return "{HOME}";
                case Keys.Left:
                    return "{LEFT}";
                case Keys.Up:
                    return "{UP}";
                case Keys.Right:
                    return "{RIGHT}";
                case Keys.Down:
                    return "{DOWN}";
                case Keys.Snapshot:
                    return "{PRTSC}";
                case Keys.Insert:
                    return "{INSERT}";
                case Keys.Delete:
                    return "{DEL}";
                case Keys.Help:
                    return "{HELP}";
                case Keys.A:
                    return "A";
                case Keys.B:
                    return "B";
                case Keys.C:
                    return "C";
                case Keys.D:
                    return "D";
                case Keys.E:
                    return "E";
                case Keys.F:
                    return "F";
                case Keys.G:
                    return "G";
                case Keys.H:
                    return "H";
                case Keys.I:
                    return "I";
                case Keys.J:
                    return "J";
                case Keys.K:
                    return "K";
                case Keys.L:
                    return "L";
                case Keys.M:
                    return "M";
                case Keys.N:
                    return "N";
                case Keys.O:
                    return "O";
                case Keys.P:
                    return "P";
                case Keys.Q:
                    return "Q";
                case Keys.R:
                    return "R";
                case Keys.S:
                    return "S";
                case Keys.T:
                    return "T";
                case Keys.U:
                    return "U";
                case Keys.V:
                    return "V";
                case Keys.W:
                    return "W";
                case Keys.X:
                    return "X";
                case Keys.Y:
                    return "Y";
                case Keys.Z:
                    return "Z";
                case Keys.Multiply:
                    return "{MULTIPLY}";
                case Keys.Add:
                    return "{ADD}";
                case Keys.Subtract:
                    return "{SUBTRACT}";
                case Keys.Divide:
                    return "{DIVIDE}";
                case Keys.F1:
                    return "{F1}";
                case Keys.F2:
                    return "{F2}";
                case Keys.F3:
                    return "{F3}";
                case Keys.F4:
                    return "{F4}";
                case Keys.F5:
                    return "{F5}";
                case Keys.F6:
                    return "{F6}";
                case Keys.F7:
                    return "{F7}";
                case Keys.F8:
                    return "{F8}";
                case Keys.F9:
                    return "{F9}";
                case Keys.F10:
                    return "{F10}";
                case Keys.F11:
                    return "{F11}";
                case Keys.F12:
                    return "{F12}";
                case Keys.Scroll:
                    return "{SCROLLLOCK}";
                case Keys.Shift:
                    return "*";
                case Keys.Control:
                    return "^";
                case Keys.Alt:
                    return "%";
                default:
                    return "";
            }
        }
    }
}
