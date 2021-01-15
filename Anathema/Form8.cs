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
    public partial class Form8 : Form
    {
        OracleDataAdapter da;
        OracleCommand comm;
        OracleConnection conn;
        DataSet ds;
        DataRow dr;
        DataTable dt;
        public Form8()
        {
            InitializeComponent();
        }
        public void DB_Connect()
        {
            String oradb = "Data Source=DESKTOP-H5PIUV5;User ID=system;Password=patti31***";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Employee ID");
            }
            else if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Employee Name");
            }
            else if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Employee Phone Number");

            }
            else if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Employee Email_ID");

            }
            else if (textBox5.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Employee Password");

            }
            else
            {
                try
                {
                    DB_Connect();
                    comm = new OracleCommand();
                    comm.CommandText = "insert into employee values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + " ')";
                    comm.CommandType = CommandType.Text;
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Inserted");
                    conn.Close();
                    }
                     catch(Exception e1)
                     {
                         textBox1.Text = "";
                         textBox2.Text = "";
                         textBox3.Text = "";
                         textBox4.Text = "";
                         textBox5.Text = "";

                     }
                

        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}

