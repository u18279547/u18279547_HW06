using System.Collections.Generic;
using System.Web.Mvc;
using LEsssGOOOOOO.Models;
using System.Data.SqlClient;
using PagedList;

namespace HW6ATMPT4.Controllers
{
    public class Order_ItemsController : Controller
    {
        private SqlConnection currConnection = new SqlConnection("Data Source=.;Initial Catalog=BikeStores;Integrated Security=True");
        Methods instance = new Methods();
        OrdersVM viewModel = null;
        // GET: order_items
        public ActionResult Index()
        {

            viewModel = new OrdersVM
            {
                Orders = instance.getOrderItems(),
                products = instance.getProducts(),
                dividedList = instance.ListofLists(),
                orderDates = instance.getOrders()
            };

            return View(viewModel);


        }
    }
}
