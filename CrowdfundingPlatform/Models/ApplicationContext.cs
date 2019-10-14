using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Models
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :
            base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Rated> Rated { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<News>()
                .HasOne<Campaign>(a => a.Campaign)
                .WithMany(d => d.News)
                .HasForeignKey(d => d.CampaignId);
            builder.Entity<Campaign>()
                .HasOne<User>(a => a.Owner)
                .WithMany(d => d.Campaigns)
                .HasForeignKey(d => d.OwnerId);
        }
    }
}
