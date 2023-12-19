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
    public partial class frmAddHomerooms : Form
    {
        string pMaLP;
        string pTenLP;
        string pNamHoc;

        GiaoVienBLL gv_bll = new GiaoVienBLL();
        LopHocBLL lp_bll = new LopHocBLL();
        ChuNhiemBLL cn_bll = new ChuNhiemBLL();
        ChuNhiemDTO cn_dto = new ChuNhiemDTO();
        ChiTietChucVuBLL ctcv_bll = new ChiTietChucVuBLL();
        ChiTietChucVuDTO ctcv_dto = new ChiTietChucVuDTO();

        public frmAddHomerooms(string ma, string ten, string nam)
        {
            InitializeComponent();
            pMaLP = ma;
            pTenLP = ten;
            pNamHoc = nam;
            this.Load += FrmHomerooms_Load;
            btnAssigning.Click += BtnAssigning_Click;
        }

        private void BtnAssigning_Click(object sender, EventArgs e)
        {
            try
            {
                //------- THÊM CHỦ NHIỆM
                cn_dto.malp = pMaLP;
                cn_dto.magv = cboTeacher.SelectedValue.ToString();
                cn_dto.namhoc = pNamHoc;
                cn_dto.trangthai = true;

                cn_bll.addCN(cn_dto);

                //------- CẬP NHẬT CHỨC VỤ
                ctcv_bll.removeCTCV(cboTeacher.SelectedValue.ToString());

                ctcv_dto.magv = cboTeacher.SelectedValue.ToString();
                ctcv_dto.macv = 3;
                ctcv_dto.namhoc = pNamHoc;

                ctcv_bll.addCTCV(ctcv_dto);

                string pHoTen = gv_bll.getNameGiaoVien(cn_dto.magv);

                MessageBox.Show("GIÁO VIÊN " + pHoTen.ToUpper() + " ĐÃ ĐƯỢC PHÂN LÀM CHỦ NHIỆM LỚP " + pTenLP, "PHẦN MỀM TÍNH PHỤ TRỘI");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void FrmHomerooms_Load(object sender, EventArgs e)
        {
            setLB();
            loadTeacher();
        }

        private void loadTeacher()
        {
            cboTeacher.DataSource = gv_bll.getDataGiaoVienKhongTonTai(pNamHoc);
            cboTeacher.DisplayMember = "HOTEN";
            cboTeacher.ValueMember = "MAGV";
        }

        private void setLB()
        {
            lbTenLP.Text = pTenLP;
            lbYear.Text = pNamHoc;
        }

    }
}
