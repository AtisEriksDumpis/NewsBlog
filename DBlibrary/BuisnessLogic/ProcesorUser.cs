using DBLibrary.DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBlibrary.BuisnessLogic
{
   public class ProcesorUser
    {
        public static int RegisterUser(string userName, string pasword, string saftyAnser,string paswordHash)
        {
            User user = new User
            {
                Username = userName,
                Pasword = pasword,
                Admin = false,
                saftyAnswer = saftyAnser,
                PaswordHash = paswordHash
            };

            string sql = @"insert into dbo.Users (
                                Username, 
                                Pasword, 
                                saftyAnswer,
                                PaswordHash
                            ) VALUES (
                                @Username, 
                                @Pasword, 
                                @saftyAnswer,
                                @PaswordHash
                            );";
            int c = SqlDataAccess.SaveData(sql, user);
            return c;
        }
        public static void DelUser(int ID)
        {
            User user = new User
            {
                ID = ID
            };

            string sql = @"DELETE FROM dbo.Users WHERE ID like @ID;";
            int c = SqlDataAccess.SaveData(sql, user);
        }
        public static void UpdatePasword(int ID,string pasHash, string userName)
        {
            User user = new User
            {
                ID = ID,
                PaswordHash = pasHash,
                Username = userName
            };

            string sql = @"UPDATE dbo.Users SET Pasword = @Username, PaswordHash = @PaswordHash WHERE Id like @ID;";
            int c = SqlDataAccess.SaveData(sql, user);
        }
        public static void UpdateProfile(int ID,string userName, string safty)
        {
            User user = new User
            {
                ID = ID,
                saftyAnswer = safty,
                Username = userName
            };

            string sql = @"UPDATE dbo.Users SET Username = @Username,saftyAnswer = @saftyAnswer  WHERE Id like @ID;";
            int c = SqlDataAccess.SaveData(sql, user);
        }
        public static void AlowPosting(int IDs, bool canMakePosts)
        {
            User user = new User
            {
                ID = IDs,
                allowPost = canMakePosts ? false : true

            };

            string sql = @"UPDATE dbo.Users SET allowPost = @allowPost WHERE Id like @ID;";
            int c = SqlDataAccess.SaveData(sql, user);
        }
        public static void AlowComenting(int IDs, bool canMakeComents)
        {
            User user = new User
            {
                ID = IDs,
                allowComent = canMakeComents ? false : true

            };

            string sql = @"UPDATE dbo.Users SET allowComent = @allowComent WHERE Id like @ID;";
            int c = SqlDataAccess.SaveData(sql, user);
        }
        public static List<User> LoadUsers()
        {
            string sql = @"select * from dbo.Users;";

            return SqlDataAccess.LoadData<User>(sql);
        }
        public static List<User> UserLogin(string userName, string pasword)
        {
            string sql = @"Select u.ID , u.PaswordHash from Users u where u.Username like @Username;";
            User user = new User
            {
                Username = userName
            };
            return SqlDataAccess.returnlist<User>(sql, user);
        }

        public static User RetreveUser(int ID)
        {
            string sql = @"Select * from Users u where u.ID like @ID;";
            User user = new User
            {
                ID = ID
            };
            var newbe = SqlDataAccess.getdata<User>(sql, user);
            return newbe[0];
        }
        public static User ForgottenPas(string userName, string saftyAnswer )
        {
            string sql = @"Select * from Users u where u.Username like @Username AND u.saftyAnswer like @saftyAnswer;";
            User user = new User
            {
                Username = userName,
                saftyAnswer = saftyAnswer,
                
                Admin = false
            };
            var newbe = SqlDataAccess.getdata<User>(sql, user);
            return newbe[0];
        }

        public static void ChangePasword(int ID, string pasword)
        {
            User user = new User
            {
                ID = ID,
                Pasword = pasword

            };

            string sql = @"UPDATE dbo.Users SET Pasword = @Pasword WHERE Id like @ID;";
            int c = SqlDataAccess.SaveData(sql, user);
        }

    }
}
