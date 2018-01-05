using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KETTHUC_DDMAITANG
    {
        private string _MADD;
        private string _MAKT;
        public string MADD
        {
            get
            {
                return _MADD;
            }

            set
            {
                _MADD = value;
            }
        }

        public string MAKT
        {
            get
            {
                return _MAKT;
            }

            set
            {
                _MAKT = value;
            }
        }
        public KETTHUC_DDMAITANG(string MADD = "", string MAKT = "")
        {
            this._MAKT = MAKT;
            this._MADD = MADD;
        }
    }
}
