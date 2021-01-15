using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anathema
{
    public partial class Search_Result : Form
    {
        String cid;
        public Search_Result(DataSet ds, String d, String id)
        {
            InitializeComponent();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = d;
            cid =  id;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int col = 0;
            String id = dataGridView1.Rows[row].Cells[col].Value.ToString();
            //MessageBox.Show(id);
            new Order(id, cid).Show();
        }
    }
}
