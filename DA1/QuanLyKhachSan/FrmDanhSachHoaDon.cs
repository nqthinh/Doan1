using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BusinessLogicLayer;
namespace QuanLyKhachSan
{
    public partial class FrmDanhSachHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public FrmDanhSachHoaDon()
        {
            InitializeComponent();
        }
        BUSHoaDon bus = new BUSHoaDon();
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrmDanhSachHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                dgvTraCuu.DataSource = bus.GetDataTruCuu();
            }
            catch
            {}
        }
    }
}