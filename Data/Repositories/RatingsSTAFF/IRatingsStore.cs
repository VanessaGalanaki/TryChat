using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryChat.Data.Repositories.RatingsSTAFF
{
    public interface IRatingsStore
    {
        Task SetRating(Rating rating);
        Task<List<Rating>> ReadmyRatings(string awardedUserId);
        Task Edit();
        Task Delete();
    }
}
