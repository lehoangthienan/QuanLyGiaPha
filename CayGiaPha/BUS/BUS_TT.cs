using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using DTO;
namespace BUS
{
    public class BUS_TT
    {
        
        DAL_TT tt = new DAL_TT();
        DAL_TV tv = new DAL_TV();
        
        public DataTable Get_Thanhtich(string MATV)
        {
            return tt.Get_Thanhtich(MATV);
        }
        public bool Insert(THANHTICH thanhtich)
        {
            return tt.Insert(thanhtich);
        }
        public SqlDataReader Autocompletar_TextBox()
        {
            return tv.Autocompletar_TextBox();
        }
        public DataTable ShowThanhTich()
        {
            return tt.ShowThanhTich();
        }
        public void Connection_Close()
        {
            tt.Connection_Close();
        }
        public bool Update_TT(THANHTICH tt_ud, string MATV)
        {
            return tt.Update_TT(tt_ud, MATV);
        }
        public DataSet Get_TT(string cbTuNam, string cbDenNam)
        {
            return tt.Get_TT(cbTuNam, cbDenNam);
        }
        public DataTable Get_MA(string TenTT)
        {
            return tt.Get_Ma(TenTT);
        }
        public bool xoaThanhTich(string KT_ID)
        {
            return tt.xoaThanhTich(KT_ID);
        }
    }
}
