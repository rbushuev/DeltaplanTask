using DeltaplanTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaplanTask.Services
{
    public class AuthClientAPIKeyServices : IAuthServices
    {
        private readonly DP_MainContext _context;

        public AuthClientAPIKeyServices(DP_MainContext context)
        {
            _context = context;
        }

        public bool IsOK(string apikey)
        {
            return _context.StmApiClients.Any(x => x.ApiKey == apikey);
        }
    }
}
