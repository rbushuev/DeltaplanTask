using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaplanTask.Helpers
{
    public class PagingParameters
    {
		public int PageNumber { get; set; } = 1;
        public int CountObject { get; set; } = 3;
    }
}
