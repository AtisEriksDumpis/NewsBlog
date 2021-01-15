using Models.ViewSpecificModels;
using static DBlibrary.BuisnessLogic.ProcesorPost;
using static DBlibrary.BuisnessLogic.ProcesorComents;
using Models;
using System.Web;

namespace Services
{
    public class PostService
    {

        public static PostModel prepPostModal(int PostID)
        {

            PostModel postModel = new PostModel()
            {
                comentList = LoadComment(PostID),
                curentPost = LoadPost(PostID),
                CurentUseerId = (int)HttpContext.Current.Session["ID"],
                comentAction = (bool)HttpContext.Current.Session["Post"]
            };
            return postModel;
        }
        public static PostsModel prepPostsModal()
        {
            PostsModel postsModel = new PostsModel()
            {
                posts = LoadPosts(),
                CurentUseerId = (int)HttpContext.Current.Session["ID"],
                postAction = (bool)HttpContext.Current.Session["Post"],
                userName = (string)HttpContext.Current.Session["Name"]
            };
            return postsModel;
        }
    }
}
