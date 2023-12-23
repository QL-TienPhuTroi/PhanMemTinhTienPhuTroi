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
    public partial class frmEditClassroom : Form
    {
        LopHocBLL lp_bll = new LopHocBLL();
        LopHocDTO lp_dto = new LopHocDTO();
        KhoiBLL kh_bll = new KhoiBLL();
        string pMaLP;
        List<LopHocDTO> lst_lp = new List<LopHocDTO>();
        public frmEditClassroom(string _MaLP)
        {
            InitializeComponent();
            txtMaLP.Enabled = false;
            pMaLP = _MaLP;
            this.Load += FrmEditClassroom_Load;
            btnFinish.Click += BtnFinish_Click;
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

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                lp_dto.malp = pMaLP;
                lp_dto.tenlp = txtTenLP.Text;
                lp_dto.siso = int.Parse(txtSiSo.Text);
                if(rdoCo.Checked)
                {
                    lp_dto.khiemkhuyet = true;
                }
                else
                {
                    lp_dto.khiemkhuyet = false;
                }
                lp_dto.makhoi = int.Parse(cboKhoi.SelectedValue.ToString());

                lp_bll.editLP(lp_dto);
                MessageBox.Show("LỚP " + lp_dto.tenlp.ToUpper() + " ĐÃ ĐƯỢC CẬP NHẬT THÀNH CÔNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CÓ GÌ ĐÓ KHÔNG ĐÚNG!", "PHẦN MỀM TÍNH PHỤ TRỘI");
            }
        }

        private void FrmEditClassroom_Load(object sender, EventArgs e)
        {
            loadDataKhoi();
            loadData();
        }
        private void loadData()
        {
            lst_lp = lp_bll.getDataLopHocTheoMa(pMaLP);
            int pMaKhoi = lp_bll.getKhoi(lst_lp[0].malp);
            string pTenKhoi = kh_bll.getDataTenKhoiTheoMa(pMaKhoi);

            txtMaLP.Text = lst_lp[0].malp.ToString();
            txtTenLP.Text = lst_lp[0].tenlp.ToString();
            txtSiSo.Text = lst_lp[0].siso.ToString();
            if (lst_lp[0].khiemkhuyet == true)
            {
                rdoCo.Checked = true;
            }
            else
            { 
                rdoKhong.Checked = true;
            }

            cboKhoi.Text = pTenKhoi;
        }
        private void loadDataKhoi()
        {
            cboKhoi.DataSource = kh_bll.getDataKhoi();
            cboKhoi.DisplayMember = "TENKHOI";
            cboKhoi.ValueMember = "MAKHOI";
        }
    }
}
