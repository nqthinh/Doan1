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
    public partial class frmDoanhThuDichVu : DevExpress.XtraEditors.XtraForm
    {
        public frmDoanhThuDichVu()
        {
            InitializeComponent();
        }
        BUSChiTietHoaDon busCTHD = new BUSChiTietHoaDon();

        private void frmDoanhThuDichVu_Load(object sender, EventArgs e)
        {
            dgvDoanhThuDichVu.DataSource = busCTHD.getDataDoanhThu();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dgvDoanhThuDichVu.ShowRibbonPrintPreview();
        }
    }
}