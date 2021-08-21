using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteVMS.Entities.Volunteers
{
    public class VolunteerQualification
    {
        public int VolunteerQualificationID { get; set; }
        public int VolunteerID { get; set; }
        public int QualificationID { get; set; }
    }
}
