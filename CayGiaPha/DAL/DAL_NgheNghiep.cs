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
    public class DAL_NgheNghiep:BDConnect
    {
        DataTable dt = new DataTable();
        public SqlCommand cmd;
        public SqlDataReader dr;
        public SqlDataReader Autocompletar_CheckListNN()//Đọc dữ liệu nghề nghiệp
        {
            try
            {
                _cn.Open();
                cmd = new SqlCommand("Select TenNNghiep from NGHENGHIEP", _cn);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;
            }
        }
        public bool ThemNN(string MANN, string TenNN)//Thêm nghề nghiệp mới vào DB
        {
            try
            {
                string sqlstr = "";
                sqlstr = "INSERT INTO NGHENGHIEP VALUES('";
                sqlstr += MANN;
                sqlstr += "',N'";
                sqlstr += TenNN;
                sqlstr += "')";
                SqlCommand cmd = new SqlCommand(sqlstr, _cn);
                _cn.Open();
                cmd.ExecuteNonQuery();
                _cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string Get_NN(string tenNN)//Lấy mã nghề nghiệp theo tên nghề nghiệp
        {
            string MaNN = "";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from NGHENGHIEP", _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int countRow = dt.Rows.Count;
                int countCol = dt.Columns.Count;
                for (int iRow = 0; iRow < countRow; iRow++)
                {
                    for (int iCol = 0; iCol < countCol; iCol++)
                    {
                        if (tenNN == (string)dt.Rows[iRow].ItemArray[iCol])
                        {
                            MaNN = (string)dt.Rows[iRow].ItemArray[iCol - 1];
                            iCol = countCol;
                            iRow = countRow;
                        }
                    }
                }
                return MaNN;
            }
            catch
            {
                return null;
            }
        }
        public int Get_SoNN()//Đếm số nghề nghiệp có trong DB
        {
            string sqlstr = "";
            sqlstr += "select count(MANNghiep) from NGHENGHIEP";
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = new SqlCommand(sqlstr, _cn);
            _cn.Open();
            int a = int.Parse(da.InsertCommand.ExecuteScalar().ToString());
            _cn.Close();
            return a;
        }
        public bool Update_TV(THANHVIEN tv_ud, string MATV)
        {
            // Ket noi
            _cn.Open();

            // Query string
            string SQL = "UPDATE THANHVIEN SET HoTen= '" + tv_ud.HoTen + "',GioiTinh= '" + tv_ud.GioiTinh + "',NgaySinh = '" + tv_ud.NgaySinh + "',NgayVaoHo= '" + tv_ud.NgayVaoHo + "',MAQQ= '" + tv_ud.MAQQ + "',TenDC= '" + tv_ud.TenDC + "',MATVCu = '" + tv_ud.MATVCu + "'WHERE MATV = '" + MATV + "'";

            // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
            SqlCommand cmd = new SqlCommand(SQL, _cn);

            // Query và kiểm tra
            cmd.ExecuteNonQuery();
            _cn.Close();
            return true;

        }
    }
}
