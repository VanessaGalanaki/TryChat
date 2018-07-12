using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TryChat.Models.POCOS
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SenderID { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        public string ReceiverID { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
        [MaxLength(500)]
        public string Body { get; set; }
        public DateTime DateSent { get; set; }
        public bool Read { get; set; }
        public Message()
        {
           
        }


    }
}
