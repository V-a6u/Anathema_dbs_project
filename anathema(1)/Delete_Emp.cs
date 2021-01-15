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
    public partial class Delete_Emp : Form
    {
        OracleDataAdapter da;
        OracleCommand comm;
        OracleConnection conn;
        DataSet ds;
        DataRow dr;
        DataTable dt;
        public Delete_Emp()
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
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select emp_id from employee";
            comm.CommandType = CommandType.Text;
            //comm.ExecuteNonQuery();
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_emp");
            dt = ds.Tables["Tbl_emp"];
            int t = dt.Rows.Count;
            listBox1.DataSource = dt.DefaultView;
            listBox1.DisplayMember = "emp_id";
            conn.Close();
         }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from employee where emp_id='"+ listBox1.Text+"'";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_publisher");
            dt = ds.Tables["Tbl_publisher"];
            int t = dt.Rows.Count;
            MessageBox.Show(t.ToString());
            dr = dt.Rows[0];
            textBox1.Text = dr["emp_id"].ToString();
            textBox2.Text = dr["emp_name"].ToString();
            textBox3.Text = dr["emp_ph_no"].ToString();
            textBox4.Text = dr["emp_email"].ToString();
            conn.Close();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "delete from employee where emp_id='" + listBox1.Text + "'";
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;
            comm.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            conn.Close();*/
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection = conn;
            comm.CommandText = "EMPDELPROC";

            OracleParameter pa1 = new OracleParameter();
            pa1.ParameterName = "X";
            pa1.DbType = DbType.String;
            pa1.Value = textBox1.Text;
            comm.Parameters.Add(pa1);

            comm.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from employee where emp_id='" + listBox1.Text + "'";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_publisher");
            dt = ds.Tables["Tbl_publisher"];
            dr = dt.Rows[0];
            textBox1.Text = dr["emp_id"].ToString();
            textBox2.Text = dr["emp_name"].ToString();
            textBox3.Text = dr["emp_ph_no"].ToString();
            textBox4.Text = dr["emp_email"].ToString();
            conn.Close();
        }
    }
}
