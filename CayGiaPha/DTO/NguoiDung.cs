using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class NguoiDung
    {
       private  string _TaiKhoan;
       private string _MatKhau;

        public string TaiKhoan
        {
            get
            {
                return _TaiKhoan;
            }

            set
            {
                _TaiKhoan = value;
            }
        }

        public string MatKhau
        {
            get
            {
                return _MatKhau;
            }

            set
            {
                _MatKhau = value;
            }
        }
        public NguoiDung(string TaiKhoan="",string MatKhau="")
        {
            this._TaiKhoan = TaiKhoan;
            this._MatKhau = MatKhau;
        }
    }
}
