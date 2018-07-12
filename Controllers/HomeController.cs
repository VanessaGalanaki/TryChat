using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TryChat.Data;
using TryChat.Models;
using TryChat.Models.POCOS;
using Microsoft.EntityFrameworkCore;
using TryChat.Models.MessagesRepository;
using TryChat.Models.Repositories.MessagesSTAFF;

namespace TryChat.Controllers
{
    public class HomeController : Controller
    {


        //private readonly ApplicationDbContext _context;

        //public HomeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult Chat()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Chat(Message newmessage)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (newmessage != null)
        //        {

        //            _context.Messages.Add(new Message()
        //            {
        //                SenderID = newmessage.SenderID,
        //                ReceiverID = newmessage.ReceiverID,
        //                Body = newmessage.Body,
        //                Read = newmessage.Read
        //            });
        //            _context.SaveChanges();
        //            ModelState.Clear();
        //        }

        //    }

        //    return View(new Message() { ReceiverID = newmessage.ReceiverID });
        //}




        public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
    }
}
