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
    public class BUS_NgheNghiep
    {
        DAL_NgheNghiep nn = new DAL_NgheNghiep();
        DAL_TV_NN tv_nn = new DAL_TV_NN();
        
        public bool ThemNN(string MANN, string TenNN)
        {
            return nn.ThemNN(MANN, TenNN);
        }
        public SqlDataReader Autocompletar_CheckListNN()
        {
            return nn.Autocompletar_CheckListNN();
        }
        public string Get_NN(string tenNN)
        {
            return nn.Get_NN(tenNN);

        }
        public int Get_SoNN()
        {
            return nn.Get_SoNN();
        }
    }
}
