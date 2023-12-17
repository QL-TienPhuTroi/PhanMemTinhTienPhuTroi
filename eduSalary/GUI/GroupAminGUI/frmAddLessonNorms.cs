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
    public partial class frmAddLessonNorms : Form
    {
        DinhMucTietDayBLL dmtd_bll = new DinhMucTietDayBLL();
        DinhMucTietDayDTO dmtd_dto = new DinhMucTietDayDTO();
        int pMaCV;
        public frmAddLessonNorms(int _MaCV)
        {
            InitializeComponent();
            pMaCV = _MaCV;
            btnFinish.Click += BtnFinish_Click;
            this.Load += FrmAddLessonNorms_Load;
        }

        private void FrmAddLessonNorms_Load(object sender, EventArgs e)
        {
            loadDataChucVu();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                dmtd_dto.macv = int.Parse(cboMaCV.SelectedValue.ToString());
                dmtd_dto.sodinhmuctietday = decimal.Parse(txtSoDMTD.Text.ToString());
                

                dmtd_bll.addDMTD(dmtd_dto);
                MessageBox.Show("SỐ ĐỊNH MỨC TIẾT DẠY " + dmtd_dto.sodinhmuctietday + " VỚI MÃ SỐ CHỨC VỤ " + dmtd_dto.macv + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }
        private void loadDataChucVu()
        {
            cboMaCV.DataSource = dmtd_bll.getDataDinhMucTietDay();

            cboMaCV.DisplayMember = "MACV";
            cboMaCV.ValueMember = "MACV";
        }
    }
}
