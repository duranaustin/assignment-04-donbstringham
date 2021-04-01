using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlabberApp.Domain;
using BlabberApp.DataStore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Text.Json.Serialization;
using System.Text.Json;
using BlabberApp.Domain.Blab;

namespace BlabberApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlabsController : ControllerBase
    {
        private readonly ILogger<BlabsController> _logger;
        private readonly BlabCollection _blabs = new BlabCollection(/*In memory, mysql, sqlserver, etc....*/);

        public BlabsController(ILogger<BlabsController> logger, BlabCollection blabs)
        {
            _blabs = blabs;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            _logger.LogInformation("GET Not Implemented");
            if (_blabs.Count() == 0) {
                return new NoContentResult();
            } 

            return Ok(_blabs.ToJson());
        }
    }
}
