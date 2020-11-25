using System;
using System.Collections.Generic;
using System.Text;

namespace DBLibrary.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Pasword { get; set; }
        public bool Admin { get; set; }
        public string saftyAnser { get; set; }
        public bool canMakePosts { get; set; }
    }
}
