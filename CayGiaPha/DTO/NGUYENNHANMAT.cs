using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class NGUYENNHANMAT
    {
        private string MANNhan;
        private string TenNNhan;

        public string MANNhan1
        {
            get
            {
                return MANNhan;
            }

            set
            {
                MANNhan = value;
            }
        }

        public string TenNNhan1
        {
            get
            {
                return TenNNhan;
            }

            set
            {
                TenNNhan = value;
            }
        }
        public NGUYENNHANMAT(string MANNhan = "", string TenNNhan = "")
        {
            this.MANNhan = MANNhan;
            this.TenNNhan = TenNNhan;
        }
    }
}
