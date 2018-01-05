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
    public class BUS_TV_NN
    {
        DAL_TV_NN DAL_tv_nn = new DAL_TV_NN();
        public bool Insert_TV_NN(TV_NGHENGHIEP tv_nn)
        {
            return DAL_tv_nn.Insert_TV_NN(tv_nn);
        }
        public bool Update_TV_NN(TV_NGHENGHIEP tv_nn_ud, string MATV)
        {
            return DAL_tv_nn.Update_TV_NN(tv_nn_ud, MATV);
        }
        public bool xoaTV_NN(string MATV)
        {
            return DAL_tv_nn.xoaTV_NN(MATV);
        }
    }
}
