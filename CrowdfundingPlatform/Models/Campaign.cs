using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public double Needed { get; set; }
        public double Available { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string VideoLink { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Bonus> Bonuses { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public Campaign()
        {
            News = new HashSet<News>();
            Comments = new HashSet<Comment>();
            Bonuses = new HashSet<Bonus>();
            Tags = new HashSet<Tag>();
        }
    }
}
