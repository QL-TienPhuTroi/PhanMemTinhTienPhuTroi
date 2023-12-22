using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using UI;
using System.Web.UI;

namespace GUI.GroupAminGUI
{
    public partial class frmAssigningHomeroom : Form
    {
        LopHocBLL lp_bll = new LopHocBLL();
        GiaoVienBLL gv_bll = new GiaoVienBLL();
        ChuNhiemBLL cn_bll = new ChuNhiemBLL();
        ChuNhiemDTO cn_old = new ChuNhiemDTO();
        ChuNhiemDTO cn_now = new ChuNhiemDTO();

        ClassroomUI[] classroomItems = new ClassroomUI[30];

        frmAddHomerooms fAddHomerooms; 
        frmEditHomerooms fEditHomerooms;

        string pHoTen;

        public frmAssigningHomeroom()
        {
            InitializeComponent();
            this.Load += FrmAssigningHomeroom_Load;
            cboYear.SelectedIndexChanged += CboYear_SelectedIndexChanged;
            rdoAll.CheckedChanged += RdoAll_CheckedChanged;
            rdo10.CheckedChanged += Rdo10_CheckedChanged;
            rdo11.CheckedChanged += Rdo11_CheckedChanged;
            rdo12.CheckedChanged += Rdo12_CheckedChanged;
            btnRefresh.Click += BtnRefresh_Click;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            loadYear();
            rdoAll.Checked = true;
            rdo10.Checked = false;
            rdo11.Checked = false;
            rdo12.Checked = false;
            loadClassrommAllItems();
        }

        private void Rdo12_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo12.Checked)
            {
                loadClassrommAllItems();
            }
        }

        private void Rdo11_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo11.Checked)
            {
                loadClassrommAllItems();
            }
        }

        private void Rdo10_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo10.Checked)
            {
                loadClassrommAllItems();
            }
        }

        private void RdoAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAll.Checked)
            {
                loadClassrommAllItems();
            }
        }

        private void FrmAssigningHomeroom_Load(object sender, EventArgs e)
        {
            setSizeFrom();
            loadYear();
            rdoAll.Checked = true;
            loadClassrommAllItems();
        }

        private void CboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadClassrommAllItems();
        }

        private void loadClassrommAllItems()
        {
            List<LopHocDTO> classroom = new List<LopHocDTO>();

            if (rdoAll.Checked)
            {
                classroom = lp_bll.getDataLopHoc();
            }
            else if (rdo10.Checked)
            {
                classroom = lp_bll.getDataLopHocTheoKhoi(rdo10.Text.ToUpper());
            }
            else if (rdo11.Checked)
            {
                classroom = lp_bll.getDataLopHocTheoKhoi(rdo11.Text.ToUpper());
            }
            else
            {
                classroom = lp_bll.getDataLopHocTheoKhoi(rdo12.Text.ToUpper());
            }

            flpLopHoc.Controls.Clear();

            for (int i = 0; i < classroom.Count; i++)
            {
                classroomItems[i] = new ClassroomUI();
                classroomItems[i].Width = 200;
                classroomItems[i].Margin = new Padding(5, 5, 5, 5);
                classroomItems[i].PMaLP = classroom[i].malp;
                classroomItems[i].PTenLP = classroom[i].tenlp;
                classroomItems[i].PSiSo = int.Parse(classroom[i].siso.ToString());
                if (classroom[i].khiemkhuyet)
                {
                    classroomItems[i].PKhiemKhuyet = "Có";
                }
                else
                {
                    classroomItems[i].PKhiemKhuyet = "Không";
                }

                if (cn_bll.isHomerooms(classroom[i].malp, cboYear.SelectedItem.ToString()))
                {
                    cn_now = cn_bll.findTeacherNow(classroom[i].malp, cboYear.SelectedItem.ToString());
                    pHoTen = gv_bll.getNameGiaoVien(cn_now.magv);

                    if (gv_bll.checkGenderTeacher(cn_now.magv))
                    {
                        classroomItems[i].PTrangThai = Properties.Resources.teacher_male;
                    }
                    else
                    {
                        classroomItems[i].PTrangThai = Properties.Resources.teacher_female;
                    }

                    classroomItems[i].PHoTen = pHoTen.ToUpper();
                }
                else
                {
                    classroomItems[i].PTrangThai = Properties.Resources.cross;
                    classroomItems[i].PHoTen = "LỚP CHƯA CÓ GVCN";
                }

                if (flpLopHoc.Controls.Count < 0)
                {
                    flpLopHoc.Controls.Clear();
                }
                else
                {
                    flpLopHoc.Controls.Add(classroomItems[i]);
                }

                //------------- THÊM
                classroomItems[i].onSelect1 += (ss, ee) =>
                {
                    var wdg = (ClassroomUI)ss;
                    if (!cn_bll.isHomerooms(wdg.PMaLP, cboYear.SelectedItem.ToString()))
                    {
                        fAddHomerooms = new frmAddHomerooms(wdg.PMaLP, wdg.PTenLP, cboYear.SelectedItem.ToString());
                        fAddHomerooms.ShowDialog();
                        loadClassrommAllItems();
                    }
                    else
                    {
                        MessageBox.Show("LỚP ĐÃ CÓ GIÁO VIÊN CHỦ NHIỆM!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                    }
                };

                //------------- XÓA
                classroomItems[i].onSelect2 += (ss, ee) =>
                {
                    var wdg = (ClassroomUI)ss;
                    cn_old = cn_bll.findTeacherNow(wdg.PMaLP, cboYear.SelectedItem.ToString());

                    if(cn_old == null)
                    {
                        MessageBox.Show("LỚP CHƯA CÓ GIÁO VIÊN CHỦ NHIỆM!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                    }
                    else
                    {
                        pHoTen = gv_bll.getNameGiaoVien(cn_old.magv);
                        DialogResult r = MessageBox.Show("BẠN CÓ MUỐN CHẮC HỦY TƯ CÁCH CHỦ NHIỆM CỦA GIÁO VIÊN " + pHoTen.ToUpper() + " KHÔNG?", "PHẦN MỀM TÍNH PHỤ TRỘI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (cn_bll.removeCN(cn_old.magv, wdg.PMaLP, cboYear.SelectedItem.ToString()))
                            {

                                MessageBox.Show("GIÁO VIÊN " + pHoTen.ToUpper() + " ĐÃ KHÔNG CÒN LÀ CHỦ NHIỆM LỚP!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                                loadClassrommAllItems();
                            }
                            else
                            {
                                MessageBox.Show("CÓ LỖI! VUI LÒNG THỬ LẠI", "PHẦN MỀM TÍNH PHỤ TRỘI");
                            }
                        }
                    }
                };

                //------------- SỬA
                classroomItems[i].onSelect3 += (ss, ee) =>
                {
                    var wdg = (ClassroomUI)ss;

                    cn_old = cn_bll.findTeacherNow(wdg.PMaLP, cboYear.SelectedItem.ToString());

                    if (cn_old == null)
                    {
                        MessageBox.Show("LỚP CHƯA CÓ GIÁO VIÊN CHỦ NHIỆM!", "PHẦN MỀM TÍNH PHỤ TRỘI");
                    }
                    else
                    {
                        fEditHomerooms = new frmEditHomerooms(wdg.PMaLP, wdg.PTenLP, cboYear.SelectedItem.ToString());
                        fEditHomerooms.ShowDialog();
                        loadClassrommAllItems();
                    }
                };
            }
        }

        private void loadYear()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            int y1, y2;
            string schoolYear = string.Empty;
            
            cboYear.Items.Clear();

            for(int i = 2021; i < year + 1; i++) 
            {
                schoolYear = i + "-" + (i + 1);
                cboYear.Items.Add(schoolYear);
            }

            cboYear.SelectedIndex = cboYear.Items.Count - 1;
        }

        private void setSizeFrom()
        {
            this.Size = new Size(1536, 816);
        }
    }
}
