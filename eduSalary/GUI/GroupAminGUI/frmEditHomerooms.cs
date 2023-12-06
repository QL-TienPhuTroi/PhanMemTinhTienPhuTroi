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
    public partial class frmEditHomerooms : Form
    {
        string pMaLP;
        string pTenLP;
        string pNamHoc;

        GiaoVienBLL gv_bll = new GiaoVienBLL();
        ChuNhiemBLL cn_bll = new ChuNhiemBLL();
        ChuNhiemDTO cn_old = new ChuNhiemDTO();
        ChuNhiemDTO cn_new = new ChuNhiemDTO();

        public frmEditHomerooms(string ma, string ten, string nam)
        {
            InitializeComponent();
            pMaLP = ma;
            pTenLP = ten;
            pNamHoc = nam;
            this.Load += FrmEditHomerooms_Load;
            btnAssigning.Click += BtnAssigning_Click;
        }

        private void BtnAssigning_Click(object sender, EventArgs e)
        {
            try
            {
                cn_old = cn_bll.findTeacherNow(pMaLP, pNamHoc);
                cn_old.trangthai = false;
                cn_bll.editCN(cn_old);

                cn_new.malp = pMaLP;
                cn_new.magv = cboTeacher.SelectedValue.ToString();
                cn_new.namhoc = pNamHoc;
                cn_new.trangthai = true;
                cn_bll.addCN(cn_new);

                string pHoTen = gv_bll.getNameGiaoVien(cn_new.magv);

                MessageBox.Show("GIÁO VIÊN " + pHoTen.ToUpper() + " ĐÃ ĐƯỢC PHÂN LÀM CHỦ NHIỆM LỚP " + pTenLP, "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void FrmEditHomerooms_Load(object sender, EventArgs e)
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
