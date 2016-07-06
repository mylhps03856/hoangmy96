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
    public partial class DMKetQua : Form
    {
        public DMKetQua()
        {
            InitializeComponent();
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            UserBUS.Instance.xemketqua(dgv);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (UserBUS.Instance.themketqua(dgv))
            {
                MessageBox.Show("Them Thanh Cong");
                btnxem_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Them Khong Thanh Cong");
            }
            
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (UserBUS.Instance.xoamottruongketqua(dgv))
            {
                MessageBox.Show("Xoa Thanh Cong");
                btnxem_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Xoa Khong Thanh Cong");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            if (UserBUS.Instance.suaketqua(dgv))
            {
                MessageBox.Show("Sua Thanh Cong");
                btnxem_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Sua Khong Thanh Cong");
            }
        }

        private void DMKetQua_Load(object sender, EventArgs e)
        {
            UserBUS.Instance.xemketqua(dgv);
        }

        
    }
}
