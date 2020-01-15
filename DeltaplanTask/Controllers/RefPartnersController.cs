using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaplanTask.Data;
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
    }
}