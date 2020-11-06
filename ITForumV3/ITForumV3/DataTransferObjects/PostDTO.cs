using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITForumV3.DataTransferObjects
{
    public class PostDTO
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime PostDate { get; set; }
        public bool IsEdited { get; set; }
        //public string BelongToThread { get; set; }
    }
}
