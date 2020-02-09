using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace TelephoneDiary
{
    public partial class Phone : Form
    {
        SqlConnection conn=new SqlConnection("Data Source=.;Initial Catalog=Phone;Integrated Security=True");
        public Phone()
        {
            InitializeComponent();
            Display();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Phone_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sc = new SqlCommand("insert into Mobile (First_name, Last_name,Mobile,Email,Category) values ('"+ textBox4.Text+ "','" + textBox5.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "')", conn);
            sc.ExecuteNonQuery();
            conn.Close();
            Display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sc = new SqlCommand("delete from Mobile where (Mobile='"+ textBox1.Text+"')", conn);
            sc.ExecuteNonQuery();
            conn.Close();
            Display();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sc = new SqlCommand("update Mobile set First_name='" + textBox4.Text + "', Last_name='" + textBox5.Text + "', Mobile='" + textBox1.Text + "', Email='" + textBox2.Text + "',Category='" + comboBox1.Text + "' where (Mobile='"+ textBox1.Text+"')", conn);
            sc.ExecuteNonQuery();
            conn.Close();
            Display();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox4.Text = "";
            textBox5.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void Display()
        {
            SqlDataAdapter Ad = new SqlDataAdapter("Select * from Mobile",conn);
            DataTable table = new DataTable();
            Ad.Fill(table);
            dataGridView1.Rows.Clear();
            foreach(DataRow item in table.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value=item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text=dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox5.Text= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text=dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text=dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text=dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

        }
    }
}
