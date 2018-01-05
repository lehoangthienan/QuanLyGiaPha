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
    public class DAL_ThamSo : BDConnect
    {
        #region Lấy số thông tin
        public int Get_SoQQ()//Lấy số quê quán 
        {
            string sqlstr = "";
            sqlstr += "select SoQQ from THAMSO";
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = new SqlCommand(sqlstr, _cn);
            _cn.Open();
            int a = int.Parse(da.InsertCommand.ExecuteScalar().ToString());
            _cn.Close();
            return a;
        }
        public int Get_SoNN()//Lấy số nghề nghiệp
        {
            string sqlstr = "";
            sqlstr += "select SoNN from THAMSO";
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = new SqlCommand(sqlstr, _cn);
            _cn.Open();
            int a = int.Parse(da.InsertCommand.ExecuteScalar().ToString());
            _cn.Close();
            return a;
        }
        public int Get_SoLTT()//Lấy số loại thành tích
        {
            string sqlstr = "";
            sqlstr += "select SoLTT from THAMSO";
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = new SqlCommand(sqlstr, _cn);
            _cn.Open();
            int a = int.Parse(da.InsertCommand.ExecuteScalar().ToString());
            _cn.Close();
            return a;
        }
        public int Get_SoNNM()//Lấy số nguyên nhân mất
        {
            string sqlstr = "";
            sqlstr += "select SoNNM from THAMSO";
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = new SqlCommand(sqlstr, _cn);
            _cn.Open();
            int a = int.Parse(da.InsertCommand.ExecuteScalar().ToString());
            _cn.Close();
            return a;
        }
        public int Get_SoDDMT()//Lấy số địa điểm mai táng
        {
            string sqlstr = "";
            sqlstr += "select SoDDMT from THAMSO";
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = new SqlCommand(sqlstr, _cn);
            _cn.Open();
            int a = int.Parse(da.InsertCommand.ExecuteScalar().ToString());
            _cn.Close();
            return a;
        }
        #endregion
        #region Sửa thông tin
        public bool Set_SoQQ(string t)//Sửa lại số quê quán đã lưu trong DB
        {
            try
            {
                string sqlstr = "";
                sqlstr = "update THAMSO set SoQQ='";
                sqlstr += t;
                sqlstr += "'";
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
        public bool Set_SoNN(string t)//Sửa lại số nghề nghiệp đã lưu trong DB
        {
            try
            {
                string sqlstr = "";
                sqlstr = "update THAMSO set SoNN='";
                sqlstr += t;
                sqlstr += "'";
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
        public bool Set_SoLTT(string t)//Sửa lại số loại thành tích đã lưu trong DB
        {
            try
            {
                string sqlstr = "";
                sqlstr = "update THAMSO set SoLTT='";
                sqlstr += t;
                sqlstr += "'";
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
        public bool Set_SoNNM(string t)//Sửa lại số nguyên nhân mất đã lưu trong DB
        {
            try
            {
                string sqlstr = "";
                sqlstr = "update THAMSO set SoNNM='";
                sqlstr += t;
                sqlstr += "'";
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
        public bool Set_SoDDMT(string t)//Sửa lại số địa điểm mai táng đã lưu trong DB
        {
            try
            {
                string sqlstr = "";
                sqlstr = "update THAMSO set SoDDMT='";
                sqlstr += t;
                sqlstr += "'";
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
        #endregion
    }
}
