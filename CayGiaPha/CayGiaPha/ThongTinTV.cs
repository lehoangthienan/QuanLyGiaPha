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
    public partial class ThongTinTV : Form
    {
        #region Tạo các đối tượng 
        BUS_tv tv = new BUS_tv();
        BUS_NgheNghiep tv_nn = new BUS_NgheNghiep();
        BUS_TT bustt = new BUS_TT();
        BUS_KT buskt = new BUS_KT();
        BUS_DDMAITANG busddmt = new BUS_DDMAITANG();
        BUS_QQ busqq = new BUS_QQ();
        BUS_NGUYENNHANMAT busnnm = new BUS_NGUYENNHANMAT();
        BUS_KT_DDMAITANG bus_ktddmt = new BUS_KT_DDMAITANG();
        BUS_TV_NN bus_tvnn = new BUS_TV_NN();
        BUS_LoaiQH bus_loaiqh = new BUS_LoaiQH();
        BUS_LoaiTT bus_loaitt = new BUS_LoaiTT();
        #endregion
        #region Thuộc tính
        private List<string> List_TenNNghiep = new List<string>();
        private List<string> List_MADD = new List<string>();
        public string MATV;
        private string gioitinh;
        private string quanhe;
        QuanLyGiaPha form1 = new QuanLyGiaPha();
        private string matv;
        private string TenQQ;
        private string TenNNM;
        #endregion
        public ThongTinTV()
        {
            InitializeComponent();
        }
        public void set_MATV(string _MATV)//Lấy mã thành viên từ form khác
        {
            this.MATV = _MATV;
        }
        private void ThongTinTV_Load(object sender, EventArgs e)
        {
            datagridTT.ReadOnly = true;
            matv = MATV;
            btnLuu.Enabled = false;
            if (tv.Get_GT(matv) == 0)
            {
                rdoNu.Checked = true;
                rdoNam.Enabled = false;
            }
            else
            {
                rdoNam.Checked = true;
                rdoNu.Enabled = false;
            }
            if (tv.Get_QH(matv) == 1)
            {
                rdoCon.Checked = true;
                rdoVoChong.Enabled = false;
            }
            else
            {
                rdoVoChong.Checked = true;
                rdoCon.Enabled = false;
            }
            // Hiển thị sơ yếu lý lịch của thành viên
            txtHoTen.DataBindings.Add("Text", tv.Get_Ten(matv), "HoTen", true);// Đổ dữ liệu của thành viên đã lưu vào các control
            txtThanhviencu.DataBindings.Add("Text", tv.Get_TVT(matv), "HoTen", true);
            txtDiachi.DataBindings.Add("Text", tv.Get_DiaChi(matv), "TenDC", true);
            dtpNgaySinh.DataBindings.Add("Text", tv.Get_NS(matv), "NgaySinh", true);
            dtpNgayVH.DataBindings.Add("Text", tv.Get_NVH(matv), "NgayVaoHo", true);
            cboQuequan.DataSource = tv.Get_QQ(matv);// Lấy thông tin quê quán và đưa vào comboBox
            cboQuequan.ValueMember = "TenQQ";
            //Lấy thông tin nghề nghề của thành viên đó và đưa vào checkedlistbox
            DataTable dt1 = tv.Get_NNghiep(matv);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                clbNghenghiep.Items.Add(dt1.Rows[i]["TenNNghiep"].ToString());
                clbNghenghiep.SetItemCheckState(i, CheckState.Checked);
            }
            //Hiển thị thành tích của thành viên
            datagridTT.DataSource = bustt.Get_Thanhtich(matv);
            //Hiển thị thông tin mất của thành viên 
            if (buskt.Get_MAKT(matv) != null)
            {
                rdoDaChet.Checked = true;
                rdoConSong.Enabled = false;
                dtpNgayMat.DataBindings.Add("Text", buskt.Get_NgayMat(matv), "NgayMat", true);
                cboNguyenNhanMat.DataSource = buskt.Get_NNhan(matv);
                cboNguyenNhanMat.ValueMember = "TenNNhan";
                //        }
                DataTable dt2 = buskt.Get_DDMT(matv);
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    clbDDMaiTang.Items.Add(dt2.Rows[i]["TenDiaDiem"].ToString());
                    clbDDMaiTang.SetItemCheckState(i, CheckState.Checked);
                }
            }
            else
            {
                rdoConSong.Checked = true;
                rdoDaChet.Enabled = false;
                dtpNgayMat.Visible = false;
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TenQQ = cboQuequan.Text;
            TenNNM = cboNguyenNhanMat.Text;
            matv = MATV;
            datagridTT.ReadOnly = false;
            txtThanhviencu.ReadOnly = false;
            rdoCon.Enabled = true;
            rdoNam.Enabled = true;
            rdoNu.Enabled = true;
            rdoVoChong.Enabled = true;
            txtHoTen.ReadOnly = false;
            txtDiachi.ReadOnly = false;
            dtpNgaySinh.Enabled = true;
            dtpNgayVH.Enabled = true;
            cboQuequan.DropDownStyle = ComboBoxStyle.DropDown;
            clbNghenghiep.Enabled = true;
            // Hiển thị dữ liệu quê quán
            cboQuequan.DataSource = null;
            try
            {
                SqlDataReader drQQ = busqq.Autocompletar_ComboBoxQQ();
                while (drQQ.Read())
                {
                    cboQuequan.Items.Add(drQQ["TenQQ"].ToString());
                }
                cboQuequan.Text = TenQQ;
                drQQ.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không có dữ liệu của quê quán"+ex.ToString());
            }
            
            //Hiển thị dữ liệu nguyên nhân mất
            if (rdoDaChet.Checked == true)
            {
                dtpNgayMat.Enabled = true;
                cboNguyenNhanMat.DropDownStyle = ComboBoxStyle.DropDown;
                clbDDMaiTang.Enabled = true;
                DataTable dt2 = buskt.Get_DDMT(matv);
                cboNguyenNhanMat.DataSource = null;
                try
                {
                    SqlDataReader drQQ = busnnm.Autocompletar_ComboBoxNNMat();
                    while (drQQ.Read())
                    {
                        cboNguyenNhanMat.Items.Add(drQQ["TenNNhan"].ToString());
                    }
                    cboNguyenNhanMat.Text = TenNNM;
                    drQQ.Close();
                }
                catch
                {
                    MessageBox.Show("Không có dữ liệu nguyên nhân mất");
                }

                //Hiển thị tất cả các địa điểm mai táng và đánh dấu địa điểm mai táng của thành viên được xem
                try
                {
                    SqlDataReader drLoaiTT = busddmt.Autocompletar_CheckListDDMaiTang();
                    while (drLoaiTT.Read())
                    {
                        clbDDMaiTang.Items.Add(drLoaiTT["TenDiaDiem"].ToString());

                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            clbDDMaiTang.Items.Add(dt2.Rows[i]["TenDiaDiem"].ToString());
                            clbDDMaiTang.SetItemCheckState(i, CheckState.Checked);
                        }
                    }
                    drLoaiTT.Close();
                    bustt.Connection_Close();
                }
                catch
                {
                    MessageBox.Show("Không có dữ liệu địa điểm mai táng ");
                }
            }
            ////Hiển thị tất cả nghề nghiệp và đánh dấu nghề nghiệp của thành viên được xem

            DataTable dt1 = tv.Get_NNghiep(matv);
            try
            {
                SqlDataReader drNN = tv_nn.Autocompletar_CheckListNN();
                while (drNN.Read())
                {
                    clbNghenghiep.Items.Add(drNN["TenNNghiep"].ToString());
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (dt1.Rows[i]["TenNNghiep"].ToString() == drNN["TenNNghiep"].ToString())
                            clbNghenghiep.SetItemCheckState(i, CheckState.Checked);

                    }
                }
                drNN.Close();
                tv.Connection_Close();
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu nghề nghiệp");
            }
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            matv = MATV;
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa tất cả thông tin thành viên này không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    tv.xoaThanhVien(matv);
                    MessageBox.Show("Xóa thông tin thành viên thành công");
                    btnThoat_Click(sender, e);
                }
                catch
                {
                    MessageBox.Show("Xóa thông tin thành viên bị lỗi");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string QQ = cboQuequan.Text;
            string NNM = cboNguyenNhanMat.Text;
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn lưu tất cả thông tin thành viên này không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                matv = MATV;
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
                        //Lưu sơ yếu lý lịch
                        DateTime NgaySinh = dtpNgaySinh.Value.Date;
                        DateTime NgayVH = dtpNgayVH.Value.Date;

                        THANHVIEN tv_up = new THANHVIEN(NgaySinh, NgayVH, tv.Generate_Doi(quanhe, tv.Get_Doi(txtThanhviencu.Text)), busqq.Get_QQ(cboQuequan.SelectedItem.ToString()), txtDiachi.Text, tv.Get_MATVC(txtThanhviencu.Text), txtHoTen.Text, gioitinh);
                        tv.Update_TV(tv_up, matv);
                        foreach (object item in clbNghenghiep.CheckedItems)//Lấy các nghề nghiệp được checked trong checkedlistbox và đưa vào List
                        {
                            List_TenNNghiep.Add(item.ToString());
                        }
                        bus_tvnn.xoaTV_NN(matv);//Xóa danh sách nghề nghiệp của thành viên để lưu mới lại
                        foreach (string s in List_TenNNghiep)//Duyệt từng tên nghề nghiệp trong List và thực hiện việc lưu nghề nghiệp
                        {
                            TV_NGHENGHIEP tv_nn_up = new TV_NGHENGHIEP(tv_nn.Get_NN(s), matv);
                            bus_tvnn.Insert_TV_NN(tv_nn_up);
                        }
                        LoaiQuanHe loaiQH = new LoaiQuanHe(tv.Get_MATVC(txtThanhviencu.Text), quanhe);
                        bus_loaiqh.Update_LoaiQH(loaiQH, matv);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa dữ liệu bị lỗi." + ex.ToString());
                    }
                }
                // Lưu dữ liệu thành tích
                    bustt.xoaThanhTich(matv);
                    for (int i = 0; i < datagridTT.Rows.Count-1; i++)//Duyệt từng dòng trong danh sách thành tích và lưu chúng lại khi sửa xong
                    {
                        DateTime ngaypsUP = (DateTime)datagridTT.Rows[i].Cells["Ngày phát sinh"].Value;
                        string s = (string)datagridTT.Rows[i].Cells["Tên thành tích"].Value;
                        THANHTICH tt = new THANHTICH(ngaypsUP, matv, bus_loaitt.Get_LoaiTT(s));
                        bustt.Insert(tt);
                    }
                
                if (rdoConSong.Checked == true)
                {
                    buskt.xoaKetThuc(buskt.Get_MAKT(matv));
                    dtpNgayMat.Visible = false;
                }
                else if (rdoDaChet.Checked == true)
                {
                    if (this.clbDDMaiTang.CheckedItems == null)
                    {
                        MessageBox.Show("Địa điểm mai táng chưa được chọn");
                    }
                    try
                    {
                        DateTime NgayMat = dtpNgayMat.Value;
                        KETTHUC kt_up = new KETTHUC(NgayMat, busnnm.Get_MANNMAT(cboNguyenNhanMat.SelectedItem.ToString()));
                        buskt.Update_KT(kt_up, matv);//Lưu lại kết thúc khi chỉnh sửa xong
                        bus_ktddmt.xoaKetThuc_DDMT(buskt.Get_MAKT(matv));
                        foreach (object item in clbDDMaiTang.CheckedItems)
                        {
                            List_MADD.Add(item.ToString());
                        }
                        foreach (string s in List_MADD)
                        {
                            KETTHUC_DDMAITANG kt_ddmt = new KETTHUC_DDMAITANG(busddmt.Get_DDMaiTang(s), buskt.Get_MAKT(matv));
                            bus_ktddmt.Insert_KT_DDMAITANG(kt_ddmt);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa dữ liệu bị lỗi." + ex.ToString());
                    }
                }
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                // Thực hiện viện hiển thị thông tin của thành viên, không thể sửa
                if (tv.Get_GT(matv) == 0)
                {
                    rdoNu.Checked = true;
                    rdoNam.Enabled = false;
                }
                else
                {
                    rdoNam.Checked = true;
                    rdoNu.Enabled = false;
                }
                if (tv.Get_QH(matv) == 1)
                {
                    rdoCon.Checked = true;
                    rdoVoChong.Enabled = false;
                }
                else
                {
                    rdoVoChong.Checked = true;
                    rdoCon.Enabled = false;
                }
                // Hiển thị sơ yếu lý lịch của thành viên
                txtThanhviencu.ReadOnly = true;
                txtHoTen.ReadOnly = true;
                txtDiachi.ReadOnly = true;
                dtpNgaySinh.Enabled = false;
                dtpNgayVH.Enabled = false;
                cboQuequan.DataSource = null;
                cboQuequan.DataSource = tv.Get_QQ(matv);
                cboQuequan.ValueMember = "TenQQ";
                //cboQuequan.DropDownStyle = ComboBoxStyle.DropDownList;
                DataTable dt1 = tv.Get_NNghiep(matv);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    clbNghenghiep.Items.Add(dt1.Rows[i]["TenNNghiep"].ToString());
                    clbNghenghiep.SetItemCheckState(i, CheckState.Checked);
                }
                clbNghenghiep.Enabled = false;
                //Hiển thị thông tin mất của thành viên 
                if (buskt.Get_MAKT(matv) != null)
                {
                    rdoDaChet.Checked = true;
                    dtpNgayMat.Enabled = false;
                    cboNguyenNhanMat.DataSource = null;
                    cboNguyenNhanMat.DataSource = buskt.Get_NNhan(matv);
                    cboNguyenNhanMat.ValueMember = "TenNNhan";
                    //cboNguyenNhanMat.DropDownStyle = ComboBoxStyle.DropDownList;
                    DataTable dt2 = buskt.Get_DDMT(matv);
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        clbDDMaiTang.Items.Add(dt2.Rows[i]["TenDiaDiem"].ToString());
                        clbDDMaiTang.SetItemCheckState(i, CheckState.Checked);
                    }
                    clbDDMaiTang.Enabled = false;
                }
                else
                {
                    rdoConSong.Checked = true;
                }
                cboQuequan.Text = QQ;
                cboNguyenNhanMat.Text = NNM;
            }
        }
        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void datagridTT_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string header = datagridTT.Columns[datagridTT.CurrentCell.ColumnIndex].HeaderText;
            if(header.Equals("Tên thành tích"))
            {
                TextBox auto = e.Control as TextBox;
                if (auto != null)
                {
                    auto.AutoCompleteMode = AutoCompleteMode.Suggest;
                    auto.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection sc = new AutoCompleteStringCollection();
                    fillauto(sc);
                    auto.AutoCompleteCustomSource = sc;
                }
            }
        }

        private void fillauto(AutoCompleteStringCollection sc)
        {
            DataTable tenTT = bus_loaitt.Get_TenTT();
            for (int i = 0; i < tenTT.Rows.Count; i++)
            {
                sc.Add(tenTT.Rows[i]["TenTT"].ToString());
            }
        }
    }
}
