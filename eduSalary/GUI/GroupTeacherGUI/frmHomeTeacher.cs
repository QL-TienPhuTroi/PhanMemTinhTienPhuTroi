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
    public partial class frmHomeTeacher : Form
    {
        PhuTroiBLL pt_bll = new PhuTroiBLL();
        ChiTietLichDayBLL ctld_bll = new ChiTietLichDayBLL();

        List<PhuTroiDTO> lst_pt = new List<PhuTroiDTO>();

        string pMaGV, pNamHoc;
        DateTime pNow = DateTime.Now;
        DateTime pStartOfWeek;

        public frmHomeTeacher(string _magv, string _namhoc)
        {
            InitializeComponent();
            pMaGV = _magv;
            pNamHoc = _namhoc;
            this.Load += FrmHomeTeacher_Load;
        }

        private void FrmHomeTeacher_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void getData()
        {
            pStartOfWeek = ctld_bll.FindStartOfWeek(pNow);
            lst_pt = pt_bll.getDataPhuTroi(pMaGV, pNamHoc);
            lbQuantityTeached.Text = ctld_bll.getCountLessonTeachingInWeek(pMaGV, pStartOfWeek, pNamHoc) + "/" + ctld_bll.getCountLessonInWeek(pMaGV, pStartOfWeek, pNamHoc);
            lbLesson.Text = lst_pt[0].sogiodaythem.ToString();
            lbExtraness.Text = lst_pt[0].tienphutroi.ToString("N0") + " vnđ";
        }
    }
}
