using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace PetShop.Models
{
    public class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string name { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
