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
    public partial class Customer_Profile : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        String cid;
        public Customer_Profile(String x)
        {
            cid = x;
            InitializeComponent();
            loadCustDetails();
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
                cname.Text = dr["CUST_NAME"].ToString();
                c_id.Text = dr["CUST_ID"].ToString();
                cemail.Text = dr["CUST_EMAIL"].ToString();
                contno.Text = dr["CUST_PH_NO"].ToString();
                address.Text = dr["ADDRESS"].ToString();
            }
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String newpass = newPass.Text;
            String conpass = reenter.Text;
            if(newpass.Equals(conpass))
            {
                DB_Connect();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "UPDATE CUSTOMER SET CUST_PASS = '" + newPass.Text + "' WHERE CUST_ID = '" + cid + "'";
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Password Changed");
            }
            else
            {
                MessageBox.Show("Password do not match");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "UPDATE CUSTOMER SET CUST_NAME = '" + cname.Text + "' WHERE CUST_ID = '" + cid + "'";
            comm.ExecuteNonQuery();
            conn.Close();

            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "UPDATE CUSTOMER SET ADDRESS = '" + address.Text + "' WHERE CUST_ID = '" + cid + "'";
            comm.ExecuteNonQuery();
            conn.Close();

            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "UPDATE CUSTOMER SET CUST_PH_NO = '" + contno.Text + "' WHERE CUST_ID = '" + cid + "'";
            comm.ExecuteNonQuery();
            conn.Close();

            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "UPDATE CUSTOMER SET CUST_EMAIL = '" + cemail.Text + "' WHERE CUST_ID = '" + cid + "'";
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Profile Updated Successfully");
        }

        private void cname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
