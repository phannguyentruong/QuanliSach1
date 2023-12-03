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
using System.Globalization;

namespace QLTHUVIEN
{
    public partial class frmQuanlythongtinsach : Form
    {
        SqlCommand cm;
        QLTVDataContext db = new QLTVDataContext();
        docgia dg = new docgia();
        khoa kh = new khoa();
        phieumuon pm = new phieumuon();
        phanloai pl = new phanloai();
        sach sa = new sach();
        Table<docgia> docgias;
        Table<khoa> khoas;
        Table<phieumuon> phieumuons;
        Table<phanloai> phanloais;
        Table<sach> sachs;
        public frmQuanlythongtinsach()
        {
            InitializeComponent();
        }

        private void hienthi()
        {
            /*
            Connection cn = new Connection();
            cn.OpenConn();
            string sqlht = "select * from sach";            
            SqlDataAdapter da = new SqlDataAdapter(sqlht, cn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvdsthongtinsach.DataSource = dt;
            cn.CloseConn();
            */
            //CÓ 2 CÁCH HIỂN THỊ ^_^!!!!
            //SqlCommand cmd = new SqlCommand(sqlht, cn.con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
        }
        public void Loadcbmaloai()
        {
            phanloai pl = new phanloai();
            phanloais = db.GetTable<phanloai>();

            var kt = from p in phanloais
                     select p.maloai;

            cbmaloai.DataSource = kt;
        }
        /*
        public DataTable danhsachsach()
        {
            
            Connection cn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("select MASACH as 'Mã Sách',NHANDE as 'Nhan đề',SOTRANG as 'Số trang',SOLUONG as 'Số lượng',NAMXB as 'Năm xuất bản',LANXB as 'Lần xuất bản',SOLANMUON as 'Số lần mượn',MALOAI as 'Mã loại',NXB as 'Nhà xuất bản',TACGIA as 'Tác giả',NGAYNHAP as 'Ngày nhập' from SACH", cn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        */

        private void frmQuanlythongtinsach_Load(object sender, EventArgs e)
        {
            phanloai pl = new phanloai();
            phanloais = db.GetTable<phanloai>();

            var kt = from p in phanloais
                     select p.maloai;

            cbmaloai.DataSource = kt;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            sach s = new sach();
            sachs = db.GetTable<sach>();

            var kt1 = from s1 in sachs
                      select s1;

            if (txtms.Text == "" || txtnhande.Text == "" || txtsoluong.Text == "" 
                || txtsotrang.Text == "" || txtnamxb.Text == "" || txtsolanmuon.Text == "" 
                || cbmaloai.Text == "" || txtnhaxb.Text == "" || txttgia.Text == "" 
                || dtpNgaynhap.Value.ToString() == "" || txtlanxb.Text == "")
            {
                MessageBox.Show("Thông tin sách không được bỏ trống!!!");
            }
            else
            {
                int dk = 0;
                foreach(var tt in kt1)
                {
                    if(txtms.Text==tt.masach)
                    {
                        dk = 1;
                        MessageBox.Show("Trùng mã sách,thêm thất bại");
                    }
                }
                if(dk==0)
                {
                    s.masach = txtms.Text;
                    s.nhande = txtnhande.Text;
                    s.sotrang = Int32.Parse(txtsotrang.Text);
                    s.solanmuon = Int32.Parse(txtsoluong.Text);
                    s.namxb = txtnamxb.Text;
                    s.lanxb = Int32.Parse(txtlanxb.Text);
                    s.solanmuon = Int32.Parse(txtsolanmuon.Text);
                    s.maloai = cbmaloai.SelectedValue.ToString();
                    s.nxb = txtnhaxb.Text;
                    s.tacgia = txttgia.Text;
                    s.ngaynhap = dtpNgaynhap.Value.ToString();
                    sachs.InsertOnSubmit(s);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công");
                }
            }

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            sach sh = new sach();
            sachs = db.GetTable<sach>();

            var kt1 = from ss in sachs
                      where ss.masach == txtms.Text
                      select ss;

            foreach(var tt in kt1)
            {
                tt.nhande = txtnhande.Text;
                tt.sotrang = Int32.Parse(txtsotrang.Text);
                tt.solanmuon = Int32.Parse(txtsoluong.Text);
                tt.namxb = txtnamxb.Text;
                tt.lanxb = Int32.Parse(txtlanxb.Text);
                tt.solanmuon = Int32.Parse(txtsolanmuon.Text);
                tt.maloai = cbmaloai.SelectedValue.ToString();
                tt.nxb = txtnhaxb.Text;
                tt.tacgia = txttgia.Text;
                tt.ngaynhap = dtpNgaynhap.Value.ToString();
            }
            db.SubmitChanges();
            MessageBox.Show("Sửa thành công");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            sach sh = new sach();
            sachs = db.GetTable<sach>();

            var kt = from ss in sachs
                     where ss.masach == txtms.Text
                     select ss;
            foreach(var tt in kt)
            {
                sachs.DeleteOnSubmit(tt);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công");
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            sach s = new sach();
            sachs = db.GetTable<sach>();

            if (txtTK.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin cần tìm!");
            }
            else
            {
                var kt1 = from sh in sachs
                          where txtTK.Text == sh.masach
                          select sh;
                foreach(var tt in kt1)
                {
                    txtms.Text = tt.masach;
                    txtnhande.Text = tt.nhande;
                    txtsoluong.Text = tt.soluong.ToString();
                    txtsotrang.Text = tt.sotrang.ToString();
                    txtnamxb.Text = tt.namxb;
                    txtsolanmuon.Text = tt.solanmuon.ToString();
                    cbmaloai.Text = tt.maloai;
                    txtnhaxb.Text = tt.nxb;
                    txttgia.Text = tt.tacgia;
                    if (DateTime.TryParseExact(tt.ngaynhap, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaymuonDateTime))
                    {
                        dtpNgaynhap.Value = ngaymuonDateTime;
                    }
                    txtlanxb.Text = tt.lanxb.ToString();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmThongKe tk = new frmThongKe();
            this.Hide();
            tk.Show();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtms.Clear();
            txtnamxb.Clear();
            txtnhande.Clear();
            txtnhaxb.Clear();
            txtsolanmuon.Clear();
            txtsoluong.Clear();
            txtsotrang.Clear();
            txttgia.Clear();
            cbmaloai.Text = "ML1";
            dtpNgaynhap.Value = DateTime.Today;
            txtms.Focus();
            frmQuanlythongtinsach_Load( sender, e);
        }
      
        private void dgvdsthongtinsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvdsthongtinsach.Rows[e.RowIndex];

                txtms.Text = row.Cells[0].Value.ToString();               
                txtnhande.Text = row.Cells[1].Value.ToString();
                txtsotrang.Text = row.Cells[2].Value.ToString();                             
                txtsoluong.Text = row.Cells[3].Value.ToString();
                txtnamxb.Text = row.Cells[4].Value.ToString();
                txtlanxb.Text = row.Cells[5].Value.ToString();
                txtsolanmuon.Text = row.Cells[6].Value.ToString();
                cbmaloai.Text = row.Cells[7].Value.ToString();
                txtnhaxb.Text = row.Cells[8].Value.ToString();
                txttgia.Text = row.Cells[9].Value.ToString();               
                dtpNgaynhap.Text = row.Cells[10].Value.ToString();               

            }
        }

    }
}
