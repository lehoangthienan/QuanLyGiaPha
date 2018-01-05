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
    public class DAL_LoaiTT : BDConnect
    {
        DataTable dt = new DataTable();
        public SqlCommand cmd;
        public SqlDataReader dr;
        public SqlDataReader Autocompletar_CheckListLoaiTT()//Đọc dữ liệu loại thành tích
        {
            try
            {
                _cn.Open();
                cmd = new SqlCommand("Select TenTT from LOAITHANHTICH", _cn);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;
            }
        }
        
        public DataTable Get_TenTT()//Lấy tên loại thành tích
        {
            try
            {
                string sql = "Select TenTT from LOAITHANHTICH";
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
        public string Get_LoaiTT(string tenloaiTT)//Lấy Mã loại thành tích theo tên loại thành tích
        {
            string MALoaiTT = "";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from LOAITHANHTICH", _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int countRow = dt.Rows.Count;
                int countCol = dt.Columns.Count;
                for (int iRow = 0; iRow < countRow; iRow++)
                {
                    for (int iCol = 0; iCol < countCol; iCol++)
                    {
                        if (tenloaiTT == (string)dt.Rows[iRow].ItemArray[iCol])
                        {
                            MALoaiTT = (string)dt.Rows[iRow].ItemArray[iCol - 1];
                            iCol = countCol;
                            iRow = countRow;
                        }
                    }
                }
                return MALoaiTT;
            }
            catch
            {
                return null;
            }
        }
        public bool ThemLTT(string MALTT, string TenTT)//Thêm loại thành tích mới vào DB
        {

            string sqlstr = "";
            sqlstr = "INSERT INTO LOAITHANHTICH VALUES('";
            sqlstr += MALTT;
            sqlstr += "',N'";
            sqlstr += TenTT;
            sqlstr += "')";
            SqlCommand cmd = new SqlCommand(sqlstr, _cn);
            _cn.Open();
            cmd.ExecuteNonQuery();
            _cn.Close();
            return true;
        }
        public int Get_SoLTT()//Đếm số loại thành tích trong DB
        {
            string sqlstr = "";
            sqlstr += "select count(MALTT) from LOAITHANHTICH";
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = new SqlCommand(sqlstr, _cn);
            _cn.Open();
            int a = int.Parse(da.InsertCommand.ExecuteScalar().ToString());
            _cn.Close();
            return a;
        }
    }
}
