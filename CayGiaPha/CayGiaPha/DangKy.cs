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
    public partial class DangKy : DevExpress.XtraEditors.XtraForm
    {
        BUS_ND bus_nd = new BUS_ND();
        public DangKy()
        {
            InitializeComponent();
            txtTenDangNhap.Focus();
            
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            if(txtTenDangNhap.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập tên tài khoản !", "Hãy nhập lại đầy đủ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
            }
            else
            {
                if(txtMatKhau.Text=="")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu !", "Hãy nhập lại đầy đủ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                }
                else
                {
                    if(txtNhapLaiMatKhau.Text=="")
                    {
                        MessageBox.Show("Bạn chưa nhập lại mật khẩu !", "Hãy nhập lại đầy đủ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNhapLaiMatKhau.Focus();
                    }
                    else
                    {
                       if(txtMatKhau.Text!=txtNhapLaiMatKhau.Text)
                        {
                            MessageBox.Show("Mật khẩu bạn nhập lại chưa chính xác !", "Hãy nhập lại chính xác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNhapLaiMatKhau.Focus();
                        }
                       else
                        {
                            NguoiDung nd = new NguoiDung(txtTenDangNhap.Text, txtMatKhau.Text);
                            if(bus_nd.Insert(nd))
                            {
                                MessageBox.Show("Tạo tài khoản thành công", "Complete", MessageBoxButtons.OK);
                            }
                            else
                                MessageBox.Show("Tạo tài khoản không thành công , hãy thử lại", "Fail", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}