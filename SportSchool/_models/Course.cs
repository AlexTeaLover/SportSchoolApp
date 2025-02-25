using System;
using System.Collections.Generic;

namespace SportSchool._models
{
    public partial class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Duration { get; set; } = null!;
    }
}
