using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class BUS_tv
    {
        DAL_TV TV = new DAL_TV();

        public int Check_SQL()
        {
            return TV.Check_SQL();
        }
        public DataSet Get_ALL(string Nam)
        {
            return TV.Get_ALL(Nam);
        }
        public DataSet Get_MatALL(string Nam)
        {
            return TV.Get_MatALL(Nam);
        }
        public DataSet Get_TV_TangTheoNam(string Nam)
        {
            return TV.Get_TV_TangTheoNam(Nam);
        }
        public DataSet Get_TV_MatTheoNam(string Nam)
        {
            return TV.Get_TV_MatTheoNam(Nam);
        }

        public DataSet Get_TV()
        {
            return TV.Get_TV();

        }
        public bool Insert(THANHVIEN tv)
        {
            return TV.Insert(tv);
        }
        public string Genarate_MATV(int countrow)
        {
            return TV.Generate_MATV(countrow);
        }
        public int Get_CountRow()
        {
            return TV.Get_CountRow();
        }
        public SqlDataReader Autocompletar_TextBox()
        {
            return TV.Autocompletar_TextBox();
        }
        public string Get_MATVC(string tenTVC)
        {
            return TV.Get_MATVC(tenTVC);
        }
        public void Connection_Close()
        {
            TV.Connection_Close();
        }
        public bool xoaThanhVien(string TV_ID)
        {
            return TV.xoaThanhVien(TV_ID);
        }
        public bool Update_TV(THANHVIEN tv_ud, string MATV)
        {
            return TV.Update_TV(tv_ud,MATV);
        }
        public DataSet Get_TimKiem(string t, int k)
        {
            return TV.Get_TimKiem(t, k);
        }
        public DataSet Get_TVTang(string cbTuNam, string cbDenNam)
        {
            return TV.Get_TVTang(cbTuNam, cbDenNam);
        }
        public DataSet Get_TAll(string cbTuNam, string cbDenNam)
        {
            return TV.Get_TAll(cbTuNam, cbDenNam);
        }
        public DataSet Get_TVGiam(string cbTuNam, string cbDenNam)
        {
            return TV.Get_TVGiam(cbTuNam, cbDenNam);
        }
        public DataSet Get_GAll(string cbTuNam, string cbDenNam)
        {
            return TV.Get_GAll(cbTuNam, cbDenNam);
        }
        public int Get_Doi(string tenTVC)
        {
            return TV.Get_Doi(tenTVC);
        }
        public int Generate_Doi(string tenQH, int i)
        {
            return TV.Generate_Doi(tenQH, i);
        }
        public DataSet Get_TimKiemNC(string txt, int gt, int lqh, int t)
        {
            return TV.Get_TimKiemNC(txt, gt, lqh, t);
        }
        public DataTable Get_Ten(string MATV)
        {
            return TV.Get_Ten(MATV);
        }
        public DataTable Get_TVT(string MATV)
        {
            return TV.Get_TVT(MATV);
        }
        public DataTable Get_DiaChi(string MATV)
        {
            return TV.Get_DiaChi(MATV);
        }
        public DataTable Get_QQ(string MATV)
        {
            return TV.Get_QQ(MATV);
        }
        public int Get_GT(string MATV)
        {
            return TV.Get_GT(MATV);
        }
        public int Get_QH(string MATV)
        {
            return TV.Get_QH(MATV);
        }
        public DataTable Get_Ma(string HoTen)
        {
            return TV.Get_Ma(HoTen);
        }
        public DataTable Get_NS(string MATV)
        {
            return TV.Get_NS(MATV);
        }
        public DataTable Get_NVH(string MATV)
        {
            return TV.Get_NVH(MATV);
        }
        public DataTable Get_NNghiep(string MATV)
        {
            return TV.Get_NNghiep(MATV);
        }
    }
    
}
