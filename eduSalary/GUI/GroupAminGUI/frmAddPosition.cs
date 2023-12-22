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
    public partial class frmAddPosition : Form
    {
        ChucVuBLL cv_bll = new ChucVuBLL();
        ChucVuDTO cv_dto = new ChucVuDTO();
        public frmAddPosition()
        {
            InitializeComponent();
            btnFinish.Click += BtnFinish_Click;
            txtMaCV.Enabled = false;
            this.Load += FrmAddPosition_Load;
        }

        private void FrmAddPosition_Load(object sender, EventArgs e)
        {
            txtMaCV.Text = createCode().ToString();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            int pMaCV = createCode();
            try
            {
                cv_dto.macv = pMaCV;
                cv_dto.tencv = txtTenCV.Text;
                
                cv_bll.addCV(cv_dto);
                MessageBox.Show("CHỨC VỤ " + cv_dto.tencv.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }
        private int createCode()
        {
            int pCode;
            int i = 1;

            while (true)
            {
                pCode = i;

                if (!cv_bll.checkPK(pCode))
                {
                    return pCode;
                }
                i++;
            }
        }
    }
}
