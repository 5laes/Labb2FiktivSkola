using System;
using System.Collections.Generic;

namespace Labb2FiktivSkola.Models
{
    public partial class TimeOfGradeTbl
    {
        public TimeOfGradeTbl()
        {
            ConnectionTbls = new HashSet<ConnectionTbl>();
        }

        public string Id { get; set; } = null!;
        public string TimeOfGrade { get; set; } = null!;

        public virtual ICollection<ConnectionTbl> ConnectionTbls { get; set; }
    }
}
