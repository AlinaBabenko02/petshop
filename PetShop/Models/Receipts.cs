using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace PetShop.Models
{
    public class Receipts
    {
        public Receipts()
        {
            Product_Lists = new HashSet<Product_List>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage ="Поле не должно быть пустым")]
        public int ClientsId { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public int DiscountsId { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public DateTime date { get; set; }
        public virtual Clients Client { get; set; }
        public virtual Discounts Discount { get; set; }
        public virtual ICollection<Product_List> Product_Lists { get; set; }
    }
}
