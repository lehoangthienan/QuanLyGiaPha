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
    public class BUS_KT_DDMAITANG
    {
        DAL_KT_DDMAITANG dal_kt_ddmt = new DAL_KT_DDMAITANG();
        public bool Insert_KT_DDMAITANG(KETTHUC_DDMAITANG kt_ddmaitang)
        {
            return dal_kt_ddmt.Insert_KT_DDMAITANG(kt_ddmaitang);
        }
        public bool xoaKetThuc_DDMT(string KT_ID)
        {
            return dal_kt_ddmt.xoaKetThuc_DDMT(KT_ID);
        }
    }
}
