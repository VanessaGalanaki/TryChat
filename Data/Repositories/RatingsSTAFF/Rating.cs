using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TryChat.Models;

namespace TryChat.Data.Repositories.RatingsSTAFF
{
    public class Rating
    {
        public int Id { get; set; }
        [Range(1,5)]
        public decimal RatingValue { get; set; }
        public string RatingText { get; set; }
        public string FromId { get; set; }
        public virtual ApplicationUser Reviewer { get; set; }
        public string ToId { get; set; }
        public virtual ApplicationUser AwardedUser { get; set; }
    }
}
