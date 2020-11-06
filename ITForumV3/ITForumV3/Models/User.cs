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
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string AccPriveleges { get; set; }
        public int PostCount { get; set; }

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
