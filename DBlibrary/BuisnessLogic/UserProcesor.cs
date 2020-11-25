using DBLibrary.DataAccess;
using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBLibrary.BuisnessLogic
{
   public class UserProcesor
    {
        public static int RegisterUser(string userName, string pasword, string saftyAnser)
        {
            UserModel user = new UserModel
            {
                Username = userName,
                Pasword = pasword,
                Admin = false,
                saftyAnser = saftyAnser
            };

            string sql = @"insert into dbo.Users (Username, Pasword, saftyAnser) VALUES (@Username, @Pasword, @saftyAnser);";
            int c = SqlDataAccess.SaveData(sql, user);
            return c;
        }
        public static int AddPost(string title, string text, int authorId)
        {
            PostModel post = new PostModel
            {
                Title = title,
                Text = text,
                authorID = authorId,
                upWoute = 0,
                downWoute = 0

            };

            string sql = @"insert into dbo.Posts (Title, Text, AuthorID, upWoute, downWoute) VALUES (@Title, @Text, @authorID, @upWoute, @downWoute);";
            int c = SqlDataAccess.SaveData(sql, post);
            return c;
        }
        public static void DeleteUser(int ID)
        {
            UserModel user = new UserModel
            {
                ID = ID
            };

            string sql = @"DELETE FROM dbo.Users WHERE Id like @ID;";
            int c = SqlDataAccess.SaveData(sql, user);
        }
        public static void UpdatePasword(int ID,string pasold, string pasnew)
        {
            UserModel user = new UserModel
            {
                ID = ID,
                Pasword = pasold,
                Username = pasnew
            };

            string sql = @"UPDATE dbo.Users SET Pasword = @Username WHERE Id like @ID;";
            int c = SqlDataAccess.SaveData(sql, user);
        }
        public static void AlowPosting(int ID, bool canMakePosts)
        {
            UserModel user = new UserModel
            {
                ID = ID,
                canMakePosts = canMakePosts ? false : true

            };

            string sql = @"UPDATE dbo.Users SET canMakePosts = @canMakePosts WHERE Id like @ID;";
            int c = SqlDataAccess.SaveData(sql, user);
        }
        public static List<UserModel> LoadUsers()
        {
            string sql = @"select * from dbo.Users;";

            return SqlDataAccess.LoadData<UserModel>(sql);
        }
        public static UserModel UserLogin(string userName, string pasword)
        {
            string sql = @"Select * from Users u where u.Username like @Username AND u.Pasword like @Pasword;";
            UserModel user = new UserModel
            {
                Username = userName,
                Pasword = pasword,
                Admin = false
            };
           var newbe = SqlDataAccess.LodeUser<UserModel>(sql, user);
            return newbe[0];//newbe;//SqlDataAccess.LodeUser<UserModel>(sql, user);
        }

        public static List<PostModel> LoadPosts()
        {
            string sql = @"select p.Title, p.Text, p.upWoute,p.downWoute as author from Posts p;";

            return SqlDataAccess.LoadData<PostModel>(sql);
        }
    }
}
