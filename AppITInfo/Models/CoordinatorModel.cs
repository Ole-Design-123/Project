using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppITInfo.Models
{
    public class CoordinatorModel
    {
        Tbl_Coordinator tbl_cord { get; set; }
        public int CID { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(7, ErrorMessage = "Index Number must be 7 digit", MinimumLength = 7)]
        public string IndexNo { get; set; }

        [Required(ErrorMessage = "Name Required.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use Alphabates only please")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile no is Required.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please insert valid mobile no.")]
        public string MobileNo { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}