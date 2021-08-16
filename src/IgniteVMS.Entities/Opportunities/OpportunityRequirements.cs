using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteVMS.Entities.Opportunities
{
    public class OpportunityRequirements
    {
        int OpportunityRequirementID { get; set; }
        int OpportunityID { get; set; }
        int QualificationID { get; set; }
    }
}
