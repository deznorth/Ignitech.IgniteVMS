using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteVMS.Entities.Volunteers
{
    public class EmergencyContact
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string HomePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
    }
}
