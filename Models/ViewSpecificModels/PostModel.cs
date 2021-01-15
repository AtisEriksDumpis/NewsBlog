using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewSpecificModels
{
    public class PostModel
    {
        public List<Comments> comentList { get; set; }
        public Post curentPost { get; set; }
        public int CurentUseerId { get; set; }
        public bool postAction { get; set; }
        public bool comentAction { get; set; }
    }
}
