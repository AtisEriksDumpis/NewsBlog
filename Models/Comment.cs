using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int PostID { get; set; }
        public int AuthID { get; set; }
        public string Author { get; set; }
        public bool Reported { get; set; }
        public bool Hiden { get; set; }
    }
}