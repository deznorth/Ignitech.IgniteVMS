using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteVMS.Entities.Volunteers
{
    public class VolunteerCreateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HomePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Address { get; set; }
        public bool DriversLicenseFiled { get; set; }
        public bool SSNOnFile { get; set; }
        public int Approved { get; set; }

        // External Information
        public User User { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
        public IEnumerable<Center> CenterPreferences { get; set; }
        public IEnumerable<Qualification> VolunteerQualifications { get; set; }
        public IEnumerable<AvailabilityTime> AvailabilityTimes { get; set; }
    }
}
