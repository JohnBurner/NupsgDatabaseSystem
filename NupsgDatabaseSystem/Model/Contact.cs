using System;

namespace NupsgDatabaseSystem.Model
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string PersonalPhone { get; set; }
        public string OtherPhone { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public int? MemberId { get; set; }
    }
}
