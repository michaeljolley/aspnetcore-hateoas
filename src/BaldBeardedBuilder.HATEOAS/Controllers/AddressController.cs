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
    [Route("api/addresses")]
    public class AddressController : RestControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly BBBContext _bbbContext;

        public AddressController(ILogger<AddressController> logger, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, BBBContext bbbContext, IMapper mapper)
            : base(actionDescriptorCollectionProvider, mapper)
        {
            _logger = logger;
            _bbbContext = bbbContext;
        }

        [HttpGet(Name = "GetAddresses")]
        public IActionResult GetAddresses()
        {
            IEnumerable<Address> addresses = _bbbContext.Addresses;
            IEnumerable<AddressModel> addressModels = addresses.Select(f => RestfulAddress(f));
            
            return Ok(addressModels);
        }

        [HttpGet("{id}", Name = "GetAddressAsync")]
        public async Task<IActionResult> GetAddressAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            Address address = await _bbbContext.Addresses.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(RestfulAddress(address));
        }
    }
}
