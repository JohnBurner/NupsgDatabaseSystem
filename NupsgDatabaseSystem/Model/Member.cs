using System;

namespace NupsgDatabaseSystem.Model
{
    public partial class Member
    {
        public int MemberId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IndexNumber { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public int? CourseId { get; set; }
        public int? CellId { get; set; }
        
    }
}
