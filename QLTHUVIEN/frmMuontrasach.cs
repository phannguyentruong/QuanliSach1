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
    public partial class frmMuontrasach : Form
    {
        SqlCommand cm;
        QLTVDataContext db = new QLTVDataContext();
        docgia dg = new docgia();
        khoa kh = new khoa();
        phieumuon pm = new phieumuon();
        Table<docgia> docgias;
        Table<khoa> khoas;
        Table<phieumuon> phieumuons;
        public frmMuontrasach()
        {
            InitializeComponent();
        }
        public void hienthi()
        {
            /*
            Connection cn = new Connection();
            cn.OpenConn();
            string sqlht = "select * from phieumuon";
            SqlCommand cmd = new SqlCommand(sqlht, cn.con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvmuontra.DataSource = dt;
            cn.CloseConn();
            */
        }
        public void Loadmasach()
        {
            phieumuon pm = new phieumuon();
            phieumuons = db.GetTable<phieumuon>();
            var kt1 = from p in phieumuons
                      select p;
            cbmasach.DataSource = kt1;
            cbmasach.ValueMember = "masach";
        }
        public void Loadmanhanvien()
        {
            phieumuon pm = new phieumuon();
            phieumuons = db.GetTable<phieumuon>();
            var kt1 = from p in phieumuons
                      select p;
            cbmanhanvien.DataSource = kt1;
            cbmanhanvien.ValueMember = "manhanvien";
        }
        /*
        public DataTable danhsachphieumuon()
        {
            /*
            Connection cn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("select madocgia as 'Mã đọc giả',ngaymuon as 'Ngày mượn',masach as 'Mã sách',manhanvien as 'Mã nhân viên',soluong as 'Số lượng',trangthai as 'Trạng thái',ngaytra as 'Ngày trả' from PHIEUMUON", cn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            
        }
        */
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtmadg.Text = "";
            dtpngaynuon.Value = DateTime.Today;
            cbmanhanvien.Text = "";
            cbmasach.Text = "";
          //  txtsoluong.Clear();
            cbmtrangthai.Text = "ĐANG MUON";
            dtpNgaytra.Value = DateTime.Today;
            frmMuontrasach_Load(sender, e);
        }

        private void frmMuontrasach_Load(object sender, EventArgs e)
        {
            hienthi();
            dtpngaynuon.Value = DateTime.Today;
            dtpNgaytra.Value = DateTime.Today;
            cbmtrangthai.Text = "ĐANG MUON";
            Loadmanhanvien();
            Loadmasach();
            //dgvmuontra.DataSource = danhsachphieumuon();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            phieumuon pm = new phieumuon();
            phieumuons = db.GetTable<phieumuon>();

            pm.madocgia = txtmadg.Text;
            pm.ngaymuon = dtpngaynuon.Text;
            pm.masach = cbmasach.Text; ;
            pm.manhanvien = cbmanhanvien.Text;
            pm.soluong = txtsoluong.Value.ToString();
            pm.trangthai = cbmtrangthai.Text;
            pm.ngaytra = dtpNgaytra.Text;

            phieumuons.InsertOnSubmit(pm);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công");
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            phieumuon pm = new phieumuon();
            phieumuons = db.GetTable<phieumuon>();

            var kt = from p in phieumuons
                     where txtTK.Text == p.madocgia
                     select p;

            foreach (var tt in kt)
            {
                tt.madocgia = txtmadg.Text;
                tt.ngaymuon = dtpngaynuon.Text;
                tt.masach = cbmasach.Text; ;
                tt.manhanvien = cbmanhanvien.Text;
                tt.soluong = txtsoluong.Value.ToString();
                tt.trangthai = cbmtrangthai.Text;
                tt.ngaytra = dtpNgaytra.Text;
            }

            db.SubmitChanges();
            MessageBox.Show("Sửa thành công");
        }

        private void dgvmuontra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvmuontra.Rows[e.RowIndex];

                //c.Text = row.Cells[0].Value.ToString();
                dtpngaynuon.Text = row.Cells[1].Value.ToString();
                cbmasach.Text = row.Cells[2].Value.ToString();
                cbmanhanvien.Text = row.Cells[3].Value.ToString();
                txtsoluong.Text = row.Cells[4].Value.ToString();
                cbmtrangthai.Text = row.Cells[5].Value.ToString();
                dtpNgaytra.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Connection cn = new Connection();
            cn.OpenConn();
            string madocgia = txtmadg.Text;
            cm = new SqlCommand("select madocgia from phieumuon where madocgia='" + madocgia + "'", cn.con);
            string ma = cm.ExecuteScalar() as string;
            if (madocgia == ma)
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa?", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult.OK == dlr)
                {
                    string sqlxoa = "delete phieumuon where MADOCGIA = '" + madocgia + "'";
                    SqlCommand cmd = new SqlCommand(sqlxoa, cn.con);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cn.CloseConn();
                        MessageBox.Show("Xóa thành công");
                        btnLammoi_Click( sender,  e);
                    }
                    catch
                    {
                        cmd.Dispose();
                        cn.CloseConn();
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
            hienthi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmQLTTDocGia ttdg = new frmQLTTDocGia();
            this.Hide();
            ttdg.Show();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            phieumuon pm = new phieumuon();
            phieumuons = db.GetTable<phieumuon>();

            if (txtTK.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin cần tìm!");
            }
            else
            {
                var kt1 = from p in phieumuons
                          where txtTK.Text == p.madocgia
                          select p;
                foreach(var tt in kt1)
                {
                    txtmadg.Text = tt.madocgia;

                    // Chuyển đổi ngày mượn từ chuỗi sang DateTime
                    if (DateTime.TryParseExact(tt.ngaymuon, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaymuonDateTime))
                    {
                        dtpngaynuon.Value = ngaymuonDateTime;
                    }

                    cbmasach.SelectedValue = tt.masach;
                    cbmanhanvien.SelectedValue = tt.manhanvien;

                    // Chuyển đổi số lượng từ chuỗi sang int
                    if (int.TryParse(tt.soluong, out int soluong))
                    {
                        txtsoluong.Value = soluong;
                    }
                    else
                    {
                        // Xử lý trường hợp không thể chuyển đổi số lượng.
                        MessageBox.Show("Số lượng không hợp lệ!");
                    }

                    cbmtrangthai.SelectedValue = tt.trangthai;
                    if (DateTime.TryParseExact(tt.ngaytra, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaytraDateTime))
                    {
                        dtpNgaytra.Value = ngaytraDateTime;
                    }
                }
            }
        }

        private void btnGiahan_Click(object sender, EventArgs e)
        {
            phieumuon pm = new phieumuon();
            phieumuons = db.GetTable<phieumuon>();

            var kt1 = from p in phieumuons
                      where txtTK.Text == p.madocgia
                      && cbmasach.Text == p.masach
                      select p;
            foreach(var tt in kt1)
            {

                DateTime currentDate = DateTime.Parse(tt.ngaytra);

            // Số ngày bạn muốn cộng thêm
                int numberOfDaysToAdd = Int32.Parse(numgiahan.Value.ToString());

            // Cộng thêm số ngày vào ngày hiện tại
            DateTime newDate = currentDate.AddDays(numberOfDaysToAdd);

                // In ra màn hình để xem kết quả
                //Console.WriteLine($"Ngày hiện tại: {currentDate:yyyy-MM-dd}");
                //Console.WriteLine($"Ngày sau khi cộng thêm {numberOfDaysToAdd} ngày: {newDate:yyyy-MM-dd}");
                tt.ngaytra = newDate.ToString();
            }
            db.SubmitChanges();
            MessageBox.Show("Gia hạn thành công");
        }
    }
}
