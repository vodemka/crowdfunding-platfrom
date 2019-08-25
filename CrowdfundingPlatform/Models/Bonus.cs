using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Models
{
    public class Bonus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public int CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}
