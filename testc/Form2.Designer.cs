﻿
namespace testc
{
    partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.butSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GridRecord = new System.Windows.Forms.DataGridView();
            this.코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.명칭 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비고 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butclose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butSave = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "거래처유형";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // butSearch
            // 
            this.butSearch.Location = new System.Drawing.Point(651, 48);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(75, 23);
            this.butSearch.TabIndex = 1;
            this.butSearch.Text = "찾기";
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(124, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(277, 23);
            this.textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(124, 94);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(277, 23);
            this.textBox3.TabIndex = 4;
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputLast_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "코드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "명칭";
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
            this.GridRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.코드,
            this.명칭,
            this.비고});
            this.GridRecord.Location = new System.Drawing.Point(443, 77);
            this.GridRecord.Name = "GridRecord";
            this.GridRecord.RowHeadersVisible = false;
            this.GridRecord.RowTemplate.Height = 25;
            this.GridRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridRecord.Size = new System.Drawing.Size(345, 165);
            this.GridRecord.TabIndex = 7;
            this.GridRecord.DoubleClick += new System.EventHandler(this.GridRecord_DoubleClick);
            // 
            // 코드
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.코드.DefaultCellStyle = dataGridViewCellStyle1;
            this.코드.HeaderText = "코드";
            this.코드.Name = "코드";
            // 
            // 명칭
            // 
            this.명칭.HeaderText = "명칭";
            this.명칭.Name = "명칭";
            // 
            // 비고
            // 
            this.비고.HeaderText = "비고";
            this.비고.Name = "비고";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(466, 48);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(179, 23);
            this.textBox4.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "분류코드 등록";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "비고";
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(713, 1);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(75, 23);
            this.butclose.TabIndex = 11;
            this.butclose.Text = "닫기";
            this.butclose.UseVisualStyleBackColor = true;
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(2, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 138);
            this.panel1.TabIndex = 12;
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(632, 1);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 13;
            this.butSave.Text = "저장";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(551, 1);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(75, 23);
            this.butNew.TabIndex = 14;
            this.butNew.Text = "신규";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(466, 1);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(75, 23);
            this.butDelete.TabIndex = 15;
            this.butDelete.Text = "삭제";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butNew);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butclose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.GridRecord);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.GridRecord)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView GridRecord;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn 코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 명칭;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비고;
    }
}