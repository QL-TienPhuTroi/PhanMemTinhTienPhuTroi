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
    public partial class frmAddCertificate : Form
    {
        BangCapBLL bc_bll = new BangCapBLL();
        BangCapDTO bc_dto = new BangCapDTO();
        public frmAddCertificate()
        {
            InitializeComponent();
            txtMaBC.Enabled = false;
            btnFinish.Click += BtnFinish_Click;
            this.Load += FrmAddCertificate_Load;
        }

        private void FrmAddCertificate_Load(object sender, EventArgs e)
        {
            txtMaBC.Text = createCode();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            string pMaBC = createCode();

            try
            {
                bc_dto.mabc = pMaBC;
                bc_dto.tenbc = txtTenBC.Text;
                bc_dto.noidaotao = txtNoiDaoTao.Text;
                bc_dto.chuyennganh = txtChuyenNganh.Text;
                bc_dto.hocvi = txtHocVi.Text;
                bc_dto.xeploai = txtXepLoai.Text;
                bc_dto.ngaycap = DateTime.Parse(dtpNgayCap.Text);

                bc_bll.addBC(bc_dto);
                MessageBox.Show("BẰNG CẤP " + bc_dto.tenbc.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }

        }
        private string createCode()
        {
            Random random = new Random();
            string pMaBC;

            while (true)
            {
                int randomNumber = random.Next(10000, 100000);
                pMaBC = "BC10" + randomNumber.ToString("D5");

                if (!bc_bll.checkPK(pMaBC))
                {
                    return pMaBC;
                }
            }
        }
    }
}
