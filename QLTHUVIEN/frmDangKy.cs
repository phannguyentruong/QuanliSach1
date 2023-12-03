using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHUVIEN
{
    public partial class frmDangKy : Form
    {
        QLTVDataContext db = new QLTVDataContext();
        docgia dg = new docgia();
        khoa kh = new khoa();
        Table<docgia> docgias;
        Table<khoa> khoas;
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            docgia dgi = new docgia();
            khoa kh = new khoa();
            docgias = db.GetTable<docgia>();
            khoas = db.GetTable<khoa>();

            var kt1 = from d in docgias
                      select d;
            int sl = 1;
            foreach(var tt in kt1)
            {
                sl++;
            }
            

            if(txtHoTen.Text=="")
            {
                MessageBox.Show("Vui lòng nhập họ tên");
            }
            else if(cboMaKhoa.Text=="")
            {
                MessageBox.Show("Vui lòng chọn mã khoa");
            }
            else if (txtDiaChi.Text=="")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ");
            }
            else if (txtMatKhau.Text=="")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
            }
            else if(txtNhapLaiMatKhau.Text=="")
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu");
            }
            else if(txtMatKhau.Text!=txtNhapLaiMatKhau.Text)
            {
                MessageBox.Show("Vui lòng nhập trùng mật khẩu");
            }
            else
            {
                dgi.madocgia = "TG" + sl;
                dgi.hoten = txtHoTen.Text;
                dgi.ngaysinh = dateNgaySinh.Value.ToString();
                dgi.makhoa = cboMaKhoa.Text;
                dgi.diachi = txtDiaChi.Text;
                dgi.ngaylapthe = DateTime.Now.ToString();
                dgi.matkhau = txtMatKhau.Text;
                docgias.InsertOnSubmit(dgi);
                db.SubmitChanges();
                MessageBox.Show("Đăng ký thành công - Mã độc giả của bạn là: TG"+sl);
                frmDangnhap dn = new frmDangnhap();
                this.Hide();
                dn.Show();
            }
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            docgia dgi = new docgia();
            khoa kh = new khoa();
            docgias = db.GetTable<docgia>();
            khoas = db.GetTable<khoa>();

            var kt2 = from k in khoas
                      select k.makhoa;
            cboMaKhoa.DataSource = kt2;
        }
    }
}