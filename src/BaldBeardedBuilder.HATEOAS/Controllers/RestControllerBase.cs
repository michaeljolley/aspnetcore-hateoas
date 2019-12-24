using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using AutoMapper;

using BaldBeardedBuilder.HATEOAS.Models;
using BaldBeardedBuilder.HATEOAS.Lib.Entities;

namespace BaldBeardedBuilder.HATEOAS.Controllers
{
    public class RestControllerBase : ControllerBase
    {
        private readonly IReadOnlyList<ActionDescriptor> _routes;
        private readonly IMapper _mapper;

        public RestControllerBase(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IMapper mapper)
        {
            _routes = actionDescriptorCollectionProvider.ActionDescriptors.Items;
            _mapper = mapper;
        }

        internal Link UrlLink(string relation, string routeName, object values)
        {
            var route = _routes.FirstOrDefault(f => f.AttributeRouteInfo.Name.Equals(routeName));
            var method = route.ActionConstraints.OfType<HttpMethodActionConstraint>().First().HttpMethods.First();
            var url = Url.Link(routeName, values).ToLower();
            return new Link(url, relation, method);
        }

        internal AddressModel RestfulAddress(Address address)
        {
            AddressModel addressModel = _mapper.Map<AddressModel>(address);

            addressModel.Links.Add(
                UrlLink("all", "GetAddresses", null));

            addressModel.Links.Add(
                UrlLink("_self", "GetAddressAsync", new { id = addressModel.Id }));

            addressModel.Links.Add(
                UrlLink("client", "GetClientAsync", new { id = addressModel.ClientId }));

            return addressModel;
        }

        internal ClientModel RestfulClient(Client client)
        {
            ClientModel clientModel = _mapper.Map<ClientModel>(client);

            clientModel.Links.Add(
                UrlLink("all", "GetClients", null));

            clientModel.Links.Add(
                UrlLink("_self", "GetClientAsync", new { id = clientModel.Id }));

            clientModel.Links.Add(
                UrlLink("addresses", "GetAddressesByClient", new { id = clientModel.Id }));

            return clientModel;
        }
    }
}
