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
    public partial class Add_Book : Form
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
        public Add_Book()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select genre_id from genre";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_genre");
            dt = ds.Tables["Tbl_genre"];
            comboBox1.DataSource = dt.DefaultView;
            comboBox1.DisplayMember = "genre_id";
            conn.Close();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select lang_id from lang";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_lang");
            dt = ds.Tables["Tbl_lang"];
            comboBox2.DataSource = dt.DefaultView;
            comboBox2.DisplayMember = "lang_id";
            conn.Close();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select author_id from author";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_author");
            dt = ds.Tables["Tbl_author"];
            comboBox3.DataSource = dt.DefaultView;
            comboBox3.DisplayMember = "author_id";
            conn.Close();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select pub_id from publisher";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_publisher");
            dt = ds.Tables["Tbl_publisher"];
            comboBox4.DataSource = dt.DefaultView;
            comboBox4.DisplayMember = "pub_id";
            conn.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Book ID");
            }
            else if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Book Title");
            }
            else if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Book Author");

            }
            else if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Please Enter book quantity");

            }
            
            else
            {
                
                try
                {
                    DB_Connect();
                    comm = new OracleCommand();
                    comm.CommandText = "insert into book values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','"+ textBox3.Text+"','"+textBox4.Text+ "')";
                    comm.CommandType = CommandType.Text;
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Inserted");
                    conn.Close();
                }
                catch (Exception e1)
                {
                    //MessageBox.Show(e1.ToString());
                    /*textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";*/
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
