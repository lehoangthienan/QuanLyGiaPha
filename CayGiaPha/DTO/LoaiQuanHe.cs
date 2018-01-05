using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiQuanHe
    {
        private string _LoaiQH;
        private string _MATV_T;
        private string _MATV_S;

        public string MATV_T
        {
            get
            {
                return _MATV_T;
            }

            set
            {
                _MATV_T = value;
            }
        }

        public string MATV_S
        {
            get
            {
                return _MATV_S;
            }

            set
            {
                _MATV_S = value;
            }
        }
        

        public string LoaiQH
        {
            get
            {
                return _LoaiQH;
            }

            set
            {
                _LoaiQH = value;
            }
        }

        public LoaiQuanHe(string MATV_T = "", string MATV_S = "", string LoaiQH ="")
        {
            this._MATV_S = MATV_S;
            this._MATV_T = MATV_T;
            this._LoaiQH = LoaiQH;
        }
        public LoaiQuanHe(string MATV_T = "", string LoaiQH = "")
        {
            this._MATV_T = MATV_T;
            this._LoaiQH = LoaiQH;
        }
    }
}
