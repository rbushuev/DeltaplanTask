using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaplanTask.Data;
using DeltaplanTask.Helpers;
using DeltaplanTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeltaplanTask.Controllers
{
    [Route("api/[controller]/{format?}")]
    [ApiController]
    [FormatFilter]
    public class StmApiClientsController : ControllerBase
    {
        private readonly DP_MainContext _context;

        public StmApiClientsController(DP_MainContext context)
        {
            _context = context;
        }

        // GET: api/stmapiclients/{json/xml}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StmApiClient>>> Get()
        {
            return await _context.StmApiClients.ToListAsync();
        }

        //POST: api/stmapiclients/{json/xml}
        [HttpPost]
        public ActionResult Post([FromBody]PagingParameters param)
        {
            return Ok(_context.StmApiClients.Skip((param.PageNumber - 1) * param.CountObject).Take(param.CountObject));
        }
    }
}