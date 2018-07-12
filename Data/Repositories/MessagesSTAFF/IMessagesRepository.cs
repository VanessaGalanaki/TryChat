using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryChat.Models.POCOS;

namespace TryChat.Models.Repositories.MessagesSTAFF
{
    public interface IMessagesRepository
    {
        Task AddNewMessage(Message newmessage); //Works
        Task<List<Message>> GetMessagesBetween(string userId,string receiverId); //Works
        List<string> MyChatBuddies(string userId);//Works
        Task<IEnumerable<ApplicationUser>> GetAllLocals();//Works

        //Task<Message> FindMessage(string receiverID); // to be done
        //Task DeteteConversation(string receiverID); // to be done
        //void EditMessage(); //to be done
        //bool UnreadMessages();//to be done
        //++
    }
}
