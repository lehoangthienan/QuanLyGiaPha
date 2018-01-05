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
    public class DAL_KT_DDMAITANG:BDConnect
    {
        public bool Insert_KT_DDMAITANG(KETTHUC_DDMAITANG kt_ddmaitang)//Thêm mã kết thúc và mã địa điểm mai táng của thành viên vào DB
        {
            try
            {
                _cn.Open();
                string SQL = "INSERT INTO KETTHUC_DDMAITANG(MADD,MAKT) VALUES ('" + kt_ddmaitang.MADD + "', '" + kt_ddmaitang.MAKT + "')";

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
        public bool xoaKetThuc_DDMT(string KT_ID)//Xóa mã kết thúc và mã địa điểm mai táng của thành viên trong DB
        {
            try
            {
            _cn.Open();
            string sqlstr = "";
            sqlstr = "delete from KETTHUC_DDMAITANG where MAKT='";
            sqlstr += KT_ID;
            sqlstr += "'";
            SqlCommand cmd = new SqlCommand(sqlstr, _cn);
                
            cmd.ExecuteNonQuery();
            _cn.Close();
            return true;

            }
            catch 
            {
                return false;
            }

        }
    }
}
