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
    public partial class Form2 : Form
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
        public Form2()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select journal_name from journal";
            comm.CommandType = CommandType.Text;
            //comm.ExecuteNonQuery();
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "Tbl_journal");
            dt = ds.Tables["Tbl_journal"];
            int t = dt.Rows.Count;
            comboBox1.DataSource = dt.DefaultView;
            comboBox1.DisplayMember = "journal_name";
            conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comm = new OracleCommand();
            comm.CommandText = "select journal_cost from publisher_order natural join journal where journal_name='" + comboBox1.SelectedItem.ToString() + "'";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "tbl_p1");
            dt = ds.Tables["tbl_p1"];
            dr = dt.Rows[0];
            int t = int.Parse(dr["journal_cost"].ToString()) * int.Parse(textBox1.Text.ToString());
            richTextBox1.AppendText("The cost price is ");
            richTextBox1.AppendText(t.ToString());
            conn.Close();
        }
    }
}
