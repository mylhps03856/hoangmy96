using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentFinal
{
    class UserBUS
    {
        private static UserBUS instance;

       public static UserBUS Instance
       {
           get 
           { 
               if (instance == null)
               {
                   instance = new UserBUS();
               }
               return instance; 
           }
           //set { classdata.instance = value; }
       }
           //thực hiện load và tìm kiếm
       private UserBUS() { }
        public void Xem(DataGridView data)
        {
            data.DataSource = UserDAO.Instance.xem();
        }
        public void xemketqua(DataGridView data)
        {
            data.DataSource = UserDAO.Instance.xemketqua();
        }
        public void xemkhoa(DataGridView data)
        {
            data.DataSource = UserDAO.Instance.xemkhoa();
        }
        public void xemmonhoc(DataGridView data)
        {
            data.DataSource = UserDAO.Instance.xemmonhoc();
        }
        public void timkiem(DataGridView data,TextBox textbox)
        {
            data.DataSource = UserDAO.Instance.timkiem(textbox);
        }
        public bool xoamotruong(DataGridView data)
        {
            String masv = data.SelectedCells[0].OwningRow.Cells["MaSV"].Value.ToString();
            return UserDAO.Instance.Xoamottruong(masv);
        }
        public bool xoamottruongketqua(DataGridView data)
        {
            String masv = data.SelectedCells[0].OwningRow.Cells["MaSV"].Value.ToString();
            String mamh = data.SelectedCells[0].OwningRow.Cells["MaMH"].Value.ToString();
            return UserDAO.Instance.Xoamottruongketqua(masv, mamh);
        }
        public bool xoamotkhoa(DataGridView data)
        {
            String makhoa = data.SelectedCells[0].OwningRow.Cells["MaKhoa"].Value.ToString();
            return UserDAO.Instance.Xoamotkhoa(makhoa);
        }
        public bool xoamonhoc(DataGridView data)
        {
            String mamh = data.SelectedCells[0].OwningRow.Cells["MaMH"].Value.ToString();
            return UserDAO.Instance.Xoamonhoc(mamh);
        }
        public bool sua(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            string oldid = row.Cells["MaSV"].Value.ToString();
            string id = row.Cells["MaSV"].Value.ToString();
            string hosv = row.Cells["HoSV"].Value.ToString();
            string tensv = row.Cells["TenSV"].Value.ToString();
            string phai = row.Cells["Phai"].Value.ToString();
            DateTime ngaysinh = ((DateTime)row.Cells["NgaySinh"].Value);
            string noisinh = row.Cells["NoiSinh"].Value.ToString();
            string makhoa = row.Cells["MaKhoa"].Value.ToString();
            float hocbong = float.Parse(row.Cells["HocBong"].Value.ToString());
            UserDTO user = new UserDTO() { Id = id, Hosv = hosv, Tensv = tensv, Phai = phai, Ngaysinh = ngaysinh, Noisinh = noisinh, Makhoa = makhoa , Hocbong = hocbong };

            return UserDAO.Instance.sua(oldid, user);

           
        }
        public bool suaketqua(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            string oldid = row.Cells["MaSV"].Value.ToString();
            string id = row.Cells["MaSV"].Value.ToString();
            string mamh = row.Cells["MaMH"].Value.ToString();
            int lanthi = int.Parse(row.Cells["LanThi"].Value.ToString());
            decimal diem = decimal.Parse(row.Cells["Diem"].Value.ToString());
            UserDTO user = new UserDTO() { Id = id , Mamh = mamh , Lanthi = lanthi , Diem = diem };
            return UserDAO.Instance.suaketqua(oldid, user);


        }
        public bool suakhoa(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            string oldmakhoa = row.Cells["MaKhoa"].Value.ToString();
            string makhoa = row.Cells["MaKhoa"].Value.ToString();
            string tenkhoa = row.Cells["TenKhoa"].Value.ToString();           
            UserDTO user = new UserDTO() { Makhoa = makhoa , Tenkhoa = tenkhoa };
           return UserDAO.Instance.suakhoa(oldmakhoa, user);


        }
        public bool suamonhoc(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            string oldmamh = row.Cells["MaMH"].Value.ToString();
            string mamh = row.Cells["MaMH"].Value.ToString();
            string tenmh = row.Cells["TenMH"].Value.ToString();
            int sotiet = int.Parse(row.Cells["SoTiet"].Value.ToString());
            
            UserDTO user = new UserDTO() { Mamh = mamh , Tenmh = tenmh , Sotiet = sotiet };
            return UserDAO.Instance.suamonhoc(oldmamh, user);


        }
        public bool them(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            string id = row.Cells["MaSV"].Value.ToString();
            string hosv = row.Cells["HoSV"].Value.ToString();
            string tensv = row.Cells["TenSV"].Value.ToString();
            string phai = row.Cells["Phai"].Value.ToString();
            DateTime ngaysinh = new DateTime(1900,1,1);  // 1900/1/1 là rỗng đối với kiểu datetime
            try
            {
                ngaysinh = ((DateTime)row.Cells["NgaySinh"].Value);
            }
            catch{}
            string makhoa = "AV";
            try
            {
                makhoa = row.Cells["MaKhoa"].Value.ToString();
            }
            catch { }
            string noisinh = row.Cells["NoiSinh"].Value.ToString();
            

            float hocbong = 0;
            try 
            {
                hocbong = float.Parse(row.Cells["HocBong"].Value.ToString());   
            }
            catch { }
                
            UserDTO user = new UserDTO() { Id = id, Hosv = hosv, Tensv = tensv, Phai = phai, Ngaysinh = ngaysinh, Noisinh = noisinh, Makhoa = makhoa, Hocbong = hocbong };

            return UserDAO.Instance.them(user);


        }
        public bool themketqua(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            string id = row.Cells["MaSV"].Value.ToString();
            string mamh = row.Cells["MaMH"].Value.ToString();
            int lanthi = (int)row.Cells["LanThi"].Value;
            decimal diem = 0;
            try
            {
                diem = decimal.Parse(row.Cells["Diem"].Value.ToString());
            }
            catch { }

            UserDTO user = new UserDTO() { Id =id , Mamh = mamh , Lanthi = lanthi , Diem = diem };

            return UserDAO.Instance.themketqua(user);
        }
        public bool themkhoa(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            string makhoa = row.Cells["MaKhoa"].Value.ToString();
            string tenkhoa = row.Cells["TenKhoa"].Value.ToString();
            UserDTO user = new UserDTO() { Makhoa=makhoa , Tenkhoa = tenkhoa };

            return UserDAO.Instance.themkhoa(user);
        }
        public bool themmonhoc(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            string mamh = row.Cells["MaMH"].Value.ToString();
            string tenmon = row.Cells["TenMH"].Value.ToString();
            int sotiet = int.Parse(row.Cells["SoTiet"].Value.ToString());
            UserDTO user = new UserDTO() { Mamh = mamh, Tenmh = tenmon , Sotiet = sotiet };

            return UserDAO.Instance.themmonhoc(user);
        }

    }
}
