using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TryChat.Data;
using TryChat.Models;
using TryChat.Models.POCOS;
using TryChat.Models.Repositories.MessagesSTAFF;



namespace TryChat.Controllers
{
    public class ChatController : Controller
    {
        //private readonly ApplicationDbContext _context;

        //public ChatController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        public IMessagesRepository MessagesRepo { get; set; }
        private readonly UserManager<ApplicationUser> _manager;
        private readonly ApplicationDbContext _context;


        public ChatController(IMessagesRepository _repo, UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            MessagesRepo = _repo;
            _manager = manager;
            _context =context;

        }

        public IActionResult Index()
        {
            ViewData["LoggedUserId"] = _manager.GetUserId(User);
            return View();
        }

        //public async Task<IActionResult> GetUserMessages(string userId,string receiverId)
        //{
        //    var messages = await MessagesRepo.GetUserMessages(_manager.GetUserId(User), "b8cc306d-e1fb-41c8-b5bc-ed5e52026997");
        //    return View(messages);
        //}
        public IActionResult GetUserMessagesGrouped(string userId)
        {
            var ChatBuddies = MessagesRepo.MyChatBuddies(_manager.GetUserId(User));
            return View(ChatBuddies);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocals()
        {
            var LocalsList = await MessagesRepo.GetAllLocals();
            return View(LocalsList);
        }

        [HttpGet]
        public IActionResult AddNewMessage(string Id)
        {
            ViewData["ReceiverId"] = Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMessage(Message newmessage)
        {
            if (newmessage != null && newmessage.Body != "")
            {

                await MessagesRepo.AddNewMessage(new Message()
                {
                    SenderID = newmessage.SenderID,
                    ReceiverID = newmessage.ReceiverID,
                    Body = newmessage.Body,
                    Read = newmessage.Read,
                    DateSent = DateTime.Now
                });
                await _context.SaveChangesAsync();
                ModelState.Clear();
            }
            return View(new Message() { ReceiverID = newmessage.ReceiverID});
        }

        //public async Task<IActionResult> GetAllMessages()
        //{
        //    var messages = await MessagesRepo.GetAllMessages();

        //    foreach (var m in messages)
        //    {

        //    }

        //    return View(messages);

        //}
    }
}