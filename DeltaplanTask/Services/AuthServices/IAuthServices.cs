using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaplanTask.Services
{
    public interface IAuthServices
    {
        bool IsOK(string apikey);
    }
}
