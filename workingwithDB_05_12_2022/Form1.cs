using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workingwithDB_05_12_2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\sqlexpress";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "select count (OrderID) from Orders";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int num = reader.GetInt32(0);

                        textBox1.Text = num.ToString();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\sqlexpress";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "select count (CustomerID) from Customers";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int num = reader.GetInt32(0);

                        string result = num.ToString();
                        MessageBox.Show(result);
                    }
                }
            }

        }
    }
}
