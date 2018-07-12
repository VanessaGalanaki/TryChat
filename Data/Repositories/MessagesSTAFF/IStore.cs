using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryChat.Models.POCOS;

namespace TryChat.Data.Repositories.MessagesSTAFF
{
    public interface IStore
    {
            Task AddNewMessage(Message message);
            Task<List<Message>> GetMessagesBetween(string id1, string id2);
            List<string> myChatBuddies(string myId);
        Task GetAllLocals();
    }
}
