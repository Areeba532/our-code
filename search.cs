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
    public partial class search : Form
    {
        string conn_str = @"Data Source = DESKTOP-TG4J7GH\SQLEXPRESS; Initial Catalog= std_info; Integrated Security = true";

        public search()
        {
            InitializeComponent();
        }

        private void search_Load(object sender, EventArgs e)
        {
            DataSelect();
        }
        public void DataSelect()
        {
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand cmd = new SqlCommand("SELECT STD_INFOO.GR_NO, NAME, F_NAME,EMAIL,GROUPP, ENTRY_TEST, PERCENTAGE FROM STD_INFOO INNER JOIN test  ON STD_INFOO.GR_NO = test.GR_NO ", conn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand cmd = new SqlCommand("SELECT  STD_INFOO.GR_NO,NAME, F_NAME, EMAIL, GROUPP, ENTRY_TEST, PERCENTAGE FROM STD_INFOO INNER JOIN test  ON STD_INFOO.GR_NO = test.GR_NO WHERE test.GR_NO = '" + gr.Text + "' OR STD_INFOO.GROUPP = '" + comboBox1.Text + "' ", conn);

            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conn_str);



            SqlCommand cmd = new SqlCommand("DELETE  FROM STD_INFOO Where GR_NO= '" + gr.Text + "' AND GROUPP= '" + comboBox1.Text + "'", conn);
            SqlCommand cmd1 = new SqlCommand("DELETE FROM test Where GR_NO= '"+ gr.Text+"'", conn);

            conn.Open();

            cmd1.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            MessageBox.Show("ARE YOU SURE ", "DELETE RECORD", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            conn.Close();
            gr.Text = "";
            comboBox1.Text = "";

            DataSelect();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gr_TextChanged(object sender, EventArgs e)
        {
            if (gr.Text == "")
            {

                DataSelect();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {

                DataSelect();
            }
        }
    }
}
