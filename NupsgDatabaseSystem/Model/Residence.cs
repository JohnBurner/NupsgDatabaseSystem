using System;

namespace NupsgDatabaseSystem.Model
{
    public class Residence
    {
        public int ResidenceId { get; set; }
        public string Name { get; set; }
        public string RoomNumber { get; set; }
        public int? MemberId { get; set; }
    }
}
