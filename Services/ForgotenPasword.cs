using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DBlibrary.BuisnessLogic.ProcesorUser;

namespace Services
{
    public static class ForgotenPasword
    {
        public static User getUserByParams(string uName, string saftyWord)
        {
            User user = new User();
            if (uName == null && saftyWord == null)
            {

                return user;
            }
            else
            {
                user = ForgottenPas(uName, saftyWord);
                return user;
            }
        }
    }
}
