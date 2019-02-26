using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace Vidly2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name.")]
        [StringLength(255, ErrorMessage = "The maximum length for the name is 255 characters")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsltter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name= "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}