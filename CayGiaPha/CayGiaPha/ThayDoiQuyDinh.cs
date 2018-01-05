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
    public partial class QuyDinh : Form
    {
        BUS_THAMSO ts = new BUS_THAMSO();
        QuanLyGiaPha cgp = new QuanLyGiaPha();
        public QuyDinh()
        {
            InitializeComponent();
        }
        public int qq()
        {
            return int.Parse(qd_qq.Text);
        }
        public int nn()
        {
            return int.Parse(qd_nn.Text);
        }
        public int ddmt()
        {
            return int.Parse(qd_ddmt.Text);
        }
        public int nnm()
        {
            return int.Parse(qd_nnm.Text);
        }
        public int ltt()
        {
            return int.Parse(qd_ltt.Text);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            qd_ddmt.Enabled = true;
            qd_ltt.Enabled = true;
            qd_nn.Enabled = true;
            qd_nnm.Enabled = true;
            qd_qq.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            qd_ddmt.Enabled = false;
            qd_ltt.Enabled = false;
            qd_nn.Enabled = false;
            qd_nnm.Enabled = false;
            qd_qq.Enabled = false;
            //Sửa lại thông tin khi thay đổi
            ts.Set_SoNN(qd_nn.Text);
            ts.Set_SoQQ(qd_qq.Text);
            ts.Set_SoLTT(qd_ltt.Text);
            ts.Set_SoNNM(qd_nnm.Text);
            ts.Set_SoDDMT(qd_ddmt.Text);
        }

        private void QuyDinh_Load(object sender, EventArgs e)
        {
            //Đưa thông tin từ DB lên gán cho các TextBox
            qd_nn.Text = ts.Get_SoNN().ToString();
            qd_qq.Text = ts.Get_SoQQ().ToString();
            qd_ltt.Text = ts.Get_SoLTT().ToString();
            qd_nnm.Text = ts.Get_SoNNM().ToString();
            qd_ddmt.Text = ts.Get_SoDDMT().ToString();
        }
    }

}
