using System;
using System.Collections.Generic;

namespace Labb2FiktivSkola.Models
{
    public partial class CourseTbl
    {
        public CourseTbl()
        {
            ConnectionTbls = new HashSet<ConnectionTbl>();
        }

        public string Id { get; set; } = null!;
        public string Course { get; set; } = null!;

        public virtual ICollection<ConnectionTbl> ConnectionTbls { get; set; }
    }
}
