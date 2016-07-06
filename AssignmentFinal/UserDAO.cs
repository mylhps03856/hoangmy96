using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentFinal
{
    class UserDAO
    {
        private static UserDAO instance;

       public static UserDAO Instance
       {
           get 
           { 
               if (instance == null)
               {
                   instance = new UserDAO();
               }
               return instance; 
           }
           //set { classdata.instance = value; }
       }
           //thực hiện load và tìm kiếm
       private UserDAO() { }
        public DataTable xem()
       {
           string query = "select * From dbo.DMSV";
           return classdata.Instance.excutequery(query);
       }
        public DataTable xemketqua()
        {
            String query = "select * from dbo.KetQua";
            return classdata.Instance.excutequery(query);
        }
        public DataTable xemkhoa()
        {
            String query = "select * from dbo.DMKhoa";
            return classdata.Instance.excutequery(query);
        }
        public DataTable xemmonhoc()
        {
            string query = "select * From dbo.DMMH";
            return classdata.Instance.excutequery(query);
        }
        public DataTable timkiem(TextBox textbox)
        {
            object[] parameter = new object[] { textbox.Text };
            string query = "select * From dbo.DMSV where Masv like '@MaSV%'";
            return classdata.Instance.excutequery(query, parameter);
        }
        public bool Xoamottruong(string masv)
        {
            string query = "Delete from DMSV where MaSV = @Masv";
            object[] para = new object[] { masv };
            if (classdata.Instance.excutenonquery(query, para) > 0)
                return true;
            return false;
        }
        public bool Xoamottruongketqua(string masv,string mamh)
        {
            string query = "Delete from KetQua where MaSV = @Masv and MaMH = @Mamh ";
            object[] para = new object[] { masv,mamh};
            if (classdata.Instance.excutenonquery(query, para) > 0)
                return true;
            return false;
        }
        public bool Xoamotkhoa(string makhoa)
        {
            string query = "Delete from DMKhoa where Makhoa = @Makhoa";
            object[] para = new object[] { makhoa };
            if (classdata.Instance.excutenonquery(query, para) > 0)
                return true;
            return false;
        }
        public bool Xoamonhoc(string mamh)
        {
            string query = "Delete from DMMH where MaMH = @Mamh";
            object[] para = new object[] { mamh };
            if (classdata.Instance.excutenonquery(query, para) > 0)
                return true;
            return false;
        }
        //Sua truong nao co ID tuong ung
        public bool sua(string id, UserDTO user)
        {
            string query = "update DMSV set HoSV = @Hosv , TenSV = @Tensv , Phai = @Phai , NgaySinh = @Ngaysinh , NoiSinh = @Noisinh , MaKhoa = @Makhoa , HocBong = @HocBong where MaSV = @oldid";
            object[] para = new object[] {user.Hosv, user.Tensv, user.Phai, user.Ngaysinh, user.Noisinh, user.Makhoa, user.Hocbong, id };
            if (classdata.Instance.excutenonquery(query,para) > 0) 
                return true;
            
            return false;

            
        }
        public bool suaketqua(string id, UserDTO user)
        {
            string query = "update KetQua set MaMH = @Mamh , LanThi = @Lanthi , Diem = @Diem where MaSV = @oldid";
            object[] para = new object[] { user.Mamh, user.Lanthi, user.Diem, id };
            if (classdata.Instance.excutenonquery(query, para) > 0)
                return true;

            return false;


        }
        public bool suamonhoc(string mamh, UserDTO user)
        {
            string query = "update DMMH set MaMH = @Mamh , TenMH = @tenmh , Sotiet = @sotiet where MaMH = @oldmamh";
            object[] para = new object[] { user.Mamh , user.Tenmh , user.Sotiet , mamh };
            if (classdata.Instance.excutenonquery(query, para) > 0)
                return true;

            return false;


        }
        public bool suakhoa(string makhoa, UserDTO user)
        {
            string query = "update DMKhoa set MaKhoa = @Makhoa , TenKhoa = @Tenkhoa where MaKhoa = @oldmakhoa";
            object[] para = new object[] { user.Makhoa, user.Tenkhoa , makhoa  };
            if (classdata.Instance.excutenonquery(query, para) > 0)
                return true;

            return false;


        }
        public bool them(UserDTO user)
        {
            string query = "insert into DMSV Values( @MaSV , @Hosv , @Tensv , @Phai , @Ngaysinh , @Noisinh , @Makhoa , @HocBong )";
            if (kiemtraIDtontai(user.Id))
            {
                //string n = "1234567890";
                //string m = n.Substring(0, 3);
                string m = timmaxid().ToString();
                string n = m.Substring(0, 3);
                string s = timmaxid().ToString();
                string a = s.Substring(3);
                int h = int.Parse(a) + 1;
                user.Id = (n + h).ToString();
                
            }
            object[] para = null;

            para = new object[] {user.Id, user.Hosv, user.Tensv, user.Phai, user.Ngaysinh, user.Noisinh, user.Makhoa, user.Hocbong };
            if (classdata.Instance.excutenonquery(query, para) > 0)
                return true;

            return false;
        }
        bool kiemtraIDtontai(string id)
        {
            string query = "Select * from DMSV where MaSV = @Masv";
            object[] para = new object[] { id };
            if (classdata.Instance.excutequery(query, para).Rows.Count > 0)
                return true;

            return false;
        }

        //bool checkIDTonTai(string ID)
        //{
        //    string query = "select ID from Users where ID = @ID";

        //    object[] para = new object[] { ID };

        //    if (DataProvider.Instance.ExecuteQuery(query, para).Rows.Count > 0)
        //        return true;

        //    return false;
        //}
        public string timmaxid()
        {
            string query = "select MAX(MaSV) From dbo.DMSV";
            return classdata.Instance.ExcuteScalar(query).ToString();
        }
        //public int TimMaxID()
        //{
        //    string query = "SELECT Max(ID) from Users";

        //    return Int32.Parse((string)DataProvider.Instance.ExecuteScalar(query));
        //}
        public bool themketqua(UserDTO user)
        {
            string query = "insert into KetQua Values( @Masv , @Mamh , @Lanthi , @Diem )";
          
            object[] para = null;
            para = new object[] { user.Id, user.Mamh, user.Lanthi , user.Diem };
            if (classdata.Instance.excutenonquery(query, para) > 0)
                return true;

            return false;
        }
        public bool themkhoa(UserDTO user)
        {
            string query = "insert into DMKhoa Values ( @MaKhoa , @TenKhoa )";
            
            object[] para = null;
            para = new object[] { user.Makhoa,user.Tenkhoa };
            if (classdata.Instance.excutenonquery(query, para) > 0)
                return true;

            return false;
        }
        public bool themmonhoc(UserDTO user)
        {
            string query = "insert into DMMH Values ( @MaMon , @TenMon , @SoTiet )";

            object[] para = null;
            para = new object[] { user.Mamh, user.Tenmh, user.Sotiet };
            if (classdata.Instance.excutenonquery(query, para) > 0)
                return true;

            return false;
        }
    }

}
