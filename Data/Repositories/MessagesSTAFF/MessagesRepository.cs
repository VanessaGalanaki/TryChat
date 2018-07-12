using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryChat.Data;
using TryChat.Data.Migrations;
using TryChat.Data.Repositories.MessagesSTAFF;
using TryChat.Models.POCOS;
using TryChat.Models.Repositories.MessagesSTAFF;

namespace TryChat.Models.MessagesRepository
{
    public class MessagesRepository : IMessagesRepository
    {
       

        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _manager;

        public MessagesRepository(ApplicationDbContext context, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _manager = manager;

        }

        public async Task<IEnumerable<ApplicationUser>> GetAllLocals()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddNewMessage(Message newmessage)
        {
            await _context.Messages.AddAsync(newmessage);
            await _context.SaveChangesAsync();
        }

        public List<string> MyChatBuddies(string userId)
        {
            var user = _context.Users.Include("ReceivedMessages").Include("SentMessages").FirstOrDefault(x => x.Id == userId);
            var received = user.ReceivedMessages.Select(r => r.SenderID).ToList();
            var sender = _context.Messages.Where(m => m.SenderID == userId).Select(s => s.ReceiverID).ToList();
            var ConcatBuddies = received.Concat(sender).Select(x => x);
            var ChatBuddies = ConcatBuddies.Distinct().ToList();
            return ChatBuddies;
        }

        public async Task<List<Message>> GetMessagesBetween(string userId,string receiverId)
        {

            var messages = _context.Messages.Where(m => (m.SenderID == userId && m.ReceiverID == receiverId) || (m.SenderID == receiverId && m.ReceiverID == userId));
              
                
            return await messages.ToListAsync() ;
        }

      
    }
}
