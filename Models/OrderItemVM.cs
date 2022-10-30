using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEsssGOOOOOO.Models
{
    public class OrderItemVM
    {
        public int order_id { get; set; }
        public int item_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal list_price { get; set; }
        public decimal discount { get; set; }

        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }

    }
}