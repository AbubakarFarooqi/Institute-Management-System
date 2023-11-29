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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Institution_System
{
    public partial class Attendence : Form
    {
        public Attendence()
        {
            InitializeComponent();
        }

        private void Attendence_Load(object sender, EventArgs e)
        {
            var con1 = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("SELECT ID , Name , RegNo FROM Student", con1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO StdAtt (StdId, StdName, Attendence, [Created-On], [Editted-On], RegNo) VALUES (@StdId, @StdName, @Attendence, GETDATE(), GETDATE(), @RegNo)", con);
                cmd.Parameters.AddWithValue("@StdId", int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                cmd.Parameters.AddWithValue("@StdName", dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()); // Correct parameter name
                cmd.Parameters.AddWithValue("@RegNo", int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()));
                cmd.Parameters.AddWithValue("@Attendence", Present);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
