using System;
using System.Collections.Generic;

namespace SportSchool._models
{
    public partial class RoleMenu
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
