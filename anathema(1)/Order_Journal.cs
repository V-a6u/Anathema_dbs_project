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
    public partial class Order_Journal : Form
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
        public Order_Journal()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select journal_name from journal";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "JOURNAL");
            dt = ds.Tables["JOURNAL"];
            int t = dt.Rows.Count;
            for (int x = 0; x < t; x++)
            {
                dr = dt.Rows[x];
                comboBox1.Items.Add(dr["JOURNAL_NAME"].ToString());
            }
            conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comm = new OracleCommand();
            comm.CommandText = "select journal_cost from publisher_order natural join journal where journal_name='" + comboBox1.SelectedItem.ToString() + "'";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "tbl_p1");
            dt = ds.Tables["tbl_p1"];
            dr = dt.Rows[0];
            int t = int.Parse(dr["journal_cost"].ToString()) * int.Parse(textBox1.Text.ToString());
            richTextBox1.AppendText("The cost price is ");
            richTextBox1.AppendText(t.ToString()+"\n");
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order Placed.");
        }
    }
}
