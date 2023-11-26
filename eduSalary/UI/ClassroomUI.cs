using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ClassroomUI: UserControl
    {
        public event EventHandler onSelect1 = null;
        public event EventHandler onSelect2 = null;
        public event EventHandler onSelect3 = null;

        public ClassroomUI()
        {
            InitializeComponent();
            this.Load += ClassroomUI_Load;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += btnDelete_Click;
            btnEdit.Click += BtnEdit_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            onSelect1?.Invoke(this, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            onSelect2?.Invoke(this, e);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            onSelect3?.Invoke(this, e);
        }

        private void ClassroomUI_Load(object sender, EventArgs e)
        {
            
        }

        private string pHoTen;
        private string pMaLP;
        private string pTenLP;
        private int pSiSo;
        private string pKhiemKhuyet;
        private Image pTrangThai;

        [Category("Custom Classroom")]
        public Image PTrangThai
        {
            get { return pTrangThai; }
            set { pTrangThai = value; picStatus.Image = value; }
        }

        [Category("Custom Classroom")]
        public string PHoTen
        {
            get { return pHoTen; }
            set { pHoTen = value; lbGV.Text = value; }
        }

        [Category("Custom Classroom")]
        public string PMaLP
        {
            get { return pMaLP; }
            set { pMaLP = value; lbMaLP.Text = value; }
        }

        [Category("Custom Classroom")]
        public string PTenLP
        {
            get { return pTenLP; }
            set { pTenLP = value; lbTenLP.Text = value; }
        }

        [Category("Custom Classroom")]
        public int PSiSo
        {
            get { return pSiSo; }
            set { pSiSo = value; lbSS.Text = value.ToString(); }
        }

        [Category("Custom Classroom")]
        public string PKhiemKhuyet
        {
            get { return pKhiemKhuyet; }
            set { pKhiemKhuyet = value; lbKK.Text = value; }
        }
    }
}
