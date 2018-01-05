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
    public class BUS_KT
    {
        DAL_KT dal_kt = new DAL_KT();
        public DataTable Get_DDMT(string MATV)
        {
            return dal_kt.Get_DDMT(MATV);
        }
        public DataTable Get_NgayMat(string MATV)
        {
            return dal_kt.Get_NgayMat(MATV);
        }
        public DataTable Get_NNhan(string MATV)
        {
            return dal_kt.Get_NNhan(MATV);
        }
        public bool Insert_KT(KETTHUC kt)
        {
            return dal_kt.Insert_KT(kt);
        }
        public string Generate_MAKT(int countrow)
        {
            return dal_kt.Generate_MAKT(countrow);
        }
        public int Get_CountRow()
        {
            return dal_kt.Get_CountRow();
        }
        public DataTable ShowKetThuc()
        {
            return dal_kt.ShowKetThuc();
        }
        public bool xoaKetThuc(string KT_ID)
        {
            return dal_kt.xoaKetThuc(KT_ID);
        }
        public string Get_MAKT(string MATV)
        {
            return dal_kt.Get_MAKT(MATV);
        }
        public bool Update_KT(KETTHUC kt_ud, string MATV)
        {
            return dal_kt.Update_KT(kt_ud, MATV);
        }
    }
}
