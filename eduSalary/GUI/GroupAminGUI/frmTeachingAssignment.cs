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
using UI;

namespace GUI.GroupAminGUI
{
    public partial class frmTeachingAssignment : Form
    {
        LopHocBLL lp_bll = new LopHocBLL();
        GiaoVienBLL gv_bll = new GiaoVienBLL();
        ChuNhiemBLL cn_bll = new ChuNhiemBLL();
        ChuNhiemDTO cn_old = new ChuNhiemDTO();
        ChuNhiemDTO cn_now = new ChuNhiemDTO();

        ClassroomAssignmentUI[] classroomItems = new ClassroomAssignmentUI[30];

        frmAddTeaching fAddTeaching;

        string pHoTen;

        public frmTeachingAssignment()
        {
            InitializeComponent();
            this.Load += FrmTeachingAssignment_Load;
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

        private void FrmTeachingAssignment_Load(object sender, EventArgs e)
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
                classroom = lp_bll.getDataLopHocTheoKhoi("10");
            }
            else if (rdo11.Checked)
            {
                classroom = lp_bll.getDataLopHocTheoKhoi("11");
            }
            else
            {
                classroom = lp_bll.getDataLopHocTheoKhoi("12");
            }

            flpLopHoc.Controls.Clear();

            for (int i = 0; i < classroom.Count; i++)
            {
                classroomItems[i] = new ClassroomAssignmentUI();
                classroomItems[i].Width = 375;
                classroomItems[i].Margin = new Padding(35, 10, 0, 20);
                classroomItems[i].PMaLP = classroom[i].malp;
                classroomItems[i].PTenLP = classroom[i].tenlp;
                classroomItems[i].PSiSo = int.Parse(classroom[i].siso.ToString());
                if (cn_bll.isHomerooms(classroom[i].malp, cboYear.SelectedItem.ToString()))
                {
                    cn_now = cn_bll.findTeacherNow(classroom[i].malp, cboYear.SelectedItem.ToString());
                    pHoTen = gv_bll.getNameGiaoVien(cn_now.magv);

                    classroomItems[i].PHoTen = pHoTen.ToUpper();
                }
                else
                {
                    classroomItems[i].PHoTen = string.Empty;
                }

                if (flpLopHoc.Controls.Count < 0)
                {
                    flpLopHoc.Controls.Clear();
                }
                else
                {
                    flpLopHoc.Controls.Add(classroomItems[i]);
                }

                classroomItems[i].onSelect += (ss, ee) =>
                {
                    var wdg = (ClassroomAssignmentUI)ss;

                    fAddTeaching = new frmAddTeaching(wdg.PMaLP, wdg.PTenLP, cboYear.SelectedItem.ToString());
                    fAddTeaching.ShowDialog();
                   //loadClassrommAllItems();
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

            for (int i = 2021; i < year + 1; i++)
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
