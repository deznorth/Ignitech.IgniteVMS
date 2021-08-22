
namespace IgniteVMS.Entities.Volunteers
{
    public class SimplifiedVolunteer
    {
        public int VolunteerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CenterPreferences { get; set; } // Comma separated center preferences
        public string VolunteerQualifications { get; set; } // Comma separated qualifications
        public string Email { get; set; }
        public string HomePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Address { get; set; }
        public bool DriversLicenseFiled { get; set; }
        public bool SSNOnFile { get; set; }
        public int Approved { get; set; } // 0: Pending, 1: Approved, 2: Denied
    }
}
