using System;
using System.Collections.Generic;

namespace Labb2FiktivSkola.Models
{
    public partial class EmployeeTbl
    {
        public EmployeeTbl()
        {
            ConnectionTbls = new HashSet<ConnectionTbl>();
        }

        public string Id { get; set; } = null!;
        public string Proffession { get; set; } = null!;

        public virtual ICollection<ConnectionTbl> ConnectionTbls { get; set; }
    }
}
