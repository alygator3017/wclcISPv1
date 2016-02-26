using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wclc.Models
{
    public class VolunteerForm
    {
        [Required]
        [DisplayName("Name (First and Last)")]
        [StringLength(322)]
        public string Name { get; set; }
        [Required]
        [StringLength(24)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}