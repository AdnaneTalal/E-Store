using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace E_Store.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Category IMAG")]
        [Required(ErrorMessage = "Please choose file toto upload.")]

        public string Image { get; set; }
    }
}