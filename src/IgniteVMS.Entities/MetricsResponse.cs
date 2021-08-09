using IgniteVMS.Entities.Opportunities;
using System.Collections.Generic;

namespace IgniteVMS.Entities
{
    public class MetricsResponse
    {
        public int PendingVolunteers { get; set; }
        public int ApprovedVolunteers { get; set; }
        public int DeniedVolunteers { get; set; }
        public IEnumerable<Opportunity> UpcomingOpportunities { get; set; }
    }
}
