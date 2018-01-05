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
    public class DAL_TT:BDConnect
    {

        public void Connection_Close()
        {
            _cn.Close();
        }
        DataTable dt = new DataTable();
        #region Lấy thông tin thành tích
        public DataSet Get_TT(string cbTuNam, string cbDenNam)//Lấy thông tin thành tích qua các năm
        {
            try
            {
                SqlDataAdapter da;
                DataSet ds;
                string sqlstr;
                sqlstr = "select tv.MATV,tv.HoTen 'HỌ TÊN', tt.MaLTT 'MÃ LOẠI THÀNH TÍCH', ltt.TenTT 'LOẠI THÀNH TÍCH', tt.NgayPhatSinh 'Ngày Phát Sinh' from THANHVIEN tv, THANHTICH tt, LOAITHANHTICH ltt where tv.MATV=tt.MATV and tt.MaLTT=ltt.MaLTT and year(tt.NgayPhatSinh) >=";
                sqlstr += cbTuNam;
                sqlstr += " and year(tt.NgayPhatSinh)<=";
                sqlstr += cbDenNam;
                da = new SqlDataAdapter(sqlstr, _cn);
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds, "THANHTICH,THANHVIEN,LOAITHANHTICH");
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public DataTable Get_Ma(string TenTT)//Lấy mã thành tích theo tên thành tích
        {
            try
            {
                string sqlstr = "";
                sqlstr += "select top 1 MaLTT from LOAITHANHTICH where TenTT Like N'%";
                sqlstr += TenTT;
                sqlstr += "%'";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable ShowThanhTich()//Lấy cả thông tin thành viên có thành tích 
        {
            try
            {
                string sql = "select TV.MATV 'Mã thành viên',TV.Hoten 'Họ Tên' ,LoaiTT.TenTT 'Tên thành tích',TT.NgayPhatSinh 'Ngày phát sinh' from THANHVIEN as TV ,THANHTICH as TT ,LOAITHANHTICH as LoaiTT Where TV.MATV = TT.MATV and TT.MaLTT = LoaiTT.MaLTT";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, _cn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable Get_Thanhtich(string MATV)//Lấy thông tin thành tích theo mã thành viên
        {
            try
            {
                string sql = "select LoaiTT.TenTT 'Tên thành tích',TT.NgayPhatSinh 'Ngày phát sinh' from THANHTICH as TT ,LOAITHANHTICH as LoaiTT Where TT.MATV ='"+MATV+"' and TT.MaLTT = LoaiTT.MaLTT";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, _cn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region Thêm xóa sửa thành tích
        public bool Insert(THANHTICH tt)//Thêm thành tích vào DB
        {
            try
            {
                _cn.Open();
                string SQL = "INSERT INTO THANHTICH(MaLTT,MATV,NgayPhatSinh) VALUES('" + tt.MaLTT + "','" + tt.MATV + "','" + tt.NgayPS + "')";
                SqlCommand cmd = new SqlCommand(SQL, _cn);
                cmd.ExecuteNonQuery();
                _cn.Close();
                return true;
            }
            catch
            {
                
                return false;

            }
        }
        public bool xoaThanhTich(string MATV)//Xóa thành tích trong DB theo mã TV
        {
            try
            {
                // Ket noi
                _cn.Open();
                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string sqlstr = "";
                sqlstr = "delete from THANHTICH where MATV='";
                sqlstr += MATV;
                sqlstr += "'";

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(sqlstr, _cn);

                // Query và kiểm tra
                cmd.ExecuteNonQuery();
                _cn.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool Update_TT(THANHTICH tt_ud, string MATV)//Sửa thông tin thành tích theo mã TV đã lưu trong DB
        {
            try
            {
                // Ket noi
                _cn.Open();

                // Query string
                string SQL = "UPDATE THANHTICH SET MaLTT= '" + tt_ud.MaLTT + "',NgayPhatSinh = '" + tt_ud.NgayPS + "'WHERE MATV = '" + MATV + "'";

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, _cn);

                // Query và kiểm tra
                cmd.ExecuteNonQuery();
                _cn.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion
    }
}
