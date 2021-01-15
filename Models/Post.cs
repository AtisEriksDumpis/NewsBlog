using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public short Rating { get; set; }
        public string Author { get; set; }
        public int AuthID { get; set; }

    }
}