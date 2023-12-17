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
    public partial class frmEditPosition : Form
    {
        ChucVuBLL cv_bll = new ChucVuBLL();
        ChucVuDTO cv_dto = new ChucVuDTO();
        int pMaCV;
        List<ChucVuDTO> lst_cv = new List<ChucVuDTO>();
        public frmEditPosition(int _MaCV)
        {
            InitializeComponent();
            pMaCV = _MaCV;
            this.Load += FrmEditPosition_Load;
            btnFinish.Click += BtnFinish_Click;

        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                cv_dto.macv = pMaCV;
                cv_dto.tencv = txtTenCV.Text;

                cv_bll.editCV(cv_dto);
                MessageBox.Show("CHỨC VỤ " + cv_dto.tencv.ToUpper() + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void FrmEditPosition_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            lst_cv = cv_bll.getDataChucVuTheoMa(pMaCV);

            cboMaCV.Text = lst_cv[0].macv.ToString();
            txtTenCV.Text = lst_cv[0].tencv;
        }
    }
}
