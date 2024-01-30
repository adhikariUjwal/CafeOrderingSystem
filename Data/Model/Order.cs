using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Data.Model
{
    public class Order
    {
        //Generates globally unique identifier for each order objects.
        public Guid Id { get; set; } = Guid.NewGuid();

        // Gets or sets the full name of the customer.
        [Required(ErrorMessage = "Full name is required.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        // Gets or sets the selected coffee for the order.
        [Display(Name = "Coffee")]
        public Coffee Coffee { get; set; }

        //Gets or sets the quantity for the selected coffee order
        public String Quantity {  get; set; }

        // Gets or sets the list of additional add-ins for the coffee order.
        public List<Add_ins> Addins { get; set; }

        //Gets or sets the total amount of the order
        public string Total {  get; set; }
    }
}
