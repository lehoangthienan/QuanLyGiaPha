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
    public partial class TangGiamTV : Form
    {
        #region Tạo các đối tượng
        BUS_tv tv = new BUS_tv();
        #endregion
        public TangGiamTV()
        {
            InitializeComponent();
        }



        private void TangGiamTV_Load(object sender, EventArgs e)
        {
            cboTuNam.Text = "1900";
            cboDenNam.Text = "2015";
            txtTemp.Visible = false;
            BindingSource bs = new BindingSource();
            tv.Get_TVTang(cboTuNam.Text, cboDenNam.Text);
            bs.DataSource = tv.Get_TVTang(cboTuNam.Text, cboDenNam.Text).Tables["THANHVIEN"];
            gridTangTheoNam.DataSource = bs;


            BindingSource bs1 = new BindingSource();
            tv.Get_TAll(cboTuNam.Text, cboDenNam.Text);
            bs1.DataSource = tv.Get_TAll(cboTuNam.Text, cboDenNam.Text).Tables["THANHVIEN"];
            gridTongTangNam.DataSource = bs1;

            BindingSource bs2 = new BindingSource();
            tv.Get_TVGiam(cboTuNam.Text, cboDenNam.Text);
            bs2.DataSource = tv.Get_TVGiam(cboTuNam.Text, cboDenNam.Text).Tables["KETTHUC"];
            gridMatTheoNam.DataSource = bs2;

            BindingSource bs3 = new BindingSource();
            tv.Get_GAll(cboTuNam.Text, cboDenNam.Text);
            bs3.DataSource = tv.Get_GAll(cboTuNam.Text, cboDenNam.Text).Tables["KETTHUC"];
            gridTongMatNam.DataSource = bs3;
        }
        
        public void bingding()
        {
            txtTemp.DataBindings.Clear();
            txtTemp.DataBindings.Add("Text", gridMatTheoNam.DataSource, "NĂM");
        }
        public void bingding1()
        {
            txtTemp.DataBindings.Clear();
            txtTemp.DataBindings.Add("Text", gridTangTheoNam.DataSource, "NĂM");
        }

        private void gridTangTheoNam_Click(object sender, EventArgs e)
        {
            bingding1();
            string t = txtTemp.Text;
            int k = int.Parse(t);
            DanhSachTVTang ct1 = new DanhSachTVTang();
            ct1.set_k(k);
            ct1.Text = "Danh sách các thành viên tăng năm  " + k.ToString();
            ct1.Show();
        }

        private void gridMatTheoNam_Click(object sender, EventArgs e)
        {
            bingding();
            string t = txtTemp.Text;
            int k = int.Parse(t);
            DanhSachTVMat ct = new DanhSachTVMat();
            ct.set_k(k);
            ct.Text = "Danh sách các thành viên mất năm " + k.ToString();
            ct.Show();
        }

        private void gridTongTangNam_Click(object sender, EventArgs e)
        {
            TongDanhSachTVTang ct3 = new TongDanhSachTVTang();
            ct3.Show();
        }

        private void gridTongMatNam_Click(object sender, EventArgs e)
        {
            TongDanhSachTVMat ct4 = new TongDanhSachTVMat();
            ct4.Show();
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            tv.Get_TVTang(cboTuNam.Text, cboDenNam.Text);
            bs.DataSource = tv.Get_TVTang(cboTuNam.Text, cboDenNam.Text).Tables["THANHVIEN"];
            gridTangTheoNam.DataSource = bs;
            BindingSource bs1 = new BindingSource();
            tv.Get_TAll(cboTuNam.Text, cboDenNam.Text);
            bs1.DataSource = tv.Get_TAll(cboTuNam.Text, cboDenNam.Text).Tables["THANHVIEN"];
            gridTongTangNam.DataSource = bs1;

            BindingSource bs2 = new BindingSource();
            tv.Get_TVGiam(cboTuNam.Text, cboDenNam.Text);
            bs2.DataSource = tv.Get_TVGiam(cboTuNam.Text, cboDenNam.Text).Tables["KETTHUC"];
            gridMatTheoNam.DataSource = bs2;

            BindingSource bs3 = new BindingSource();
            tv.Get_GAll(cboTuNam.Text, cboDenNam.Text);
            bs3.DataSource = tv.Get_GAll(cboTuNam.Text, cboDenNam.Text).Tables["KETTHUC"];
            gridTongMatNam.DataSource = bs3;
    }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
