using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalPortal.Dtos
{
    public class MembershipTypeDto
    {
        public byte id { get; set; }
        public string Name { get; set; }
        public byte DiscountRate { get; set; }
    }
}