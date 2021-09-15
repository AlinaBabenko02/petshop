using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace PetShop.Models
{
    public class Product_List
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public int ReceiptsId { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public int ProductsId { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public int amount { get; set; }
        public virtual Receipts Receipts { get; set; }
        public virtual Products Product{ get; set; }
    }
}
