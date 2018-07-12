using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryChat.Models;

namespace TryChat.Data.Repositories.RatingsSTAFF
{
    public class RatingsRepository : IRatingsStore
    {
        private readonly UserManager<ApplicationUser> _manager;
        private readonly ApplicationDbContext _context;
        public RatingsRepository(UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            _manager = manager;
            _context = context;
        }
        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public Task Edit()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Rating>> ReadmyRatings(string awarderUserId)
        {
            var myRatings = _context.Ratings.Where(m => m.ToId== awarderUserId);
            return await myRatings.ToListAsync();
        }
        public async Task SetRating(Rating newrating)
        {
            await _context.Ratings.AddAsync(newrating);
            await _context.SaveChangesAsync();
        }
    }
}
