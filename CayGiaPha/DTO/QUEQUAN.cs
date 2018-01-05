using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QUEQUAN
    {
        private string _MAQQ;
        public string MA_QQ
        {
            get { return _MAQQ; }
            set { _MAQQ = value; }
        }
        private string _TenQQ;
        public string Ten_QQ
        {
            get { return _TenQQ; }
            set { _TenQQ = value; }
        }
        public QUEQUAN(string MAQQ="",string TenQQ="")
        {
            this._MAQQ = MAQQ;
            this._TenQQ = TenQQ;
        }
    }
}
