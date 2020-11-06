using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITForumV3.Models
{
    public class Thread
    {
        [Column("ThreadId")]
        public long Id { get; set; }
        public string ThreadName { get; set; }
        public DateTime ThreadCreation { get; set; }
        public string OP { get; set; }




    }
}
