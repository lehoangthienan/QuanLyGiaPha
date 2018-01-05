using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class THANHVIEN
    {
        private string _MATV;
        private string _MAQQ;
        private string _TenDC;
        private string _HoTen;
        private string _GioiTinh;
        private int _Doi;
        private DateTime _NgaySinh;
        private DateTime _NgayVaoHo;
        //private string _NgaySinh, _ThangSinh, _NamSinh;
        //private string _NgayVH, _ThangVH, _NamVH;
        private string _MATVCu;
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

        public string MAQQ
        {
            get
            {
                return _MAQQ;
            }

            set
            {
                this._MAQQ = value;
            }
        }
        

        

        public string HoTen
        {
            get
            {
                return _HoTen;
            }

            set
            {
                this._HoTen = value;
            }
        }

        public string GioiTinh
        {
            get
            {
                return _GioiTinh;
            }

            set
            {
                this._GioiTinh = value;
            }
        }
       

        

        public string MATVCu
        {
            get
            {
                return _MATVCu;
            }

            set
            {
                _MATVCu = value;
            }
        }

        public string TenDC
        {
            get
            {
                return _TenDC;
            }

            set
            {
                _TenDC = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return _NgaySinh;
            }

            set
            {
                _NgaySinh = value;
            }
        }

        public DateTime NgayVaoHo
        {
            get
            {
                return _NgayVaoHo;
            }

            set
            {
                _NgayVaoHo = value;
            }
        }

        public int Doi
        {
            get
            {
                return _Doi;
            }

            set
            {
                _Doi = value;
            }
        }

        public THANHVIEN(DateTime NgaySinh, DateTime NgayVaoHo,int Doi, string MATV = "", string MAQQ = "", string TenDC = "", string MATVCu ="",string HoTen = "", string GioiTinh = "")
        {
            this._Doi = Doi;
            this._MATV = MATV;
            this._MAQQ = MAQQ;
            this.TenDC = TenDC;
            this._MATVCu = MATVCu;
            this._HoTen = HoTen;
            this._GioiTinh = GioiTinh;
            this._NgaySinh = NgaySinh;
            this._NgayVaoHo = NgayVaoHo;
        }
        public THANHVIEN(DateTime NgaySinh, DateTime NgayVaoHo,int Doi ,string MAQQ = "", string TenDC = "", string MATVCu = "", string HoTen = "", string GioiTinh = "")
        {
            this._Doi = Doi;
            this._MAQQ = MAQQ;
            this.TenDC = TenDC;
            this._MATVCu = MATVCu;
            this._HoTen = HoTen;
            this._GioiTinh = GioiTinh;
            this._NgaySinh = NgaySinh;
            this._NgayVaoHo = NgayVaoHo;
        }
        public THANHVIEN(DateTime NgaySinh, DateTime NgayVaoHo, int Doi, string MAQQ = "", string TenDC = "", string HoTen = "", string GioiTinh = "")
        {
            this._Doi = Doi;
            this._MAQQ = MAQQ;
            this.TenDC = TenDC;
            this._HoTen = HoTen;
            this._GioiTinh = GioiTinh;
            this._NgaySinh = NgaySinh;
            this._NgayVaoHo = NgayVaoHo;
        }

    }
}
