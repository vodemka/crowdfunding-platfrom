using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Models
{
    public class User : IdentityUser
    {
        public string Theme { get; set; } = "Light";
        public string Language { get; set; } = "English";
        public bool IsBlocked { get; set; } = false;
        public virtual ICollection<Campaign> Campaigns { get; set; }

        public User()
        {
            Campaigns = new HashSet<Campaign>();
        }
    }
}
