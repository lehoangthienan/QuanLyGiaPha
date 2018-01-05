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
    public class DAL_NGUYENNHANMAT:BDConnect
    {
        SqlCommand cmd;
        SqlDataReader dr;
        public SqlDataReader Autocompletar_ComboBoxNNMat()//Đọc dữ liệu nguyên nhân mất
        {
            try
            {
                _cn.Open();
                cmd = new SqlCommand("Select TenNNhan from NGUYENNHANMAT", _cn);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;
            }
        }
        public bool ThemNNM(string MaNNhan, string TenNNhan)//Thêm nguyên nhân mất mới vào DB
        {
            try
            {
                string sqlstr = "";
                sqlstr = "INSERT INTO NGUYENNHANMAT VALUES('";
                sqlstr += MaNNhan;
                sqlstr += "',N'";
                sqlstr += TenNNhan;
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
        public int Get_SoNNM()//Đếm số nguyên nhân mất
        {
            string sqlstr = "";
            sqlstr += "select count(MaNNhan) from NGUYENNHANMAT";
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = new SqlCommand(sqlstr, _cn);
            _cn.Open();
            int a = int.Parse(da.InsertCommand.ExecuteScalar().ToString());
            _cn.Close();
            return a;
        }
        public string Get_MANNMAT(string tenNNMAT)//Lấy mã nguyên nhân mất theo tên nguyên nhân mất
        {
            string MaNNMAT = "";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from NGUYENNHANMAT", _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int countRow = dt.Rows.Count;
                int countCol = dt.Columns.Count;
                for (int iRow = 0; iRow < countRow; iRow++)
                {
                    for (int iCol = 0; iCol < countCol; iCol++)
                    {
                        if (tenNNMAT == (string)dt.Rows[iRow].ItemArray[iCol])
                        {
                            MaNNMAT = (string)dt.Rows[iRow].ItemArray[iCol - 1];
                            iCol = countCol;
                            iRow = countRow;
                        }
                    }
                }
                return MaNNMAT;
            }
            catch
            {
                return null;
            }
        }
    }
}
