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

namespace DBS_Project
{
    public partial class Customer_Register : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public Customer_Register()
        {
            InitializeComponent();
        }

        public void DB_Connect()
        {
            String oradb = "Data Source=DESKTOP-F4OL5LL;User ID=system;Password=sys";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please Enter  ID");
            }
            else if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Name");
            }
            else if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Email");

            }
            else if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Address");

            }

            else
            {

                try
                {
                    DB_Connect();
                    int i = int.Parse(textBox3.Text);
                    comm = new OracleCommand();
                    comm.CommandText = "insert into customer values('" + textBox1.Text + "','" + textBox2.Text + "'," + i + ",'" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                    comm.CommandType = CommandType.Text;
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Inserted");
                    conn.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                    /*textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";*/
                }
            }
        }
    }
}

