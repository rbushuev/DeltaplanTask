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
    public class DtTechController : ControllerBase
    {
        private readonly DP_MainContext _context;

        public DtTechController(DP_MainContext context)
        {
            _context = context;
        }

        // GET: api/dttech/{json/xml}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtTech>>> DtTech()
        {
            return await _context.DtTech.ToListAsync();
        }
    }
}