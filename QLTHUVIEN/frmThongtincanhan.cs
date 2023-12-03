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
    public partial class frmthongtincanhan : Form
    {
        xuly xl = new xuly();
        public string ma = "";
        QLTVDataContext db = new QLTVDataContext();
        docgia dg = new docgia();
        phieumuon pm = new phieumuon();
        khoa kh = new khoa();
        Table<docgia> docgias;
        Table<khoa> khoas;
        Table<phieumuon> phieumuons;
        public frmthongtincanhan()
        {
            InitializeComponent();
        }
        public string mdg;
        private void frmthongtin_Load(object sender, EventArgs e)
        {
            docgia dgo = new docgia();
            docgias = db.GetTable<docgia>();
            var kt = from d in docgias
                     where d.madocgia == mdg
                     select d;

            foreach(var tt in kt)
            {
                txtHoTen.Text = tt.hoten;
                txtDiaChi.Text = tt.diachi;
                txtNgaySinh.Text = tt.ngaysinh;
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            phieumuon pm = new phieumuon();
            phieumuons = db.GetTable<phieumuon>();

            frmTIMKIEM tk = new frmTIMKIEM();
            tk.mdg = mdg;
            this.Hide();
            tk.Show();

        }
    }
}
