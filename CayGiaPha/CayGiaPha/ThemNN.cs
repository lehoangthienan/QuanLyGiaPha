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
    public partial class ThemNN : Form
    {
        #region Tạo các đối tượng
        BUS_NgheNghiep nn = new BUS_NgheNghiep();
        BUS_QQ qq = new BUS_QQ();
        BUS_LoaiTT ltt = new BUS_LoaiTT();
        BUS_DDMAITANG ddmt = new BUS_DDMAITANG();
        BUS_NGUYENNHANMAT nnm = new BUS_NGUYENNHANMAT();
        BUS_THAMSO ts = new BUS_THAMSO();
        #endregion
        public ThemNN()
        {
            InitializeComponent();
        }
        QuyDinh qd = new QuyDinh();
        private void button1_Click(object sender, EventArgs e)
        {
                    
            nn.ThemNN(txt_MaNN.Text, txt_TenNN.Text);
            int snn = qd.nn();
            if (snn <= nn.Get_SoNN())
                btn_themNN.Enabled = false;
        }
        private void btn_ThemQQ_Click(object sender, EventArgs e)
        {
            qq.ThemQQ(txt_MaQQ.Text, txt_TenQQ.Text);
            int sqq = qd.qq();
            if (sqq <= qq.Get_SoQQ())
                btn_ThemQQ.Enabled = false;
        }
        private void btn_ThemLTT_Click(object sender, EventArgs e)
        {
            ltt.ThemLTT(txt_MaTT.Text, txt_TenTT.Text);
            int sltt = qd.ltt();
            if (sltt <= ltt.Get_SoLTT())
                btn_ThemLTT.Enabled = false;
        }

        private void btnThem_DDMT_Click(object sender, EventArgs e)
        {
            ddmt.ThemDDMT(txt_MaDD.Text, txt_TenDD.Text);
            int sddmt = qd.ddmt();
            if(sddmt<=ddmt.Get_SoDDMT())
                btnThem_DDMT.Enabled = false;
        }

        private void btnThem_NNM_Click(object sender, EventArgs e)
        {
            nnm.ThemLTT(txt_MaNNM.Text, txt_TenNNM.Text);
            int snnm = qd.nnm();
            if (snnm <= nnm.Get_SoNNM())
                btnThem_NNM.Enabled = false;
        }
        private void ThemNN_Load(object sender, EventArgs e)
        {
            txt_MaNN.Focus();
            int sqq = ts.Get_SoQQ();
            if (sqq <= qq.Get_SoQQ())
                btn_ThemQQ.Enabled = false;
            int snn = ts.Get_SoNN();
            if (snn <= nn.Get_SoNN())
                btn_themNN.Enabled = false;
            int sltt = ts.Get_SoLTT();
            if (sltt <= ltt.Get_SoLTT())
                btn_ThemLTT.Enabled = false;
            int sddmt = ts.Get_SoDDMT();
            if (sddmt <= ddmt.Get_SoDDMT())
                btnThem_DDMT.Enabled = false;
            int snnm = ts.Get_SoNNM();
            if (snnm <= nnm.Get_SoNNM())
                btnThem_NNM.Enabled = false;
        }
    }
}
