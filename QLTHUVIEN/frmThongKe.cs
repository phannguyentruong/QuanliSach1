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
    public partial class frmThongKe : Form
    {
        QLTVDataContext db = new QLTVDataContext();
        docgia dg = new docgia();
        khoa kh = new khoa();
        phieumuon pm = new phieumuon();
        sach sa = new sach();
        Table<docgia> docgias;
        Table<khoa> khoas;
        Table<phieumuon> phieumuons;
        Table<sach> sachs;
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            sach sachh = new sach();
            sachs = db.GetTable<sach>();
            phieumuon pm = new phieumuon();
            phieumuons = db.GetTable<phieumuon>();

            string tt = cboTinhTrang.SelectedItem.ToString();

            var kt1 = from p in phieumuons
                      where p.trangthai == tt
                      group p by p.masach into g
                      select new { MaSach = g.Key, Soluong = g.Sum(p => Convert.ToInt32(p.soluong)) };

            dataGridView1.DataSource = kt1;
        }
    }
}
