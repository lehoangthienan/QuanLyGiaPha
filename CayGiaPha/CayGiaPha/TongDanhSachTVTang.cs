using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;
namespace CayGiaPha
{
    public partial class TongDanhSachTVTang : Form
    {
        BUS_tv tv = new BUS_tv();
        public TongDanhSachTVTang()
        {
            InitializeComponent();
        }
        public int k = 0;
        TangGiamTV tg = new TangGiamTV();

        private void ChiTiet3_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();

            tv.Get_ALL(k.ToString());
            bs.DataSource = tv.Get_ALL(k.ToString()).Tables["THANHVIEN"];
            gridCTTongTangNam.DataSource = bs;
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            tv.Get_ALL(k.ToString());
            bs.DataSource = tv.Get_ALL(k.ToString()).Tables["THANHVIEN"];
            gridCTTongTangNam.DataSource = bs;
            ExportToExcel_TVT excel = new ExportToExcel_TVT();
            DataTable dt = (DataTable)bs.DataSource;
            excel.Export(dt, "Danh sach", "DANH SÁCH THÀNH VIÊN TĂNG");
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
