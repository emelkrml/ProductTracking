using ProductTrackingApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductTrackingApp.MvcUI.Models
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}