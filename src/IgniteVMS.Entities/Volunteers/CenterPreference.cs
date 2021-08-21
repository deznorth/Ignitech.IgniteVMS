using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteVMS.Entities.Volunteers
{
    public class CenterPreference
    {
        public int CenterPreferenceID { get; set; }
        public int VolunteerID { get; set; }
        public int CenterID { get; set; }
    }
}
