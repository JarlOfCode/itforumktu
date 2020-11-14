using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITForumV3.Models
{
    public class User
    {
        [Column("UserId")]
        public long Id { get; set; }
        [Column("userName")]
        public string UserName { get; set; }
        [Column("passWord")]
        public string PassWord { get; set; }
        [Column("role")]
        public string Role { get; set; }
        [Column("postCount")]
        public int PostCount { get; set; }
        //[Column("image")]
        //public Image Image { get; }

        //public Image

        //public User(long id, string userName, string passWord, string accPriveleges)
        //{
        //    //Id = id;
        //    //UserName = userName;
        //    //PassWord = passWord;
        //    //AccPriveleges = accPriveleges;
        //    ////PostCount = postCount;
        //}
    }

}
