using System;
using System.Collections;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Hashtable tbl = new Hashtable();
        private void button1_Click(object sender, EventArgs e)

        {
            tbl.Clear();
            const string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\sqlexpress";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "select EmployeeID,FirstName,LastName from Employees";

                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();



                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        string lasttName = reader.GetString(reader.GetOrdinal("LastName"));
                        int colIdx = reader.GetOrdinal("EmployeeID");
                        int EmployeeID = reader.GetInt32(colIdx);

                        string fullName = $"{firstName} {lasttName}";

                        tbl.Add(EmployeeID, fullName);
                    }


                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int numberEmployee =int.Parse(textBox1.Text);
            string fullName = (string)tbl[numberEmployee];

            MessageBox.Show(fullName);
            

        }

    }
}

