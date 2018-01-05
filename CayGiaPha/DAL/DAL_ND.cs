using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_ND : BDConnect
    {
        DataTable dt = new DataTable();

        public DAL_ND()
        {
            dt = Get_ND();
            dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };
        }
        public DataTable Get_ND()//Lấy thông tin tài khoản
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from NguoiDung", _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }

      public bool Insert(NguoiDung nd)//Thêm tài khoản mới vào DB
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from NguoiDung", _cn);
                dt.Columns.Add("TaiKhoan");
                dt.Columns.Add("MatKhau");
                DataRow r = dt.NewRow();
                r["TaiKhoan"] = nd.TaiKhoan;
                r["MatKhau"] = nd.MatKhau;
                dt.Rows.Add(r);
                SqlCommandBuilder cm = new SqlCommandBuilder(da);
                da.Update(dt);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(NguoiDung nd)//Sửa thông tin tài khoản đã lưu trong DB
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from NguoiDung", _cn);
                DataRow r = dt.Rows.Find(nd.TaiKhoan.ToString());
                if (r != null)
                {
                    r["MatKhau"] = nd.MatKhau;
                }
                SqlCommandBuilder cm = new SqlCommandBuilder(da);
                da.Update(dt);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    
}
