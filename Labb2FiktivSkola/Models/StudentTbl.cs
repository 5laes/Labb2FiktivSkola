using System;
using System.Collections.Generic;

namespace Labb2FiktivSkola.Models
{
    public partial class StudentTbl
    {
        public StudentTbl()
        {
            ConnectionTbls = new HashSet<ConnectionTbl>();
        }

        public string Id { get; set; } = null!;
        public string ClassYear { get; set; } = null!;

        public virtual ICollection<ConnectionTbl> ConnectionTbls { get; set; }
    }
}
