using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Models
{
    public partial class Product
    {
        public int ID { get; set; }
        public string Name  { get; set; }
        
        public string Description  { get; set; }
        public decimal Price  { get; set; }

        public int Quantity { get; set; }
        public int? CategoryID { get; set; }
       

        public virtual Category Category { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Product IMAG")]
        [Required(ErrorMessage = "Please choose file toto upload.")]

        public string Image { get; set; }
       
    }

}