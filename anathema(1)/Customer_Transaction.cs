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

namespace anathema
{
    public partial class Customer_Transaction : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        string cid;
        int i = 0;
        public Customer_Transaction(string x)
        {
            InitializeComponent();
            cid = x;
            fillGrid();
        }
        public void DB_Connect()
        {
            String oradb = "Data Source=DESKTOP-F4OL5LL;User ID=system;Password=sys";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        public void fillGrid()
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT * FROM CUST_ORDER WHERE CUST_ID = '"+cid+"'";
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "CUST_ORDER");
            dt = ds.Tables["CUST_ORDER"];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "CUST_ORDER";
            conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
