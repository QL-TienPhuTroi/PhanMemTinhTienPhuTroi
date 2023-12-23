using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.GroupAminGUI
{
    public partial class frmAddClassroom : Form
    {
        LopHocBLL lp_bll = new LopHocBLL();
        LopHocDTO lp_dto = new LopHocDTO();
        KhoiBLL kh_bll = new KhoiBLL();
        public frmAddClassroom()
        {
            InitializeComponent();
            txtMaLP.Enabled = false;
            btnFinish.Click += BtnFinish_Click;
            this.Load += FrmAddClassroom_Load;
            txtTenLP.Leave += TxtTenLP_Leave;
        }

        private void TxtTenLP_Leave(object sender, EventArgs e)
        {
            string input = txtTenLP.Text;

            // Sử dụng biểu thức chính quy để kiểm tra định dạng chuỗi
            string pattern = @"^(10|11|12)[A-Za-z][0-9]{1}$";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(input))
            {
                MessageBox.Show("TÊN LỚP KHÔNG ĐÚNG, VUI LÒNG NHẬP LẠI!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void FrmAddClassroom_Load(object sender, EventArgs e)
        {
            txtMaLP.Text = createCode();
            loadDataKhoi();
        }


        private void BtnFinish_Click(object sender, EventArgs e)
        {
            string pMaLP = createCode();
            
            try
            {
                lp_dto.malp = pMaLP;
                lp_dto.tenlp = txtTenLP.Text;
                lp_dto.siso = int.Parse(txtSiSo.Text);
                
                if (rdoCo.Checked)
                {
                    lp_dto.khiemkhuyet = true;
                }
                else
                {
                    lp_dto.khiemkhuyet = false;
                }
                lp_dto.makhoi = int.Parse(cboKhoi.SelectedValue.ToString());

                lp_bll.addLP(lp_dto);
                MessageBox.Show("LỚP " + lp_dto.tenlp.ToUpper() + " ĐÃ ĐƯỢC THÊM THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }
        private void loadDataKhoi()
        {
            cboKhoi.DataSource = kh_bll.getDataKhoi();
            cboKhoi.DisplayMember = "TENKHOI";
            cboKhoi.ValueMember = "MAKHOI";
        }
        private string createCode()
        {
            Random random = new Random();
            string pMaLP;

            while (true)
            {
                int randomNumber = random.Next(10000, 100000);
                pMaLP = "LP100" + randomNumber.ToString("D5");

                if (!lp_bll.checkPK(pMaLP))
                {
                    return pMaLP;
                }
            }
        }

    }
}
