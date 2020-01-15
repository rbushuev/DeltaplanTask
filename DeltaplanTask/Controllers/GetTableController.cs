using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeltaplanTask.Data;
using DeltaplanTask.Models;

namespace DeltaplanTask.Controllers
{
    [Route("api/[controller]/[action]/{format?}")]
    [ApiController]
    [FormatFilter]
    public class GetTableController : ControllerBase
    {
        private readonly DP_MainContext _context;

        public GetTableController(DP_MainContext context)
        {
            _context = context;
        }

        // GET: api/getTable/stmapiclients/{json/xml}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StmApiClient>>> StmApiClients()
        {
            return await _context.StmApiClients.ToListAsync();
        }

        // GET: api/getTable/refpartners/{json/xml}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefPartner>>> RefPartners()
        {
            return await _context.RefPartners.ToListAsync();
        }

        // GET: api/getTable/dttech/{json/xml}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtTech>>> DtTech()
        {
            return await _context.DtTech.ToListAsync();
        }

        // GET: api/getTable/dtbase/{json/xml}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtBase>>> DtBase()
        {
            return await _context.DtBase.ToListAsync();
        }

        // GET: api/getTable/refmediatype/{json/xml}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefMediaType>>> RefMediaType()
        {
            return await _context.RefMediaType.ToListAsync();
        }

    }
}
