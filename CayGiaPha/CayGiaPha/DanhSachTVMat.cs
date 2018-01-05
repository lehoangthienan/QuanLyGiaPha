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
    public partial class DanhSachTVMat : Form
    {
        BUS_tv tv = new BUS_tv();

        public DanhSachTVMat()
        {
            InitializeComponent();
        }
        public int k = 0;
        TangGiamTV tg = new TangGiamTV();
        BindingSource bs = new BindingSource();
        private void ChiTiet_Load(object sender, EventArgs e)
        {
            tv.Get_TV_MatTheoNam(k.ToString());
            bs.DataSource = tv.Get_TV_MatTheoNam(k.ToString()).Tables["THANHVIEN,KETTHUC"];
            gridCTMatTungNam.DataSource = bs;
        }
        public void set_k(int k)
        {
            this.k = k;
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel_TVGofYear excel = new ExportToExcel_TVGofYear();
                DataTable dt = (DataTable)bs.DataSource;
                excel.Export(dt, "Danh sach", "DANH SÁCH THÀNH VIÊN GIẢM NĂM " + k.ToString());
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
