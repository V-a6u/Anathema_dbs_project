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
    public partial class Emp_Order : Form
    {
        OracleDataAdapter da;
        OracleCommand comm;
        OracleConnection conn;
        DataSet ds;
        DataRow dr;
        DataTable dt;
        public void DB_Connect()
        {
            String oradb = "Data Source=DESKTOP-F4OL5LL;User ID=system;Password=sys";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        public Emp_Order()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select title from book";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "BOOK");
            dt = ds.Tables["BOOK"];
            int t = dt.Rows.Count;
            for(int x=0; x<t; x++)
            {
                dr = dt.Rows[x];
                comboBox1.Items.Add(dr["TITLE"].ToString());
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Book f = new Add_Book();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                DB_Connect();
                comm = new OracleCommand();
                string temp = comboBox1.SelectedItem.ToString();
                MessageBox.Show(temp);
                comm.CommandText = "select * from(select cost_price from publisher_order natural join book where title='" + temp + "')T";
                comm.CommandType = CommandType.Text;
                da = new OracleDataAdapter(comm.CommandText, conn);
                ds = new DataSet();
                da.Fill(ds, "T");
                dt = ds.Tables["T"];
                dr = dt.Rows[0];
                int t = int.Parse(dr["cost_price"].ToString()) * int.Parse(textBox1.Text.ToString());
                richTextBox1.AppendText("The cost price is ");
                richTextBox1.AppendText(t.ToString()+"\n");
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Order_Journal f = new Order_Journal();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Book f = new Add_Book();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add_Publisher f = new Add_Publisher();
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            delete_Pub f = new delete_Pub();
            f.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            View_Customer f = new View_Customer();
            f.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Generate_Rep f = new Generate_Rep();
            f.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Add_emp f = new Add_emp();
            f.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Delete_Emp f = new Delete_Emp();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "PROC1";

            OracleParameter pa1 = new OracleParameter();
            pa1.DbType = DbType.String;
            pa1.ParameterName = "X";
            pa1.Value = comboBox1.SelectedItem.ToString();
            comm.Parameters.Add(pa1);

            OracleParameter pa2 = new OracleParameter();
            pa2.DbType = DbType.Int32;
            pa2.ParameterName = "Y";
            pa2.Value = int.Parse(textBox1.Text);
            comm.Parameters.Add(pa2);

            int res = comm.ExecuteNonQuery();
            if (res != 0)
            {
                MessageBox.Show("Order Placed.");
            }
        }
    }
}
