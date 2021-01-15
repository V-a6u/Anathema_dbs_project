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
    public partial class Form5 : Form
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
        public Form5()
        {
            InitializeComponent();
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from publisher where pub_id=" + listBox1.Text;
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_publisher");
            dt = ds.Tables["Tbl_publisher"];
            dr = dt.Rows[0];
            textBox1.Text = dr["pub_id"].ToString();
            textBox2.Text = dr["pub_name"].ToString();
            textBox3.Text = dr["pub_state"].ToString();
             conn.Close();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select pub_id from publisher";
            comm.CommandType = CommandType.Text;
            //comm.ExecuteNonQuery();
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_pub");
            dt = ds.Tables["Tbl_pub"];
            int t = dt.Rows.Count;
            listBox1.DataSource = dt.DefaultView;
            listBox1.DisplayMember = "pub_id";
            conn.Close();
         }

        private void button2_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "delete from publisher where pub_id='" + listBox1.Text +"'";
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;
            comm.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from publisher where pub_id='" + listBox1.Text + "'";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_publisher");
            dt = ds.Tables["Tbl_publisher"];
            dr = dt.Rows[0];
            textBox1.Text = dr["pub_id"].ToString();
            textBox2.Text = dr["pub_name"].ToString();
            textBox3.Text = dr["pub_state"].ToString();
            conn.Close();
        }
    }
}
