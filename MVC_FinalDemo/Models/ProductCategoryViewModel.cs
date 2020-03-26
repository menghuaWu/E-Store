using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_FinalDemo.Models;

namespace MVC_FinalDemo.Models
{
    public class ProductCategoryViewModel
    {
        public List<tProduct> Products { get; set; }
        public List<tCatagory> Category { get; set; }
    }
}