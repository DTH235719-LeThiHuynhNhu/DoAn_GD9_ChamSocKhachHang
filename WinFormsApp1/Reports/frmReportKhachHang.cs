using ChamSocKhachHang.Data;
using ChamSocKhachHang.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChamSocKhachHang.Reports
{
    public partial class frmReportKhachHang : Form
    {
        CSKHContext context = new CSKHContext();

        public frmReportKhachHang()
        {
            InitializeComponent();
        }

        private void frmReportKhachHang_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "Reports/rptKhachHang.rdlc";

            // 🔥 Load combobox nhân viên
            cbNhanVien.Items.Add("Tất cả");

            foreach (var nv in context.NhanViens.ToList())
            {
                cbNhanVien.Items.Add(nv.HoTen);
            }

            cbNhanVien.SelectedIndex = 0;

            // 🔥 Load combobox sắp xếp
            cbSapXep.Items.Add("Tên A-Z");
            cbSapXep.Items.Add("Tên Z-A");

            // 🔥 Load report lần đầu
            LoadReport();
        }

        // 🔥 HÀM LOAD REPORT (CỐT LÕI)
        void LoadReport(string nhanVien = "Tất cả", string sapXep = "")
        {
            List<KhachHangDTO> ds = new List<KhachHangDTO>();

            int stt = 1;

            var khachHangs = context.KhachHangs.ToList();
            var lichSus = context.LichSuChamSocs
                                .Include("NhanVien")
                                .ToList();

            foreach (var item in khachHangs)
            {
                var lichSu = lichSus.Where(ls => ls.KhachHangID == item.ID);

                // 🔥 LỌC THEO NHÂN VIÊN
                if (nhanVien != "Tất cả")
                {
                    lichSu = lichSu.Where(ls =>
                        ls.NhanVien != null &&
                        ls.NhanVien.HoTen != null &&
                        ls.NhanVien.HoTen.Trim().ToLower() == nhanVien.Trim().ToLower()
                    );
                }

                if (!lichSu.Any()) continue;

                ds.Add(new KhachHangDTO
                {
                    STT = stt++,
                    HoTen = item.HoTen,
                    DienThoai = item.DienThoai,
                    Email = item.Email,
                    DiaChi = item.DiaChi,

                    LichSuChamSoc = string.Join(", ",
                        lichSu.Select(ls => ls.GhiChu)),

                    NhanVienPhuTrach = string.Join(", ",
                        lichSu.Select(ls => ls.NhanVien != null ? ls.NhanVien.HoTen : ""))
                });
                // 🔥 TÌM KIẾM THEO TÊN
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    ds = ds.Where(x =>
                        x.HoTen != null &&
                        x.HoTen.ToLower().Contains(txtSearch.Text.ToLower())
                    ).ToList();
                }
            }

            // 🔥 SẮP XẾP
            if (sapXep == "Tên A-Z")
                ds = ds.OrderBy(x => x.HoTen).ToList();

            if (sapXep == "Tên Z-A")
                ds = ds.OrderByDescending(x => x.HoTen).ToList();

            // 🔥 ĐỔ VÀO REPORT
            ReportDataSource rds = new ReportDataSource("DanhSachKhachHang", ds);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }


        private void btnLoc_Click_1(object sender, EventArgs e)
        {
            string nv = cbNhanVien.SelectedItem.ToString();
            string sort = cbSapXep.SelectedItem?.ToString();

            LoadReport(nv, sort);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadReport(cbNhanVien.Text, cbSapXep.Text);
        }
    }
}