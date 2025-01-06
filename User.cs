﻿using System;
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
        public string PostID { get; set; }  
        public string PostTitle { get; set; }
        public string PostDesc { get; set; }
        public string PostImage { get; set; }
        public User UserID { get; set; }
    }
}