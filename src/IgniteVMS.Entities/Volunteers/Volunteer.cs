using System;
using System.Collections.Generic;

namespace IgniteVMS.Entities.Volunteers
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

        //External
        public IEnumerable<Center> CenterPreferences { get; set; }
        public IEnumerable<Qualification> VolunteerQualifications { get; set; }
        public IEnumerable<AvailabilityTime> AvailabilityTimes { get; set; }
        public UserResponse User { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
    }
}
