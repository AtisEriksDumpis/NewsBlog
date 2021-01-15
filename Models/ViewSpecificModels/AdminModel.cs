using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewSpecificModels
{
    public class AdminModel
    {
        public List<Comments> reportedComments { get; set; }
        public List<User> Users { get; set; }
    }
}
