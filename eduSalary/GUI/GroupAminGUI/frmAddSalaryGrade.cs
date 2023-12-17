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
    public partial class frmAddSalaryGrade : Form
    {
        BacLuongBLL bl_bll = new BacLuongBLL();
        BacLuongDTO bl_dto = new BacLuongDTO();
        ChucDanhBLL cd_bll = new ChucDanhBLL();
        public frmAddSalaryGrade()
        {
            InitializeComponent();
            btnFinish.Click += BtnFinish_Click;
            this.Load += FrmAddSalaryGrade_Load;
            cboMaSoCD.SelectedIndexChanged += CboMaSoCD_SelectedIndexChanged;
        }

        private void CboMaSoCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmAddSalaryGrade_Load(object sender, EventArgs e)
        {
            loadDataChucDanh();
            loadDataBacLuong();
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                bl_dto.masocd = cboMaSoCD.SelectedValue.ToString();
                bl_dto.bac = int.Parse(cboBac.SelectedValue.ToString());
                bl_dto.hesoluong = decimal.Parse(txtHeSoLuong.Text);
                bl_dto.mucluongcoso = decimal.Parse(txtMucLuongCoSo.Text);

                bl_bll.addBL(bl_dto);
                MessageBox.Show("BẬC LƯƠNG " + bl_dto.bac + " VỚI MÃ SỐ CHỨC DANH " + bl_dto.masocd + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }
        private void loadDataChucDanh()
        {
            cboMaSoCD.DataSource = cd_bll.getDataChucDanh();
            cboMaSoCD.DisplayMember = "MASOCD";
            cboMaSoCD.ValueMember = "MASOCD";
        }
        private void loadDataBacLuong()
        {
            string pMaCD = cboMaSoCD.SelectedValue.ToString();
            cboBac.DataSource = bl_bll.getDataBacLuongTheoMaCD(pMaCD);
            cboBac.DisplayMember = "BAC";
            cboBac.ValueMember = "BAC";
        }
    }
}
