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
    public class RefPartnersController : ControllerBase
    {
        private readonly DP_MainContext _context;

        public RefPartnersController(DP_MainContext context)
        {
            _context = context;
        }

        // GET: api/refpartners/{json/xml}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefPartner>>> RefPartners()
        {
            return await _context.RefPartners.ToListAsync();
        }

        //POST: api/refpartners/{json/xml}
        [HttpPost]
        public ActionResult Post([FromBody]PagingParameters param)
        {
            return Ok(_context.RefPartners.Skip((param.PageNumber - 1) * param.CountObject).Take(param.CountObject));
        }
    }
}