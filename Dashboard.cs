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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student b = new Student();
            b.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
           Teacher b = new Teacher();
            b.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
           Courses b = new Courses();
            b.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
           Evaluation b = new Evaluation();
            b.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
          attend b = new attend();
            b.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
           Mischallanoues b = new Mischallanoues();
            b.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
           Management b = new Management();
            b.ShowDialog();
        }
    }
}
