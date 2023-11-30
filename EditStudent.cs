using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Institution_System
{
    public partial class EditStudent : Form
    {
        public EditStudent()
        {
            InitializeComponent();
        }

        private void EditStudent_Load(object sender, EventArgs e)
        {
            var con1 = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Student", con1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 == e.ColumnIndex)
            {
                this.Hide();
                Form EditStu = new EditStu(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()), dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() , int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()) , dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() , dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() , dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() );
                EditStu.ShowDialog();
                this.Hide();
            }
            }
    }
}
