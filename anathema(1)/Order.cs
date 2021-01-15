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
    public partial class Order : Form
    {
        String s;
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        String cid;
        public Order(String x, String id)
        {
            InitializeComponent();
            s = x;
            cid = id;
            loadBookDetails(s);
        }

        public void DB_Connect()
        {
            String oradb = "Data Source=DESKTOP-F4OL5LL;User ID=system;Password=sys";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        public void loadBookDetails(String id)
        {
            DB_Connect();
            String s = id;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT * FROM(SELECT BOOK.BOOK_ID, BOOK.TITLE, BOOK_D1.AUTHOR_NAME ,BOOK.UNIT_PRICE FROM BOOK_D1 , BOOK  WHERE BOOK.TITLE = BOOK_D1.TITLE AND BOOK.TITLE = '" + s + "') T";
            da = new OracleDataAdapter(comm.CommandText, conn);
            ds = new DataSet();
            da.Fill(ds, "T");
            dt = ds.Tables["T"];
            dr = dt.Rows[0];
            bid.Text = dr["BOOK_ID"].ToString();
            bname.Text = dr["TITLE"].ToString();
            aname.Text = dr["AUTHOR_NAME"].ToString();
            unit.Text = dr["UNIT_PRICE"].ToString();
            conn.Close();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                String id = cid;
                String coid = generateOrderID();
                int qty = int.Parse(quantity.Text);
                MessageBox.Show(qty.ToString());
                DB_Connect();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "INSERT INTO CUST_ORDER VALUES('"+ coid +"', '" + id + "', '" + bid.Text + "', "+ qty +", TO_DATE('04-MAY-19', 'DD-MM-YY')," + int.Parse(unit.Text) + ")";
                comm.ExecuteNonQuery();
                MessageBox.Show("Order Placed!");
                conn.Close();
                new Customer_Bill(coid, bname.Text, quantity.Text, unit.Text).Show();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        public String generateOrderID()
        {
            int t = 0;
            try
            {
                DB_Connect();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT * FROM(SELECT * FROM CUST_ORDER)T";
                da = new OracleDataAdapter(comm.CommandText, conn);
                ds = new DataSet();
                da.Fill(ds, "T");
                dt = ds.Tables["T"];
                t = dt.Rows.Count;
                t++;
                conn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return "CO" + t.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(generateOrderID() + cid);
        }
    }
}
