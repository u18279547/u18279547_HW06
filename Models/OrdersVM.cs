using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEsssGOOOOOO.Models
{
    public class OrdersVM
    {
        public List<OrderItemVM> Orders { get; set; }
        public List<ProductVM> products { get; set; }
        public List<List<OrderItemVM>> dividedList { get; set; }

        public List<OrderWithDateVM> orderDates { get; set; }
    }
}