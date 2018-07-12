using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TryChat.Data;
using TryChat.Data.Repositories.RatingsSTAFF;
using TryChat.Models;

namespace TryChat.Controllers
{
    public class RatingController : Controller
    {
        public IRatingsStore RatingsRepo { get; set; }
        private readonly UserManager<ApplicationUser> _manager;
        private readonly ApplicationDbContext _context;


        public RatingController(IRatingsStore _repo, UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            RatingsRepo = _repo;
            _manager = manager;
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SetRating(string Id)
        {
            ViewData["AwardedId"] = Id;
            return View();
        }
       
       
        [HttpPost]
        public async Task<JsonResult> SetRating(Rating newrating)
        {
            if (newrating != null && newrating.RatingText != "")
            {

                await RatingsRepo.SetRating(new Rating()
                {
                    FromId = newrating.FromId,
                    ToId = newrating.ToId,
                    RatingText = newrating.RatingText,
                    RatingValue = newrating.RatingValue
                });
               
                await _context.SaveChangesAsync();
                
            }
            return Json("Ok");
        }
    }
}