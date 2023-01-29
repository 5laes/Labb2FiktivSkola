using System;
using System.Collections.Generic;

namespace Labb2FiktivSkola.Models
{
    public partial class GradeTbl
    {
        public GradeTbl()
        {
            ConnectionTbls = new HashSet<ConnectionTbl>();
        }

        public string Id { get; set; } = null!;
        public string Grade { get; set; } = null!;

        public virtual ICollection<ConnectionTbl> ConnectionTbls { get; set; }
    }
}
