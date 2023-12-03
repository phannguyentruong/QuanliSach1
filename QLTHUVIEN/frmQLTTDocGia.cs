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
using System.Data.Linq;

namespace QLTHUVIEN
{
    public partial class frmQLTTDocGia : Form
    {
        SqlCommand cm;
        QLTVDataContext db = new QLTVDataContext();
        docgia dg = new docgia();
        khoa kh = new khoa();
        Table<docgia> docgias;
        Table<khoa> khoas;
        public frmQLTTDocGia()
        {
            InitializeComponent();
        }

        private void hienthi()
        {
            docgia docgia = new docgia();
            docgias = db.GetTable<docgia>();

            var ktr = from dg in docgias
                      select dg;
            dgvDSTTdocgia.DataSource = ktr;
        }
        public void Loadmakhoa()
        {
            /*
            Connection cn = new Connection();
            cn.OpenConn();
            cm = new SqlCommand("select makhoa from khoa", cn.con);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cbmakhoa.DataSource = ds.Tables[0];
            cbmakhoa.ValueMember = "makhoa";

            */
        }
        /*
        public DataTable danhsachdocgia()
        {
            /*
            Connection cn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("select MADOCGIA as 'Mã đọc giả',HOTEN as 'Họ tên',NGAYSINH as 'Ngày sinh',MAKHOA as 'Mã khoa',DIACHI as 'Địa chỉ',NGAYLAPTHE as 'Ngày lập thẻ',MATKHAU as 'Mật khẩu' from DOCGIA", cn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            
        }
        */
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            /*
            txtmdg.Clear();
            txthoten.Clear();
            txtdiachi.Clear();
            txtmatkhau.Clear();
            cbmakhoa.Text = "CNTT";
            dtpngaylapthe.Value = DateTime.Today;
            dtpNgaysinh.Value = DateTime.Today;
            frmQLTTDocGia_Load(sender, e);
            */
        }

        private void frmQLTTDocGia_Load(object sender, EventArgs e)
        {
            /*
            hienthi();
            dtpngaylapthe.Value = DateTime.Today;
            dtpNgaysinh.Value = DateTime.Today;
            Loadmakhoa();
            dgvDSTTdocgia.DataSource = danhsachdocgia();
            */
            
        }

        private void dgvDSTTdocgia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDSTTdocgia.Rows[e.RowIndex];

                txtmdg.Text = row.Cells[0].Value.ToString();
                txthoten.Text = row.Cells[1].Value.ToString();
                dtpNgaysinh.Text = row.Cells[2].Value.ToString();
                cbmakhoa.Text = row.Cells[3].Value.ToString();
                txtdiachi.Text = row.Cells[4].Value.ToString();
                dtpngaylapthe.Text = row.Cells[5].Value.ToString();
                txtmatkhau.Text = row.Cells[6].Value.ToString();
            }
        }


        private void btnthem_Click(object sender, EventArgs e)
        {
            docgia dogi = new docgia();
            docgias = db.GetTable<docgia>();

            string madocgia = txtmdg.Text;
            string hoten = txthoten.Text;
            DateTime ngaysinh = dtpNgaysinh.Value;
            string makhoa = cbmakhoa.Text;
            string diachi = txtdiachi.Text;
            DateTime ngaylapthe = dtpngaylapthe.Value;
            string matkhau = txtmatkhau.Text;

            DateTime nams = Convert.ToDateTime(dtpNgaysinh.Value.ToString());
            int Ngt = int.Parse(DateTime.Now.Year.ToString());
            int nn = int.Parse(nams.Year.ToString());
            int tuoi = Ngt - nn;

            var ktr1 = from dgi in docgias
                       where dgi.madocgia == txtmdg.Text
                       select dgi;
            int mdg = 0;
            foreach(var tt in ktr1)
            {
                mdg++;
            }

            if (mdg != 0)
                MessageBox.Show("Mã độc giả đã tồn tại!");
            else { 


            if (madocgia=="" || makhoa == "" || diachi == ""|| matkhau == "")
            {
                MessageBox.Show("Thông tin đọc giả không được bỏ trống!!!");
            }
            if (tuoi < 18)
            {
                errorProvider1.SetError(dtpNgaysinh, "Đọc giả phải đủ 18 tuổi");
                return;
            }
            else
            if(tuoi > 100)
            {
                errorProvider1.SetError(dtpNgaysinh, "Đọc giả phải nho hon 100 tuổi");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (ngaysinh >= ngaylapthe)
            {
                MessageBox.Show("Ngày lập thẻ phải sau ngay sinh");
            }
           

            else
            {
                    dogi.madocgia = txtmdg.Text;
                    dogi.hoten = txthoten.Text;
                    dogi.ngaysinh = dtpNgaysinh.Text;
                    dogi.makhoa = cbmakhoa.SelectedItem.ToString();
                    dogi.diachi = txtdiachi.Text;
                    dogi.ngaylapthe = dtpngaylapthe.Text;
                    dogi.matkhau = txtmatkhau.Text;

                    docgias.InsertOnSubmit(dogi);
                    db.SubmitChanges();
                    MessageBox.Show("Them thanh cong");

            }
            }
            hienthi();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            docgia dogi = new docgia();
            docgias = db.GetTable<docgia>();

            var kt = from dg in docgias
                     where txtTK.Text == dg.madocgia
                     select dg;

            foreach(var tt in kt)
            {
                //dogi.madocgia = txtmdg.Text;
                tt.hoten = txthoten.Text;
                tt.ngaysinh = dtpNgaysinh.Text;
                tt.makhoa = cbmakhoa.SelectedItem.ToString();
                tt.diachi = txtdiachi.Text;
                tt.ngaylapthe = dtpngaylapthe.Text;
                tt.matkhau = txtmatkhau.Text;
            }

            db.SubmitChanges();
            MessageBox.Show("Sửa thành công");
            hienthi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            docgia dogi = new docgia();
            docgias = db.GetTable<docgia>();

            string madocgia = txtmdg.Text;
            if (txtTK.Text == "")
                MessageBox.Show("Vui long nhap ma can xoa");
            else
            {
                var kt = from dg in docgias
                         where dg.madocgia == madocgia
                         select dg;
                foreach (var k in kt)
                {
                    docgias.DeleteOnSubmit(k);
                }
                db.SubmitChanges();
                MessageBox.Show("Xoa thanh cong");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmQuanlythongtinsach tts = new frmQuanlythongtinsach();
            this.Hide();
            tts.Show();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            docgia dogi = new docgia();
            docgias = db.GetTable<docgia>();

            if (txtTK.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin cần tìm!");
            }
            else
            {
                var ktr = from dgi in docgias
                          where dgi.madocgia == txtTK.Text
                          select dgi;

                foreach(var tt in ktr)
                {
                    txtmdg.Text = tt.madocgia;
                    txthoten.Text = tt.hoten;
                    DateTime ns = DateTime.Parse(tt.ngaysinh);
                    dtpNgaysinh.Value = ns;
                    cbmakhoa.SelectedValue = tt.makhoa;
                    txtdiachi.Text = tt.diachi;
                    DateTime nlt = DateTime.Parse(tt.ngaysinh);
                    dtpngaylapthe.Value = nlt;
                    txtmatkhau.Text = tt.matkhau;
                }
            }
        }

        private void dtpNgaysinh_ValueChanged(object sender, EventArgs e)
        {

            //DateTime nams = Convert.ToDateTime(dtpNgaysinh.Value.ToString());
            //int Ngt=int.Parse(DateTime.Now.Year.ToString());
            //int nn = int.Parse(nams.Year.ToString());
            //int tuoi = Ngt - nn;
            //if(tuoi<18)
            //{
            //    errorProvider1.SetError(dtpNgaysinh, "Đọc giả phải đủ 18 tuổi");
            //    return;
            //}
            //else
            //{
            //    errorProvider1.Clear();
            //}
        }

        
    }
}
