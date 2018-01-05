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
    public partial class ThayDoiMatKhau : Form
    {
        #region Tạo các đối tượng
        BUS_ND bus_nd = new BUS_ND();
        #endregion
        public ThayDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tài khoản !", "Hãy nhập đầy đủ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
            }
            else
            {
                if (txtMKHienTai.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu cũ !", "Hãy nhập đầy đủ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMKHienTai.Focus();
                }
                else
                {
                    if (txtMKMoi.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu mới !", "Hãy nhập đầy đủ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMKMoi.Focus();
                    }
                    else
                    {
                        if (txtXacNhanMK.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập lại mật khẩu mới !", "Hãy nhập đầy đủ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtXacNhanMK.Focus();
                        }
                        else
                        {
                            SqlConnection _cn = new SqlConnection(@"Data Source=THIENAN\SQLEXPRESS;Initial Catalog=QUANLYCAYGIAPHA;Integrated Security=True");
                            _cn.Open();
                            string tk = txtTenDangNhap.Text;
                            string mk = txtMKHienTai.Text;
                            string sql = "select * from NguoiDung where TaiKhoan='" + tk + "' and MatKhau='" + mk + "'";
                            SqlCommand cmd = new SqlCommand(sql, _cn);
                            SqlDataReader dta = cmd.ExecuteReader();
                            if (dta.Read() == true)
                            {
                                NguoiDung nd = new NguoiDung(txtTenDangNhap.Text, txtMKMoi.Text);
                                if (bus_nd.Update(nd))
                                {
                                    MessageBox.Show("Thay đổi mật khẩu thành công !", "Complete", MessageBoxButtons.OK);
                                }
                                else
                                    MessageBox.Show("Thay đổi mật khẩu thất bại , hãy thử lại", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                            else
                            {
                                MessageBox.Show("Nhập sai tài khoảng hoặc mật khẩu cũ !", "Hãy nhập lại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }

        }
        

        private void ThayDoiMatKhau_Load_1(object sender, EventArgs e)
        {

            txtTenDangNhap.Focus();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
