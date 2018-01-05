using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DIADIEMMAITANG
    {
        private string MADD;
        private string TenDiaDiem;

        public string MADD1
        {
            get
            {
                return MADD;
            }

            set
            {
                MADD = value;
            }
        }

        public string TenDiaDiem1
        {
            get
            {
                return TenDiaDiem;
            }

            set
            {
                TenDiaDiem = value;
            }
        }
        public DIADIEMMAITANG(string MADD = "", string TenDiaDiem = "")
        {
            this.MADD = MADD;
            this.TenDiaDiem = TenDiaDiem;
        }
    }
}
