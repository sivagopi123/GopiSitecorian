using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Dtos
{
    public class CustomerDto
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(maximumLength: 255)]
        public string CustomerName { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        [Required]
        public int MembershipTypeId { get; set; }
        public DateTime? CustomerBirthDate { get; set; }
    }
}