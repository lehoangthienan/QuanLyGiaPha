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
    public partial class GhiNhanKetThuc : Form
    {
        #region Tạo các đối tượng
        BUS_TT bus_tt = new BUS_TT();
        BUS_DDMAITANG bus_ddmaitang = new BUS_DDMAITANG();
        BUS_NGUYENNHANMAT bus_nnmat = new BUS_NGUYENNHANMAT();
        BUS_KT bus_kt = new BUS_KT();
        BUS_tv bus_tv = new BUS_tv();
        BUS_KT_DDMAITANG bus_kt_ddmt = new BUS_KT_DDMAITANG();
        #endregion
        #region Thuộc tính
        List<string> List_MADD = new List<string>();
        #endregion
        public GhiNhanKetThuc()
        {
            InitializeComponent();
        }
        private string tenDH;
        public void set_tenDH(string _tenDH)//Lấy thông tin tên dòng họ từ form khác
        {
            this.tenDH = _tenDH;
        }
        private void GhiNhanKetThuc_Load(object sender, EventArgs e)
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
            dtpNgayMat.Format = DateTimePickerFormat.Custom;
            dtpNgayMat.CustomFormat = "dd/MM/yyyy";
            dtpNgayMat.Value = DateTime.Now.AddDays(0);
            try
            {
                SqlDataReader drHT = bus_tt.Autocompletar_TextBox();//Tự động gợi ý dữ liệu khi gõ 
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
            try//Thêm danh sách nguyên nhân mất vào comboBox
            {
                SqlDataReader drQQ =  bus_nnmat.Autocompletar_ComboBoxNNMat();
                while (drQQ.Read())
                {
                    cboNguyenNhanMat.Items.Add(drQQ["TenNNhan"].ToString());
                }
                cboNguyenNhanMat.SelectedIndex = 0;
                drQQ.Close();
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu nguyên nhân mất");
            }
            try//Thêm danh sách địa điểm mai táng vào checkedlistBox
            {
                SqlDataReader drLoaiTT = bus_ddmaitang.Autocompletar_CheckListDDMaiTang();
                while (drLoaiTT.Read())
                {
                    clbDDMaiTang.Items.Add(drLoaiTT["TenDiaDiem"].ToString());
                }
                drLoaiTT.Close();
                bus_tt.Connection_Close();
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu địa điểm mai táng ");
            }
            gridKetThuc.DataSource = bus_kt.ShowKetThuc();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (this.txtHoTen.TextLength == 0)
            {
                MessageBox.Show("Họ tên không được bỏ trống");
            }
            else if(this.clbDDMaiTang.CheckedItems == null)
            {
                MessageBox.Show("Địa điểm mai táng chưa được chọn");
            }
            try
            {
                DateTime NgayMat = dtpNgayMat.Value;
                KETTHUC kt = new KETTHUC(NgayMat, bus_kt.Generate_MAKT(bus_kt.Get_CountRow()), bus_nnmat.Get_MANNMAT(cboNguyenNhanMat.SelectedItem.ToString()), bus_tv.Get_MATVC(txtHoTen.Text));
                bus_kt.Insert_KT(kt);
                foreach (object item in clbDDMaiTang.CheckedItems)
                {
                    List_MADD.Add(item.ToString());
                }
                foreach (string s in List_MADD)
                {
                    KETTHUC_DDMAITANG kt_ddmt = new KETTHUC_DDMAITANG(bus_ddmaitang.Get_DDMaiTang(s), bus_kt.Generate_MAKT(bus_kt.Get_CountRow() - 1));
                    bus_kt_ddmt.Insert_KT_DDMAITANG(kt_ddmt);
                }
                MessageBox.Show("Ghi dữ liệu thành công");
            }
                catch (Exception ex)
            {
                MessageBox.Show("Ghi dữ liệu bị lỗi." + ex.ToString());
            }
        }
        
    }
}
