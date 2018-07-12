using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TryChat.Data.Repositories.RatingsSTAFF;
using TryChat.Models.POCOS;

namespace TryChat.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
            SentMessages = new List<Message>();
            ReceivedMessages = new List<Message>();
        }

        public virtual ICollection<Message> SentMessages { get; set; }

        public virtual ICollection<Message> ReceivedMessages { get; set; }
        public virtual ICollection<Rating> GivenRatings { get; set; }

        public virtual ICollection<Rating> ReceivedRatings { get; set; }
        [NotMapped]
        public decimal OverallRating {
            get {
                if (ReceivedRatings.Count >0)
                {
                    return ReceivedRatings.Average(x => x.RatingValue);
                }
                return 0;
            }
        }
    }
}
