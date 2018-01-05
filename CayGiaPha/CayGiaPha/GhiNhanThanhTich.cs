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
    public partial class GhiNhanThanhTich : Form
    {
        #region Tạo các đối tượng
        BUS_TT bustt = new BUS_TT();
        BUS_tv bustv = new BUS_tv();
        BUS_LoaiTT busloaiTT = new BUS_LoaiTT();
        #endregion
        #region Thuộc tính
        List<string> List_TenLoaiTT = new List<string>();
        #endregion
        public GhiNhanThanhTich()
        {
            InitializeComponent();
        }
        private string tenDH;
        public void set_tenDH(string _tenDH)//Lấy thông tin tên dòng họ từ form khác
        {
            this.tenDH = _tenDH;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            if(this.txtHoTen.TextLength == 0)
            {
                MessageBox.Show("Họ tên không được bỏ trống");
            }
            else
            {
                try
                {
                    DateTime NgayPS = dtpNgayPS.Value;
                    foreach (object item in clbLoaiTT.CheckedItems)
                    {
                        List_TenLoaiTT.Add(item.ToString());
                    }
                    foreach (string s in List_TenLoaiTT)
                    {
                        THANHTICH tt = new THANHTICH(NgayPS, bustv.Get_MATVC(txtHoTen.Text),busloaiTT.Get_LoaiTT(s));
                        bustt.Insert(tt);
                    }
                    MessageBox.Show("Ghi dữ liệu thành công");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ghi dữ liệu bị lỗi." + ex.ToString());
                }
            }
        }

        private void GhiNhanThanhTich_Load(object sender, EventArgs e)
        {
            if (tenDH == null)
            {
                txtHoTen.Text = "Trần ";
            }
            else
            {
                txtHoTen.Text = tenDH;
            }
            txtHoTen.Focus();
            dtpNgayPS.Format = DateTimePickerFormat.Custom;
            dtpNgayPS.CustomFormat = "dd/MM/yyyy";
            dtpNgayPS.Value = DateTime.Now.AddDays(0);
            try////Tự động gợi ý dữ liệu khi gõ 
            {
                SqlDataReader drHT = bustt.Autocompletar_TextBox();
                while (drHT.Read())
                {
                    txtHoTen.AutoCompleteCustomSource.Add(drHT["HoTen"].ToString());
                }
                drHT.Close();
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu của thành viên");
            }
            try//Thêm danh sách thành tích vào checkedlistBox
            {
                SqlDataReader drLoaiTT = busloaiTT.Autocompletar_CheckListLoaiTT();
                while (drLoaiTT.Read())
                {
                    clbLoaiTT.Items.Add(drLoaiTT["TenTT"].ToString());
                }
                drLoaiTT.Close();
                bustt.Connection_Close();
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu loại thành tích");
            }
            gridThanhTich.DataSource = bustt.ShowThanhTich();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = System.DateTime.Now;
        }
    }
}
