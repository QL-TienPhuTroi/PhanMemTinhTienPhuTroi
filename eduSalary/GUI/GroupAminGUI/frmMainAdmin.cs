﻿using System;
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
using TheArtOfDevHtmlRenderer.Adapters;
using System.Diagnostics;

namespace GUI.GroupAminGUI
{
    public partial class frmMainAdmin : Form
    {
        bool expand1 = true;
        bool expand2 = true;

        string pCode, pPass, pHoTen, pNamHoc;

        GiaoVienBLL gv_bll = new GiaoVienBLL();

        frmHomeAdmin fHomeAdmin = new frmHomeAdmin();

        frmTeacher fTeacher;
        frmPosition fPosition = new frmPosition();
        frmCareerTitles fCareerTitles = new frmCareerTitles();
        frmSalaryGrade fSalaryGrade = new frmSalaryGrade();
        frmLessonNorms fLessonNorms = new frmLessonNorms();
        frmSubject fSubject = new frmSubject();
        frmClassroom fClassroom = new frmClassroom();
        frmCertificate fCertificates = new frmCertificate();

        frmAssigningHomeroom fAssigningHomeroom = new frmAssigningHomeroom();
        frmTeachingAssignment fTeacherAssignment = new frmTeachingAssignment();
        frmConfirmLesson fConfirmLesson;
        frmExtraness fExtraness;

        public frmMainAdmin(string Code, string Pass)
        {
            InitializeComponent();

            timerNavigationMenu1 = new Timer();
            timerNavigationMenu1.Interval = 10;
            timerNavigationMenu1.Enabled = true;

            timerNavigationMenu2 = new Timer();
            timerNavigationMenu2.Interval = 10;
            timerNavigationMenu2.Enabled = true;

            timerNavigationMenu1.Tick += TimerNavigationMenu1_Tick;
            timerNavigationMenu2.Tick += TimerNavigationMenu2_Tick;

            btnHome.Click += BtnHome_Click;
            btnManager.Click += BtnManager_Click;
            btnAssignment.Click += BtnAssignment_Click;
            btnConfirmLesson.Click += BtnConfirmLesson_Click;
            btnExtraness.Click += BtnExtraness_Click;

            btnTeacher.Click += BtnTeacher_Click;
            btnPosition.Click += BtnPosition_Click;
            btnCareerTitles.Click += BtnCareerTitles_Click;
            btnSalaryGrade.Click += BtnSalaryGrade_Click;
            btnLessonNorms.Click += BtnLessonNorms_Click;
            btnDegree.Click += BtnCertificates_Click; ;
            btnSubject.Click += BtnSubject_Click;

            btnClassroom.Click += BtnClassroom_Click;

            btnHomeroomTeacher.Click += BtnHomeroomTeacher_Click;
            btnTeachingAssignment.Click += BtnTeachingAssignment_Click;

            btnLogout.Click += BtnLogout_Click;
            btnExit.Click += BtnExit_Click;

            this.Load += FrmMainAdmin_Load;

            pCode = Code;
            pPass = Pass;
            pNamHoc = lbNamHoc.Text;
            pHoTen = gv_bll.getNameGiaoVien(pCode); 
        }

        private void BtnCertificates_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "QUẢN LÝ BẰNG CẤP";
            pnlBody.Controls.Clear();
            fCertificates.TopLevel = false;
            fCertificates.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fCertificates);
            fCertificates.Show();
        }
        private void BtnSubject_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "QUẢN LÝ MÔN HỌC";
            pnlBody.Controls.Clear();
            fSubject.TopLevel = false;
            fSubject.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fSubject);
            fSubject.Show();
        }
        private void BtnLessonNorms_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "ĐỊNH MỨC TIẾT DẠY";
            pnlBody.Controls.Clear();
            fLessonNorms.TopLevel = false;
            fLessonNorms.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fLessonNorms);
            fLessonNorms.Show();
        }

        private void FrmMainAdmin_Load(object sender, EventArgs e)
        {
            lbFrmName.Text = "HELLO ^_^";
            pnlBody.Controls.Clear();
            fHomeAdmin.TopLevel = false;
            fHomeAdmin.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fHomeAdmin);
            fHomeAdmin.Show();

            loadGreeting();
            lbNamHoc.Text = getNamHoc();
            setSizeFrom();
        }           

        private void BtnTeacher_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "QUẢN LÝ GIÁO VIÊN";
            pnlBody.Controls.Clear();
            fTeacher = new frmTeacher(pNamHoc);
            fTeacher.TopLevel = false;
            fTeacher.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fTeacher);
            fTeacher.Show();
        }

        private void BtnPosition_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "QUẢN LÝ CHỨC VỤ";
            pnlBody.Controls.Clear();
            fPosition.TopLevel = false;
            fPosition.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fPosition);
            fPosition.Show();
        }

        private void BtnCareerTitles_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "CHỨC DANH NGHỀ NGHIỆP";
            pnlBody.Controls.Clear();
            fCareerTitles.TopLevel = false;
            fCareerTitles.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fCareerTitles);
            fCareerTitles.Show();
        }

        private void BtnSalaryGrade_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "QUẢN LÝ BẬC LƯƠNG";
            pnlBody.Controls.Clear();
            fSalaryGrade.TopLevel = false;
            fSalaryGrade.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fSalaryGrade);
            fSalaryGrade.Show();
        }

        private void BtnClassroom_Click(object sender, EventArgs e)
        {
            lbFrmName.Text = "QUẢN LÝ LỚP HỌC";
            pnlBody.Controls.Clear();
            fClassroom.TopLevel = false;
            fClassroom.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fClassroom);
            fClassroom.Show();
        }

        private void BtnTeachingAssignment_Click(object sender, EventArgs e)
        {
            this.Hide();
            fTeacherAssignment.ShowDialog();
            this.Show();
        }

        private void BtnHomeroomTeacher_Click(object sender, EventArgs e)
        {
            this.Hide();
            fAssigningHomeroom.ShowDialog();
            this.Show();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            if (expand2)
            {
                timerNavigationMenu2.Start();
                TimerNavigationMenu2_Tick(sender, e);
            }

            if (expand1)
            {
                timerNavigationMenu1.Start();
                TimerNavigationMenu1_Tick(sender, e);
            }


            pnlHome.Visible = true;
            pnlManager.Visible = false;
            pnlAssignment.Visible = false;
            pnlConfirmLesson.Visible = false;
            pnlExtraness.Visible = false;

            lbFrmName.Text = "HELLO ^_^";
            pnlBody.Controls.Clear();
            fHomeAdmin.TopLevel = false;
            fHomeAdmin.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fHomeAdmin);
            fHomeAdmin.Show();
        }

        private void BtnManager_Click(object sender, EventArgs e)
        {
            timerNavigationMenu1.Start();

            if (expand2)
            {
                timerNavigationMenu2.Start();
                TimerNavigationMenu2_Tick(sender, e);
            }

            pnlHome.Visible = false;
            pnlManager.Visible = true;
            pnlAssignment.Visible = false;
            pnlConfirmLesson.Visible = false;
            pnlExtraness.Visible = false;
        }

        private void BtnAssignment_Click(object sender, EventArgs e)
        {
            timerNavigationMenu2.Start();
                        
            if (expand1)
            {
                timerNavigationMenu1.Start();
                TimerNavigationMenu1_Tick(sender, e);
            }

            pnlManager.Visible = false;
            pnlHome.Visible = false;
            pnlAssignment.Visible = true;
            pnlConfirmLesson.Visible = false;
            pnlExtraness.Visible = false;
        }

        private void BtnConfirmLesson_Click(object sender, EventArgs e)
        {
            if (expand2)
            {
                timerNavigationMenu2.Start();
                TimerNavigationMenu2_Tick(sender, e);
            }

            if (expand1)
            {
                timerNavigationMenu1.Start();
                TimerNavigationMenu1_Tick(sender, e);
            }

            pnlHome.Visible = false;
            pnlManager.Visible = false;
            pnlAssignment.Visible = false;
            pnlConfirmLesson.Visible = true;
            pnlExtraness.Visible = false;

            fConfirmLesson = new frmConfirmLesson(lbNamHoc.Text);
            lbFrmName.Text = "XÁC NHẬN LỊCH DẠY";
            pnlBody.Controls.Clear();
            fConfirmLesson.TopLevel = false;
            fConfirmLesson.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fConfirmLesson);
            fConfirmLesson.Show();
        }

        private void BtnExtraness_Click(object sender, EventArgs e)
        {
            if (expand2)
            {
                timerNavigationMenu2.Start();
                TimerNavigationMenu2_Tick(sender, e);
            }

            if (expand1)
            {
                timerNavigationMenu1.Start();
                TimerNavigationMenu1_Tick(sender, e);
            }

            pnlHome.Visible = false;
            pnlManager.Visible = false;
            pnlAssignment.Visible = false;
            pnlConfirmLesson.Visible = false;
            pnlExtraness.Visible = true;

            fExtraness = new frmExtraness(lbNamHoc.Text);
            lbFrmName.Text = "BẢNG LƯƠNG PHỤ TRỘI";
            pnlBody.Controls.Clear();
            fExtraness.TopLevel = false;
            fExtraness.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(fExtraness);
            fExtraness.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TimerNavigationMenu1_Tick(object sender, EventArgs e)
        {
            if (!expand1)
            {
                dropDownMenu1.Height += 15;
                if(dropDownMenu1.Height >= dropDownMenu1.MaximumSize.Height)
                {
                    timerNavigationMenu1.Stop();
                    expand1 = true;
                }
            }
            else
            {
                dropDownMenu1.Height -= 15;
                if (dropDownMenu1.Height <= dropDownMenu1.MinimumSize.Height)
                {
                    timerNavigationMenu1.Stop();
                    expand1 = false;
                }
            }
        }

        private void TimerNavigationMenu2_Tick(object sender, EventArgs e)
        {
            if (!expand2)
            {
                dropDownMenu2.Height += 15;
                if (dropDownMenu2.Height >= dropDownMenu2.MaximumSize.Height)
                {
                    timerNavigationMenu2.Stop();
                    expand2 = true;
                }
            }
            else
            {
                dropDownMenu2.Height -= 15;
                if (dropDownMenu2.Height <= dropDownMenu2.MinimumSize.Height)
                {
                    timerNavigationMenu2.Stop();
                    expand2 = false;
                }
            }
        }

        private void loadGreeting()
        {
            string pName = getName().ToUpper();
            lbHello.Text = pName;
        }

        public string getName()
        {
            string[] names = pHoTen.Split(' ');
            return names[names.Length - 2] + " " + names[names.Length - 1];
        }

        private string getNamHoc()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            int y1, y2;
            string schoolYear = string.Empty;

            if(month >= 1 && month < 9) 
            {
                schoolYear = (year - 1) + "-" + year;
            }
            else
            {
                schoolYear = year + "-" + (year + 1);
            }
            return schoolYear;
        }

        private void setSizeFrom()
        {
            this.Size = new Size(1536, 816);
        }
    }
}
