using System;
using System.Collections.Generic;

namespace DeltaplanTask.Models
{
    public partial class RefMediaType
    {
        public RefMediaType()
        {
            DtBase = new HashSet<DtBase>();
        }

        public short MediaTypeId { get; set; }
        public short FkRefMediaGroupId { get; set; }
        public string MediaType { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<DtBase> DtBase { get; set; }
    }
}
