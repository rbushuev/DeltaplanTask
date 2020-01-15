using System;
using System.Collections.Generic;

namespace DeltaplanTask.Models
{
    public partial class StmApiClient
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ApiKey { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
