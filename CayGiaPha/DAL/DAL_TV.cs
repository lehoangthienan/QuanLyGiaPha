using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAL
{
    public class DAL_TV:BDConnect
    {
        
        DataTable dt = new DataTable();
        public SqlCommand cmd;
        public SqlDataReader dr;

        public void Connection_Close()
        {
            _cn.Close();
        }
        public int Check_SQL()//Kiểm tra xem trong DB có thành viên nào không
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from THANHVIEN", _cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int row = dt.Rows.Count;
            if (row != 0)
                 return 1;
            else
                return 0;
;        }
        public int Get_CountRow()//Lấy số dòng của bảng Thành viên
        {
            int countRow;
            SqlDataAdapter da = new SqlDataAdapter("Select * from THANHVIEN", _cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return countRow = dt.Rows.Count;
        }
        
        public SqlDataReader Autocompletar_TextBox()//Đọc dữ liệu Họ tên thành viên 
        {
            try
            {
                _cn.Open();
                cmd = new SqlCommand("Select HoTen from THANHVIEN", _cn);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;
            }
        }
        #region Thêm xóa sửa thành viên
        public bool Insert(THANHVIEN tv)//Thêm thành viên mới vào DB
        {
            _cn.Open();
            
            string SQL = "INSERT INTO THANHVIEN(MATV,HoTen,GioiTinh,NgaySinh,NgayVaoHo,Doi,MAQQ,TenDC,MATVCu) VALUES ('" + tv.MATV+ "',N'" + tv.HoTen+ "',N'" + tv.GioiTinh + "', '" +tv.NgaySinh + "', '" + tv.NgayVaoHo + "','" + tv.Doi+ "','" + tv.MAQQ + "', N'" + tv.TenDC + "', '" + tv.MATVCu + "')";

            SqlCommand cmd = new SqlCommand(SQL, _cn);
            cmd.ExecuteNonQuery();
            _cn.Close();
            return true;
            
        }
        public bool xoaThanhVien(string TV_ID)//Xóa thành viên trong DB
        {
            try
            {
                // Ket noi
                _cn.Open();
                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string sqlstr = "";
                sqlstr = "delete from THANHTICH where MATV='";
                sqlstr += TV_ID;
                sqlstr += "' delete from LOAIQUANHE where MATV_S='";
                sqlstr += TV_ID;
                sqlstr += "' delete from KETTHUC where MATV='";
                sqlstr += TV_ID;
                sqlstr += "' delete from THANHVIEN_NGHENGHIEP where MATV='";
                sqlstr += TV_ID;
                sqlstr += "' delete from THANHVIEN where MATV='";
                sqlstr += TV_ID;
                sqlstr += "'";
                SqlCommand cmd = new SqlCommand(sqlstr, _cn);

                cmd.ExecuteNonQuery();
                _cn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update_TV(THANHVIEN tv_ud,string MATV)//Sửa thông tin thành viên đã lưu trong DB
        {
                // Ket noi
                _cn.Open();

                // Query string
                string SQL = "UPDATE THANHVIEN SET HoTen= N'" + tv_ud.HoTen + "',Doi ='"+tv_ud.Doi+"',GioiTinh= N'" + tv_ud.GioiTinh + "',NgaySinh = '" + tv_ud.NgaySinh + "',NgayVaoHo= '" + tv_ud.NgayVaoHo + "',MAQQ= '" + tv_ud.MAQQ+ "',TenDC= N'" + tv_ud.TenDC + "',MATVCu = '" + tv_ud.MATVCu + "'WHERE MATV = '" + MATV+"'";

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, _cn);

                // Query và kiểm tra
                cmd.ExecuteNonQuery();
                _cn.Close();
                return true;
          
        }
        #endregion
        #region Genarate
        public int Generate_Doi(string tenQH,int i)//Tự động cập nhật đời khi thêm mới thành viên
        {
            if (tenQH == "Con")
                i += 1;
            if(tenQH =="Vợ/Chồng")
                 return i;
            return i;
        }
        public string Generate_MATV(int countrow)//Tự động thêm Mã thành viên khi thêm thành viên mới
        {
            string temp = "TV";
            string s = "";
            if (countrow < 9)
            {
                s = temp + "0" + Convert.ToString(countrow + 1);
            }
            else
                s = temp + Convert.ToString(countrow + 1);
            return s;
        }
        #endregion
        #region Tìm kiếm
        public DataSet Get_TimKiem(string t, int k)//Lấy danh sách tìm kiếm được theo khóa
        {
            try
            {
                SqlDataAdapter da;
                DataSet ds;
                string sqlstr = "";
                sqlstr = "select tvm.MATV 'Mã thành viên', tvm.HoTen 'Họ Tên', tvm.GioiTinh 'Giới tính', tvm.NgaySinh 'Ngày sinh', tvm.Doi 'Đời', tvc.HoTen 'Thành viên cũ'  from THANHVIEN tvc, THANHVIEN tvm";
                sqlstr += " where tvm.MATVCu=tvc.MATV and tvm.HoTen LIKE '%";
                sqlstr += t;
                sqlstr += "%'";
                if (k == 0)
                {
                    sqlstr += " and tvm.GioiTinh='Nam'";
                }
                if (k == 1)
                {
                    sqlstr += " and tvm.GioiTinh!='Nam'";
                }
                da = new SqlDataAdapter(sqlstr, _cn);
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds, "THANHVIEN, LOAIQUANHE, THANHVIEN, QUEQUAN, NGHENGHIEP, THANHVIEN_NGHENGHIEP");
                return ds;
            }
            catch
            {
                return null;
            }

        }
        
        public DataSet Get_TimKiemNC(string txt, int gt, int lqh, int t)//Lấy danh sách thành viên theo tìm kiếm nâng cao
        {
            try
            {
                SqlDataAdapter da;
                DataSet ds;
                string sqlstr = "";
                sqlstr += "select distinct tv.MATV 'Mã thành viên', tv.HoTen 'Họ Tên', tv.GioiTinh 'Giới tính', tv.NgaySinh 'Ngày sinh', tv.Doi 'Đời', tvc.HoTen 'Thành viên cũ' ";
                sqlstr += "from THANHVIEN tv, LOAIQUANHE lqh, THANHVIEN tvc, QUEQUAN qq, NGHENGHIEP nn, THANHVIEN_NGHENGHIEP lv where tv.MATVCu=tvc.MATV  ";

                if (gt == 1)
                {
                    sqlstr += "and tv.GioiTinh= 'Nam' ";
                }
                if (gt == 2)
                {
                    sqlstr += "and tv.GioiTinh!= 'Nam' ";
                }
                if (lqh == 1)
                {
                    sqlstr += " and lqh.GhiChu='Con' and tv.MATV=lqh.MATV_S ";
                }
                if (lqh == 2)
                {
                    sqlstr += " and lqh.GhiChu !='Con' and tv.MATV=lqh.MATV_S ";
                }
                if (t == 0)
                {
                    sqlstr += " and tv.HoTen like N'%";
                    sqlstr += txt;
                    sqlstr += "%'";
                }
                if (t == 1)
                {
                    sqlstr += " and tv.TenDC like N'%";
                    sqlstr += txt;
                    sqlstr += "%'";
                }
                if (t == 2)
                {
                    sqlstr += " and qq.MAQQ=tv.MAQQ and qq.TenQQ like N'%";
                    sqlstr += txt;
                    sqlstr += "%'";
                }
                if (t == 3)
                {
                    sqlstr += " and nn.MANNghiep=lv.MANNghiep and lv.MATV=tv.MATV and nn.TenNNghiep like N'%";
                    sqlstr += txt;
                    sqlstr += "%'";
                }
                da = new SqlDataAdapter(sqlstr, _cn);
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds, "THANHVIEN, LOAIQUANHE, THANHVIEN, QUEQUAN, NGHENGHIEP, THANHVIEN_NGHENGHIEP");
                return ds;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region Lấy thông tin thành viên
        public DataTable Get_Ten(string MATV)//Lấy tên của thành viên theo mã thành viên
        {
            try
            {
                string sqlstr = "";
                sqlstr += "select HoTen from THANHVIEN where MATV='";
                sqlstr += MATV;
                sqlstr += "'";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable Get_DiaChi(string MATV)//Lấy địa chỉ của  thành viên theo mã thành viên
        {
            try
            {
                string sqlstr = "";
                sqlstr += "select TenDC from THANHVIEN where MATV='";
                sqlstr += MATV;
                sqlstr += "'";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable Get_QQ(string MATV)//Lấy quê quán của thành viên theo mã thành viên
        {
            try
            {
                string sqlstr = "";
                sqlstr += "select qq.TenQQ from THANHVIEN tv, QUEQUAN qq where tv.MAQQ=qq.MAQQ and tv.MATV='";
                sqlstr += MATV;
                sqlstr += "'";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable Get_NS(string MATV)//Lấy năm sinh của  thành viên theo mã thành viên
        {
            try
            {
                string sqlstr = "";
                sqlstr += "select NgaySinh from THANHVIEN where MATV='";
                sqlstr += MATV;
                sqlstr += "'";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable Get_NVH(string MATV)//Lấy ngày vào họ của  thành viên theo mã thành viên
        {
            try
            {
                string sqlstr = "";
                sqlstr += "select NgayVaoHo from THANHVIEN where MATV='";
                sqlstr += MATV;
                sqlstr += "'";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public int Get_GT(string MATV)//Lấy giới tính của thành viên theo mã thành viên
        {
            try
            {
                string sqlstr = "";
                sqlstr += "select count(MATV) from THANHVIEN where GioiTinh='Nam' and MATV='";
                sqlstr += MATV;
                sqlstr += "'";
                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = new SqlCommand(sqlstr, _cn);
                _cn.Open();
                int a = int.Parse(da.InsertCommand.ExecuteScalar().ToString());
                _cn.Close();
                return a;
            }
            catch
            {
                return -1;
            }
        }
        public int Get_QH(string MATV)//Lấy quan hệ của thành viên theo mã thành viên
        {
            try
            {
                string sqlstr = "";
                sqlstr += "select count(MATV_S) from LOAIQUANHE where LOAIQUANHE.GhiChu='Con' and MATV_S='";
                sqlstr += MATV;
                sqlstr += "'";
                SqlDataAdapter da = new SqlDataAdapter();
                da.InsertCommand = new SqlCommand(sqlstr, _cn);
                _cn.Open();
                int a = int.Parse(da.InsertCommand.ExecuteScalar().ToString());
                _cn.Close();
                return a;
            }
            catch
            {
                return -1;
            }
        }
        public DataTable Get_NNghiep(string MATV)//Lấy nghề nghiệp của thành viên theo mã thành viên
        {
            try
            {
                string sqlstr = "select NN.TenNNghiep from THANHVIEN_NGHENGHIEP as TV_NN, NGHENGHIEP as NN where MATV= '"+MATV+ "' and TV_NN.MANNghiep = NN.MANNghiep";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable Get_TVT(string MATV) //Lấy mã thành viên trước của thành viên theo mã thành viên
        {
            try
            {
                string sqlstr = "";
                sqlstr += "select tv.HoTen from THANHVIEN tv, LOAIQUANHE lqh where lqh.MATV_T = tv.MATV and MATV_S='";
                sqlstr += MATV;
                sqlstr += "'";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable Get_Ma(string HoTen) //Lấy mã của thành viên theo họ tên
        {
            try
            {
                string sqlstr = "";
                sqlstr += "select top 1 MATV from THANHVIEN where HoTen Like '%";
                sqlstr += HoTen;
                sqlstr += "%'";
                SqlDataAdapter da = new SqlDataAdapter(sqlstr, _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataSet Get_ALL(string Nam)//Lấy thông tin thành viên 
        {
            SqlDataAdapter da;
            DataSet ds;
            string sqlstr = "";
            sqlstr = "select MATV 'Mã Thành Viên', HoTen 'Họ Tên', GioiTinh 'Giới Tính', NgaySinh 'Ngày Sinh', TenDC 'Tên Địa Chỉ'";
            sqlstr += "from THANHVIEN ";
            da = new SqlDataAdapter(sqlstr, _cn);
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds, "THANHVIEN");
            return ds;
        }
        public DataSet Get_MatALL(string Nam)//Lấy thông tin về thành viên đã mất
        {
            SqlDataAdapter da;
            DataSet ds;
            string sqlstr = "";
            sqlstr = "select tv.MATV 'Mã Thành Viên', tv.HoTen 'Họ Tên', tv.GioiTinh 'Giới Tính', tv.NgaySinh 'Ngày Sinh', tv.TenDC 'Tên Địa Chỉ'";
            sqlstr += "from THANHVIEN tv, KETTHUC kt";
            sqlstr += " where tv.MATV=kt.MATV";
            da = new SqlDataAdapter(sqlstr, _cn);
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds, "THANHVIEN,KETTHUC");
            return ds;
        }
        public DataSet Get_TV_TangTheoNam(string Nam)//Lấy thông tin thành viên theo Ngày vào họ
        {
            SqlDataAdapter da;
            DataSet ds;
            string sqlstr = "";
            sqlstr = "select MATV 'Mã Thành Viên', HoTen 'Họ Tên', GioiTinh 'Giới Tính', NgaySinh 'Ngày Sinh', TenDC 'Tên Địa Chỉ'";
            sqlstr += "from THANHVIEN ";
            sqlstr += " where  year(NgayVaoHo)='";
            sqlstr += Nam;
            sqlstr += "'";
            da = new SqlDataAdapter(sqlstr, _cn);
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds, "THANHVIEN");
            return ds;
        }
        public DataSet Get_TV_MatTheoNam(string Nam)//Lấy thông tin thành viên mất theo năm mất
        {
            SqlDataAdapter da;
            DataSet ds;
            string sqlstr = "";
            sqlstr = "select tv.MATV 'Mã Thành Viên', tv.HoTen 'Họ Tên', tv.GioiTinh 'Giới Tính', tv.NgaySinh 'Ngày Sinh', tv.TenDC 'Tên Địa Chỉ'";
            sqlstr += "from THANHVIEN tv, KETTHUC kt";
            sqlstr += " where tv.MATV=kt.MATV and year(kt.NgayMat)='";
            sqlstr += Nam;
            sqlstr += "'";
            da = new SqlDataAdapter(sqlstr, _cn);
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds, "THANHVIEN,KETTHUC");
            return ds;
        }
        public DataSet Get_TV()//Lấy tất thông tin thành viên                 
        {
            try
            {
                SqlDataAdapter da;
                DataSet ds;
                string sqlstr = "";
                sqlstr = "select tvm.MATV 'Mã thành viên', tvm.HoTen 'Họ Tên',tvm.GioiTinh 'Giới tính', tvm.NgaySinh 'Ngày sinh',tvm.Doi 'Đời', tvc.HoTen 'Thành viên cũ'  from THANHVIEN tvc, THANHVIEN tvm where tvm.MATVCu=tvc.MATV";
                da = new SqlDataAdapter(sqlstr, _cn);
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds, "THANHVIEN, LOAIQUANHE, THANHVIEN, QUEQUAN, NGHENGHIEP, THANHVIEN_NGHENGHIEP");
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public int Get_Doi(string tenTVC)//Lấy số đời của thành viên
        {
            int doi = 0;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from THANHVIEN", _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int countRow = dt.Rows.Count;
                int countCol = 7;
                for (int iRow = 0; iRow < countRow; iRow++)
                {
                    for (int iCol = 0; iCol < countCol; iCol++)
                    {
                        if (tenTVC == (string)dt.Rows[iRow].ItemArray[iCol])
                        {
                            doi = (int)dt.Rows[iRow].ItemArray[iCol + 4];
                            iRow = countRow;
                            iCol = countCol;
                        }
                    }
                }
                return doi;
            }
            catch
            {
                return 0;
            }
        }
        public string Get_MATVC(string tenTVC)//Lấy mã thành viên cũ
        {
            string MATVC = "";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from THANHVIEN", _cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int countRow = dt.Rows.Count;
                int countCol = 3;
                for (int iRow = 0; iRow < countRow; iRow++)
                {
                    for (int iCol = 0; iCol < countCol; iCol++)
                    {
                        if (tenTVC == (string)dt.Rows[iRow].ItemArray[iCol])
                        {
                            MATVC = (string)dt.Rows[iRow].ItemArray[iCol - 2];
                            iCol = countCol;
                            iRow = countRow;
                        }
                    }
                }
                return MATVC;
            }
            catch
            {
                return null;
            }
        }


            public DataSet Get_TVTang(string cbTuNam, string cbDenNam)//Lấy danh sách thông tin thành viên tăng qua các năm
        {
            try
            {
                SqlDataAdapter da;
                DataSet ds;

                string sqlstr = "";
                sqlstr = "select year(NgayVaoHo) 'Năm', count(MATV) 'Số TV Mới',";
                sqlstr += "count(case when GioiTinh='Nam' then 1 end) 'Số Nam',";
                sqlstr += "count(case when GioiTinh='Nu' then 1 end) 'Số Nữ',";
                sqlstr += "count(case when NgayVaoHo!=NgaySinh then 1 end) 'Số Kết Hôn'";
                sqlstr += "from THANHVIEN";
                sqlstr += " where YEAR(NgayVaoHo)>=";
                sqlstr += cbTuNam;
                sqlstr += " and year(NgayVaoHo)<=";
                sqlstr += cbDenNam;
                sqlstr += " group by year(NgayVaoHo)";
                da = new SqlDataAdapter(sqlstr, _cn);
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds, "THANHVIEN");
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public DataSet Get_TAll(string cbTuNam, string cbDenNam)//Lấy số thành viên tăng qua các năm
        {
            SqlDataAdapter da1;
            DataSet ds1;
            string sqlstr1 = "";
            sqlstr1 = "select count(MATV) 'Số TV Mới',";
            sqlstr1 += "count(case when GioiTinh='Nam' then 1 end) 'Số Nam',";
            sqlstr1 += "count(case when GioiTinh='Nu' then 1 end) 'Số Nữ',";
            sqlstr1 += "count(case when NgayVaoHo!=NgaySinh then 1 end) 'Số Kết Hôn'";
            sqlstr1 += "from THANHVIEN where year(NgayVaoHo)>=";
            sqlstr1 += cbTuNam;
            sqlstr1 += " and year(NgayVaoHo)<=";
            sqlstr1 += cbDenNam;
            da1 = new SqlDataAdapter(sqlstr1, _cn);
            ds1 = new DataSet();
            ds1.Clear();
            da1.Fill(ds1, "THANHVIEN");
            return ds1;
        }
        public DataSet Get_TVGiam(string cbTuNam, string cbDenNam)//Lấy thông tin thành viên mất qua các năm
        {
            SqlDataAdapter da;
            DataSet ds;

            string sqlstr = "";
            sqlstr = "select year(NgayMat) 'NĂM', COUNT(MAKT)'SỐ NGƯỜI MẤT'";
            sqlstr += "from KETTHUC";
            sqlstr += " where YEAR(NgayMat)>=";
            sqlstr += cbTuNam;
            sqlstr += " and year(NgayMat)<=";
            sqlstr += cbDenNam;
            sqlstr += " group by year(NgayMat)";
            da = new SqlDataAdapter(sqlstr, _cn);
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds, "KETTHUC");
            return ds;
        }
        public DataSet Get_GAll(string cbTuNam, string cbDenNam)//Lấy số thành viên mất qua các năm
        {
            SqlDataAdapter da;
            DataSet ds;

            string sqlstr = "";
            sqlstr = "select COUNT(MAKT)'SỐ NGƯỜI MẤT'";
            sqlstr += "from KETTHUC";
            sqlstr += " where YEAR(NgayMat)>=";
            sqlstr += cbTuNam;
            sqlstr += " and year(NgayMat)<=";
            sqlstr += cbDenNam;
            da = new SqlDataAdapter(sqlstr, _cn);
            ds = new DataSet();
            ds.Clear();
            da.Fill(ds, "KETTHUC");
            return ds;
        }

        #endregion
    }

}
