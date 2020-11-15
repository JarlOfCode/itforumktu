using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITForumV3.Models
{
    public class Post
    {
        [Column("postId")]
        public long Id { get; set; }
        [Column("text")]
        public string Text { get; set; }
        [Column("creationDate")]
        public DateTime PostDate { get; set; }
        [Column("editDate")]
        public DateTime? editDate { get; set; }
        [Column("fk_thread")]
        public int fk_thread { get; set; }
    }
}
