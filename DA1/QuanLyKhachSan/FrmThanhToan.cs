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
using ValueObject;
namespace QuanLyKhachSan
{
    public partial class FrmThanhToan : DevExpress.XtraEditors.XtraForm
    {
        public FrmThanhToan()
        {
            InitializeComponent();
        }

        BUSChiTietHoaDon busChiTietHoaDon = new BUSChiTietHoaDon();
        public string ID = "";
        BUSPhong busPhong = new BUSPhong();
        ObjPhong objPhong = new ObjPhong();
        ObjHoaDon objHoaDon = new ObjHoaDon();
        BUSHoaDon busHoaDon = new BUSHoaDon();
        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            txtMaHoaDon.Enabled = false;
            txtPhong.Enabled = false;
            txtTrangThai.Enabled = false;
            dateNgayTra.Enabled = false;
            DataTable dt = new DataTable();
            dt = busChiTietHoaDon.getDataMaHoaDon(ID);
            txtMaHoaDon.Text = ID; 
            if (dt.Rows.Count > 0)
            {
                txtPhong.Text = dt.Rows[0]["PHG_MAPHONG"].ToString();
                txtTrangThai.Text = dt.Rows[0]["HD_TRANGTHAI"].ToString();
            }
            dgvCTHD.DataSource = busHoaDon.GetDataSuDungDichVu(txtMaHoaDon.Text);
        }

        private void btnChapNhan_Click(object sender, EventArgs e)
        {
            objPhong.PHG_HienTrang = "Chưa thuê";
            objPhong.PHG_MaPhong = txtPhong.Text;
            objHoaDon.HD_MaHoaDon = txtMaHoaDon.Text;
            objHoaDon.HD_NgayTra = dateNgayTra.Text = DateTime.Now.ToString();
            objHoaDon.HD_TrangThaiHoaDon = "Đã thanh toán";
            try
            {
                if(txtTrangThai.Text == "Đã thanh toán")
                {
                    XtraMessageBox.Show("Hóa đơn này đã được thanh toán trước đó, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtTrangThai.Text == "Đã hủy")
                {
                    XtraMessageBox.Show("Hóa đơn này đã bị hủy, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                else
                {
                    busPhong.UpdateTrangThai(objPhong);
                    busHoaDon.UpdateTrangThai(objHoaDon);
                    dgvCTHD.ShowRibbonPrintPreview();
                    XtraMessageBox.Show("Đã thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch
            { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}