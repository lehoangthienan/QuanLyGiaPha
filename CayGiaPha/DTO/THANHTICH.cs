using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class THANHTICH
    {
        private string _MATV;
        private string _MaLTT;
        private DateTime _NgayPS;

        public string MATV
        {
            get
            {
                return _MATV;
            }

            set
            {
                _MATV = value;
            }
        }
        

        public string MaLTT
        {
            get
            {
                return _MaLTT;
            }

            set
            {
                _MaLTT = value;
            }
        }
        
        public DateTime NgayPS
        {
            get
            {
                return _NgayPS;
            }

            set
            {
                _NgayPS = value;
            }
        }

        public THANHTICH(DateTime NgayPS, string MATV = "", string MaLTT = "")
        {
            this._NgayPS = NgayPS;
            this._MaLTT = MaLTT;
            this._MATV = MATV;
        }
        public THANHTICH(DateTime NgayPS, string MaLTT = "")
        {
            this._NgayPS = NgayPS;
            this._MaLTT = MaLTT;
        }
    }
}

