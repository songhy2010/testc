
namespace testc2
{
    partial class uc매출처변상품단가복사
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
            this.label1 = new System.Windows.Forms.Label();
            this.butSearch = new System.Windows.Forms.Button();
            this.GridRecord = new System.Windows.Forms.DataGridView();
            this.코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.상품 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.규격 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.최종단가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수정단가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbs사입품 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.txt코드 = new System.Windows.Forms.TextBox();
            this.txt코드old = new System.Windows.Forms.TextBox();
            this.txts거래처코드 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "원본 매출처";
            // 
            // butSearch
            // 
            this.butSearch.Location = new System.Drawing.Point(378, 22);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(75, 23);
            this.butSearch.TabIndex = 3;
            this.butSearch.Text = "찾기";
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // GridRecord
            // 
            this.GridRecord.AllowUserToAddRows = false;
            this.GridRecord.AllowUserToDeleteRows = false;
            this.GridRecord.AllowUserToOrderColumns = true;
            this.GridRecord.AllowUserToResizeRows = false;
            this.GridRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GridRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridRecord.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.코드,
            this.상품,
            this.규격,
            this.최종단가,
            this.수정단가});
            this.GridRecord.EnableHeadersVisualStyles = false;
            this.GridRecord.Location = new System.Drawing.Point(12, 62);
            this.GridRecord.Name = "GridRecord";
            this.GridRecord.RowHeadersVisible = false;
            this.GridRecord.RowTemplate.Height = 25;
            this.GridRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridRecord.Size = new System.Drawing.Size(684, 570);
            this.GridRecord.TabIndex = 4;
            // 
            // 코드
            // 
            this.코드.FillWeight = 30F;
            this.코드.HeaderText = "코드";
            this.코드.MinimumWidth = 30;
            this.코드.Name = "코드";
            this.코드.ReadOnly = true;
            // 
            // 상품
            // 
            this.상품.FillWeight = 58.24826F;
            this.상품.HeaderText = "상품";
            this.상품.MinimumWidth = 70;
            this.상품.Name = "상품";
            this.상품.ReadOnly = true;
            // 
            // 규격
            // 
            this.규격.FillWeight = 55F;
            this.규격.HeaderText = "규격";
            this.규격.MinimumWidth = 55;
            this.규격.Name = "규격";
            this.규격.ReadOnly = true;
            // 
            // 최종단가
            // 
            this.최종단가.FillWeight = 45F;
            this.최종단가.HeaderText = "최종단가";
            this.최종단가.MinimumWidth = 45;
            this.최종단가.Name = "최종단가";
            this.최종단가.ReadOnly = true;
            // 
            // 수정단가
            // 
            this.수정단가.FillWeight = 45F;
            this.수정단가.HeaderText = "수정단가";
            this.수정단가.MinimumWidth = 45;
            this.수정단가.Name = "수정단가";
            this.수정단가.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 23);
            this.textBox1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(233, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "▼";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cmbs사입품
            // 
            this.cmbs사입품.FormattingEnabled = true;
            this.cmbs사입품.Location = new System.Drawing.Point(282, 22);
            this.cmbs사입품.Name = "cmbs사입품";
            this.cmbs사입품.Size = new System.Drawing.Size(90, 23);
            this.cmbs사입품.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1007, 86);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "▼";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(861, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(149, 23);
            this.textBox2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(784, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "대상 매출처";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(1066, 86);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 11;
            this.btnCopy.Text = "복사";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(784, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "* 상품별 최종단가를 아래 매출처에 복사";
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(620, 636);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 13;
            this.butSave.Text = "수정저장";
            this.butSave.UseVisualStyleBackColor = true;
            // 
            // txt코드
            // 
            this.txt코드.Location = new System.Drawing.Point(910, 86);
            this.txt코드.Name = "txt코드";
            this.txt코드.Size = new System.Drawing.Size(29, 23);
            this.txt코드.TabIndex = 14;
            // 
            // txt코드old
            // 
            this.txt코드old.Location = new System.Drawing.Point(958, 86);
            this.txt코드old.Name = "txt코드old";
            this.txt코드old.Size = new System.Drawing.Size(29, 23);
            this.txt코드old.TabIndex = 15;
            // 
            // txts거래처코드
            // 
            this.txts거래처코드.Location = new System.Drawing.Point(141, 21);
            this.txts거래처코드.Name = "txts거래처코드";
            this.txts거래처코드.Size = new System.Drawing.Size(41, 23);
            this.txts거래처코드.TabIndex = 16;
            // 
            // uc매출처변상품단가복사
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 671);
            this.Controls.Add(this.txts거래처코드);
            this.Controls.Add(this.txt코드old);
            this.Controls.Add(this.txt코드);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.cmbs사입품);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GridRecord);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.label1);
            this.Name = "uc매출처변상품단가복사";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.DataGridView GridRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn 코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 상품;
        private System.Windows.Forms.DataGridViewTextBoxColumn 규격;
        private System.Windows.Forms.DataGridViewTextBoxColumn 최종단가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 수정단가;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbs사입품;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.TextBox txt코드;
        private System.Windows.Forms.TextBox txt코드old;
        private System.Windows.Forms.TextBox txts거래처코드;
    }
}