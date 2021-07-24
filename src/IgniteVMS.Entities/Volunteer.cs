using System;

namespace IgniteVMS.Entities
{
    public class Volunteer
    {
        public int VolunteerID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Address { get; set; }
        public int? EmergencyContactID { get; set; }
        public bool DriversLicenseFiled { get; set; }
        public bool SSNOnFile { get; set; }
        public bool? Approved { get; set; } = null;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
