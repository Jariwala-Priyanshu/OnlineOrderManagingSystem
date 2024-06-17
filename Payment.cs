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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=polDB;Integrated Security=True;Encrypt=False");
        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("Insert into pay values(@P_ID,@P_Name,@C_Name,@PaymentMethod)", con);

            cnn.Parameters.AddWithValue("@P_ID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@P_Name", textBox2.Text);

            cnn.Parameters.AddWithValue("@C_Name", textBox3.Text);

            cnn.Parameters.AddWithValue("@PaymentMethod", textBox4.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            BindData();
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8NH2GBN;Initial Catalog=polDB;Integrated Security=True;Encrypt=False");

            SqlCommand cnn = new SqlCommand("select * from pay", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("Delete pay where P_ID=@P_ID", con);

            cnn.Parameters.AddWithValue("@P_ID", int.Parse(textBox1.Text));
            

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
