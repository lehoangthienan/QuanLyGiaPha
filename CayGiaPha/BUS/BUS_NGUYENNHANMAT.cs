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
    public class BUS_NGUYENNHANMAT
    {
        DAL_NGUYENNHANMAT dal_nnmat = new DAL_NGUYENNHANMAT();
        public SqlDataReader Autocompletar_ComboBoxNNMat()
        {
            return dal_nnmat.Autocompletar_ComboBoxNNMat();
        }
        public string Get_MANNMAT(string tenNNMAT)
        {
            return dal_nnmat.Get_MANNMAT(tenNNMAT);
        }
        public bool ThemLTT(string MaNNhan, string TenNNHan)
        {
            return dal_nnmat.ThemNNM(MaNNhan, TenNNHan);
        }

        public int Get_SoNNM()
        {
            return dal_nnmat.Get_SoNNM();
        }
    }
    
}
