// Decompiled with JetBrains decompiler
// Type: smartMain.Controls.conTextNumber
// Assembly: smartMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D2CC3615-8674-4A2E-AE78-B541A9F4EDDB
// Assembly location: E:\Work\smart 장터지기\smartMain.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace smartMain.Controls
{
    [ToolboxBitmap(typeof(TextBox))]
    public class conTextNumber : TextBox
    {
        private Color saveBackColor = Color.White;
        private Color focusedBackColor = Color.White;
        private Color borderColor = Color.White;
        private string formatString = "#,0";
        private string valueType = "수량";
        private string waterMarkText = string.Empty;
        private Color waterMarkColor = Color.Gray;
        private static int WM_PAINT = 15;

        private void conTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            SendKeys.SendWait("{tab}");
        }

        private void conTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                e.Handled = true;
            bool includePoint = false;
            if (this.formatString.IndexOf('.') > -1)
                includePoint = true;
            conTextNumber.TypingOnlyNumber(sender, e, includePoint, true);
        }

        private static void TypingOnlyNumber(
          object sender,
          KeyPressEventArgs e,
          bool includePoint,
          bool includeMinus)
        {
            bool flag = false;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                if (includePoint && e.KeyChar == '.')
                    flag = true;
                if (includeMinus && e.KeyChar == '-')
                    flag = true;
                if (!flag)
                    e.Handled = true;
            }
            if (includePoint && e.KeyChar == '.' && (string.IsNullOrEmpty((sender as TextBox).Text.Trim()) || (sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
            if (!includeMinus || e.KeyChar != '-' || (sender as TextBox).Text.IndexOf('-') >= 1 || (sender as TextBox).SelectionLength != 0 || string.IsNullOrEmpty((sender as TextBox).Text.Trim()))
                return;
            e.Handled = true;
            if ((sender as TextBox).Text.Trim() == "-")
                (sender as TextBox).Text = "";
            else
                (sender as TextBox).Text = (double.Parse((sender as TextBox).Text.Trim()) * -1.0).ToString();
        }

        [Description("입력모드의 배경색을 지정하세요.")]
        [Category("con 모양 설정")]
        [Browsable(true)]
        public Color _FocusedBackColor
        {
            get => this.focusedBackColor;
            set => this.focusedBackColor = value;
        }

        [Category("con 모양 설정")]
        [Browsable(true)]
        [Description("테두리 색을 지정하세요.")]
        public Color _BorderColor
        {
            get => this.borderColor;
            set => this.borderColor = value;
        }

        [Browsable(true)]
        [Category("con 모양 설정")]
        [Description("숫자 형식을 입력하세요.")]
        public string _FormatString
        {
            get => this.formatString;
            set => this.formatString = value;
        }

        [Browsable(true)]
        [Category("con 모양 설정")]
        [Description("값의 특성(수량, 단가)을 입력하세요.")]
        public string _ValueType
        {
            get => this.valueType;
            set => this.valueType = value;
        }

        [Category("con 모양 설정")]
        [Browsable(true)]
        [Description("배경글을 입력하세요.")]
        public string _WaterMarkText
        {
            get => this.waterMarkText;
            set => this.waterMarkText = value;
        }

        public Color _WaterMarkColor
        {
            get => this.waterMarkColor;
            set => this.waterMarkColor = value;
        }

        public conTextNumber()
        {
            this.saveBackColor = this.BackColor;
            this.AutoSize = false;
            this.TextAlign = HorizontalAlignment.Right;
            this.KeyPress += new KeyPressEventHandler(this.conTextBox_KeyPress);
            this.KeyDown += new KeyEventHandler(this.conTextBox_KeyDown);
        }

        protected override void WndProc(ref Message m)
        {
            bool flag = false;
            if (m.Msg == 15)
            {
                base.WndProc(ref m);
                flag = true;
                if (m.Msg == conTextNumber.WM_PAINT)
                {
                    Graphics graphics = Graphics.FromHwnd(this.Handle);
                    Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
                    ControlPaint.DrawBorder(graphics, bounds, this.borderColor, ButtonBorderStyle.Solid);
                    graphics.Dispose();
                }
                this.DrawWaterMarkText();
            }
            else if (m.Msg == 8 && this.Multiline)
                this.DrawWaterMarkText();
            if (flag)
                return;
            base.WndProc(ref m);
        }

        private void DrawWaterMarkText()
        {
            if (!string.IsNullOrEmpty(this.Text) || string.IsNullOrEmpty(this._WaterMarkText) || !this.IsHandleCreated || this.Focused || !this.Visible)
                return;
            using (Graphics graphics = Graphics.FromHwnd(this.Handle))
            {
                StringFormat format = new StringFormat();
                float y = (float)(((double)this.Height - (double)graphics.MeasureString(this._WaterMarkText, this.Font, this.Width, format).Height) / 2.0);
                RectangleF layoutRectangle = new RectangleF(0.0f, y, (float)this.Width, (float)this.Height - y * 2f);
                graphics.DrawString(this._WaterMarkText, this.Font, (Brush)new SolidBrush(this._WaterMarkColor), layoutRectangle, format);
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            this.ImeMode = ImeMode.Inherit;
            this.saveBackColor = this.BackColor;
            this.BackColor = this.focusedBackColor;
            this.Text = this.Text.Replace(",", "");
            this.Select(0, this.Text.Length);
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = this.saveBackColor;
            if (this.Text.Trim() == "" || this.Text.Trim() == "-")
                this.Text = "0";
            int length = 0;
            if (this.formatString.IndexOf('.') > -1)
                length = this.formatString.Length - this.formatString.IndexOf('.') - 1;
            if (this.Text.IndexOf('.') > -1)
            {
                string text = this.Text;
                if (text.Length - text.IndexOf('.') - 1 > length)
                {
                    this.Text = text.Substring(0, text.IndexOf('.') + 1);
                    this.Text += text.Substring(text.IndexOf('.') + 1, length);
                }
            }
            this.Text = double.Parse(this.Text).ToString(this.formatString);
            base.OnLeave(e);
        }
    }
}
