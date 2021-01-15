using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBS_Project;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace anathema
{
    public partial class Customer_Home : Form
    {

        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        String cid;
        public Customer_Home(string x)
        {
            InitializeComponent();
            cid = x;
            loadCustDetails();
            loadSubs();
            loadAllSubs();
        }

        public void DB_Connect()
        {
            String oradb = "Data Source=DESKTOP-F4OL5LL;User ID=system;Password=sys";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        public void loadCustDetails()
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT * FROM CUSTOMER WHERE CUST_ID ='" + cid + "'";
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "CUSTOMER");
            dt = ds.Tables["CUSTOMER"];
            int t = dt.Rows.Count;
            if (t != 0)
            {
                dr = dt.Rows[i]; 
                label1.Text = dr["CUST_NAME"].ToString();
                label2.Text = dr["CUST_ID"].ToString();
                label3.Text = dr["CUST_EMAIL"].ToString();
                label4.Text = dr["CUST_PH_NO"].ToString();
            }
            conn.Close();
        }

        public void loadSubs()
        {
            DB_Connect();
            string sid = cid;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT JOURNAL_NAME FROM JOURNAL NATURAL JOIN SUBSCRIPTION T WHERE T.CUST_ID = '"+ sid +"'";
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "T");
            dt = ds.Tables["T"];
            int t = dt.Rows.Count;
            if (t != 0)
            {
                for (int x = 0; x < t; x++)
                {
                    dr = dt.Rows[x];
                    listBox1.Items.Add(dr["JOURNAL_NAME"]);
                }
            }
            conn.Close();
        }

        public void loadAllSubs()
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT * FROM JOURNAL";
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "JOURNAL");
            dt = ds.Tables["JOURNAL"];
            int t = dt.Rows.Count;

            for(int x=0; x<t; x++)
            {
                dr = dt.Rows[x];
                comboBox1.Items.Add(dr["JOURNAL_NAME"]);
            }
            conn.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Customer_Transaction f2 = new Customer_Transaction(cid);
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Customer_Profile(cid).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Book_Search(cid).Show();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(comboBox1.SelectedItem.ToString() + "");
                listBox1.Items.Add(comboBox1.SelectedItem.ToString());
                new Journal_Bill(comboBox1.SelectedItem.ToString(), cid).Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
