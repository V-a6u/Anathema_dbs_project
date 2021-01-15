using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anathema;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace anathema
{
    public partial class Emp_Home : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        string eid;
        public Emp_Home(string x)
        {
            InitializeComponent();
            eid = x;
            loadAdminDetails();
        }

        public void DB_Connect()
        {
            String oradb = "Data Source=DESKTOP-F4OL5LL;User ID=system;Password=sys";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        public void loadAdminDetails()
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT * FROM EMPLOYEE WHERE EMP_ID ='" + eid + "'";
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "EMPLOYEE");
            dt = ds.Tables["EMPLOYEE"];
            int t = dt.Rows.Count;
            if (t != 0)
            {
                dr = dt.Rows[i];
                ename.Text = dr["EMP_NAME"].ToString();
                e_id.Text = dr["EMP_ID"].ToString();
                email.Text = dr["EMP_EMAIL"].ToString();
                econtno.Text = dr["EMP_PH_NO"].ToString();
            }
            conn.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void econtno_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ename_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Emp_Order().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Generate_Rep().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Add_emp().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new delete_Pub().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Order_Journal().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Add_Publisher().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Delete_Emp().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new View_Customer().Show();
        }

        private void Emp_Home_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Add_Book().Show();
        }
    }
}
