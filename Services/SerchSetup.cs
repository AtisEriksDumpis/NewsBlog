using Models.ViewSpecificModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DBlibrary.BuisnessLogic.ProcesorPost;
using static DBlibrary.BuisnessLogic.ProcesorLikes;
using static DBlibrary.BuisnessLogic.ProcesorComents;
using Models;
using System.Web;

namespace Services
{
    public class SerchSetup
    {
        public static SerchModel setupSerchModal(string serchText)
        {
            SerchModel serchModel = new SerchModel()
            {
                posts = serchResults("%" + serchText + "%"),
                postAction = (bool)HttpContext.Current.Session["Post"],
                userName = (string)HttpContext.Current.Session["Name"],
                CurentUseerId = (int)HttpContext.Current.Session["ID"]
        };
            foreach (var post in serchModel.posts)
            {
                post.Rating = LoadLikes(post.ID);
            }
            return serchModel;
        }
    }
}
