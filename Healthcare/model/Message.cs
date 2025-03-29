using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Message
    {
        public int MessageID { get; set; }
        public string MessageName { get; set; }

        public int SentToId { get; set; }

        [ForeignKey("SentToId")]
        public User SentTo { get; set; }

        public int SentFromId { get; set; }
        [ForeignKey("SentFromId")]
        public User SentFrom { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
