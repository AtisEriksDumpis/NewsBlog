using DBLibrary.DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBlibrary.BuisnessLogic
{
    public class ProcesorPost
    {
        public static int AddPost(string title, string text, int authorId)
        {
            Post post = new Post
            {
                Title = title,
                Text = text,
                AuthID = authorId

            };

            string sql = @"insert into dbo.Posts (
                                Title, 
                                Text, 
                                AuthID,
                                date) 
                            VALUES (
                                @Title, 
                                @Text, 
                                @AuthID, 
                                GETDATE()
                            );";
            int c = SqlDataAccess.SaveData(sql, post);
            return c;
        }
        public static void DeletePost(int ID)
        {
            Post post = new Post
            {
                ID = ID
            };

            string sql = @"DELETE FROM dbo.Posts WHERE ID = @ID;";
            int c = SqlDataAccess.SaveData(sql, post);
        }
        public static List<Post> LoadPosts()
        {
            string sql = @"select * from Posts;";
            var pagaidu = SqlDataAccess.LoadData<Post>(sql);

            return pagaidu;
        }
        public static Post LoadPost(int PostID)
        {
            Post post = new Post
            {
                ID = PostID
            };
            string sql = @"select * from Posts where ID like @ID;";
            var pagaidu = SqlDataAccess.getdata<Post>(sql,post);

            return pagaidu[0];
        }
        public static List<Post> latest5Posts()
        {
            string sql = @"select TOP 5 p.* from Posts p ORDER BY p.date desc;";
            var pagaidu = SqlDataAccess.LoadData<Post>(sql);

            return pagaidu;
        }
        public static List<Post> top3Liked()
        {
            string sql = @"select top 3 
                                p.*  
                            from 
                                (select sum(v.VAL) as val, v.PID as postID from Voutes v  group by v.PID) a, 
                                Posts p 
                            where p.ID like a.postID Order by a.val desc;";
            var pagaidu = SqlDataAccess.LoadData<Post>(sql);

            return pagaidu;
        }
        public static List<Post> latest3comented()
        {

            string sql = @"Select TOP 3 p.* from Posts p, Coments c where p.ID like c.PostID  Order by c.date desc;";
            var pagaidu = SqlDataAccess.LoadData<Post>(sql);

            return pagaidu;
        }
        public static List<Post> serchResults(string serchText)
        {
            Post post = new Post
            {
                Text = serchText
            };
            string sql = @"select * from Posts p where p.Title like @Text or p.Text like @Text;";
            var pagaidu = SqlDataAccess.returnlist<Post>(sql, post);

            return pagaidu;
        }
    }
}
