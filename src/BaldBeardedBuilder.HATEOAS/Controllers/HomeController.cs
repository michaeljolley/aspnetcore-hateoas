using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;

using AutoMapper;

using BaldBeardedBuilder.HATEOAS.Models;

namespace BaldBeardedBuilder.HATEOAS.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : RestControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IMapper mapper)
            : base(actionDescriptorCollectionProvider, mapper)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot()
        {
            RootModel rootModel = new RootModel();
            rootModel.Links.Add(
                UrlLink("addresses", "GetAddresses", null));

            rootModel.Links.Add(
                UrlLink("clients", "GetClients", null));

            return Ok(rootModel);
        }
    }
}
