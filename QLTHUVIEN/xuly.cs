using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace QLTHUVIEN
{
    class xuly
    {
        DataSet ds = new DataSet();
        Connection cn = new Connection();
        SqlCommand cm, cm1;
        SqlDataAdapter da;
        SqlDataReader dr;
        public int KTdangnhap(string USER, string PASSWORD)
        {

            cn.OpenConn();
            cm = new SqlCommand("select manhanvien from nhanvien where manhanvien='" + USER + "' and matkhau='" + PASSWORD + "'", cn.con);
            dr = cm.ExecuteReader();
            if (dr.Read())
            {
                return 1;
            }
            else
                return 0;
            cm.Dispose();
            dr.Dispose();
            cn.CloseConn();

        }
        public int KTdangnhap2(string USER, string PASSWORD)
        {

            cn.OpenConn();
            cm = new SqlCommand("select madocgia from docgia where madocgia='" + USER + "' and matkhau='" + PASSWORD + "'", cn.con);
            dr = cm.ExecuteReader();
            if (dr.Read())
            {
                return 1;
            }
            else
                return 0;
            cm.Dispose();
            dr.Dispose();
            cn.CloseConn();

        }
        public string quyenhan(string USER)
        {
            cn.OpenConn();
            string a = "select quyenhan from nhanvien where manhanvien='" + USER + "'";
            SqlDataReader dr = cn.executeSQL(a);
            string quyen = "";
            while (dr.Read())
            {
                quyen = dr[0].ToString();
            }
            cn.CloseConn();
            return quyen;
        }

        //public bool doimatkhau(string ai, string matkhaucu, string mkmoi)
        //{
        //    cn.OpenConn();
        //    string cm1 = "update  nhanvien set matkhau='" + matkhaucu + "' where manhanvien='" + ai + "' and matkhau ='" + mkmoi + "' ";
        //    try
        //    {
        //        //cm1.ExecuteNonQuery();
        //        //cm1.Dispose();
        //        //cn.CloseConn();
        //        if (cn.executeUpdate(cm1) == true)

        //        { return true; }
        //    }
        //    catch
        //    {
        //        da.Dispose();
        //        cn.CloseConn();
        //        return false;
        //    }
        //}

        public DataTable thongtincanhan(string ai)
        {
            cn.OpenConn();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select MANHANVIEN as 'Mã nhân viên',HOTEN as 'Họ tên',DIACHI as 'Địa chỉ',TENDANGNHAP as 'Tên đăng nhập',MATKHAU as 'Mật khẩu',QUYENHAN as 'Quyền hạn' from nhanvien where manhanvien='" + ai + "'", cn.con);
            da.Fill(dt);
            cn.CloseConn();
            return dt;
        }
        public DataTable thongtincanhan2(string ai)
        {
            cn.OpenConn();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select MADOCGIA as 'Mã đọc giả',HOTEN as 'Họ tên',NGAYSINH as 'Ngày sinh',MAKHOA as 'Mã khoa',DIACHI as 'Địa chỉ',NGAYLAPTHE as 'Ngày lập thẻ',MATKHAU as 'Mật khẩu' from docgia where madocgia='" + ai + "'", cn.con);
            da.Fill(dt);
            cn.CloseConn();
            return dt;
        }
        public string XinChao1(string manhanvien)
        {
            Connection cn = new Connection();
            cn.OpenConn();
            SqlCommand cm = new SqlCommand("select hoten from nhanvien where manhanvien='" + manhanvien + "'", cn.con);
            string hoten = cm.ExecuteScalar() as string;
            cn.CloseConn();
            return hoten;
        }
        public string XinChao2(string madocgia)
        {
            Connection cn = new Connection();
            cn.OpenConn();
            SqlCommand cm = new SqlCommand("select hoten from docgia where madocgia='" + madocgia + "'", cn.con);
            string hoten = cm.ExecuteScalar() as string;
            cn.CloseConn();
            return hoten;
        }
        //public string GetMD5(string chuoi)
        //{
        //    string str_md5 = "";
        //    byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);

        //    MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
        //    mang = my_md5.ComputeHash(mang);

        //    foreach (byte b in mang)
        //    {
        //        str_md5 += b.ToString("X2");
        //    }

        //    return str_md5;
        //}
    }
}
