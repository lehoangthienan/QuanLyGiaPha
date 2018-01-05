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
    public class BUS_LoaiTT
    {
        DAL_LoaiTT dal_loaitt = new DAL_LoaiTT();
        
        public SqlDataReader Autocompletar_CheckListLoaiTT()
        {
            return dal_loaitt.Autocompletar_CheckListLoaiTT();
        }
        public string Get_LoaiTT(string tenloaiTT)
        {
            return dal_loaitt.Get_LoaiTT(tenloaiTT);
        }
        public bool ThemLTT(string MaLTT, string TenTT)
        {
            return dal_loaitt.ThemLTT(MaLTT, TenTT);
        }
        public int Get_SoLTT()
        {
            return dal_loaitt.Get_SoLTT();
        }
        public DataTable Get_TenTT()
        {
            return dal_loaitt.Get_TenTT();
        }
    }
}
