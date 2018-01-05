using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DTO;
using BUS;
namespace CayGiaPha
{
    public partial class DanhSachTVTang : DevExpress.XtraEditors.XtraForm
    {
        BUS_tv tv = new BUS_tv();
        public DanhSachTVTang()
        {
            InitializeComponent();
        }
        public int k = 0;
        TangGiamTV tg = new TangGiamTV();

        BindingSource bs = new BindingSource();
        private void ChiTiet1_Load(object sender, EventArgs e)
        {
            tv.Get_TV_TangTheoNam(k.ToString());
            bs.DataSource = tv.Get_TV_TangTheoNam(k.ToString()).Tables["THANHVIEN"];
            gridCTTangTungNam.DataSource = bs;
        }
        public void set_k(int k)
        {
            this.k = k;
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel_TTVofYear excel = new ExportToExcel_TTVofYear();
                DataTable dt = (DataTable)bs.DataSource;
                excel.Export(dt, "Danh sach", "DANH SÁCH THÀNH VIÊN TĂNG NĂM " + k.ToString());
            }
            catch
            {
                MessageBox.Show("Again!");
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}