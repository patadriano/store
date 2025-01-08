using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store
{
    public class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }    
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class Posts
    {
        public int PostID { get; set; }  
        public string PostTitle { get; set; }
        public string PostDesc { get; set; }
        //public byte[] PostImage { get; set; }
        public string PostImage { get; set; }
        public User UserID { get; set; }
    }
    public class ProfileUser
    {
        public int ProfileID { get; set; }
        public string ProfileName { get; set; }
        public string ProfileImage { get; set; }
        public int UserID { get; set; }

    }
}