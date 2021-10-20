using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testc
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void butclose_Click(object sender, EventArgs e)
        {   
                Form1 showForm1 = new Form1();
                showForm1.Show();
        }
    }
}
