using System;
using System.Collections.Generic;
using System.Text;

namespace DBLibrary.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AdminPrivaleges { get; set; }
    }
}
