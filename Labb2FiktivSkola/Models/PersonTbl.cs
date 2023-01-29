using System;
using System.Collections.Generic;

namespace Labb2FiktivSkola.Models
{
    public partial class PersonTbl
    {
        public PersonTbl()
        {
            ConnectionTbls = new HashSet<ConnectionTbl>();
        }

        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string PersonNumber { get; set; } = null!;
        public int Age { get; set; }

        public virtual ICollection<ConnectionTbl> ConnectionTbls { get; set; }
    }
}
