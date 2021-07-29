using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.ViewModel
{
    public class CreateOrder
    {
            [Required(ErrorMessage = "Please enter your first name")]
            [Display(Name = "First Name")]
            [StringLength(30)]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Please enter your last name")]
            [Display(Name = "Lastst Name")]
            [StringLength(30)]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Please enter your address")]
            [Display(Name = "Street address")]
            [StringLength(100)]
            public string Address { get; set; }

            [Required(ErrorMessage = "Please enter your city")]
            [StringLength(20, MinimumLength = 2)]
            public string City { get; set; }

            [Required(ErrorMessage = "Please enter your state")]
            [StringLength(20, MinimumLength = 2)]
            public string State { get; set; }

            [Required(ErrorMessage = "Please enter your Zip")]
            [StringLength(20, MinimumLength = 2)]
            public string ZipCode { get; set; }

            [Required(ErrorMessage = "Please enter your state")]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }
        }
}
