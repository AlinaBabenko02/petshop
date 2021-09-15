using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace PetShop.Models
{
    public class Products
    {
        public Products()
        {
            Product_Lists = new HashSet<Product_List>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string name { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string info { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string price { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public int CategoriesId { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public int ProvidersId { get; set; }
        public virtual ICollection<Product_List> Product_Lists { get; set; }
        public virtual Providers Provider { get; set; }
        public virtual Categories Category { get; set; }
    }
}
