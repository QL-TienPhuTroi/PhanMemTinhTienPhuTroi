﻿using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GroupAminGUI
{
    public partial class frmAddDetailTeaching : Form
    {
        ThoiGianDayBLL tgd_bll =new ThoiGianDayBLL();
        GiaoVienBLL gv_bll =new GiaoVienBLL();
        ChiTietLichDayBLL ctld_bll = new ChiTietLichDayBLL();
        ChiTietLichDayDTO ctld_dto = new ChiTietLichDayDTO();
        XacNhanLichDayBLL xnld_bll = new XacNhanLichDayBLL();
        XacNhanLichDayDTO xnld_dto = new XacNhanLichDayDTO();
        MonHocBLL mh_bll = new MonHocBLL();

        ChuNhiemBLL cn_bll = new ChuNhiemBLL();
        BacLuongBLL bl_bll = new BacLuongBLL();
        LopHocBLL lp_bll = new LopHocBLL();
        PhuTroiBLL pt_bll = new PhuTroiBLL();
        PhuTroiDTO pt_dto = new PhuTroiDTO();

        string pMaLich, pMaLP, pTenLP, pTenMH, pMaGV, pNamHoc, pThu;
        DateTime pNgayDay, pThoiGianBatDau;
        int pTietDay, pMaMH;

        frmDetailLesson fDetailLesson = new frmDetailLesson();

        public frmAddDetailTeaching(string _malich, string _malop,string _tenlop, string _tenmh, string _magv, DateTime _thoigianbatdau, int _mamh, string _namhoc)
        {
            InitializeComponent();
            pMaLich = _malich;
            pMaLP = _malop;
            pTenLP = _tenlop;
            pTenMH = _tenmh;
            pMaGV = _magv;
            pMaMH = _mamh;
            pNamHoc = _namhoc;
            pThoiGianBatDau = _thoigianbatdau;
            this.Load += FrmAddDetailTeaching_Load;
            lbDetail.Click += LbDetail_Click;
            btnFinish.Click += BtnFinish_Click;
            btnRemove.Click += BtnRemove_Click;
            btnClearAll.Click += BtnClearAll_Click;
            btnRemoveLesson.Click += BtnRemoveLesson_Click;
            btnRemoveLessonAll.Click += BtnRemoveLessonAll_Click;
            dtpThu.ValueChanged += DtpThu_ValueChanged;
        }

        private void DtpThu_ValueChanged(object sender, EventArgs e)
        {
            DateTime minDate = pThoiGianBatDau;

            if (dtpThu.Value < minDate)
            {
                MessageBox.Show("THỜI GIAN KHÔNG ĐÚNG TRONG KẾ HOẠCH! ", "PHẦN MỀM TÍNH PHỤ TRỘI");
                dtpThu.Value = minDate;
            }
        }

        private void BtnRemoveLessonAll_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("BẠN CÓ MUỐN CHẮC XÓA LỊCH DẠY CỦA GIÁO VIÊN NÀY KHÔNG KHÔNG?", "PHẦN MỀM TÍNH PHỤ TRỘI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                pMaLich = dgvDetailTeachingSchedule.CurrentRow.Cells[0].Value.ToString();
                pThu = dgvDetailTeachingSchedule.CurrentRow.Cells[1].Value.ToString();
                pNgayDay = DateTime.Parse(dgvDetailTeachingSchedule.CurrentRow.Cells[2].Value.ToString());
                pTietDay = int.Parse(dgvDetailTeachingSchedule.CurrentRow.Cells[3].Value.ToString());

                xnld_bll.removeXNLDThu(pMaLich, pNgayDay);

                if (ctld_bll.removeCTLD(pMaLich, pThu))
                {

                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG LỊCH DẠY CỦA GIÁO VIÊN NÀY", "PHẦN MỀM TÍNH PHỤ TRỘI");
                    loadDataDetailTeaching();
                    loadLesson();
                }
                else
                {
                    MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM TÍNH PHỤ TRỘI");
                }
            }
        }

        private void BtnRemoveLesson_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("BẠN CÓ MUỐN CHẮC XÓA LỊCH DẠY CỦA GIÁO VIÊN NÀY KHÔNG KHÔNG?", "PHẦN MỀM TÍNH PHỤ TRỘI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                pMaLich = dgvDetailTeachingSchedule.CurrentRow.Cells[0].Value.ToString();
                pNgayDay = DateTime.Parse(dgvDetailTeachingSchedule.CurrentRow.Cells[2].Value.ToString());
                pTietDay = int.Parse(dgvDetailTeachingSchedule.CurrentRow.Cells[3].Value.ToString());

                xnld_bll.removeXNLD(pMaLich, pTietDay, pNgayDay);

                if (ctld_bll.removeCTLD(pMaLich, pNgayDay, pTietDay))
                {

                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG LỊCH DẠY CỦA GIÁO VIÊN NÀY", "PHẦN MỀM TÍNH PHỤ TRỘI");
                    loadDataDetailTeaching();
                    loadLesson();
                }
                else
                {
                    MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM TÍNH PHỤ TRỘI");
                }
            }
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("BẠN CÓ MUỐN CHẮC XÓA TOÀN BỘ LỊCH DẠY CỦA GIÁO VIÊN NÀY KHÔNG KHÔNG?", "PHẦN MỀM TÍNH PHỤ TRỘI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                pMaLich = dgvDetailTeachingSchedule.CurrentRow.Cells[0].Value.ToString();
                pNgayDay = DateTime.Parse(dgvDetailTeachingSchedule.CurrentRow.Cells[2].Value.ToString());
                pTietDay = int.Parse(dgvDetailTeachingSchedule.CurrentRow.Cells[3].Value.ToString());

                xnld_bll.removeXNLD(pMaLich);

                if (ctld_bll.removeCTLD(pMaLich))
                {

                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG TOÀN BỘ LỊCH DẠY CỦA GIÁO VIÊN NÀY", "PHẦN MỀM TÍNH PHỤ TRỘI");
                    loadDataDetailTeaching();
                    loadLesson();
                }
                else
                {
                    MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM TÍNH PHỤ TRỘI");
                }
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("BẠN CÓ MUỐN CHẮC XÓA LỊCH DẠY CỦA GIÁO VIÊN NÀY KHÔNG KHÔNG?", "PHẦN MỀM TÍNH PHỤ TRỘI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                pMaLich = dgvDetailTeachingSchedule.CurrentRow.Cells[0].Value.ToString();
                pNgayDay = DateTime.Parse(dgvDetailTeachingSchedule.CurrentRow.Cells[2].Value.ToString());
                pTietDay = int.Parse(dgvDetailTeachingSchedule.CurrentRow.Cells[3].Value.ToString());

                xnld_bll.removeXNLD(pMaLich, pTietDay, pNgayDay);

                if (ctld_bll.removeCTLD(pMaLich, pNgayDay))
                {

                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG LỊCH DẠY CỦA GIÁO VIÊN NÀY", "PHẦN MỀM TÍNH PHỤ TRỘI");
                    loadDataDetailTeaching();
                    loadLesson();
                }
                else
                {
                    MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM TÍNH PHỤ TRỘI");
                }
            }
        }

        private void BtnFinish_Click(object sender, EventArgs e)
            {
            try
            {
                DateTime pNgayDay = dtpThu.Value;
                int pTietDay = int.Parse(cboLesson.SelectedValue.ToString());
                string _tenmhcl = ctld_bll.getNameLessonCungLop(pMaLP, pNgayDay, pTietDay);
                string _tenmhkl = ctld_bll.getNameLessonKhacLop(pMaGV, pNgayDay, pTietDay);
                string _tenlp = ctld_bll.getNameClassroom(pNgayDay, pTietDay);
                DateTime pNgayDauTuan = ctld_bll.FindStartOfWeek(pNgayDay);
                int pSoTietDay = (int)ctld_bll.getCountLessonInWeek(pMaGV, pNgayDauTuan, pNamHoc);
                int pSoDinhMucTietDay = (int)gv_bll.getDinhMucTietDay(pMaGV, pNamHoc);
                int pSoTietToiDaMH = (int)mh_bll.getSoTietToiDa(pMaMH);
                int pSoTietPhanMH = (int)ctld_bll.getCountLessonInWeek(pMaGV, pNgayDauTuan, pNamHoc, pMaMH, pMaLP);

                if(pSoTietPhanMH < pSoTietToiDaMH)
                {
                    if (pSoTietDay >= pSoDinhMucTietDay)
                    {
                        DialogResult r = MessageBox.Show("BẠN ĐÃ PHÂN CHO GIÁO VIÊN NÀY " + pSoTietDay + " TIẾT TRÊN TUẦN ĐÃ VƯỢT QUA ĐỊNH MỨC TIẾT DẠY CỦA GIÁO VIÊN NÀY LÀ " + pSoDinhMucTietDay + " TIẾT, BẠN CÓ CHẮC VẪN MUỐN PHÂN LỊCH CHO GIÁO VIÊN NÀY?", "PHẦN MỀM TÍNH PHỤ TRỘI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (ctld_bll.checkTrungMon(pMaMH, pNgayDay, pTietDay))
                            {
                                MessageBox.Show("MÔN " + pTenMH.ToUpper() + " ĐÃ ĐƯỢC PHÂN LỊCH VÀO TIẾT " + pTietDay + " CỦA LỚP " + pTenLP + " NÀY RỒI!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                            }
                            else if (ctld_bll.checkTrungLichCungLop(pMaLP, pNgayDay, pTietDay))
                            {
                                MessageBox.Show("KHÔNG THỂ THÊM LỊCH DẠY MÔN " + pTenMH.ToUpper() + " DO TRÙNG LỊCH VỚI MÔN " + _tenmhcl.ToUpper(), "PHẦN MỀM TÍNH PHỤ TRỘI");
                            }
                            else if (ctld_bll.checkTrungLichKhacLop(pMaGV, pNgayDay, pTietDay))
                            {
                                MessageBox.Show("KHÔNG THỂ THÊM LỊCH DẠY DO GIÁO VIÊN " + gv_bll.getNameGiaoVien(pMaGV).ToUpper() + " ĐANG DẠY MÔN " + _tenmhkl.ToUpper() + " Ở LỚP " + _tenlp.ToUpper(), "PHẦN MỀM TÍNH PHỤ TRỘI");
                            }
                            else
                            {
                                for (int i = 0; i <= 36; i++)
                                {
                                    ctld_dto.malich = pMaLich;
                                    ctld_dto.thu = GetDayOfWeek(pNgayDay);
                                    ctld_dto.ngayday = pNgayDay.AddDays(i * 7);
                                    ctld_dto.tietday = pTietDay;

                                    ctld_bll.addCTLD(ctld_dto);

                                    if (!xnld_bll.checkPK(ctld_dto.malich, ctld_dto.ngayday, ctld_dto.tietday))
                                    {
                                        xnld_dto.malich = pMaLich;
                                        xnld_dto.ngayday = ctld_dto.ngayday;
                                        xnld_dto.tietday = ctld_dto.tietday;
                                        xnld_dto.hoanthanh = false;

                                        xnld_bll.addXNLD(xnld_dto);
                                    }
                                }
                                MessageBox.Show("LỊCH DẠY ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                                loadDataDetailTeaching();
                                loadLesson();
                            }
                        }
                    }
                    else
                    {                        
                        if (ctld_bll.checkTrungLichCungLop(pMaLP, pNgayDay, pTietDay))
                        {
                            MessageBox.Show("KHÔNG THỂ THÊM LỊCH DẠY MÔN " + pTenMH.ToUpper() + " DO TRÙNG LỊCH VỚI MÔN " + _tenmhcl.ToUpper(), "PHẦN MỀM TÍNH PHỤ TRỘI");
                        }
                        else if (ctld_bll.checkTrungLichKhacLop(pMaGV, pNgayDay, pTietDay))
                        {
                            MessageBox.Show("KHÔNG THỂ THÊM LỊCH DẠY DO GIÁO VIÊN " + gv_bll.getNameGiaoVien(pMaGV).ToUpper() + " ĐANG DẠY MÔN " + _tenmhkl.ToUpper() + " Ở LỚP " + _tenlp.ToUpper(), "PHẦN MỀM TÍNH PHỤ TRỘI");
                        }
                        else
                        {
                            for (int i = 0; i <= 36; i++)
                            {
                                ctld_dto.malich = pMaLich;
                                ctld_dto.thu = GetDayOfWeek(pNgayDay);
                                ctld_dto.ngayday = pNgayDay.AddDays(i * 7);
                                ctld_dto.tietday = pTietDay;

                                ctld_bll.addCTLD(ctld_dto);

                                if (!xnld_bll.checkPK(ctld_dto.malich, ctld_dto.ngayday, ctld_dto.tietday))
                                {
                                    xnld_dto.malich = pMaLich;
                                    xnld_dto.ngayday = ctld_dto.ngayday;
                                    xnld_dto.tietday = ctld_dto.tietday;
                                    xnld_dto.hoanthanh = false;

                                    xnld_bll.addXNLD(xnld_dto);
                                }
                            }
                            MessageBox.Show("LỊCH DẠY ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                            loadDataDetailTeaching();
                            loadLesson();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("KHÔNG THỂ PHÂN LỊCH DO SỐ TIẾT DẠY CỦA MÔN " + pTenMH.ToUpper() + " ĐÃ ĐỦ CHO MỘT TUẦN", "PHẦN MỀM TÍNH PHỤ TRỘI");
                }

                calExtraness();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void LbDetail_Click(object sender, EventArgs e)
        {
            fDetailLesson.ShowDialog();
        }

        private void FrmAddDetailTeaching_Load(object sender, EventArgs e)
        {
            txtMaLD.Text = pMaLich;
            lbTitle.Text = "CHI TIẾT KẾ HOẠCH PHÂN CÔNG GIÁO VIÊN LỚP " + pTenLP;
            lbLesson.Text = "MÔN: " + pTenMH.ToUpper() + " - GIÁO VIÊN: " + gv_bll.getNameGiaoVien(pMaGV).ToUpper();
            dtpThu.Value = pThoiGianBatDau;
            loadLesson();
            loadDataDetailTeaching();
        }

        private string GetDayOfWeek(DateTime pNgayDay)
        {
            DateTime selectedDate = pNgayDay;

            DayOfWeek dayOfWeek = selectedDate.DayOfWeek;

            return GetDayOfWeekName(dayOfWeek);
        }

        private string GetDayOfWeekName(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "CN";
                case DayOfWeek.Monday:
                    return "2";
                case DayOfWeek.Tuesday:
                    return "3";
                case DayOfWeek.Wednesday:
                    return "4";
                case DayOfWeek.Thursday:
                    return "5";
                case DayOfWeek.Friday:
                    return "6";
                case DayOfWeek.Saturday:
                    return "7";
                default:
                    return string.Empty;
            }
        }

        private void loadLesson()
        {
            cboLesson.DataSource = tgd_bll.getDataThoiGianDay();
            cboLesson.DisplayMember = "TENTIET";
            cboLesson.ValueMember = "MATG";
        }

        private void loadDataDetailTeaching()
        {
            dgvDetailTeachingSchedule.DataSource = ctld_bll.getDataChiTietLichDay(pMaLich);

            dgvDetailTeachingSchedule.Columns[0].HeaderText = "Mã lịch";
            dgvDetailTeachingSchedule.Columns[1].HeaderText = "Thứ";
            dgvDetailTeachingSchedule.Columns[2].HeaderText = "Ngày dạy";
            dgvDetailTeachingSchedule.Columns[3].HeaderText = "Tiết dạy";
        }

        private void calExtraness()
        {
            List<GiaoVienDTO> lst_Teacher = new List<GiaoVienDTO>();
            lst_Teacher = gv_bll.getDataGiaoVien();

            for (int i = 0; i < lst_Teacher.Count; i++)
            {
                decimal pHeSoLuong = bl_bll.getHeSoLuong(lst_Teacher[i].masocd, lst_Teacher[i].bac);
                decimal pMucLuongCoSo = bl_bll.getMucLuongCoSo(lst_Teacher[i].masocd, lst_Teacher[i].bac);
                decimal pTongLuong = (pHeSoLuong * pMucLuongCoSo) * 12;
                int pLuongGioday;
                decimal sotuan = (decimal)36 / 52;

                pt_dto.magv = lst_Teacher[i].magv;
                pt_dto.tongtietday = ctld_bll.getCountLessonInYear(lst_Teacher[i].magv, pNamHoc);
                pt_dto.tongtietdaday = ctld_bll.getCountLessonTeachingInYear(lst_Teacher[i].magv, pNamHoc);
                if (gv_bll.checkHT(lst_Teacher[i].magv))
                {
                    pt_dto.tongtietquydinh = 2 * 36;
                    if (pt_dto.tongtietdaday <= 2 * 36)
                    {
                        pt_dto.sogiodaythem = 0;
                    }
                    else
                    {
                        float pSoGioDayThem = (pt_dto.tongtietdaday - 72) * 45 / 60;
                        pt_dto.sogiodaythem = pSoGioDayThem;
                    }

                    pLuongGioday = (int)((pTongLuong / (2 * 36)) * sotuan);
                    pt_dto.luonggioday = pLuongGioday;
                }
                else if (gv_bll.checkHP(lst_Teacher[i].magv))
                {
                    pt_dto.tongtietquydinh = 4 * 36;
                    if (pt_dto.tongtietdaday <= 4 * 36)
                    {
                        pt_dto.sogiodaythem = 0;
                    }
                    else
                    {
                        float pSoGioDayThem = (pt_dto.tongtietdaday - 144) * 45 / 60;
                        pt_dto.sogiodaythem = pSoGioDayThem;
                    }

                    pLuongGioday = (int)((pTongLuong / (4 * 36)) * sotuan);
                    pt_dto.luonggioday = pLuongGioday;
                }
                else if (cn_bll.checkHomeroom(lst_Teacher[i].magv, pNamHoc))
                {
                    pt_dto.tongtietquydinh = 13 * 36;
                    if (pt_dto.tongtietdaday <= 13 * 36)
                    {
                        pt_dto.sogiodaythem = 0;
                    }
                    else
                    {
                        float pSoGioDayThem = (pt_dto.tongtietdaday - 468) * 45 / 60;
                        pt_dto.sogiodaythem = pSoGioDayThem;
                    }

                    pLuongGioday = (int)((pTongLuong / (13 * 36)) * sotuan);
                    pt_dto.luonggioday = pLuongGioday;
                }
                else if (cn_bll.checkHomeroomKT(lst_Teacher[i].magv, pNamHoc))
                {
                    pt_dto.tongtietquydinh = 14 * 36;
                    if (pt_dto.tongtietdaday <= 14 * 36)
                    {
                        pt_dto.sogiodaythem = 0;
                    }
                    else
                    {
                        float pSoGioDayThem = (pt_dto.tongtietdaday - 504) * 45 / 60;
                        pt_dto.sogiodaythem = pSoGioDayThem;
                    }

                    pLuongGioday = (int)((pTongLuong / (14 * 36)) * sotuan);
                    pt_dto.luonggioday = pLuongGioday;
                }
                else
                {
                    pt_dto.tongtietquydinh = 17 * 36;
                    if (pt_dto.tongtietdaday <= 17 * 36)
                    {
                        pt_dto.sogiodaythem = 0;
                    }
                    else
                    {
                        float pSoGioDayThem = (pt_dto.tongtietdaday - 612) * 45 / 60;
                        pt_dto.sogiodaythem = pSoGioDayThem;
                    }

                    pLuongGioday = (int)((pTongLuong / (17 * 36)) * sotuan);
                    pt_dto.luonggioday = pLuongGioday;
                }

                pt_dto.tienphutroi = (decimal)pt_dto.sogiodaythem * pt_dto.luonggioday * (decimal)1.5;

                if (pt_bll.checkPK(lst_Teacher[i].magv))
                {
                    pt_bll.editPT(pt_dto, pNamHoc);
                }
                else
                {
                    pt_bll.addPT(pt_dto, pNamHoc);
                }
            }
        }
    }
}
