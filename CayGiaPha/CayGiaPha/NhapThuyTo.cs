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
using DevExpress.XtraEditors;

namespace CayGiaPha
{
    public partial class NhapThuyTo : DevExpress.XtraEditors.XtraForm
    {
        #region Tạo các đối tượng
        BUS_tv bustv = new BUS_tv();
        BUS_QQ busqq = new BUS_QQ();
        BUS_NgheNghiep busnn = new BUS_NgheNghiep();
        BUS_TV_NN bustv_nn = new BUS_TV_NN();
        BUS_LoaiQH busloai_QH = new BUS_LoaiQH();
        #endregion
        #region Thuộc tính
        List<string> List_TenNNghiep = new List<string>();
        string gioitinh = "";
        #endregion
        public NhapThuyTo()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (this.txtTendongho.TextLength == 0)
            {
                MessageBox.Show("Tên dòng họ không được bỏ trống");
            }
            else if (this.txtHoTen.TextLength == 0)
            {
                MessageBox.Show("Họ tên không được bỏ trống");
            }
            else if (txtDiachi.TextLength == 0)
            {
                MessageBox.Show("Địa chỉ không được bỏ trống");
            }
            else
            {
                try
                {
                    ThemTV themtv = new ThemTV();
                    GhiNhanKetThuc gnkt = new GhiNhanKetThuc();
                    GhiNhanThanhTich gntt = new GhiNhanThanhTich();
                    themtv.set_tenDH(txtTendongho.Text);//Lấy giá trị text của txtTendongho 
                    gnkt.set_tenDH(txtTendongho.Text);//Lấy giá trị text của txtTendongho 
                    gntt.set_tenDH(txtTendongho.Text);//Lấy giá trị text của txtTendongho 
                    if (rdoNam.Checked == true)
                    {
                        gioitinh = rdoNam.Text;
                    }
                    if (rdoNu.Checked == true)
                    {
                        gioitinh = rdoNu.Text;
                    }
                    DateTime NgaySinh = dtpNgaySinh.Value.Date;
                    DateTime NgayVH = dtpNgayVH.Value.Date;

                    THANHVIEN tv = new THANHVIEN(NgaySinh, NgayVH, 1, "TV01", busqq.Get_QQ(cboQuequan.SelectedItem.ToString()), txtDiachi.Text, txtHoTen.Text, gioitinh);
                    bustv.Insert(tv);
                    foreach (object item in clbNghenghiep.CheckedItems)
                    {
                        List_TenNNghiep.Add(item.ToString());
                    }
                    foreach (string s in List_TenNNghiep)
                    {
                        TV_NGHENGHIEP tv_nn = new TV_NGHENGHIEP(busnn.Get_NN(s), bustv.Genarate_MATV(bustv.Get_CountRow() - 1));
                        bustv_nn.Insert_TV_NN(tv_nn);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm dữ liệu bị lỗi." + ex.ToString());
                }
            }
            QuanLyGiaPha f = new QuanLyGiaPha();
            f.Show();
            this.Hide();
        }

        private void NhapThuyTo_Load(object sender, EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgayVH.Format = DateTimePickerFormat.Custom;
            dtpNgayVH.CustomFormat = "dd/MM/yyyy";
            
            try
            {
                SqlDataReader drQQ = busqq.Autocompletar_ComboBoxQQ();
                while (drQQ.Read())
                {
                    cboQuequan.Items.Add(drQQ["TenQQ"].ToString());
                }
                cboQuequan.SelectedIndex = 0;
                drQQ.Close();
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu của quê quán");
            }
            try
            {
                SqlDataReader drNN = busnn.Autocompletar_CheckListNN();
                while (drNN.Read())
                {
                    clbNghenghiep.Items.Add(drNN["TenNNghiep"].ToString());
                }
                drNN.Close();
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu nghề nghiệp");
            }
            bustv.Connection_Close();
        }

        private void txtTendongho_TextChanged(object sender, EventArgs e)
        {
            txtHoTen.Text = txtTendongho.Text;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}