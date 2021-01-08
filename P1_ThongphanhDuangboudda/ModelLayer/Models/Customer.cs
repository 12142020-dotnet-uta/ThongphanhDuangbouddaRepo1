using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [StringLength(60, MinimumLength = 2)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter more than 2 characters")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
      
    }
}
