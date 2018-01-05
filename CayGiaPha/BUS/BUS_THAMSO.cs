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
    public class BUS_THAMSO
    {
        DAL_ThamSo ts = new DAL_ThamSo();
        public int Get_SoQQ()
        {
            return ts.Get_SoQQ();
        }
        public int Get_SoNN()
        {
            return ts.Get_SoNN();
        }
        public int Get_SoLTT()
        {
            return ts.Get_SoLTT();
        }
        public int Get_SoNNM()
        {
            return ts.Get_SoNNM();
        }
        public int Get_SoDDMT()
        {
            return ts.Get_SoDDMT();
        }
        public bool Set_SoQQ(string t)
        {
            return ts.Set_SoQQ(t);
        }
        public bool Set_SoNN(string t)
        {
            return ts.Set_SoNN(t);
        }
        public bool Set_SoLTT(string t)
        {
            return ts.Set_SoLTT(t);
        }
        public bool Set_SoNNM(string t)
        {
            return ts.Set_SoNNM(t);
        }
        public bool Set_SoDDMT(string t)
        {
            return ts.Set_SoDDMT(t);
        }
    }
}
