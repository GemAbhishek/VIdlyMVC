using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMVC.Models
{
    public class Customer
    {
        [Required]
        public int  Id { get; set; }
        [Required(ErrorMessage ="Please enter customer Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display( Name = "Date Of Birth")]
        [Min18YearForMembership]
        public DateTime? Dob { get; set; }


    }
}
