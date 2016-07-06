using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AssignmentFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionstring = @"workstation id=QuanliSV.mssql.somee.com;packet size=4096;user id=mylhps03856_SQLLogin_1;pwd=aqpy1r5nui;data source=QuanliSV.mssql.somee.com;persist security info=False;initial catalog=QuanliSV";
        private void btnxem_Click(object sender, EventArgs e)
        {
            //string query = "select * From dbo.DMSV";
            //dgv.DataSource =classdata.Instance.excutequery(query);
            UserBUS.Instance.Xem(dgv);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            
            if (UserBUS.Instance.them(dgv))
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
            //MessageBox.Show(classdata.Instance.excutenonquery("delete from DMSV Where MaSV ='7'").ToString());
            if (UserBUS.Instance.xoamotruong(dgv)) 
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
            if (UserBUS.Instance.sua(dgv))
            {
                MessageBox.Show("Sua Thanh Cong");
                btnxem_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Sua Khong Thanh Cong");
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            //string query = "select * From dbo.DMSV where Masv like @MaSV";
            //object[] paramete = new object[] { txttimkiem.Text };
            //dgv.DataSource =classdata.Instance.excutequery(query,paramete);
            UserBUS.Instance.timkiem(dgv, txttimkiem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserBUS.Instance.Xem(dgv);
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //comboBox1.DataSource = UserDAO.Instance.xem();
            //comboBox1.DisplayMember = "TenSV";
            string s = "1234567890";
            string a = s.Substring(9);
            int m = int.Parse(a) + 1;
            MessageBox.Show(m.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        
    }
}
