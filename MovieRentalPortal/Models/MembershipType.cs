﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalPortal.Models
{
    public class MembershipType
    {
        public byte id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

    }
}