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
using BUS;
using DTO;

namespace CayGiaPha
{
    public partial class DangNhap : Form
    {
        BUS_tv bustv = new BUS_tv();
        public DangNhap()
        {
            InitializeComponent();
            txtTK.Focus();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtTK.Text=="")
                {
                    MessageBox.Show("Bạn chưa nhập tài khoản !","Hãy nhập đầy đủ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTK.Focus();
                }
                else
                {
                    if(txtMK.Text=="")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu !", "Hãy nhập đầy đủ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMK.Focus();
                    }
                    else
                    {
                        SqlConnection _cn = new SqlConnection(@"Data Source=THIENAN\SQLEXPRESS;Initial Catalog=QUANLYCAYGIAPHA;Integrated Security=True");
                        _cn.Open();
                        string tk = txtTK.Text;
                        string mk = txtMK.Text;
                        string sql = "select * from NguoiDung where TaiKhoan='" + tk + "' and MatKhau='" + mk + "'";
                        SqlCommand cmd = new SqlCommand(sql, _cn);
                        SqlDataReader dta = cmd.ExecuteReader();
                        if (dta.Read() == true)
                        {
                            if (bustv.Check_SQL() == 0)
                            {
                                NhapThuyTo ntt = new NhapThuyTo();
                                ntt.ShowDialog();
                                this.Hide();
                            }
                            else if (bustv.Check_SQL() == 1)
                            {
                                QuanLyGiaPha f1 = new QuanLyGiaPha();
                                f1.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nhập sai tài khoản hoặc mật khẩu !", "Hãy nhập lại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
               
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối !");
            }
        }
        


        private void txtMK_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (e.KeyChar ==(char)Keys.Enter)
                {
                    btnDangNhap.Focus();
                }
            
        }
    }
}
