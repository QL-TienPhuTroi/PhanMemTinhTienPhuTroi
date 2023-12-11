using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ClassroomAssignmentUI : UserControl
    {
        public event EventHandler onSelect = null;
        public ClassroomAssignmentUI()
        {
            InitializeComponent();
            this.Load += ClassroomAssignmentUI_Load;
            btnEnter.Click += BtnEnter_Click;
        }

        private void ClassroomAssignmentUI_Load(object sender, EventArgs e)
        {

        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private string pHoTen;
        private string pMaLP;
        private string pTenLP;
        private int pSiSo;
               
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
            set { pMaLP = value;}
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
    }
}
