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
    public class DAL_KT:BDConnect
    {
        #region Lấy thông tin 
        public DataTable Get_DDMT(string MATV)//Lấy tên địa điểm mai tang theo mã TV
        {
            try
            {
                string sqlstr = "select ddmt.TenDiaDiem from DIADIEMMAITANG as ddmt, KETTHUC_DDMAITANG as kt_ddmt, KETTHUC kt where kt.MATV= '" + MATV + "' and kt_ddmt.MAKT = kt.MAKT and kt_ddmt.MADD = ddmt.MADD";
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
        public DataTable Get_NgayMat(string MATV)//Lấy ngày mất theo mã thành viên 
        {
            try
            {
                string sqlstr = "";
                sqlstr += "select NgayMat from KETTHUC where MATV='";
                sqlstr += MATV;
                sqlstr += "'";
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
        public DataTable Get_NNhan(string MATV)//Lấy nguyên nhân mất theo mã TV
        {
            try
            {
                string sqlstr = "";
                sqlstr += "select nnm.TenNNhan from KETTHUC kt, NGUYENNHANMAT nnm where kt.MANNhan = nnm.MANNhan and kt.MATV='";
                sqlstr += MATV;
                sqlstr += "'";
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
        public DataTable ShowKetThuc()//Lấy thông tin thành viên đã mất 
        {
            try
            {
                string sql = "select TV.MATV 'Mã TV',TV.Hoten 'Họ Tên',DDMT.TenDiaDiem 'Địa điểm mai táng',NNM.TenNNhan 'Nguyên nhân mất', KT.NgayMat 'Ngày mất' from THANHVIEN as TV ,KETTHUC as KT ,DIADIEMMAITANG as DDMT, NGUYENNHANMAT as NNM, KETTHUC_DDMAITANG as KT_DDMT Where TV.MATV = KT.MATV and KT.MANNhan = NNM.MANNhan and KT.MAKT = KT_DDMT.MAKT and KT_DDMT.MADD= DDMT.MADD";
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
        public string Get_MAKT(string MATV)//Lẫy mã kết thúc theo mã thành viên
        {
            string SQL = "select MAKT from KETTHUC where MATV = '" + MATV + "'";
            SqlDataAdapter da = new SqlDataAdapter(SQL, _cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int row = dt.Rows.Count;
            if (row != 0)
                return (string)dt.Rows[0].ItemArray[0];
            else
                return null;
        }
        #endregion
        #region Thêm xóa sửa 
        public bool Insert_KT(KETTHUC kt)//Thêm kết thúc của thành viên vào DB
        {
            _cn.Open();
            string SQL = " INSERT INTO KETTHUC(MAKT,MATV,NgayMat,MANNhan) VALUES ('" + kt.MAKT + "','" + kt.MATV + "','" + kt.NgayMat + "','" + kt.MANNhan + "')";
            SqlCommand cmd = new SqlCommand(SQL, _cn);
            cmd.ExecuteNonQuery();
            _cn.Close();
            return true;
          
        }


        public bool xoaKetThuc(string KT_ID)//Xóa thông tin kết thúc của thành viên theo mã kết thúc
        {
            try
            {
                _cn.Open();
                string sqlstr = "";
                sqlstr = "delete from KETTHUC where MAKT='";
                sqlstr += KT_ID;
                sqlstr += "' delete from KETTHUC_DDMAITANG where MAKT='";
                sqlstr += KT_ID;
                sqlstr += "'";
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
        public bool Update_KT(KETTHUC kt_ud, string MATV)//Sửa thông tin kết thúc đã lưu trong DB
        {
            try
            {
                _cn.Open();
                string SQL = "UPDATE KETTHUC SET NgayMat= '" + kt_ud.NgayMat + "',MANNhan= '" + kt_ud.MANNhan + "' WHERE MATV = '" + MATV + "'";
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
        #endregion
        public string Generate_MAKT(int countrow)
        {
            string temp = "KT";
            string s = "";
            if (countrow < 9)
            {
                s = temp + "0" + Convert.ToString(countrow + 1);
            }
            else
                s = temp + Convert.ToString(countrow + 1);
            return s;
        }
        public int Get_CountRow()//Lấy số cột của bảng kết thúc
        {
            int countRow;
            SqlDataAdapter da = new SqlDataAdapter("Select * from KETTHUC", _cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return countRow = dt.Rows.Count;
        }


    }

}
