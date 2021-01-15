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
    public partial class Form6 : Form
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
        public Form6()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select cust_id from customer";
            comm.CommandType = CommandType.Text;
            //comm.ExecuteNonQuery();
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_customer");
            dt = ds.Tables["Tbl_customer"];
            int t = dt.Rows.Count;
            comboBox1.DataSource = dt.DefaultView;
            comboBox1.DisplayMember = "cust_id";
            conn.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from customer where cust_id='" + comboBox1.Text + "'";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "customer");
            dt = ds.Tables["customer"];
            int t = dt.Rows.Count;
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "customer";
            conn.Close();
        }
    }
}
