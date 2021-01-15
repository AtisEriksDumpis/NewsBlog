using DBLibrary.DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBlibrary.BuisnessLogic
{
    public class ProcesorComents
    {
        public static int AddComments(string tekst, int postID, int authorId)
        {
            Comments comment = new Comments
            {
                Comment = tekst,
                PostID = postID,
                AuthID = authorId


            };
            string sql = @"insert into 
                                dbo.Comments 
                                (
                                    Comment, 
                                    PostID, 
                                    AuthID,
                                    date
                                ) 
                            VALUES 
                                (
                                    @Comment, 
                                    @PostID, 
                                    @AuthID,
                                    GETDATE()
                                );";
            int c = SqlDataAccess.SaveData(sql, comment);
            return c;
        }
        public static void DeleteComment(int ID)
        {
            Comments comment = new Comments
            {
                Id = ID
                
                
            };

            string sql = @"DELETE FROM dbo.Comments WHERE Id = @Id;";
            int c = SqlDataAccess.SaveData(sql, comment);
        }
        public static List<Comments> LoadComment(int PostID)
        {
            Comments post = new Comments()
            {
                PostID = PostID
            };
            string sql = @"select 
                            c.Coment, 
                            c.Id, 
                            c.AuthID,
                            c.PostID,
                            c.Reportd,
                            c.Hiden,
                            u.Username as Author 
                        from 
                            Coments c, 
                            Users u 
                        where c.AuthID like u.Id
                           And c.PostID like @PostID;";
            var pagaidu = SqlDataAccess.returnlist<Comments>(sql, post);

            return pagaidu;
        }
        public static List<Comments> LoadReportd()
        {
            string sql = @"select 
                            c.Coment, 
                            c.Id, 
                            c.AuthID,
                            c.PostID,
                            c.Reportd,
                            c.Hiden,
                            u.Username as Author 
                        from 
                            Coments c, 
                            Users u 
                        where c.AuthID like u.Id 
                        AND c.Reportd like 1;";
            var pagaidu = SqlDataAccess.LoadData<Comments>(sql);

            return pagaidu;
        }
        public static void ReportComment(int ID,string mesage)
        {
            Comments comment = new Comments
            {
                Id = ID


            };

            string sql = @"UPDATE dbo.Coments SET Reportd = 1 WHERE Id like @Id;;";
            int c = SqlDataAccess.SaveData(sql, comment);
        }
        public static void HideComment(int ID)
        {
            Comments comment = new Comments
            {
                Id = ID


            };

            string sql = @"UPDATE dbo.Coments SET Hiden = 1 WHERE Id like @Id;";
            int c = SqlDataAccess.SaveData(sql, comment);
        }
        public static void RestoreComment(int ID)
        {
            Comments comment = new Comments
            {
                Id = ID


            };

            string sql = @"UPDATE dbo.Coments SET Hiden = 0, Reportd = 0 WHERE Id like @Id;";
            int c = SqlDataAccess.SaveData(sql, comment);
        }

    }
}
