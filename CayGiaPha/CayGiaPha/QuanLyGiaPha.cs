using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;

namespace CayGiaPha
{
    public partial class QuanLyGiaPha : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Tạo các đối tượng
        BUS_tv tv = new BUS_tv();
        #endregion
        #region Thuộc tính
        private string _MATV;
        private int number = 0;
        #endregion
        public QuanLyGiaPha()
        {
            InitializeComponent();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThemTV frmThemTV = new ThemTV();
            frmThemTV.ShowDialog();
        }

        private void btnThemTT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GhiNhanThanhTich frmGhiNhanTT = new GhiNhanThanhTich();
            frmGhiNhanTT.ShowDialog();
        }

        private void btnThemKT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GhiNhanKetThuc frmGhiNhanKT = new GhiNhanKetThuc();
            frmGhiNhanKT.ShowDialog();
        }

        private void btnBaoCaoTT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThanhTichTV frmBaoCaoTT = new ThanhTichTV();
            frmBaoCaoTT.ShowDialog();
        }

        private void btnBaoCaoTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TangGiamTV frmBaoCaoTV = new TangGiamTV();
            frmBaoCaoTV.ShowDialog();
        }

        private void btnChangepass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThayDoiMatKhau frmThayDoiThongTin = new ThayDoiMatKhau();
            frmThayDoiThongTin.ShowDialog();
        }

        private void btnXemTT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThongTinTV frmThongTinTV = new ThongTinTV();
            frmThongTinTV.ShowDialog();
        }

        private void btnThayDoiQD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QuyDinh frmThayDoiQD = new QuyDinh();
            frmThayDoiQD.ShowDialog();
        }

        private void llbTKNangCao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            number = 1;
            lbTimKiem.Text = "Từ khóa";
            llbHTTKNangCao.Text = "";
            gbTKNC.Visible = true;
            panelTKN.Size = new Size(415, 300);
            gcTKNhanh.Dock = DockStyle.Fill;
        }

        private void llbAnTKNangCao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            number = 0;
            lbTimKiem.Text = "Họ và tên:";
            llbHTTKNangCao.Text = "Hiển thị tìm kiếm nâng cao";
            gbTKNC.Visible = false;
            panelTKN.Size = new Size(415, 150);
            gcTKNhanh.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtTuKhoa;
            btnXem.Enabled = false;
            txtTemp.Visible = false;
            panelTKN.Size = new Size(415, 150);
            gcTKNhanh.Dock = DockStyle.Fill;
            BindingSource bs = new BindingSource();
            tv.Get_TV();
            bs.DataSource = tv.Get_TV().Tables["THANHVIEN, LOAIQUANHE, THANHVIEN, QUEQUAN, NGHENGHIEP, THANHVIEN_NGHENGHIEP"];
            gridDSTK.DataSource = bs;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string text = "";
            text = txtTuKhoa.Text;
            BindingSource bs = new BindingSource();
            if(number ==0)
            {

                int k = -1;
                if (rdoNam.Checked == true)
                    k = 0;
                if (rdoNu.Checked == true)
                    k = 1;
                tv.Get_TimKiem(text, k);
                
                
                bs.DataSource = tv.Get_TimKiem(text, k).Tables["THANHVIEN, LOAIQUANHE, THANHVIEN, QUEQUAN, NGHENGHIEP, THANHVIEN_NGHENGHIEP"];
                gridDSTK.DataSource = bs;
            }
            else
            {

                int gt = 0;
                if (rdoNam.Checked == true)
                    gt = 1;
                else if (rdoNu.Checked == true)
                    gt = 2;
                int lqh = 0;
                if (rdoCon.Checked == true)
                    lqh = 1;
                else if (rdoVoChong.Checked == true)
                    lqh = 2;
                int t = 0;
                if (rdoHoTen.Checked == true)
                    t = 0;
                else if (rdoDC.Checked == true)
                    t = 1;
                else if (rdoNNghiep.Checked == true)
                    t = 3;
                else if (rdoQQ.Checked == true)
                    t = 2;
                tv.Get_TimKiemNC(text, gt, lqh, t);
                bs.DataSource = tv.Get_TimKiemNC(text, gt, lqh, t).Tables["THANHVIEN, LOAIQUANHE, THANHVIEN, QUEQUAN, NGHENGHIEP, THANHVIEN_NGHENGHIEP"];
                gridDSTK.DataSource = bs;
            }
            if (gridViewDSTK.RowCount == 0)
                MessageBox.Show("Kết quả tìm kiếm không có.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            ThongTinTV frmThongTinTV = new ThongTinTV();
            frmThongTinTV.set_MATV(_MATV);
            frmThongTinTV.ShowDialog();
        }

        private void btnThemQD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThemNN frmThemNN = new ThemNN();
            frmThemNN.ShowDialog();
        }
        public void bingding()//Đưa dữ liệu mã thành viên vào TextBox
        {
            txtTemp.DataBindings.Clear();
            txtTemp.DataBindings.Add("Text", gridDSTK.DataSource, "Mã thành viên");
        }
        private void gridDSTK_Click(object sender, EventArgs e)
        {
            btnXem.Enabled = true;
            bingding();
            _MATV = (txtTemp.Text).Trim();//cắt khoảng trắng ở cuối chuỗi
        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void QuanLyGiaPha_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        

        private void txtTuKhoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnTimKiem_Click(sender, e);
        }
       
    }         
}
