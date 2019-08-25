using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Models
{
    public class Rated
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }
        public double Value { get; set; }
    }
}
