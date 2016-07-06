using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFinal
{
   public class classdata
   {
       private static classdata instance;

       public static classdata Instance
       {
           get 
           { 
               if (instance == null)
               {
                   instance = new classdata();
               }
               return classdata.instance; 
           }
           //set { classdata.instance = value; }
       }
           //thực hiện load và tìm kiếm
       private classdata() { }

       string connectionstring = @"workstation id=QuanliSV.mssql.somee.com;packet size=4096;user id=mylhps03856_SQLLogin_1;pwd=aqpy1r5nui;data source=QuanliSV.mssql.somee.com;persist security info=False;initial catalog=QuanliSV";
        public DataTable excutequery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            SqlConnection connect = new SqlConnection(connectionstring);
            connect.Open();
            //sqlcommand --> nên dùng cho insert , update, delete
            //sqldataadapter --> nên dùng cho câu lệnh select
            SqlCommand command = new SqlCommand(query, connect);
            if (parameter != null)
            {
                string[] temp = query.Split(' ');
                List<string> listpara = new List<string>();
                foreach (string item in temp)
                {
                    if (item[0] == '@')
                        listpara.Add(item);
                }
                for (int i = 0; i < parameter.Length; i++)
                {
                    command.Parameters.AddWithValue(listpara[i], parameter[i]);
                }
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(data);

            connect.Close();
            return data;
        }
       
       // THực hiện thêm xóa sửa
       public int excutenonquery(string query, object[] parameter = null)
        {
            int accpectedrows = 0;
            SqlConnection connect = new SqlConnection(connectionstring);
            connect.Open();
            //sqlcommand --> nên dùng cho insert , update, delete
            //sqldataadapter --> nên dùng cho câu lệnh select
            SqlCommand command = new SqlCommand(query, connect);
            if (parameter != null)
            {
                string[] temp = query.Split(' ');
                List<string> listpara = new List<string>();
                foreach (string item in temp)
                {
                    if (item[0] == '@')
                        listpara.Add(item);
                }
                for (int i = 0; i < parameter.Length; i++)
                {
                    command.Parameters.AddWithValue(listpara[i], parameter[i]);
                }
            }
           //Thuc hien cau query tra ve so dong ma cau truy van thuc hien dc 
            accpectedrows = command.ExecuteNonQuery();
            connect.Close();
       
            return accpectedrows;

        }
       public object ExcuteScalar(string query, object[] parameter = null)
       {
           object accpectedrows = 0;
           SqlConnection connect = new SqlConnection(connectionstring);
           connect.Open();
           //sqlcommand --> nên dùng cho insert , update, delete
           //sqldataadapter --> nên dùng cho câu lệnh select
           SqlCommand command = new SqlCommand(query, connect);
           if (parameter != null)
           {
               string[] temp = query.Split(' ');
               List<string> listpara = new List<string>();
               foreach (string item in temp)
               {
                   if (item[0] == '@')
                       listpara.Add(item);
               }
               for (int i = 0; i < parameter.Length; i++)
               {
                   command.Parameters.AddWithValue(listpara[i], parameter[i]);
               }
           }
           //Thuc hien cau query tra ve so dong ma cau truy van thuc hien dc 
           accpectedrows = command.ExecuteScalar();
           connect.Close();

           return accpectedrows;

       }
    }
}
