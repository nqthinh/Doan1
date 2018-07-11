using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraEditors;
using ValueObject;
using BusinessLogicLayer;
using DataAccessLayer;
namespace QuanLyKhachSan
{
    public partial class FrmTinhTrangPhong : DevExpress.XtraEditors.XtraForm
    {
        public FrmTinhTrangPhong()
        {
            InitializeComponent();
        }
        dbConnect db = new dbConnect();
        BUSKhachHang bus = new BUSKhachHang();
        ObjKhachHang obj = new ObjKhachHang();
        BUSHoaDon busHoaDon = new BUSHoaDon();
        BUSPhong busPhong = new BUSPhong();
        ObjHoaDon objHD = new ObjHoaDon();
        BUSNhanVien busNhanVien = new BUSNhanVien();
        ObjPhong objPhong = new ObjPhong();
        private bool IsInsert = true;

        public string MaTuTang()
        {
            string s, snew;
            int i = 0;
            try
            {
                string str = "select top 1 KH_MAKH from KHACHHANG ORDER BY KH_MAKH DESC";
                s = db.getData(str).Rows[0][0].ToString();
                snew = s.Substring(3).ToString();
                i = int.Parse(snew);
                i++;
                if (i < 10)
                    return "KH0000" + i.ToString();
                else if (i >= 10 && i < 100)
                    return "KH000" + i.ToString();
                else if (i > 100 && i < 1000)
                    return "KH00" + i.ToString();
                else if (i > 1000 && i < 10000)
                    return "KH0" + i.ToString();
                else
                    return "KH" + i.ToString();
            }
            catch
            {
                return "KH00001";
            }
        }
        public string MaTuTangHOADON()
        {
            string s, snew;
            int i = 0;
            try
            {
                string str = "select top 1 HD_MAHD from HOADON ORDER BY HD_MAHD DESC";
                s = db.getData(str).Rows[0][0].ToString();
                snew = s.Substring(3).ToString();
                i = int.Parse(snew);
                i++;
                if (i < 10)
                    return "HD0000" + i.ToString();
                else if (i >= 10 && i < 100)
                    return "HD000" + i.ToString();
                else if (i > 100 && i < 1000)
                    return "HD00" + i.ToString();
                else if (i > 1000 && i < 10000)
                    return "HD0" + i.ToString();
                else
                    return "HD" + i.ToString();
            }
            catch
            {
                return "HD00001";
            }
        }

        void LoadList(){
            listView.Items.Clear();

            string connectionString = @"Data Source=210.245.90.220,1433;Network Library=DBMSSOCN;Initial Catalog=vtechsne_QLKS;User ID=vtechsne_QLKS;Password=#842Ewzm";
            SqlConnection connect = new SqlConnection(connectionString);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_TRANGTHAI_SELECT_ALL", connect);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);


        
            foreach (DataRow dr in dt.Rows)
            {
                listView.View = View.LargeIcon;
                listView.LargeImageList = imageList1;

                ListViewItem item = new ListViewItem(dr["SOPHONG"].ToString(), 2);
                item.SubItems.Add(dr["LPHG_TENLOAI"].ToString());
                item.SubItems.Add(dr["PHG_GIA"].ToString());
                item.SubItems.Add(dr["PHG_HIENTRANG"].ToString());

                listView.Items.Add(item);

            }
        }
        private void FrmTinhTrangPhong_Load(object sender, EventArgs e)
        {
            cbbNhanVien.Properties.DataSource = busNhanVien.getData();
            cbbNhanVien.Properties.DisplayMember = "NV_HOTEN";
            cbbNhanVien.Properties.ValueMember = "NV_MANV";
            txtHienTrang.Enabled = false;

            txtMaKH.Text = MaTuTang();
            txtMaHoaDon.Text = MaTuTangHOADON();
            txtMaKH.Enabled = false;
            txtMaHoaDon.Enabled = false;
            txtMaPhong.Enabled = false;
            txtHienTrang.Enabled = false;
            txtLoaiPhong.Enabled = false;
            txtGiaPhong.Enabled = false;
            LoadList();
           
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {   
           try
           {
               if (this.listView.SelectedIndices.Count > 0)
               {
                   txtMaPhong.Text = listView.SelectedItems[0].SubItems[0].Text;
                   txtLoaiPhong.Text = listView.SelectedItems[0].SubItems[1].Text;
                   txtGiaPhong.Text = listView.SelectedItems[0].SubItems[2].Text;
                   txtHienTrang.Text = listView.SelectedItems[0].SubItems[3].Text;

               }
           }
            catch
           {

           }
            
        }

        private void btnDatPhong2_Click(object sender, EventArgs e)
        {
            //Thêm thông tin khách hàng
            obj.KH_MaKH = txtMaKH.Text;
            obj.KH_TenKH = txtTenKH.Text;
            obj.KH_SDT = txtSDT.Text;


            //Lưu thông tin vào hóa đơn
            objHD.HD_MaHoaDon = txtMaHoaDon.Text;
            objHD.HD_NgayHoaDon = DateTime.ParseExact(dateNgayDatPhong.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            objHD.HD_NgayThue = DateTime.ParseExact(dateNgayNhanPhong.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            objHD.HD_SoLuongKhach = txtSoLuongKhach.Text;
            objHD.NV_MANV = cbbNhanVien.EditValue.ToString();
            objHD.PHG_MaPhong = txtMaPhong.Text;
            objHD.KH_MaKH = txtMaKH.Text;
            objHD.HD_TrangThaiHoaDon = "Chưa thanh toán";

            //Cập nhật trạng thái phòng



            try
            {
                if (IsInsert == true)
                {
                    if (txtMaKH.Text == "" || txtMaHoaDon.Text == "")
                    {
                        XtraMessageBox.Show("Mã khách hàng không được để trống. Vui lòng điền thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtSoLuongKhach.Text == "" || txtTenKH.Text == "" || txtSDT.Text == "" || dateNgayDatPhong.Text == "" || dateNgayNhanPhong.Text == "" ){
                        XtraMessageBox.Show("Thông tin khách hàng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        if (txtHienTrang.Text == "Đang thuê")
                        {
                            XtraMessageBox.Show("Phòng này đã được thuê. Vui lòng chọn phòng khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (txtHienTrang.Text == "Không sử dụng")
                        {
                            XtraMessageBox.Show("Phòng này hiện không được sử dụng. Vui lòng chọn phòng khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if ((txtHienTrang.Text == "Đang sữa chữa"))
                        {
                            if (XtraMessageBox.Show("Phòng này đang được sửa chữa bạn có chắc chắn muốn thuê", "Đang chờ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                txtHienTrang.Text = "Đang thuê";
                                objPhong.PHG_HienTrang = txtHienTrang.Text;
                                objPhong.PHG_MaPhong = txtMaPhong.Text;
                                busPhong.UpdateTrangThai(objPhong); //Cập nhật trạng thái phòng
                                bus.InsertDK(obj); //Insert khách hàng

                                busHoaDon.Insert(objHD); //Insert Hóa đơn
                                LoadList();
                            }
                        }
                        else
                        {
                            txtHienTrang.Text = "Đang thuê";
                            objPhong.PHG_HienTrang = txtHienTrang.Text;
                            objPhong.PHG_MaPhong = txtMaPhong.Text;
                            busPhong.UpdateTrangThai(objPhong); //Cập nhật trạng thái phòng
                            bus.InsertDK(obj); //Insert khách hàng
                            busHoaDon.Insert(objHD); //Insert Hóa đơn
                            LoadList();
                        }
                        XtraMessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Thông tin nhập vào không chính xác, vui lòng kiểm tra lại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void XoaText()
        {
            txtMaHoaDon.Text = string.Empty;
            txtMaKH.Text = string.Empty;
            txtMaPhong.Text = string.Empty;
            txtLoaiPhong.Text = String.Empty;
            txtGiaPhong.Text = string.Empty;
            txtHienTrang.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            dateNgayDatPhong.Text = string.Empty;
            dateNgayNhanPhong.Text = string.Empty;
            txtSoLuongKhach.Text = string.Empty;
            txtSDT.Text = string.Empty;
            cbbNhanVien.Text = string.Empty;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XoaText();
            LoadList(); //Tải lại
            txtMaKH.Text = MaTuTang();
            txtMaHoaDon.Text = MaTuTangHOADON();
            
        }
    }
}