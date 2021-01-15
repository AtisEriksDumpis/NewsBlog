using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZendeskApi_v2.Requests.HelpCenter;

namespace Models.ViewSpecificModels
{
    public class HomeModel
    {
        public List<Post> Latest5 { get; set; }
        public List<Post> Comented3 { get; set; }
        public List<Post> TopLiked3 { get; set; }
    }
}