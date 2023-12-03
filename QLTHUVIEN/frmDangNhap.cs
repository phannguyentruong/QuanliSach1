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
    public partial class frmDangnhap : Form
    {
        Connection cn = new Connection();
        SqlCommand cm;
        QLTVDataContext db = new QLTVDataContext();
        docgia dg = new docgia();
        khoa kh = new khoa();
        Table<docgia> docgias;
        Table<khoa> khoas;
        public frmDangnhap()
        {
            InitializeComponent();
        }
        private void btndangnhap_Click(object sender, EventArgs e)
        {
           docgia dg = new docgia();
            docgias = db.GetTable<docgia>();

            var kt1 = from dgg in docgias
                      where dgg.madocgia == txtuser.Text
                      && dgg.matkhau == txtpass.Text
                      select dgg;
            int sl = 0;
            foreach(var tt in kt1)
            {
                sl = 1;
                frmthongtincanhan ttcn = new frmthongtincanhan();
                ttcn.mdg = tt.madocgia;
                this.Hide();
                ttcn.Show();
            }
            if (txtuser.Text == "thuthu" && txtpass.Text == "thuthu")
            {
                frmMuontrasach mts = new frmMuontrasach();
                this.Hide();
                mts.Show();
            }
            if (sl == 0 && (txtuser.Text != "thuthu" && txtpass.Text != "thuthu"))
                MessageBox.Show("Mã độc giả hoặc mật khẩu không đúng!");
            
        }


        private void btnTHOAT_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ckbHienpass_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void frmDangnhap_Load(object sender, EventArgs e)
        {
           // txtuser.Text = "NV1";
           // txtpass.Text = "123";
           // cbquyenhan.Text = "thuthu";
        }
    }
}
