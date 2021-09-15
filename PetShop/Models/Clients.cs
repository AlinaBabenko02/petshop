using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace PetShop.Models
{
    public class Clients
    {
        public Clients()
        {
            Receipts = new HashSet<Receipts>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string name { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string surname { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string phone { get; set; }
        public virtual ICollection<Receipts> Receipts { get; set; }
    }
}
