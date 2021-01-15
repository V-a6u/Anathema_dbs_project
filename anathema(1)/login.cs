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
    public partial class login : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public login()
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
            id.Text = id.Text.ToUpper();
            pass.Text = pass.Text.ToUpper();
            string key = id.Text.ElementAt(0).ToString();
            if (key == "C")
            {
                try
                {
                    DB_Connect();
                    string lid = id.Text;
                    string lpass = pass.Text;
                    comm = new OracleCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT CUST_ID , FUNC2(CUST_ID)AS PASS FROM CUSTOMER WHERE CUST_ID = '"+lid+"'";
                    da = new OracleDataAdapter(comm.CommandText, conn);
                    ds = new DataSet();
                    da.Fill(ds, "CUSTOMER");
                    dt = ds.Tables["CUSTOMER"];
                    dr = dt.Rows[i];
                    int t = dt.Rows.Count;
                    if (lpass == dr["PASS"].ToString())
                    {
                        new Customer_Home(dr["CUST_ID"].ToString()).Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
            else if (key == "E")
            {
                try
                {
                    DB_Connect();
                    string lid = id.Text;
                    string lpass = pass.Text;
                    comm = new OracleCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "SELECT EMP_ID , FUNC3(EMP_ID)AS PASS FROM EMPLOYEE WHERE EMP_ID = '"+lid+"'";
                    da = new OracleDataAdapter(comm.CommandText, conn);
                    ds = new DataSet();
                    da.Fill(ds, "EMPLOYEE");
                    dt = ds.Tables["EMPLOYEE"];
                    dr = dt.Rows[i];
                    int t = dt.Rows.Count;
                    if (lpass == dr["PASS"].ToString())
                    {
                        new Emp_Home(dr["EMP_ID"].ToString()).Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Customer_Register().Show();
        }
    }
}
