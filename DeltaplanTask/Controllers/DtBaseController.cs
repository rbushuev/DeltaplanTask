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
    public class DtBaseController : ControllerBase
    {
        private readonly DP_MainContext _context;

        public DtBaseController(DP_MainContext context)
        {
            _context = context;
        }

        // GET: api/dtbase/{json/xml}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtBase>>> DtBase()
        {
            return await _context.DtBase.ToListAsync();
        }

        //POST: api/dtbase/{json/xml}
        [HttpPost]
        public ActionResult Post([FromBody]PagingParameters param)
        {
            return Ok(_context.DtBase.Skip((param.PageNumber - 1) * param.CountObject).Take(param.CountObject));
        }
    }
}