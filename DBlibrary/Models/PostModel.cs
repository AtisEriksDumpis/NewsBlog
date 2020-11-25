using System;
using System.Collections.Generic;
using System.Text;

namespace DBLibrary.Models
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int upWoute { get; set; }
        public int downWoute { get; set; }
        public string author { get; set; }
        public int authorID { get; set; }
    }
}
