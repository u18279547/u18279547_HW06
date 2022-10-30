using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LEsssGOOOOOO.Models
{
    public class Methods
    {
        private SqlConnection currConnection = new SqlConnection("Data Source=.;Initial Catalog=BikeStores;Integrated Security=True");

        public List<ProductVM> getProducts()
        {

            List<ProductVM> products = new List<ProductVM>();

            string sqlQuery = "select * from production.products";
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductVM product = new ProductVM();
                    product.product_id = Convert.ToInt32(reader["product_id"]);
                    product.product_name = Convert.ToString(reader["product_name"]);

                    products.Add(product);
                }
            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message;
            }
            finally
            {
                currConnection.Close();
            }

            return products;
        }

        public List<OrderItemVM> getOrderItems()
        {
            List<OrderItemVM> order_Items = new List<OrderItemVM>();
            string sqlQuery = "select * from sales.order_items";
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrderItemVM items = new OrderItemVM();
                    items.order_id = Convert.ToInt32(reader["order_id"]);
                    items.item_id = Convert.ToInt32(reader["item_id"]);
                    items.product_id = Convert.ToInt32(reader["product_id"]);
                    items.quantity = Convert.ToInt32(reader["quantity"]);
                    items.list_price = Convert.ToInt32(reader["list_price"]);
                    items.discount = Convert.ToInt32(reader["discount"]);
                    order_Items.Add(items);
                }
            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message;
            }
            finally
            {
                currConnection.Close();
            }

            return order_Items;
        }

        public List<OrderWithDateVM> getOrders()
        {
            List<OrderWithDateVM> orders = new List<OrderWithDateVM>();
            string sqlQuery = "select * from sales.orders";
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrderWithDateVM items = new OrderWithDateVM();
                    items.order_id = Convert.ToInt32(reader["order_id"]);
                    items.order_Date = Convert.ToString(reader["order_date"]);

                    orders.Add(items);
                }
            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message;
            }
            finally
            {
                currConnection.Close();
            }

            return orders;
        }

        public int getNumberOfOrders()
        {
            int TotalOrders = 0;
            string sqlQuery = "SELECT TOP 1 order_id FROM sales.order_items order by order_id desc";
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                TotalOrders = Convert.ToInt32(reader["order_id"]);

            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message;
            }
            finally
            {
                currConnection.Close();
            }

            return TotalOrders;
        }

        public List<List<OrderItemVM>> ListofLists()
        {
            int num = getNumberOfOrders();
            List<List<OrderItemVM>> combinedList = new List<List<OrderItemVM>>();

            string sqlQuery = "";

            for (var i = 1; i <= num; i++)
            {
                decimal GTotal = 0;
                List<OrderItemVM> orderItemVMs = new List<OrderItemVM>();
                try
                {
                    sqlQuery = "select * from sales.order_items where order_id =" + i;
                    currConnection.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderItemVM items = new OrderItemVM();
                        items.order_id = Convert.ToInt32(reader["order_id"]);
                        items.item_id = Convert.ToInt32(reader["item_id"]);
                        items.product_id = Convert.ToInt32(reader["product_id"]);
                        items.quantity = Convert.ToInt32(reader["quantity"]);
                        items.list_price = Convert.ToDecimal(reader["list_price"]);
                        items.discount = Convert.ToDecimal(reader["discount"]);
                        items.Total = items.list_price * items.quantity;
                        GTotal += items.Total;
                        orderItemVMs.Add(items);
                    }
                }
                catch (Exception err)
                {
                    string Message = "Error: " + err.Message;
                }
                finally
                {
                    currConnection.Close();

                }
                combinedList.Add(orderItemVMs);


            }

            return combinedList;
        }

        public int[] getNumberOfBikesSOld()
        {
            int[] TotalOrders = new int[12];
            for (var i = 1; i < 13; i++)
            {
                string sqlQuery = "select COUNT(*) as 'sales' from sales.orders WHERE MONTH(order_date) =" + i;

                try
                {
                    int sales = 0;
                    currConnection.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    sales = Convert.ToInt32(reader["sales"]);
                    TotalOrders[i - 1] = sales;
                }
                catch (Exception err)
                {
                    string Message = "Error: " + err.Message;
                }
                finally
                {
                    currConnection.Close();
                }
            }

            return TotalOrders;
        }
    }
}