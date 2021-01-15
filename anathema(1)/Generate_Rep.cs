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
    public partial class Generate_Rep : Form
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
        public Generate_Rep()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public int getBookCount()
        {
            int t = 0;
            try
            {
                DB_Connect();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT * FROM BOOK";
                da = new OracleDataAdapter(comm.CommandText, conn);
                ds = new DataSet();
                da.Fill(ds, "BOOK");
                dt = ds.Tables["BOOK"];
                t = dt.Rows.Count;
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return t;
        }
        public int getCustCount()
        {
            int t = 0;
            try
            {
                DB_Connect();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT * FROM CUSTOMER";
                da = new OracleDataAdapter(comm.CommandText, conn);
                ds = new DataSet();
                da.Fill(ds, "CUSTOMER");
                dt = ds.Tables["CUSTOMER"];
                t = dt.Rows.Count;
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return t;
        }

        public int getOrderCount()
        {
            int t = 0;
            try
            {
                DB_Connect();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "select sum(cust_order_qty) as sum from cust_order;";
                da = new OracleDataAdapter(comm.CommandText, conn);
                ds = new DataSet();
                da.Fill(ds, "cust_order");
                dt = ds.Tables["cust_order"];
                dr = dt.Rows[0];
                t = int.Parse(dr["sum"].ToString());
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return t;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = getBookCount().ToString();
            textBox2.Text = getOrderCount().ToString();
            textBox5.Text = getBookCount().ToString();
            textBox6.Text = getCustCount().ToString();
            textBox7.Text = getOrderCount().ToString();
        }
    }
}
