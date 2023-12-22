using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI.GroupAminGUI
{
    public partial class frmAddTeaching : Form
    {
        MonHocBLL mh_bll = new MonHocBLL();
        GiaoVienBLL gv_bll = new GiaoVienBLL();
        LichDayBLL ld_bll = new LichDayBLL();
        XacNhanLichDayBLL xnld_bll = new XacNhanLichDayBLL();
        LopHocBLL lp_bll = new LopHocBLL();

        LichDayDTO ld_dto = new LichDayDTO();

        frmAddDetailTeaching fAddDetailTeaching;

        private string pMaLP, pTenLP, pNamHoc, pMaLich, pTenMH, pMaGV;
        private int pMaMH;
        private DateTime pThoiGianBatDau;

        public frmAddTeaching(string _malp, string _tenlp, string _namhoc)
        {
            InitializeComponent();
            pMaLP = _malp;
            pTenLP = _tenlp;
            pNamHoc = _namhoc;
            loadDataMonHoc();
            this.Load += FrmAddTeaching_Load;
            cboMH.SelectedIndexChanged += CboMH_SelectedIndexChanged;
            dtpTGBD.ValueChanged += DtpTGBD_ValueChanged;
            btnFinish.Click += BtnFinish_Click;
            btnRemove.Click += BtnRemove_Click;
            dgvTeachingSchedule.DoubleClick += DgvTeachingSchedule_DoubleClick;
        }

        private void DgvTeachingSchedule_DoubleClick(object sender, EventArgs e)
        {
            pMaLich = dgvTeachingSchedule.CurrentRow.Cells[0].Value.ToString();
            pMaGV = dgvTeachingSchedule.CurrentRow.Cells[1].Value.ToString();
            pTenMH = dgvTeachingSchedule.CurrentRow.Cells[2].Value.ToString();
            pThoiGianBatDau = DateTime.Parse(dgvTeachingSchedule.CurrentRow.Cells[4].Value.ToString());
            pMaMH = mh_bll.getMaMonHocTheoTenMH(pTenMH);

            fAddDetailTeaching = new frmAddDetailTeaching(pMaLich, pMaLP, pTenLP, pTenMH, pMaGV, pThoiGianBatDau, pMaMH, pNamHoc);
            fAddDetailTeaching.ShowDialog();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("BẠN CÓ MUỐN CHẮC XÓA LỊCH DẠY CỦA GIÁO VIÊN NÀY KHÔNG KHÔNG?", "PHẦN MỀM TÍNH PHỤ TRỘI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                pMaLich = dgvTeachingSchedule.CurrentRow.Cells[0].Value.ToString();

                xnld_bll.removeXNLD(pMaLich);

                if (ld_bll.removeLD(pMaLich))
                {

                    MessageBox.Show("ĐÃ XÓA THÀNH CÔNG LỊCH DẠY CỦA GIÁO VIÊN NÀY", "PHẦN MỀM TÍNH PHỤ TRỘI");
                    loadDataTeachingSchedule();
                    loadDataMonHoc();
                }
                else
                {
                    MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM TÍNH PHỤ TRỘI");
                }
            }
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            string pMaLich = createCode();

            try
            {
                ld_dto.malich = pMaLich;
                ld_dto.magv = cboTenGV.SelectedValue.ToString();
                ld_dto.mamh = int.Parse(cboMH.SelectedValue.ToString());
                ld_dto.malp = pMaLP;
                ld_dto.thoigianbatdau = dtpTGBD.Value;
                ld_dto.thoigianketthuc = dtpTGKT.Value;
                ld_dto.namhoc = pNamHoc;

                ld_bll.addLD(ld_dto);
                MessageBox.Show("LỊCH DẠY ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                loadDataTeachingSchedule();
                loadDataMonHoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void DtpTGBD_ValueChanged(object sender, EventArgs e)
        {
            setThoiGianKetThuc(dtpTGBD.Value);
        }

        private void CboMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMH.SelectedItem != null && cboMH.SelectedValue is int)
            {
                cboTenGV.Enabled = true;
                int _macm = mh_bll.findMaChuyenMonTheoMaMonHoc((int)cboMH.SelectedValue);
                loadDataGiaoVien(_macm);
            }
        }

        private void FrmAddTeaching_Load(object sender, EventArgs e)
        {
            lbTenLP.Text = pTenLP;
            loadDataMonHoc();
            setThoiGianKetThuc(dtpTGBD.Value);
            loadDataTeachingSchedule();
        }

        private void loadDataMonHoc()
        {
            int _makhoi = lp_bll.getKhoi(pMaLP);

            var monhoc = mh_bll.getDataMonHocKhongTonTai(pMaLP, pNamHoc, _makhoi);

            if (monhoc != null)
            {
                cboMH.DataSource = monhoc;
                cboMH.DisplayMember = "TENMH";
                cboMH.ValueMember = "MAMH";
            }
        }

        private void loadDataGiaoVien(int _macm)
        {
            if(!string.IsNullOrEmpty(cboMH.Text))
            {
                var giaovien = gv_bll.getDataGiaoVienTheoCM(_macm, pNamHoc);

                if (giaovien != null)
                {
                    cboTenGV.DataSource = giaovien;
                    cboTenGV.DisplayMember = "HOTEN";
                    cboTenGV.ValueMember = "MAGV";
                }
            }
        }

        private void setThoiGianKetThuc(DateTime pThoiGianBatDau)
        {
            dtpTGKT.Value = pThoiGianBatDau.AddDays(36 * 7);  
        }

        private void loadDataTeachingSchedule()
        {
            dgvTeachingSchedule.DataSource = ld_bll.getDataLichDayLocTheoLop(pMaLP, pNamHoc);

            dgvTeachingSchedule.Columns[0].HeaderText = "Mã lịch";
            dgvTeachingSchedule.Columns[1].HeaderText = "Mã giáo viên";
            dgvTeachingSchedule.Columns[2].HeaderText = "Tên môn học";
            dgvTeachingSchedule.Columns[3].HeaderText = "Mã lớp";
            dgvTeachingSchedule.Columns[4].HeaderText = "Thời gian bắt đầu";
            dgvTeachingSchedule.Columns[5].HeaderText = "Thời gian kết thúc";
            dgvTeachingSchedule.Columns[6].HeaderText = "Năm học";
        }

        private string createCode()
        {
            Random random = new Random();
            string pMaLich;

            while (true)
            {
                int randomNumber = random.Next(100000, 1000000);
                pMaLich = "3010" + randomNumber.ToString("D6");

                if (!ld_bll.checkPK(pMaLich))
                {
                    return pMaLich;
                }
            }
        }
    }
}
