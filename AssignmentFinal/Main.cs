using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentFinal
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form1 = new DMMonHoc();
            form1.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form1 = new DMKetQua();
            form1.Show();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form1 = new DMKhoa();
            form1.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
         
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form1 = new DMKhoa();
            form1.Show();
        }

        private void mônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form1 = new DMMonHoc();
            form1.Show();
        }
    }
}
