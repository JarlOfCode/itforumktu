using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITForumV3.Models
{
    public class Post
    {
        [Column("PostId")]
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime PostDate { get; set; }
        public bool IsEdited { get; set; }
        public string BelongToThread { get; set; }
        public int fk_thread { get; set; }
    }
}
