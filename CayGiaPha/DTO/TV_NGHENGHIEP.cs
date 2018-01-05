using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TV_NGHENGHIEP
    {
        private string _MANNghiep;
        private string _MATV;

        public string MANNghiep
        {
            get
            {
                return _MANNghiep;
            }

            set
            {
                this._MANNghiep = value;
            }
        }

        public string MATV
        {
            get
            {
                return _MATV;
            }

            set
            {

                this._MATV = value;
            }
        }
        public TV_NGHENGHIEP(string MANNghiep = "",string MATV = "")
        {
            this._MANNghiep = MANNghiep;
            this._MATV = MATV;
        }
    }
}
