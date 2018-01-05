using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class LOAITHANHTICH
    {
        private string _MALTT;
        private string _TenTT;


        public LOAITHANHTICH(string MALTT = "", string TenTT = "")
        {
            this._MALTT = MALTT;
            this._TenTT = TenTT;
        }

        public string MALTT
        {
            get
            {
                return _MALTT;
            }

            set
            {
                _MALTT = value;
            }
        }

        public string TenTT
        {
            get
            {
                return _TenTT;
            }

            set
            {
                _TenTT = value;
            }
        }
    }
}
