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
    public partial class TongDanhSachTVMat : Form
    {
        BUS_tv tv = new BUS_tv();
        public TongDanhSachTVMat()
        {
            InitializeComponent();
        }
        public int k = 0;
        TangGiamTV tg = new TangGiamTV();
        private void ChiTiet4_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();

            tv.Get_MatALL(k.ToString());
            bs.DataSource = tv.Get_MatALL(k.ToString()).Tables["THANHVIEN,KETTHUC"];
            gridCTTongMatNam.DataSource = bs;
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            tv.Get_MatALL(k.ToString());
            bs.DataSource = tv.Get_MatALL(k.ToString()).Tables["THANHVIEN,KETTHUC"];
            gridCTTongMatNam.DataSource = bs;

            ExportToExcel_GTV excel = new ExportToExcel_GTV();
            DataTable dt = (DataTable)bs.DataSource;
            excel.Export(dt, "Danh sach", "DANH SÁCH THÀNH VIÊN GIẢM ");
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
