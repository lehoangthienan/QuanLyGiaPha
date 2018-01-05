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
    public class BUS_LoaiQH
    {
        DAL_LoaiQH DAL_LoaiQH = new DAL_LoaiQH();
        public bool Insert_LoaiQH(LoaiQuanHe loaiQQ)
        {
            return DAL_LoaiQH.Insert_LoaiQQ(loaiQQ);
        }
        public bool Update_LoaiQH(LoaiQuanHe loaiQH, string MATV)
        {
            return DAL_LoaiQH.Update_LoaiQH(loaiQH, MATV);
        }
    }
}
