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
    public class DAL_LoaiQH : BDConnect
    {
        public bool Insert_LoaiQQ(LoaiQuanHe loaiQQ)//Thêm quan hệ của thành viên vào DB
        {
            _cn.Open();
            string SQL = "INSERT INTO LOAIQUANHE(MATV_T,MATV_S,GhiChu) VALUES ('" + loaiQQ.MATV_T + "','" + loaiQQ.MATV_S + "','" + loaiQQ.LoaiQH + "')";

            SqlCommand cmd = new SqlCommand(SQL, _cn);
            cmd.ExecuteNonQuery();
            _cn.Close();
            return true;
        }
        public bool Update_LoaiQH(LoaiQuanHe loaiQH, string MATV)//Sửa quan hệ của thành viên đã lưu trong DB
        {
            try
            {
                _cn.Open();
                string SQL = "UPDATE LOAIQUANHE SET MATV_T= '" + loaiQH.MATV_T + "',GhiChu = '" + loaiQH.LoaiQH + "' WHERE MATV_S = '" + MATV + "'";
                
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
    }
}
