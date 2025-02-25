using System;
using System.Collections.Generic;

namespace SportSchool._models
{
    public partial class Employee
    {
        public Employee()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
