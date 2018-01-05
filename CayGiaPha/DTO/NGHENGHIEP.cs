using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NGHENGHIEP
    {
        private string _MANNghiep;
        private string _TenNNghiep;

        public string MANNghiep
        {
            get
            {
                return _MANNghiep;
            }

            set
            {
                _MANNghiep = value;
            }
        }

        public string TenNNghiep
        {
            get
            {
                return _TenNNghiep;
            }

            set
            {
                _TenNNghiep = value;
            }
        }
        public NGHENGHIEP(string MANNghiep = "", string TenNNghiep = "")
        {
            this._MANNghiep = MANNghiep;
            this._TenNNghiep = TenNNghiep;
        }
    }
}
