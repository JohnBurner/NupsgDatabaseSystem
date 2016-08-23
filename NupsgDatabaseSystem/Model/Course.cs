using System;

namespace NupsgDatabaseSystem.Model
{
    public class Course
    {
        public int ProgramId { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public int? Lenght { get; set; }
    }
}
