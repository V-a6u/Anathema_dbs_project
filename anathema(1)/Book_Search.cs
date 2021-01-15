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
    public partial class Book_Search : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        String cid;

        public Book_Search(String x)
        {
            InitializeComponent();
            cid = x;
        }

        public void DB_Connect()
        {
            String oradb = "Data Source=DESKTOP-F4OL5LL;User ID=system;Password=sys";
            conn = new OracleConnection(oradb);
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    DB_Connect();
                    comm = new OracleCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    if (radioButton1.Checked == true)
                    {
                        String gen = textBox1.Text;
                        comm.CommandText = "SELECT * FROM (SELECT B.TITLE, G.GENRE_NAME, A.AUTHOR_NAME FROM BOOK B , GENRE G, AUTHOR A WHERE B.GENRE_ID = G.GENRE_ID AND B.AUTHOR_ID = A.AUTHOR_ID AND G.GENRE_NAME = '" + gen.ToUpper() + "') T";
                        da = new OracleDataAdapter(comm.CommandText, conn);
                        ds = new DataSet();
                        da.Fill(ds, "T");
                        dt = ds.Tables["T"];
                        dr = dt.Rows[i];
                        int t = dt.Rows.Count;
                        if (t != 0)
                        {
                            //MessageBox.Show(dr["TITLE"].ToString());
                            new Search_Result(ds, "T", cid).Show();
                        }
                    }
                    else if (radioButton2.Checked == true)
                    {
                        String auth = textBox1.Text;
                        comm.CommandText = "SELECT * FROM (SELECT B.TITLE, G.GENRE_NAME, A.AUTHOR_NAME FROM BOOK B , GENRE G, AUTHOR A WHERE B.GENRE_ID = G.GENRE_ID AND B.AUTHOR_ID = A.AUTHOR_ID AND A.AUTHOR_NAME = '" + auth.ToUpper() + "') T";
                        da = new OracleDataAdapter(comm.CommandText, conn);
                        ds = new DataSet();
                        da.Fill(ds, "T");
                        dt = ds.Tables["T"];
                        dr = dt.Rows[i];
                        int t = dt.Rows.Count;
                        if (t != 0)
                        {
                            //MessageBox.Show(dr["TITLE"].ToString());
                            new Search_Result(ds, "T", cid).Show();
                        }
                    }
                    else
                    {
                        String auth = textBox1.Text;
                        comm.CommandText = "SELECT * FROM (SELECT B.TITLE, G.GENRE_NAME, A.AUTHOR_NAME FROM BOOK B , GENRE G, AUTHOR A WHERE B.GENRE_ID = G.GENRE_ID AND B.AUTHOR_ID = A.AUTHOR_ID) T";
                        da = new OracleDataAdapter(comm.CommandText, conn);
                        ds = new DataSet();
                        da.Fill(ds, "T");
                        dt = ds.Tables["T"];
                        dr = dt.Rows[i];
                        int t = dt.Rows.Count;
                        if (t != 0)
                        {
                            //MessageBox.Show(dr["TITLE"].ToString());
                            new Search_Result(ds, "T", cid).Show();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Current search doesnot match anything in our database.\nPlease try again!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
