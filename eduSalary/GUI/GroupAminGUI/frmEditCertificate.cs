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
    public partial class frmEditCertificate : Form
    {
        BangCapBLL bc_bll = new BangCapBLL();
        BangCapDTO bc_dto = new BangCapDTO();
        List<BangCapDTO> lst_bc = new List<BangCapDTO>();
        string pMaBC;
        public frmEditCertificate(string _MaBC)
        {
            InitializeComponent();
            pMaBC = _MaBC;
            this.Load += FrmEditCertificate_Load;
            btnFinish.Click += BtnFinish_Click;
            txtMaBC.Enabled = false;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                bc_dto.mabc = txtMaBC.Text;
                bc_dto.tenbc = txtTenBC.Text;
                bc_dto.noidaotao = txtNoiDaoTao.Text;
                bc_dto.chuyennganh = txtChuyenNganh.Text;
                bc_dto.hocvi = txtHocVi.Text;
                bc_dto.xeploai = txtXepLoai.Text;
                bc_dto.ngaycap = DateTime.Parse(dtpNgayCap.Text);

                bc_bll.editBC(bc_dto);
                MessageBox.Show("BẰNG CẤP " + bc_dto.tenbc.ToUpper() + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void FrmEditCertificate_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            lst_bc = bc_bll.getDataBangCapTheoMa(pMaBC);
            txtMaBC.Text = lst_bc[0].mabc;
            txtTenBC.Text = lst_bc[0].tenbc;
            txtNoiDaoTao.Text = lst_bc[0].noidaotao;
            txtChuyenNganh.Text = lst_bc[0].chuyennganh;
            txtHocVi.Text = lst_bc[0].hocvi;
            txtXepLoai.Text = lst_bc[0].xeploai;
            dtpNgayCap.Text = lst_bc[0].ngaycap.ToString();
        }
    }
}
