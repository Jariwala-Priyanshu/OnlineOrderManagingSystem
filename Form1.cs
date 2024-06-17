using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineOrderManagingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product ps = new Product();
            ps.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order od = new Order();
            od.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Seller sl = new Seller();
            sl.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Delivery ds = new Delivery();
            ds.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Payment ps = new Payment();
            ps.Show();
        }
    }
}
