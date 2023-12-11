using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        string pMaLich, pTenLP, pTenMH, pMaGV;
        DateTime pNgayDay;
        int pTietDay;

        frmDetailLesson fDetailLesson = new frmDetailLesson();

        public frmAddDetailTeaching(string _malich, string _tenlop, string _tenmh, string _magv)
        {
            InitializeComponent();
            pMaLich = _malich;
            pTenLP = _tenlop;
            pTenMH = _tenmh;
            pMaGV = _magv;
            this.Load += FrmAddDetailTeaching_Load;
            lbDetail.Click += LbDetail_Click;
            btnFinish.Click += BtnFinish_Click;
            btnRemove.Click += BtnRemove_Click;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("BẠN CÓ MUỐN CHẮC XÓA LỊCH DẠY CỦA GIÁO VIÊN NÀY KHÔNG KHÔNG?", "PHẦN MỀM TÍNH PHỤ TRỘI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                pMaLich = dgvDetailTeachingSchedule.CurrentRow.Cells[0].Value.ToString();
                pNgayDay = DateTime.Parse(dgvDetailTeachingSchedule.CurrentRow.Cells[2].Value.ToString());
                pTietDay = int.Parse(dgvDetailTeachingSchedule.CurrentRow.Cells[3].Value.ToString());

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

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i <= 36; i++)
                {
                    ctld_dto.malich = pMaLich;
                    ctld_dto.thu = GetDayOfWeek(dtpThu.Value);
                    ctld_dto.ngayday = dtpThu.Value.AddDays(i * 7);
                    ctld_dto.tietday = int.Parse(cboLesson.SelectedValue.ToString());

                    ctld_bll.addCTLD(ctld_dto);
                }
                MessageBox.Show("LỊCH DẠY ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                loadDataDetailTeaching();
                loadLesson();
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
    }
}
