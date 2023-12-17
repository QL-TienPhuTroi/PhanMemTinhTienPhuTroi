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
    public partial class frmConfirmLesson : Form
    {
        XacNhanLichDayBLL xnld_bll = new XacNhanLichDayBLL();
        GiaoVienBLL gv_bll = new GiaoVienBLL();
        ChiTietLichDayBLL ctld_bll = new ChiTietLichDayBLL();
        ChuNhiemBLL cn_bll = new ChuNhiemBLL();
        BacLuongBLL bl_bll = new BacLuongBLL();
        LopHocBLL lp_bll = new LopHocBLL();
        ChiTietLichDayDTO ctld_dto = new ChiTietLichDayDTO();
        PhuTroiBLL pt_bll = new PhuTroiBLL();
        PhuTroiDTO pt_dto = new PhuTroiDTO();

        DateTime pNow = DateTime.Now;
        string pMaLich;
        int pTietDay;
        string pNamHoc;
        DateTime pNgayDay;

        public frmConfirmLesson(string _namhoc)
        {
            InitializeComponent();
            pNamHoc = _namhoc;
            this.Load += FrmConfirmLesson_Load;
            btnPresent.Click += BtnPresent_Click;
            btnConfirm.Click += BtnConfirm_Click;
            btnBack.Click += BtnBack_Click;
            btnNext.Click += BtnNext_Click;
            dtpNgayDay.ValueChanged += DtpNgayDay_ValueChanged;
        }

        private void DtpNgayDay_ValueChanged(object sender, EventArgs e)
        {
            loadDataConfirmLesson(dtpNgayDay.Value);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            dtpNgayDay.Value = dtpNgayDay.Value.AddDays(1);

            loadDataConfirmLesson(dtpNgayDay.Value);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            dtpNgayDay.Value = dtpNgayDay.Value.AddDays(-1);

            loadDataConfirmLesson(dtpNgayDay.Value);
        }

        private void FrmConfirmLesson_Load(object sender, EventArgs e)
        {
            dtpNgayDay.Value = pNow;
            loadDataConfirmLesson(pNow);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvConfirmLesson.CurrentCell != null)
                {
                    pMaLich = dgvConfirmLesson.CurrentRow.Cells[0].Value.ToString();
                    pTietDay = int.Parse(dgvConfirmLesson.CurrentRow.Cells[5].Value.ToString());
                    pNgayDay = DateTime.Parse(dgvConfirmLesson.CurrentRow.Cells[6].Value.ToString());

                    if (!xnld_bll.checkConfirm(pMaLich, pNgayDay, pTietDay))
                    {
                        xnld_bll.editXNLD(pMaLich, pTietDay, pNgayDay);
                        MessageBox.Show("XÁC NHẬN THÀNH CÔNG", "PHẦN MỀM TÍNH PHỤ TRỘI");

                        loadDataConfirmLesson(pNgayDay);
                        calExtraness();
                    }
                    else
                    {
                        MessageBox.Show("TIẾT DẠY ĐÃ ĐƯỢC XÁC NHẬN TỪ TRƯỚC, VUI LÒNG THỬ LẠI!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                    }
                }
            }
            catch
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void BtnPresent_Click(object sender, EventArgs e)
        {
            dtpNgayDay.Value = pNow;

            loadDataConfirmLesson(pNow);
        }

        private void loadDataConfirmLesson(DateTime pNgayDay)
        {
            dgvConfirmLesson.DataSource = ctld_bll.getDataLessonDaily(pNgayDay);

            dgvConfirmLesson.Columns[0].HeaderText = "Mã lịch";
            dgvConfirmLesson.Columns[1].HeaderText = "MSGV";
            dgvConfirmLesson.Columns[2].HeaderText = "Họ tên";
            dgvConfirmLesson.Columns[3].HeaderText = "Tên môn học";
            dgvConfirmLesson.Columns[4].HeaderText = "Tên lớp";
            dgvConfirmLesson.Columns[5].HeaderText = "Tiết dạy";
            dgvConfirmLesson.Columns[6].HeaderText = "Ngày dạy";
            dgvConfirmLesson.Columns[7].HeaderText = "Hoàn thành";

            dgvConfirmLesson.Columns[0].Width = 120;
            dgvConfirmLesson.Columns[1].Width = 120;
            dgvConfirmLesson.Columns[2].Width = 180;
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
