using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Institution_System
{
    public partial class attend : Form
    {
        public attend()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Attendence b = new Attendence();
            b.ShowDialog();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherAtten b = new TeacherAtten();
            b.ShowDialog();
        }

        private void managementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MangementAtten b = new MangementAtten();
            b.ShowDialog();
        }
    }
}
