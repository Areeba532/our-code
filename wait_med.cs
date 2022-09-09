using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class wait_med : Form
    {
        string conn_str = @"Data Source = DESKTOP-TG4J7GH\SQLEXPRESS; Initial Catalog= std_info; Integrated Security = true";
        public wait_med()
        {
            InitializeComponent();
        }

        private void wait_med_Load(object sender, EventArgs e)
        {
            DataSelect();
        }
        public void DataSelect()
        {
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand cmd = new SqlCommand("SELECT  STD_INFOO.GR_NO,NAME, F_NAME, EMAIL, GROUPP, ENTRY_TEST, PERCENTAGE FROM STD_INFOO INNER JOIN test  ON STD_INFOO.GR_NO = test.GR_NO WHERE test.PERCENTAGE < 50 AND STD_INFOO.GROUPP = 'Pre Medical' ", conn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
