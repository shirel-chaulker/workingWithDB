using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workingwithDB_05_12_2022
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Hashtable tbl = new Hashtable();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            const string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\sqlexpress";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string queryString = "select ProductID, ProductName,UnitPrice,UnitsInStock from Products";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    try
                    {
                        connection.Open();



                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                string Name = reader.GetString(reader.GetOrdinal("ProductName"));
                                int productid = reader.GetInt32(reader.GetOrdinal("ProductID"));
                                SqlMoney UnitPrice = reader.GetSqlMoney(reader.GetOrdinal("UnitPrice"));
                                int UnitsInStock = reader.GetInt16(reader.GetOrdinal("UnitsInStock"));

                                Product item = new Product(productid, Name, UnitPrice, UnitsInStock);
                                tbl.Add(item.ProductID, item);
                            }


                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show(ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show(ex.StackTrace);
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
        string name;
        SqlMoney unitprice;
        int UnitsInStock;
        private void button2_Click(object sender, EventArgs e)
        {
            int productid = int.Parse(textBox1.Text);

            if(tbl[productid] is Product)
            {
               Product product = (Product)tbl[productid];
                name = product.ProductName;
                unitprice = product.UnitPrice;
                UnitsInStock = product.UnitsInStock;

                label1.Text = $"{name} {unitprice}";
                
            }
       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = $"{UnitsInStock}";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            const string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\sqlexpress";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlMoney number = SqlMoney.Parse(textBox2.Text);
                     

                    string queryString = "select count (ProductID) from Products where UnitPrice >" + number;

                    SqlCommand command = new SqlCommand(queryString, connection);
                    try
                    {
                        connection.Open();


                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                int count = reader.GetInt32(0);
                                MessageBox.Show(count.ToString());
                                
                            }

                            
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show(ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show(ex.StackTrace);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
    }

