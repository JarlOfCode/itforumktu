using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITForumV3.DataTransferObjects
{
    public class ThreadDTo
    {
        public long Id { get; set; }
        public string ThreadName { get; set; }
        public DateTime ThreadCreation { get; set; }
    }
}
