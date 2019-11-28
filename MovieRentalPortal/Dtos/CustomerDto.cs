using MovieRentalPortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalPortal.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }
        public bool IsSubscribedForNewsLetter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
    }
}