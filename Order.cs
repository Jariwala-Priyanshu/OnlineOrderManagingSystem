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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=polDB;Integrated Security=True;Encrypt=False");

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("Insert into od values(@Order_ID,@Product_Name,@OrderDate,@Product_Price)", con);

            cnn.Parameters.AddWithValue("@Order_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Product_Name", textBox2.Text);

            cnn.Parameters.AddWithValue("@OrderDate", dateTimePicker1.Value);

            cnn.Parameters.AddWithValue("@Product_Price", comboBox1.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Order_Load(object sender, EventArgs e)
        {
            BindData();
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=polDB;Integrated Security=True;Encrypt=False");

            SqlCommand cnn = new SqlCommand("select * from od", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("Delete od where Order_ID=@Order_ID", con);

            cnn.Parameters.AddWithValue("@Order_ID", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
        }
    }
}
