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
    public class RefMediaTypeController : ControllerBase
    {
        private readonly DP_MainContext _context;

        public RefMediaTypeController(DP_MainContext context)
        {
            _context = context;
        }

        // GET: api/refmediatype/{json/xml}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefMediaType>>> RefMediaType()
        {
            return await _context.RefMediaType.ToListAsync();
        }
    }
}