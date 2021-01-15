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
    public partial class Journal_Bill : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        String cid;
        String jar;
        public Journal_Bill(String x, String y)
        {
            jar = x;
            cid = y;
            InitializeComponent();
            j_name.Text = jar;
            loadDetails();
        }

        public void DB_Connect()
        {
            String oradb = "Data Source=DESKTOP-F4OL5LL;User ID=system;Password=sys";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        public void loadDetails()
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT * FROM JOURNAL WHERE JOURNAL_NAME ='" + jar + "'";
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "JOURNAL");
            dt = ds.Tables["JOURNAL"];
            int t = dt.Rows.Count;
            if (t != 0)
            {
                dr = dt.Rows[i];
                j_id.Text = dr["JOURNAL_ID"].ToString();
                pub_id.Text = dr["PUB_ID"].ToString();
                issue.Text = dr["ISSUE"].ToString();
                cost.Text = dr["JOURNAL_COST"].ToString();
            }
            conn.Close();
        }

        public String generateSubID()
        {
            int t = 0;
            try
            {
                DB_Connect();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT * FROM(SELECT * FROM SUBSCRIPTION)T";
                da = new OracleDataAdapter(comm.CommandText, conn);
                ds = new DataSet();
                da.Fill(ds, "T");
                dt = ds.Tables["T"];
                t = dt.Rows.Count;
                t++;
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return "S" + t.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(generateSubID() + cid);
        }

        private void Journal_Bill_Load(object sender, EventArgs e)
        {

        }

        private void j_id_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String id = cid;
                String coid = generateSubID();
                String jarid = j_id.Text;
                DB_Connect();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "INSERT INTO SUBSCRIPTION VALUES('" + coid + "', '" + id + "', '" + jarid + "', TO_DATE('04-MAY-19', 'DD-MM-YY'), 'ACTIVE')";
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Subscribed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
