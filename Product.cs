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

namespace OnlineOrderManagingSystem
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=polDB;Integrated Security=True;Encrypt=False");

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("Insert into product values(@Product_ID,@Product_Name,@Product_Price)", con);

            cnn.Parameters.AddWithValue("@Product_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Product_Name", textBox2.Text);

            cnn.Parameters.AddWithValue("@Product_Price", comboBox1.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void Product_Load(object sender, EventArgs e)
        {
            BindData();
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=polDB;Integrated Security=True;Encrypt=False");

            SqlCommand cnn = new SqlCommand("select * from product", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("Delete product where product_id=@product_id", con);

            cnn.Parameters.AddWithValue("@Product_ID", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }
    }
}
