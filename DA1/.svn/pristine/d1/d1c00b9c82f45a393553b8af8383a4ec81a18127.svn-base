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


using ValueObject;
using BusinessLogicLayer;
using DataAccessLayer;
namespace QuanLyKhachSan
{
    public partial class FrmSuDungDichVu : DevExpress.XtraEditors.XtraForm
    {
        BUSChiTietHoaDon busChiTietHoaDon = new BUSChiTietHoaDon();
        public FrmSuDungDichVu()
        {
            InitializeComponent();
        }

        dbConnect db = new dbConnect();
        BUSDichVu busdichvu = new BUSDichVu();
        ObjChiTietHoaDon objChiTietHoaDon = new ObjChiTietHoaDon();
        BUSChiTietHoaDon busCTHD = new BUSChiTietHoaDon();
        BUSHoaDon busHoaDon = new BUSHoaDon();
        public bool isinsert = false;
        public EventHandler LamMoi;
        public string ID = "";
        ObjHoaDon objHoaDon = new ObjHoaDon();



        //Xóa dữ liệu textbox
        void XoaText()
        {
            //txtMaCTHD.Text = String.Empty;
            cbbDichVu.Text = String.Empty;
            txtDonGia.Text = String.Empty;
            txtSoLuong.Text = String.Empty;
        }

        //Khóa textbox
        void KhoaText()
        {
            cbbDichVu.Enabled = false;
            txtSoLuong.Enabled = false;
            dateNgayGioSuDung.Enabled = false;
        }

        //Mở khóa textbox
        void MoKhoaText()
        {
            cbbDichVu.Enabled = true;
            txtSoLuong.Enabled = true;
            dateNgayGioSuDung.Enabled = true;
        }
        private void FrmSuDungDichVu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vtechsne_QLKSDataSet.DICHVU' table. You can move, or remove it, as needed.
            cbbDichVu.Properties.DataSource = busdichvu.GetData();
            cbbDichVu.Properties.ValueMember = "DV_MADV";
            cbbDichVu.Properties.DisplayMember = "DV_TENDV";
            btnSua.Enabled = false;
            btnNhapMoi.Enabled = false;
            btnLuu.Enabled = true;
            txtMaHoaDon.Enabled = false;
            txtMaCTHD.Enabled = false;
            try
            {
                if (isinsert == false)
                {
                    DataTable dt = new DataTable();
                    dt = busChiTietHoaDon.GetDataByID(ID);
                    txtMaCTHD.Text = ID;
                    txtSoLuong.Text = dt.Rows[0]["CTHD_SOLUONG"].ToString();
                    dateNgayGioSuDung.Text = dt.Rows[0]["CTHD_NGAYSUDUNGDV"].ToString();
                    txtMaHoaDon.Text = dt.Rows[0]["HD_MAHD"].ToString();
                    cbbDichVu.Text = dt.Rows[0]["DV_TENDV"].ToString();
                    txtDonGia.Text = dt.Rows[0]["DV_GIADICHVU"].ToString();
                    txtThanhTien.Text = (Double.Parse(txtDonGia.Text) * Double.Parse(txtSoLuong.Text)).ToString();
                    dgvCTHD.DataSource = busChiTietHoaDon.getDataMaHoaDon(txtMaHoaDon.Text); //Hiển thị danh sách sử dụng dịch vụ của txtMaHoaDon
                    btnLuu.Enabled = true;
                }
                else
                {
                    btnNhapMoi.Enabled = true;
                    DataTable dt = new DataTable();
                    txtMaCTHD.Text = MaTuTang();
                    dt = busChiTietHoaDon.getDataMaHoaDon(ID);
                    txtMaHoaDon.Text = ID;
                    dgvCTHD.DataSource = busChiTietHoaDon.getDataMaHoaDon(txtMaHoaDon.Text); //Hiển thị danh sách sử dụng dịch vụ của txtMaHoaDon
                    txtThanhTien.Text = (Double.Parse(txtDonGia.Text) * Double.Parse(txtSoLuong.Text)).ToString();
                    btnLuu.Enabled = true;
                }
            }
            catch
            {}
        }
        public string MaTuTang()
        {
            string s, snew;
            int i = 0;
            try
            {
                string str = "select top 1 CTHD_MACTHD from CHITIETHD ORDER BY CTHD_MACTHD DESC";
                s = db.getData(str).Rows[0][0].ToString();
                snew = s.Substring(3).ToString();
                i = int.Parse(snew);
                i++;
                if (i < 10)
                    return "CT0000" + i.ToString();
                else if (i >= 10 && i < 100)
                    return "CT000" + i.ToString();
                else if (i > 100 && i < 1000)
                    return "CT00" + i.ToString();
                else if (i > 1000 && i < 10000)
                    return "CT0" + i.ToString();
                else
                    return "CT" + i.ToString();
            }
            catch
            {
                return "CT00001";
            }
        }
        //Khi một dịch vụ được chọn, thì đơn giá sẽ thay đổi
        private void cbbDichVu_EditValueChanged(object sender, EventArgs e)
        {
           try
           {
               txtDonGia.EditValue = cbbDichVu.GetColumnValue("DV_GIADICHVU").ToString();
           }
            catch
           { }
            
        }
        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            XoaText();
            txtMaCTHD.Text = MaTuTang();
            MoKhoaText();
            isinsert = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {

            isinsert = false;
            MoKhoaText();
            btnNhapMoi.Enabled = false;
        } 
        //Tính textbox thành tiền
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtThanhTien.Text = (Double.Parse(txtDonGia.Text) * Double.Parse(txtSoLuong.Text)).ToString();
            }
            catch
            { }
        }
        //Lưu lại CTHD
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
            objChiTietHoaDon.CTHD_MaChiTietHoaDon = txtMaCTHD.Text;
            objChiTietHoaDon.CTHD_NgaySuDungDichVu = DateTime.ParseExact(dateNgayGioSuDung.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            objChiTietHoaDon.CTHD_MaDichVu = cbbDichVu.EditValue.ToString();
            objChiTietHoaDon.CTHD_SoLuong = txtSoLuong.Text;
            objChiTietHoaDon.HD_MaHoaDon = txtMaHoaDon.Text;

                if (isinsert == true)
                {
                        busChiTietHoaDon.Insert(objChiTietHoaDon);
                        XtraMessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvCTHD.DataSource = busChiTietHoaDon.getDataMaHoaDon(txtMaHoaDon.Text); //Hiển thị danh sách sử dụng dịch vụ của txtMaHoaDon
                        XoaText();
                        KhoaText();
                        txtMaCTHD.Text = string.Empty;
                        txtMaCTHD.Text = MaTuTang();
                        btnNhapMoi.Enabled = true;
                }
                else
                {
                        busChiTietHoaDon.Update(objChiTietHoaDon);
                        XtraMessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvCTHD.DataSource = busChiTietHoaDon.getDataMaHoaDon(txtMaHoaDon.Text); //Hiển thị danh sách sử dụng dịch vụ của txtMaHoaDon
                        XoaText();
                        KhoaText();
                        txtMaCTHD.Text = string.Empty;
                        txtMaCTHD.Text = MaTuTang();
                        btnNhapMoi.Enabled = true;
                }
            }
            catch
            {
                XtraMessageBox.Show("Thông tin nhập bị thiếu hoặc có sai sót, nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Load lại lưới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                btnNhapMoi.Enabled = true;
                dgvCTHD.DataSource = busChiTietHoaDon.getDataMaHoaDon(txtMaHoaDon.Text); //Hiển thị danh sách sử dụng dịch vụ của txtMaHoaDon
            }
            catch
            { }
            
        }
        //Click vào CTHD
        private void dgvCTHD_Click(object sender, EventArgs e)
        {
            try
            {
                isinsert = false;
                KhoaText();
                btnSua.Enabled = true;
                txtMaHoaDon.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HD_MAHD").ToString();
                txtMaCTHD.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CTHD_MACTHD").ToString();
                dateNgayGioSuDung.Text = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CTHD_NGAYSUDUNGDV").ToString()).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                txtSoLuong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CTHD_SOLUONG").ToString();
                txtDonGia.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DV_GIADICHVU").ToString();
                cbbDichVu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            }
            catch
            {}
        }
        //In CTHD
        private void btnInPhieu_Click_1(object sender, EventArgs e)
        {
            try
            {
                dgvCTHD.ShowRibbonPrintPreview();
            }
            catch
            { }
            
        }
        //Xóa CTHĐ
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa thông tin này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtMaCTHD.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                try
                {
                    busCTHD.Delete(txtMaCTHD.Text);
                    XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhoaText();
                    dgvCTHD.DataSource = busChiTietHoaDon.getDataMaHoaDon(txtMaHoaDon.Text); //Hiển thị danh sách sử dụng dịch vụ của txtMaHoaDon
                    XoaText();
                }
                catch
                {
                    XtraMessageBox.Show("Lỗi dữ liệu, Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        
    }
}