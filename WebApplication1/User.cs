using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class User
    {      
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public bool isAdmin { get; set; }
    }
}