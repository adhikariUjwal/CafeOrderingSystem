using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Data.Model
{
    public class Add_ins
    {
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage = "Add-ins Name is Required")] // Required attribute ensures that this field is mandatory.
        [Display(Name = "Name")] // Display attribute changes the label that will be shown in the UI.
        public string Name { get; set; }


        [Required(ErrorMessage = "Add-ins price is Required")] // Required attribute ensures that this field is mandatory.
        [Display(Name = "Price")] // Display attribute changes the label that will be shown in the UI.
        public String Price { get; set; }
    }
}
