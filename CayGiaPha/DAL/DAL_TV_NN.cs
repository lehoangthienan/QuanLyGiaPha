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
    
    public class DAL_TV_NN:BDConnect
    {     
        public bool Insert_TV_NN(TV_NGHENGHIEP tv_nn)//Thêm thành viên mới vào DB
        {
            try
            {
                _cn.Open();
                string SQL = "INSERT INTO THANHVIEN_NGHENGHIEP(MANNghiep,MATV) VALUES ('" + tv_nn.MANNghiep + "', '" + tv_nn.MATV + "')";

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
        public bool Update_TV_NN(TV_NGHENGHIEP tv_nn_ud, string MATV)//Chỉnh sửa dữ liệu đã lưu trong DB
        {
            // Ket noi
            _cn.Open();

            // Query string
            string SQL = "UPDATE THANHVIEN_NGHENGHIEP SET MANNghiep= '" + tv_nn_ud.MANNghiep + "',MATV = '" + tv_nn_ud.MATV + "'WHERE MATV = '" + MATV + "'";

            // Command (mặc định command type = text ).
            SqlCommand cmd = new SqlCommand(SQL, _cn);

            // Query và kiểm tra
            cmd.ExecuteNonQuery();
            _cn.Close();
            return true;

        }
        public bool xoaTV_NN(string MATV)//xóa thông tin một thành viên trong DB
        {
           
            // Ket noi
                _cn.Open();
            // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
            string sqlstr = "";
            sqlstr = "delete from THANHVIEN_NGHENGHIEP where MATV='";
            sqlstr += MATV;
            sqlstr += "'";

            // Command (mặc định command type = text).
            SqlCommand cmd = new SqlCommand(sqlstr, _cn);

            // Query và kiểm tra
            cmd.ExecuteNonQuery();
            _cn.Close();
            return true;
            

        }
    }
}
