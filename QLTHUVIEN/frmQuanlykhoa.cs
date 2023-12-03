using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTHUVIEN
{
    public partial class frmQuanlykhoa : Form
    {
        SqlCommand cm;
        public frmQuanlykhoa()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
            Connection cn = new Connection();
            cn.OpenConn();
            string sqlht = "select * from khoa";
            SqlCommand cmd = new SqlCommand(sqlht, cn.con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvDSkhoa.DataSource = dt;
            cn.CloseConn();
        }
        public DataTable danhsachkhoa()
        {
            Connection cn = new Connection();
            SqlDataAdapter da = new SqlDataAdapter("select MAKHOA as 'Mã khoa',TENKHOA as 'Tên khoa',DIACHI as 'Địa chỉ',SDT as 'Số điện thoại' from khoa", cn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtmakhoa.Clear();
            txttenkhoa.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
        }

        private void frmQuanlykhoa_Load(object sender, EventArgs e)
        {
            hienthi();
            dgvDSkhoa.DataSource = danhsachkhoa();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            Connection cn = new Connection();
            cn.OpenConn();
            string makhoa = txtmakhoa.Text;
            string tenkhoa = txttenkhoa.Text;
            string diachi = txtdiachi.Text;
            string sdt = txtsdt.Text;          
            cm = new SqlCommand("select makhoa from khoa where makhoa='" + makhoa + "'", cn.con);
            string ma = cm.ExecuteScalar() as string;
            if (makhoa == "" || tenkhoa == "" || diachi == "" || sdt == "")
            {
                MessageBox.Show("Thông tin khoa không được bỏ trống!!!");
            }
            else
            if (makhoa == ma)
            {
                MessageBox.Show("Trùng mã khoa, thêm thất bại");
            }
            else
            {
                string sqlthem = "insert into khoa values('" + makhoa + "',N'" + tenkhoa + "',N'" + diachi + "','" + sdt + "')";
                SqlCommand cmd = new SqlCommand(sqlthem, cn.con);
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cn.CloseConn();
                    MessageBox.Show("Thêm thành công");
                }
                catch
                {
                    cmd.Dispose();
                    cn.CloseConn();
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            hienthi();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            Connection cn = new Connection();
            cn.OpenConn();
            string makhoa = txtmakhoa.Text;
            string tenkhoa = txttenkhoa.Text;
            string diachi = txtdiachi.Text;
            string sdt = txtsdt.Text;
            cm = new SqlCommand("select makhoa from khoa where makhoa='" + makhoa + "'", cn.con);
            string ma = cm.ExecuteScalar() as string;
            if (makhoa == ma)
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa?", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult.OK == dlr)
                {
                    string sqlsua = "update khoa set MAKHOA='" + makhoa + "',TENKHOA='" + tenkhoa + "',DIACHI='" + diachi + "',SDT='" + sdt + "' where  MAKHOA='" + makhoa + "'";
                    SqlCommand cmd = new SqlCommand(sqlsua, cn.con);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cn.CloseConn();
                        MessageBox.Show("Sửa thành công");
                    }
                    catch
                    {
                        cmd.Dispose();
                        cn.CloseConn();
                        MessageBox.Show("Sửa thất bại!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Không thay đổi mã khoa!");
            }
            hienthi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Connection cn = new Connection();
            cn.OpenConn();
            string makhoa = txtmakhoa.Text;
            cm = new SqlCommand("select makhoa from khoa where makhoa='" + makhoa + "'", cn.con);
            string ma = cm.ExecuteScalar() as string;
            if (makhoa == ma)
            {
                DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa?", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult.OK == dlr)
                {
                    string sqlxoa = "delete khoa where makhoa='" + makhoa + "'";
                    SqlCommand cmd = new SqlCommand(sqlxoa, cn.con);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cn.CloseConn();
                        MessageBox.Show("Xóa thành công");
                        btnLammoi_Click(sender, e);
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
            this.Dispose();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (txtTK.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin cần tìm!");
            }
            else
            {
                Connection cn = new Connection();
                cn.OpenConn();
                string makhoa = txtTK.Text;
                string sqltk = "select *from khoa where makhoa ='" + makhoa + "'";
                SqlCommand cmd = new SqlCommand(sqltk, cn.con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvDSkhoa.DataSource = dt;
            }
        }

        private void dgvDSkhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDSkhoa.Rows[e.RowIndex];

                txtmakhoa.Text = row.Cells[0].Value.ToString();
                txttenkhoa.Text = row.Cells[1].Value.ToString();
                txtdiachi.Text = row.Cells[2].Value.ToString();
                txtsdt.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}
