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
    public class BUS_QQ
    {
        DAL_QQ qq = new DAL_QQ();
        public SqlDataReader Autocompletar_ComboBoxQQ()
        {
            return qq.Autocompletar_ComboBoxQQ();
        }
        public string Get_QQ(string tenQQ)
        {
            return qq.Get_QQ(tenQQ);

        }
        public bool ThemQQ(string MaQQ, string TenQQ)
        {
            return qq.ThemQQ(MaQQ, TenQQ);
        }
        public int Get_SoQQ()
        {
            return qq.Get_SoQQ();
        }
    }
}
