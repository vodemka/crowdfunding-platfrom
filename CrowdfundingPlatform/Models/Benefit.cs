using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Models
{
    public class Benefit
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public int BonusId { get; set; }
        public virtual Bonus Bonus { get; set; }
        public DateTime Date { get; set; }
    }
}
