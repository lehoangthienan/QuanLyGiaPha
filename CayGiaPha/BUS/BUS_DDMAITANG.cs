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
    public class BUS_DDMAITANG
    {
        DAL_DDMAITANG dal_ddmaitang = new DAL_DDMAITANG();
        public SqlDataReader Autocompletar_CheckListDDMaiTang()
        {
            return dal_ddmaitang.Autocompletar_CheckListDDMaiTang();
        }
        public string Get_DDMaiTang(string tenDDMaiTang)
        {
            return dal_ddmaitang.Get_DDMaiTang(tenDDMaiTang);
        }
        public bool ThemDDMT(string MaDD, string TenDiaDiem)
        {
            return dal_ddmaitang.ThemDDMT(MaDD, TenDiaDiem);
        }
        public int Get_SoDDMT()
        {
            return dal_ddmaitang.Get_SoDDMT();
        }
    }
}
