using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace PetShop.Models
{
    public class Discounts
    {
        public Discounts()
            {
            Receipts = new HashSet<Receipts>();
            }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public int amout_of_discount { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string info { get; set; }
        public virtual ICollection<Receipts> Receipts { get; set; }
    }
}
