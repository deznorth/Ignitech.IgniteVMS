using System;

namespace IgniteVMS.Entities.Opportunities
{
    public class Opportunity
    {
        public int OpportunityID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CenterID { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
