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

namespace GUI.GroupTeacherGUI
{
    public partial class frmTeachingSchedule : Form
    {
        LichDayBLL ld_bll = new LichDayBLL();
        ChiTietLichDayBLL ctld_bll = new ChiTietLichDayBLL();

        List<LichGiangDayDTO> lgd_dto = new List<LichGiangDayDTO>();

        string pMaGV, pNamHoc;
        DateTime pNow = DateTime.Now;
        DateTime pDate;

        public frmTeachingSchedule(string _magv, string _namhoc)
        {
            InitializeComponent();
            pMaGV = _magv;
            pNamHoc = _namhoc;
            this.Load += FrmTeachingSchedule_Load;
            dtpNgayDay.ValueChanged += DtpNgayDay_ValueChanged;
            btnPresent.Click += BtnPresent_Click;
            btnBack.Click += BtnBack_Click;
            btnNext.Click += BtnNext_Click;
        }

        private void DtpNgayDay_ValueChanged(object sender, EventArgs e)
        {
            setDate(dtpNgayDay.Value);
            loadTeachingSchedule(dtpNgayDay.Value);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            dtpNgayDay.Value = dtpNgayDay.Value.AddDays(7);
            setDate(dtpNgayDay.Value);
            loadTeachingSchedule(dtpNgayDay.Value);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            dtpNgayDay.Value = dtpNgayDay.Value.AddDays(-7);
            setDate(dtpNgayDay.Value);
            loadTeachingSchedule(dtpNgayDay.Value);
        }

        private void BtnPresent_Click(object sender, EventArgs e)
        {
            dtpNgayDay.Value = pNow;
            setDate(dtpNgayDay.Value);
            loadTeachingSchedule(dtpNgayDay.Value);
        }

        private void FrmTeachingSchedule_Load(object sender, EventArgs e)
        {
            dtpNgayDay.Value = pNow;
            setDate(dtpNgayDay.Value);
            loadTeachingSchedule(dtpNgayDay.Value);
        }

        private void setDate(DateTime pDateTime)
        {
            pDate = ctld_bll.FindStartOfWeek(pDateTime);

            Date1.Text = pDate.ToString("dd/MM/yyyy");
            Date2.Text = pDate.AddDays(1).ToString("dd/MM/yyyy");
            Date3.Text = pDate.AddDays(2).ToString("dd/MM/yyyy");
            Date4.Text = pDate.AddDays(3).ToString("dd/MM/yyyy");
            Date5.Text = pDate.AddDays(4).ToString("dd/MM/yyyy");
            Date6.Text = pDate.AddDays(5).ToString("dd/MM/yyyy");
            Date7.Text = pDate.AddDays(6).ToString("dd/MM/yyyy");
        }

        private void loadTeachingSchedule(DateTime pDateTime)
        {
            DateTime pDateTemp;
            pDate = ctld_bll.FindStartOfWeek(pDateTime);

            resetPanel();
            for (int i = 0; i < 7; i++)
            {
                pDateTemp = pDate.AddDays(i);

                lgd_dto = ld_bll.getDataLichDayTheoGV(pMaGV, pDateTemp, pNamHoc);

                if (lgd_dto.Count != 0) 
                {
                    for(int j = 0; j < lgd_dto.Count; j++)
                    {
                        //-------- THỨ 2
                        if (pDateTemp.DayOfWeek == DayOfWeek.Monday)
                        {
                            if (lgd_dto[j].tietday == 1)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T2T1.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T2T1.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 2)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T2T2.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T2T2.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 3)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T2T3.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T2T3.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 4)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T2T4.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T2T4.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 5)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T2T5.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T2T5.Controls.Add(lb);
                            }
                        }

                        //-------- THỨ 3
                        if (pDateTemp.DayOfWeek == DayOfWeek.Tuesday)
                        {
                            if (lgd_dto[j].tietday == 1)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T3T1.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T3T1.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 2)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T3T2.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T3T2.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 3)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T3T3.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T3T3.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 4)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T3T4.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T3T4.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 5)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T3T5.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T3T5.Controls.Add(lb);
                            }
                        }

                        //-------- THỨ 4
                        if (pDateTemp.DayOfWeek == DayOfWeek.Wednesday)
                        {
                            if (lgd_dto[j].tietday == 1)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T4T1.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T4T1.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 2)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T4T2.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T4T2.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 3)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T4T3.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T4T3.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 4)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T4T4.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T4T4.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 5)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T4T5.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T4T5.Controls.Add(lb);
                            }
                        }

                        //-------- THỨ 5
                        if (pDateTemp.DayOfWeek == DayOfWeek.Thursday)
                        {
                            if (lgd_dto[j].tietday == 1)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T5T1.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T5T1.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 2)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T5T2.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T5T2.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 3)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T5T3.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T5T3.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 4)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T5T4.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T5T4.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 5)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T5T5.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T5T5.Controls.Add(lb);
                            }
                        }

                        //-------- THỨ 6
                        if (pDateTemp.DayOfWeek == DayOfWeek.Friday)
                        {
                            if (lgd_dto[j].tietday == 1)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T6T1.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T6T1.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 2)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T6T2.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T6T2.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 3)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T6T3.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T6T3.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 4)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T6T4.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T6T4.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 5)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T6T5.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T6T5.Controls.Add(lb);
                            }
                        }

                        //-------- THỨ 7
                        if (pDateTemp.DayOfWeek == DayOfWeek.Saturday)
                        {
                            if (lgd_dto[j].tietday == 1)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T7T1.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T7T1.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 2)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T7T2.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T7T2.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 3)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T7T3.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T7T3.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 4)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T7T4.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T7T4.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 5)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T7T5.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T7T5.Controls.Add(lb);
                            }
                        }

                        //-------- CHỦ NHẬT
                        if (pDateTemp.DayOfWeek == DayOfWeek.Sunday)
                        {
                            if (lgd_dto[j].tietday == 1)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T8T1.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T8T1.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 2)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T8T2.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T8T2.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 3)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T8T3.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T8T3.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 4)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T8T4.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T8T4.Controls.Add(lb);
                            }

                            if (lgd_dto[j].tietday == 5)
                            {
                                Label lb = new Label();
                                lb.AutoSize = false;
                                lb.Size = new Size(T2T1.Width, T2T1.Height);
                                lb.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                                T8T5.Controls.Clear();
                                lb.Text = lgd_dto[j].tenmh + " - " + lgd_dto[j].tenlp + "\nTiết: " + lgd_dto[j].tietday;
                                T8T5.Controls.Add(lb);
                            }
                        }
                    }
                }
            }
        }

        private void resetPanel()
        {
            T2T1.Controls.Clear();
            T2T2.Controls.Clear();
            T2T3.Controls.Clear();
            T2T4.Controls.Clear();
            T2T5.Controls.Clear();

            T3T1.Controls.Clear();
            T3T2.Controls.Clear();
            T3T3.Controls.Clear();
            T3T4.Controls.Clear();
            T3T5.Controls.Clear();

            T4T1.Controls.Clear();
            T4T2.Controls.Clear();
            T4T3.Controls.Clear();
            T4T4.Controls.Clear();
            T4T5.Controls.Clear();

            T5T1.Controls.Clear();
            T5T2.Controls.Clear();
            T5T3.Controls.Clear();
            T5T4.Controls.Clear();
            T5T5.Controls.Clear();

            T6T1.Controls.Clear();
            T6T2.Controls.Clear();
            T6T3.Controls.Clear();
            T6T4.Controls.Clear();
            T6T5.Controls.Clear();

            T7T1.Controls.Clear();
            T7T2.Controls.Clear();
            T7T3.Controls.Clear();
            T7T4.Controls.Clear();
            T7T5.Controls.Clear();

            T8T1.Controls.Clear();
            T8T2.Controls.Clear();
            T8T3.Controls.Clear();
            T8T4.Controls.Clear();
            T8T5.Controls.Clear();
        }
    }
}
