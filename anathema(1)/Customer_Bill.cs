using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBS_Project
{
    public partial class Customer_Bill : Form
    {
        String bname;
        String unit;
        String qty;
        String coid;
        public Customer_Bill(String w, String x, String y, String z)
        {
            InitializeComponent();
            coid = w;
            bname = x;
            qty = y;
            unit = z;
            load();
        }

        public void load()
        {
            b_name.Text = bname;
            o_id.Text = coid;
            quant.Text = qty;
            cost.Text = (int.Parse(qty) * int.Parse(unit)).ToString();
            date.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Bill_Load(object sender, EventArgs e)
        {

        }
    }
}
