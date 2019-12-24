using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;

using AutoMapper;

using BaldBeardedBuilder.HATEOAS.Lib.Data;
using BaldBeardedBuilder.HATEOAS.Models;
using BaldBeardedBuilder.HATEOAS.Lib.Entities;

namespace BaldBeardedBuilder.HATEOAS.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : RestControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly BBBContext _bbbContext;

        public ClientController(ILogger<ClientController> logger, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, BBBContext bbbContext, IMapper mapper)
            : base(actionDescriptorCollectionProvider, mapper)
        {
            _logger = logger;
            _bbbContext = bbbContext;
        }

        [HttpGet(Name = "GetClients")]
        public IActionResult GetClients()
        {
            IEnumerable<Client> clients = _bbbContext.Clients;
            IEnumerable<ClientModel> clientModels = clients.Select(f => RestfulClient(f));
            
            return Ok(clientModels);
        }

        [HttpGet("{id}", Name = "GetClientAsync")]
        public async Task<IActionResult> GetClientAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            Client client = await _bbbContext.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(RestfulClient(client));
        }

        [HttpGet("{id}/addresses", Name = "GetAddressesByClient")]
        public IActionResult GetAddressesByClient(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            IEnumerable<Address> addresses = _bbbContext.Addresses.Where(w => w.ClientId.Equals(id));
            IEnumerable<AddressModel> addressModels = addresses.Select(f => RestfulAddress(f));

            return Ok(addressModels);
        }

    }
}
