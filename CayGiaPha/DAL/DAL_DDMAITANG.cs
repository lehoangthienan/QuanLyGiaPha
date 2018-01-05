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
    public class DAL_DDMAITANG:BDConnect
    {
        public SqlCommand cmd;
        public SqlDataReader dr;

        public bool ThemDDMT(string MaDD, string TenDiaDiem)//Thêm địa điểm mai táng mới vào DB
        {
            try
            {
                string sqlstr = "";
                sqlstr = "INSERT INTO DIADIEMMAITANG VALUES('";
                sqlstr += MaDD;
                sqlstr += "',N'";
                sqlstr += TenDiaDiem;
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
        public int Get_SoDDMT()//Đếm số địa điểm mai táng trong DB
        {
            string sqlstr = "";
            sqlstr += "select count(MaDD) from DIADIEMMAITANG";
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = new SqlCommand(sqlstr, _cn);
            _cn.Open();
            int a = int.Parse(da.InsertCommand.ExecuteScalar().ToString());
            _cn.Close();
            return a;
        }
        public SqlDataReader Autocompletar_CheckListDDMaiTang()//Đọc dữ liệu tên địa điểm mai táng
        {
            try
            {
                _cn.Open();
                cmd = new SqlCommand("Select TenDiaDiem from DIADIEMMAITANG", _cn);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;
            }
        }
        public string Get_DDMaiTang(string tenDDMaiTang)//Lấy mã địa điểm mai táng theo tên địa điểm mai táng
        {
            string MaDDMaiTang = "";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from DIADIEMMAITANG", _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int countRow = dt.Rows.Count;
                int countCol = dt.Columns.Count;
                for (int iRow = 0; iRow < countRow; iRow++)
                {
                    for (int iCol = 0; iCol < countCol; iCol++)
                    {
                        if (tenDDMaiTang == (string)dt.Rows[iRow].ItemArray[iCol])
                        {
                            MaDDMaiTang = (string)dt.Rows[iRow].ItemArray[iCol - 1];
                            iCol = countCol;
                            iRow = countRow;
                        }
                    }
                }
                return MaDDMaiTang;
            }
            catch
            {
                return null;
            }
        }
    }
}
