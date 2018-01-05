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
    public partial class ThemTV : Form
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
        private string gioitinh = "";
        private string quanhe = "";
        private string tenDH;
        #endregion
        public ThemTV()
        {
            InitializeComponent();

            txtThanhviencu.Focus();
        }
        public void set_tenDH(string _tenDH)//Lấy tên dòng họ từ form khác
        {
            this.tenDH = _tenDH;
        }
        private void ThemTV_Load(object sender, EventArgs e)
        {
            
            if (tenDH == null)
            {
                txtThanhviencu.Text = "Trần ";
                txtHoTen.Text = "Trần ";
            }
            else
            {
                txtThanhviencu.Text = tenDH;
                txtHoTen.Text = tenDH;
            }
            this.ActiveControl = txtThanhviencu;
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgayVH.Format = DateTimePickerFormat.Custom;
            dtpNgayVH.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Value = DateTime.Now.AddDays(0);
            dtpNgayVH.Value = DateTime.Now.AddDays(0);
            try//Tự động gợi ý dữ liệu khi gõ 
            {
                SqlDataReader dr = bustv.Autocompletar_TextBox();
                while (dr.Read())
                {
                    txtThanhviencu.AutoCompleteCustomSource.Add(dr["HoTen"].ToString());
                }
                dr.Close();
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu của thành viên");
            }
            try//Thêm danh sách quê quán vào comboBox
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
            try//Thêm danh sách nghề nghiệp vào checkedlistBox
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

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (this.txtThanhviencu.TextLength == 0)
            {
                MessageBox.Show("Tên thành viên cũ không được bỏ trống");
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
                    if (rdoNam.Checked == true)
                    {
                        gioitinh = rdoNam.Text;
                    }
                    if (rdoNu.Checked == true)
                    {
                        gioitinh = rdoNu.Text;
                    }
                    if (rdoCon.Checked == true)
                    {
                        quanhe = rdoCon.Text;
                    }
                    if (rdoVoChong.Checked == true)
                    {
                        quanhe = rdoVoChong.Text;
                    }
                    DateTime NgaySinh = dtpNgaySinh.Value.Date;
                    DateTime NgayVH = dtpNgayVH.Value.Date;

                    THANHVIEN tv = new THANHVIEN(NgaySinh, NgayVH,bustv.Generate_Doi(quanhe,bustv.Get_Doi(txtThanhviencu.Text)),
                    bustv.Genarate_MATV(bustv.Get_CountRow()), busqq.Get_QQ(cboQuequan.SelectedItem.ToString()), txtDiachi.Text,
                    bustv.Get_MATVC(txtThanhviencu.Text), txtHoTen.Text, gioitinh);

                    bustv.Insert(tv);
                    foreach (object item in clbNghenghiep.CheckedItems)//Lấy các nghề nghiệp được checked trong checkedlistbox và đưa vào List
                    {
                        List_TenNNghiep.Add(item.ToString());
                    }
                    foreach (string s in List_TenNNghiep)//Duyệt từng tên nghề nghiệp trong List và thực hiện việc lưu nghề nghiệp
                    {
                        TV_NGHENGHIEP tv_nn = new TV_NGHENGHIEP(busnn.Get_NN(s), bustv.Genarate_MATV(bustv.Get_CountRow() - 1));
                        bustv_nn.Insert_TV_NN(tv_nn);
                    }
                    LoaiQuanHe loaiQH = new LoaiQuanHe(bustv.Get_MATVC(txtThanhviencu.Text), bustv.Genarate_MATV(bustv.Get_CountRow() - 1), quanhe);
                    busloai_QH.Insert_LoaiQH(loaiQH);
                    MessageBox.Show("Thêm dữ liệu thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm dữ liệu bị lỗi." + ex.ToString());
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            if (rdoCon.Checked == true)
            {
                dtpNgayVH.Value = dtpNgaySinh.Value;

            }
        }
    }
}
