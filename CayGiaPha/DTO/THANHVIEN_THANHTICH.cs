using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class THANHVIEN_THANHTICH
    {
        private string MATT;
        private string MATV;

        public string MATT1
        {
            get
            {
                return MATT;
            }

            set
            {
                MATT = value;
            }
        }

        public string MATV1
        {
            get
            {
                return MATV;
            }

            set
            {
                MATV = value;
            }
        }
        public THANHVIEN_THANHTICH(string MATT = "", string MATV = "")
        {
            this.MATT = MATT;
            this.MATV = MATV;
        }
    }
}
