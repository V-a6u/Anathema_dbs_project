using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Anathema
{
    public partial class Form1 : Form
    {
        OracleDataAdapter da;
        OracleCommand comm;
        OracleConnection conn;
        DataSet ds;
        DataRow dr;
        DataTable dt;
        public void DB_Connect()
        {
            String oradb = "Data Source=DESKTOP-H5PIUV5;User ID=system;Password=patti31***";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        public Form1()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select title from book";
            comm.CommandType = CommandType.Text;
            //comm.ExecuteNonQuery();
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_book");
            dt = ds.Tables["Tbl_book"];
            int t = dt.Rows.Count;
            comboBox1.DataSource = dt.DefaultView;
            comboBox1.DisplayMember = "title";
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comm = new OracleCommand();
            comm.CommandText = "select cost_price from publisher_order natural join book where title='" + comboBox1.SelectedItem.ToString() + "'";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "tbl_p1");
            dt = ds.Tables["tbl_p1"];
            dr = dt.Rows[0];
            int t = int.Parse(dr["cost_price"].ToString()) * int.Parse(textBox1.Text.ToString());
            richTextBox1.AppendText("The cost price is ");
            richTextBox1.AppendText(t.ToString());
            conn.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.Show();
            this.Hide();
        }
    }
}
