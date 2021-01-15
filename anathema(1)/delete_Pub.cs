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
    public partial class delete_Pub : Form
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
        public delete_Pub()
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
            /*
            try
            {
                DB_Connect();
                comm = new OracleCommand();
                comm.Connection = conn;
                String tem = textBox1.Text.ToString();
                MessageBox.Show(tem);
                comm.CommandType = CommandType.Text;
                comm.CommandText = "DELETE FROM PUBLISHER WHERE PUB_ID = '" + tem+ "'"; 
                comm.ExecuteNonQuery();
                MessageBox.Show("Deleted");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.Connection = conn;
            comm.CommandText = "PUBDELPROC";

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

        private void delete_Pub_Load(object sender, EventArgs e)
        {

        }
    }
}
