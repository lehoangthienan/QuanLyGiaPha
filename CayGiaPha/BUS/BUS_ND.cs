using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;

namespace BUS
{
   public class BUS_ND
    {
        DAL_ND dal_nd = new DAL_ND();
        public bool Insert(NguoiDung nd)
        {
            return dal_nd.Insert(nd);
        }
        public bool Update(NguoiDung nd)
        {
            return dal_nd.Update(nd);
        }
    }
}
