using System;

using AutoMapper;
using BaldBeardedBuilder.HATEOAS.Lib.Entities;
using BaldBeardedBuilder.HATEOAS.Models;

namespace BaldBeardedBuilder.HATEOAS
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Address, AddressModel>();
            CreateMap<Client, ClientModel>();
        }
    }
}
