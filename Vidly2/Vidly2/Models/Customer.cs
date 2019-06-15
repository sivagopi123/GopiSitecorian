using System;
using System.ComponentModel.DataAnnotations;


namespace Vidly2.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(maximumLength: 255)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Is User Subscribed for Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }
        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }

        [Required]
        public int MembershipTypeId { get; set; }
        [Display(Name = "Birth Date of Customer")]
        public DateTime? CustomerBirthDate { get; set; }
    }
}