using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class waiting_list : Form
    {
        public waiting_list()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            wait_eng wait = new wait_eng();
            wait.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wait_cs wait = new wait_cs();
            wait.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            wait_arts wait = new wait_arts();
            wait.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wait_med wait = new wait_med();
            wait.Show();
        }

        private void waiting_list_Load(object sender, EventArgs e)
        {

        }
    }
}
