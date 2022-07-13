using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace E_Store.Models
{   
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {

    }
    public class ProductMetaData
    {
        [Display(Name = "Products Name")]
        public string Name;
    }
}