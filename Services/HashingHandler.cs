using Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Web;
using static DBlibrary.BuisnessLogic.ProcesorUser;


namespace Services
{
    public class HashingHandler
    {
        public void login(string username, string pasword)
        {
            SessionHandler sessionHandler = new SessionHandler();
            int c = (int)HttpContext.Current.Session["ID"];
            List<User> posibleUsers = UserLogin(username, pasword);
            foreach (User user in posibleUsers)
            {

                string pasHash = user.PaswordHash;
                byte[] HashDB = Convert.FromBase64String(pasHash);
                byte[] salt = new byte[16];
                Array.Copy(HashDB, 0, salt, 0, 16);
                var hashedPasSalt = new Rfc2898DeriveBytes(pasword, salt, 100);
                byte[] hash = hashedPasSalt.GetBytes(20);
                bool loggedIn = true;
                for (int i = 0; i < 20; i++)
                {
                    if (HashDB[i + 16] != hash[i]) loggedIn = false;
                }


                if (loggedIn)
                {
                    sessionHandler.setupSessionData(user.ID);
                    break;
                }
            }
        }
        public void paswordChanger(string pasold, string pasnew)
        {
            User user = RetreveUser((int)HttpContext.Current.Session["ID"]);

            //checkPasword(usr,pasold);


            if (checkPasword(user, pasold))
            {
                string pasHash = user.PaswordHash;
                byte[] HashDB = Convert.FromBase64String(pasHash);
                byte[] salt = new byte[16];
                Array.Copy(HashDB, 0, salt, 0, 16);
                var hashedPasSalt = new Rfc2898DeriveBytes(pasold, salt, 100);
                byte[] hash = hashedPasSalt.GetBytes(20);
                bool isLoggedIn = true;
                for (int i = 0; i < 20; i++)
                {
                    if (HashDB[i + 16] != hash[i]) isLoggedIn = false;
                }
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                string savedPaswordHash = Convert.ToBase64String(hashBytes);
                UpdatePasword((int)HttpContext.Current.Session["ID"], savedPaswordHash, pasnew);
            }
        }

        public bool checkPasword(User user,string pasword)
        {
            string pasHash = user.PaswordHash;
            byte[] HashDB = Convert.FromBase64String(pasHash);
            byte[] salt = new byte[16];
            Array.Copy(HashDB, 0, salt, 0, 16);
            var hashedPasSalt = new Rfc2898DeriveBytes(pasword, salt, 100);
            byte[] hash = hashedPasSalt.GetBytes(20);
            bool isLoggedIn = true;
            for (int i = 0; i < 20; i++)
            {
                if (HashDB[i + 16] != hash[i]) isLoggedIn = false;
            }
            return isLoggedIn;
        }
    }
}
