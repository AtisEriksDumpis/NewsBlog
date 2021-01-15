using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static DBlibrary.BuisnessLogic.ProcesorUser;

namespace Services
{
    public class RegiserHandler
    {
        public void registeNewUser(User model)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var hashedPasSalt = new Rfc2898DeriveBytes(model.Pasword, salt, 100);
            byte[] hash = hashedPasSalt.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPaswordHash = Convert.ToBase64String(hashBytes);

            var recordsCrieited = RegisterUser(model.Username, model.Pasword, model.saftyAnswer, savedPaswordHash);
            
        }
    }
}
