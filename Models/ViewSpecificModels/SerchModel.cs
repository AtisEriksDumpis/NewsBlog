using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewSpecificModels
{
    public class SerchModel
    {
        public List<Post> posts { get; set; }
        public int CurentUseerId { get; set; }
        public bool postAction { get; set; }
        public bool comentAction { get; set; }
        public string userName { get; set; }
    }
}
