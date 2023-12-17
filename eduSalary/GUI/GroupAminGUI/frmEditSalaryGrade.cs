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
    public partial class frmEditSalaryGrade : Form
    {
        BacLuongBLL bl_bll = new BacLuongBLL();
        BacLuongDTO bl_dto = new BacLuongDTO();
        ChucDanhBLL cd_bll = new ChucDanhBLL();
        string pMaBL;
        int pBac;
        List<BacLuongDTO> lst_bl = new List<BacLuongDTO>();
        public frmEditSalaryGrade(string _MaBl, int _Bac)
        {
            InitializeComponent();
            pMaBL = _MaBl;
            pBac = _Bac;
            this.Load += FrmEditSalaryGrade_Load;
            btnFinish.Click += BtnFinish_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                bl_dto.masocd = pMaBL;
                bl_dto.bac = pBac;
                bl_dto.hesoluong = decimal.Parse(txtHeSoLuong.Text);
                bl_dto.mucluongcoso = decimal.Parse(txtMucLuongCoSo.Text);

                bl_bll.editBL(bl_dto);
                MessageBox.Show("BẬC LƯƠNG " + bl_dto.bac + " CỦA MÃ SỐ CHỨC DANH" + bl_dto.masocd + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void FrmEditSalaryGrade_Load(object sender, EventArgs e)
        {
            lst_bl = bl_bll.getDataBacLuongTheoMa(pMaBL, pBac);
            loadData();
        }
        private void loadData()
        {
            txtMaSoCD.Text = lst_bl[0].masocd;
            txtBac.Text = lst_bl[0].bac.ToString();
            txtHeSoLuong.Text = lst_bl[0].hesoluong.ToString();
            txtMucLuongCoSo.Text = lst_bl[0].mucluongcoso.ToString();
        }
    }
}
