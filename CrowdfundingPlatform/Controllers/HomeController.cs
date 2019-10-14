using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrowdfundingPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CrowdfundingPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext context;

        public HomeController(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            foreach (var item in context.Campaigns)
            {
                item.VideoLink = item.VideoLink.Replace("watch?v=", "embed/");
            }
            await context.SaveChangesAsync();
            return View(await context.Campaigns.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCampaign(
        [Bind("Title,Subject,Description,Needed,Expiration,VideoLink")] Campaign campaign)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    campaign.CreatedAt = DateTime.Now;
                    campaign.UpdatedAt = DateTime.Now;
                    campaign.Owner = context.Users.FirstOrDefault(p=>p.Email.Equals(User.Identity.Name));
                    context.Add(campaign);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View("Add");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
