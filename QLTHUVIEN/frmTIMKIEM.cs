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
using System.Data;
using System.Data.Linq;
using System.Web.Caching;
namespace QLTHUVIEN
{
    public partial class frmTIMKIEM : Form
    {
        QLTVDataContext db = new QLTVDataContext();
        sach sach = new sach();
        phieumuon pm = new phieumuon();
        Table<phieumuon> phieumuons;
        Table<sach> sachs;
        public frmTIMKIEM()
        {
            InitializeComponent();
        }

        private void frmTIMKIEM_Load(object sender, EventArgs e)
        {
            cbtimkiem.Text = "Mã sách";
        }

        public DataTable hienthi(string sqlht)
        {
            Connection cn = new Connection();
            cn.OpenConn();
            SqlDataAdapter da = new SqlDataAdapter(sqlht, cn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            cn.CloseConn();
        }
        //private void btntimkiem_Click(object sender, EventArgs e)
        //{
        //    if(cbtimkiem.Text=="Mã sách")
        //        dgvthongtin.DataSource = hienthi("select * from sach where masach like '%" + txttimkiem.Text.Trim() + "%'");
        //    if (cbtimkiem.Text == "Nhan đề")
        //        dgvthongtin.DataSource = hienthi("select * from sach where nhande like '%" + txttimkiem.Text.Trim() + "%'");
        //    if (cbtimkiem.Text == "Tác giả")               
        //        dgvthongtin.DataSource = hienthi("select * from sach where tacgia like '%" + txttimkiem.Text.Trim() + "%'");
        //}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            if (cbtimkiem.Text == "Mã sách")
                dgvthongtin.DataSource = hienthi("select * from sach where masach like '%" + txttimkiem.Text.Trim() + "%'");
            if (cbtimkiem.Text == "Nhan đề")
                dgvthongtin.DataSource = hienthi("select * from sach where nhande like '%" + txttimkiem.Text.Trim() + "%'");
            if (cbtimkiem.Text == "Tác giả")
                dgvthongtin.DataSource = hienthi("select * from sach where tacgia like '%" + txttimkiem.Text.Trim() + "%'");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            sach sach = new sach();
            sachs = db.GetTable<sach>();

            if (txttimkiem.Text != "")
            {
                var ktr = from s in sachs
                          where s.tacgia == txttimkiem.Text
                          select s;

                string loai = cbtimkiem.SelectedItem.ToString();
                if (loai == "Mã sách")
                {
                    ktr = from s in sachs
                          where s.masach == txttimkiem.Text
                          select s;
                }
                else if (loai == "Nhan đề")
                {
                    ktr = from s in sachs
                          where s.nhande == txttimkiem.Text
                          select s;
                }

                dgvthongtin.DataSource = ktr;
            }
            if (txttimkiem.Text == "")
            {
                var ktr = from s in sachs
                          select s;
                dgvthongtin.DataSource = ktr;
            }
        }
        public string mdg;
        private void btnMuon_Click(object sender, EventArgs e)
        {
            phieumuon pm = new phieumuon();
            phieumuons = db.GetTable<phieumuon>();
            DateTime currentDate = DateTime.Now.Date;

            pm.madocgia = mdg;
            pm.ngaymuon = DateTime.Now.Date.ToString();
            pm.masach = mas;
            pm.manhanvien = "nv1";
            pm.soluong = lstSoLuong.Text;
            pm.trangthai = "DANG MUON";

            // Số ngày bạn muốn cộng thêm
            int numberOfDaysToAdd = Int32.Parse(lstSoNgayMuon.SelectedItem.ToString());

            // Cộng thêm số ngày vào ngày hiện tại
            DateTime newDate = currentDate.AddDays(numberOfDaysToAdd);

            pm.ngaytra = newDate.ToString();

            phieumuons.InsertOnSubmit(pm);
            db.SubmitChanges();
            MessageBox.Show("Thêm thành công");
        }

        private void dgvthongtin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sach sach = new sach();
            sachs = db.GetTable<sach>();


        }

        string mas = "";
        private void dgvthongtin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            phieumuon pm = new phieumuon();
            phieumuons = db.GetTable<phieumuon>();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy giá trị từ cell được chọn
                object cellValue = dgvthongtin.Rows[e.RowIndex].Cells[0].Value;
                pm.madocgia = "TG3";
                pm.ngaymuon = DateTime.Now.ToString();
                pm.masach = dgvthongtin.Rows[e.RowIndex].Cells[0].Value.ToString();
                pm.manhanvien = "nv1";
                pm.soluong = lstSoLuong.Text;
                pm.trangthai = "DANG MUON";

                mas = pm.masach;
                MessageBox.Show(pm.masach);
            }

            }
        } 
    }
