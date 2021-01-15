using Models.ViewSpecificModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DBlibrary.BuisnessLogic.ProcesorUser;
using static DBlibrary.BuisnessLogic.ProcesorPost;
using static DBlibrary.BuisnessLogic.ProcesorLikes;
using static DBlibrary.BuisnessLogic.ProcesorComents;
using Models;

namespace Services
{
    public static class HomeHandler
    {
        public static HomeModel prepData() 
        {
            HomeModel homeModel = new HomeModel()
            {
                TopLiked3 = top3Liked(),
                Comented3 = latest3comented(),
                Latest5 = latest5Posts()
            };
            foreach (Post post in homeModel.TopLiked3)
            {
                post.Rating = LoadLikes(post.ID);
            }
            foreach (Post post in homeModel.Comented3)
            {
                post.Rating = LoadLikes(post.ID);
            }
            foreach (Post post in homeModel.Latest5)
            {
                post.Rating = LoadLikes(post.ID);
            }
            return homeModel;
        }
    }
}
