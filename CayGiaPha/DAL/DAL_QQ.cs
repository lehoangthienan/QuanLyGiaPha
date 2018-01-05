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
    public class DAL_QQ : BDConnect
    {
        DataTable dt = new DataTable();
        public SqlCommand cmd;
        public SqlDataReader dr;
        public bool ThemQQ(string MAQQ, string TenQQ)//Thêm quê quán mới vào DB
        {

            string sqlstr = "";
            sqlstr = "INSERT INTO QUEQUAN VALUES('";
            sqlstr += MAQQ;
            sqlstr += "',N'";
            sqlstr += TenQQ;
            sqlstr += "')";
            SqlCommand cmd = new SqlCommand(sqlstr, _cn);
            _cn.Open();
            cmd.ExecuteNonQuery();
            _cn.Close();
            return true;
        }
        public int Get_SoQQ()//Đêm số quê quán trong DB
        {
            string sqlstr = "";
            sqlstr += "select count(MAQQ) from QUEQUAN";
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = new SqlCommand(sqlstr, _cn);
            _cn.Open();
            int a = int.Parse(da.InsertCommand.ExecuteScalar().ToString());
            _cn.Close();
            return a;
        }

        public SqlDataReader Autocompletar_ComboBoxQQ()//Đọc dữ liệu quê quán
        {
            try
            {
                _cn.Open();
                cmd = new SqlCommand("Select TenQQ from QUEQUAN", _cn);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;
            }
        }
        public string Get_QQ(string tenQQ)//Lấy mã quê quán theo tên quê quán
        {
            string MaQQ = "";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from QUEQUAN", _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int countRow = dt.Rows.Count;
                int countCol = dt.Columns.Count;
                for (int iRow = 0; iRow < countRow; iRow++)
                {
                    for (int iCol = 0; iCol < countCol; iCol++)
                    {
                        if (tenQQ == (string)dt.Rows[iRow].ItemArray[iCol])
                        {
                            MaQQ = (string)dt.Rows[iRow].ItemArray[iCol - 1];
                            iCol = countCol;
                            iRow = countRow;
                        }
                    }
                }
                return MaQQ;
            }
            catch
            {
                return null;
            }
        }
    }
}
