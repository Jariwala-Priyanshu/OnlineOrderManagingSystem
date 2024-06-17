using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OnlineOrderManagingSystem
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=polDB;Integrated Security=True;Encrypt=False");

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("Insert into cust values(@Customer_ID,@Customer_Name,@Phone,@Address)", con);

            cnn.Parameters.AddWithValue("@Customer_ID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Customer_Name", textBox2.Text);

            cnn.Parameters.AddWithValue("@Phone", textBox3.Text);
            cnn.Parameters.AddWithValue("@Address", textBox4.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            BindData();
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=polDB;Integrated Security=True;Encrypt=False");

            SqlCommand cnn = new SqlCommand("select * from cust", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("Delete cust where Customer_ID=@Customer_ID", con);

            cnn.Parameters.AddWithValue("@Customer_ID", int.Parse(textBox1.Text));
          

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
