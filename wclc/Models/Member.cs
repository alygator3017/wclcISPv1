using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wclc.Models
{
    public class Member
    {
        //member id
        public int MemberId { get; set; }
        //first name
        [Required]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }
        //last name
        [Required]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }
        //street address
        [DisplayName("Address")]
        [Required]
        [StringLength(70, MinimumLength = 3)]
        public string StreetAddress { get; set; }
        //apt-suite no
        [DisplayName("Apt/Suite")]
        [StringLength(70)]
        public String aptSuite { get; set; }
        //city
        [DisplayName("City")]
        [Required]
        [StringLength(40)]
        public string City { get; set; }
        //state
        [DisplayName("State")]
        [Required]
        [StringLength(40)]
        public string State { get; set; }
        //zip
        [Required]
        [DisplayName("Zip Code")]
        [StringLength(10, MinimumLength = 5)]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }
        //phone
        [DisplayName("Phone Number (Optional)")]
        [StringLength(24)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        //email
        [Required]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //in gift of
        [DisplayName("In Gift Of")]
        public String inGiftOf { get; set; }
    }
}