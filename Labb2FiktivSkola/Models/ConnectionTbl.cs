using System;
using System.Collections.Generic;

namespace Labb2FiktivSkola.Models
{
    public partial class ConnectionTbl
    {
        public int Id { get; set; }
        public string PersonId { get; set; } = null!;
        public string? EmployeeId { get; set; }
        public string? StudentId { get; set; }
        public string? CourseId { get; set; }
        public string? GradeId { get; set; }
        public string? TimeOfGradeId { get; set; }
        public string? GradeSetById { get; set; }

        public virtual CourseTbl? Course { get; set; }
        public virtual EmployeeTbl? Employee { get; set; }
        public virtual GradeTbl? Grade { get; set; }
        public virtual GradeSetByTbl? GradeSetBy { get; set; }
        public virtual PersonTbl Person { get; set; } = null!;
        public virtual StudentTbl? Student { get; set; }
        public virtual TimeOfGradeTbl? TimeOfGrade { get; set; }
    }
}
