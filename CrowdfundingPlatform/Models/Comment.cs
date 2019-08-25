using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
