using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteVMS.Entities.Volunteers
{
    public class AvailabilityTime
    {
        public int AvailabilityTimeID {get; set;}
        public int VolunteerID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
