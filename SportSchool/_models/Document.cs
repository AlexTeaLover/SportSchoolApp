using System;
using System.Collections.Generic;

namespace SportSchool._models
{
    public partial class Document
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime? Expires { get; set; }
        public int SignedBy { get; set; }

        public virtual Employee SignedByNavigation { get; set; } = null!;
    }
}
