using System;
using System.Collections.Generic;

namespace Labb2FiktivSkola.Models
{
    public partial class GradeSetByTbl
    {
        public GradeSetByTbl()
        {
            ConnectionTbls = new HashSet<ConnectionTbl>();
        }

        public string Id { get; set; } = null!;
        public string GradeSetBy { get; set; } = null!;

        public virtual ICollection<ConnectionTbl> ConnectionTbls { get; set; }
    }
}
