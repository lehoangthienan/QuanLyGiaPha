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
    public partial class ThanhTichTV : Form
    {
        #region Tạo các đối tượng
        BUS_TT tt = new BUS_TT();
        #endregion
        public ThanhTichTV()
        {
            InitializeComponent();

        }
        BindingSource bs = new BindingSource();

        private void ThanhTichTV_Load(object sender, EventArgs e)
        {
            cboTuNam.Text = "1900";
            cboDenNam.Text = "2015";
            tt.Get_TT(cboTuNam.Text, cboDenNam.Text);
            bs.DataSource = tt.Get_TT(cboTuNam.Text, cboDenNam.Text).Tables["THANHTICH,THANHVIEN,LOAITHANHTICH"];
            gridControl1.DataSource = bs;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            tt.Get_TT(cboTuNam.Text, cboDenNam.Text);
            bs.DataSource = tt.Get_TT(cboTuNam.Text, cboDenNam.Text).Tables["THANHTICH,THANHVIEN,LOAITHANHTICH"];
            gridControl1.DataSource = bs;
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            ExportToExcel_LTT excel = new ExportToExcel_LTT();
            DataTable dt = (DataTable)bs.DataSource;
            excel.Export(dt, "Danh sach", "DANH SÁCH THÀNH TÍCH CÁC THÀNH VIÊN TỪ NĂM " + cboTuNam.Text + " ĐẾN NĂM " + cboDenNam.Text);//Xuất file Excel
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
