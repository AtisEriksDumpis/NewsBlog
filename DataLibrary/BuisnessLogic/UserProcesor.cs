using DBLibrary.DataAccess;
using DBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBLibrary.BuisnessLogic
{
   public class UserProcesor
    {
        public static int RegisterUser(string userName, string pasword)
        {
            UserModel user = new UserModel
            {
                UserName = userName,
                Password = pasword,
                AdminPrivaleges = 0
            };

            string sql = @"insert into dbo.Users (Username, Pasword) VALUES (@UserName, @Password);";
            int c = SqlDataAccess.SaveData(sql, user);
            return c;
        }
        public static List<UserModel> LoadUsers()
        {
            string sql = @"select Username, Pasword, Admin from dbo.Users;";

            return SqlDataAccess.LoadData<UserModel>(sql);
        }
    }
}
