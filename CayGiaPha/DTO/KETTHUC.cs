using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KETTHUC
    {
        private string _MAKT;
        private string _MANNhan;
        private string _MATV;
        private DateTime _NgayMat;

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

        public string MANNhan
        {
            get
            {
                return _MANNhan;
            }

            set
            {
                _MANNhan = value;
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
                _MATV = value;
            }
        }

        public DateTime NgayMat
        {
            get
            {
                return _NgayMat;
            }

            set
            {
                _NgayMat = value;
            }
        }
        public KETTHUC(DateTime NgayMat, string MAKT = "", string MANNhan = "", string MATV = "")
        {
            this._NgayMat = NgayMat;
            this._MAKT = MAKT;
            this._MANNhan = MANNhan;
            this._MATV = MATV;
        }

        public KETTHUC(DateTime NgayMat, string MANNhan = "")
        {
            this._NgayMat = NgayMat;
            this._MANNhan = MANNhan;
        }
    }
}
