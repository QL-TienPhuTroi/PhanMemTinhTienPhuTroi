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
    public partial class frmEditLessonNorms : Form
    {
        DinhMucTietDayBLL dmtd_bll = new DinhMucTietDayBLL();
        DinhMucTietDayDTO dmtd_dto = new DinhMucTietDayDTO();
        int pMaCV;
        decimal pSoDMTD;
        List<DinhMucTietDayDTO> lst_dmtd = new List<DinhMucTietDayDTO>();
        public frmEditLessonNorms(int _MaCV, decimal _SoDMTD)
        {
            InitializeComponent();
            pMaCV = _MaCV;
            pSoDMTD = _SoDMTD;
            btnFinish.Click += BtnFinish_Click;
            this.Load += FrmEditLessonNorms_Load;
        }

        private void FrmEditLessonNorms_Load(object sender, EventArgs e)
        {
            lst_dmtd = dmtd_bll.getDataDinhMucTietDayTheoMaVaSoDMTD(pMaCV, pSoDMTD);
            loadData();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                dmtd_dto.macv = pMaCV;
                dmtd_dto.sodinhmuctietday = pSoDMTD;

                dmtd_bll.editDMTD(dmtd_dto);
                MessageBox.Show("SỐ ĐỊNH MỨC TIẾT DẠY " + dmtd_dto.sodinhmuctietday + " CỦA MÃ SỐ CHỨC VỤ" + dmtd_dto.macv + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }
        private void loadData()
        {
            txtMaCV.Text = lst_dmtd[0].macv.ToString();
            txtSoDMTD.Text = lst_dmtd[0].sodinhmuctietday.ToString();
          
        }
    }
}
