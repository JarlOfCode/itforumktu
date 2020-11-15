using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITForumV3.Models
{
    public class Thread
    {
        [Column("threadId")]
        public long Id { get; set; }
        [Column("threadName")]
        public string ThreadName { get; set; }
        [Column("creationDate")]
        public DateTime ThreadCreation { get; set; }
        //public string OP { get; set; }
    }
}
