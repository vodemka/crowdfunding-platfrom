using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdfundingPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrowdfundingPlatform.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ApplicationContext context;
        public CampaignController(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Details(int? id)
        {
            List<User> users = new List<User>();
            users = await context.Users.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await context.Campaigns.Include("Owner")
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}