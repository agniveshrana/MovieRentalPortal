using AutoMapper;
using MovieRentalPortal.Models;
using MovieRentalPortal.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalPortal.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(dest => dest.CustomerId, action => action.Ignore());
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}