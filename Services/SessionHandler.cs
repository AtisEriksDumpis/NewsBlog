using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static DBlibrary.BuisnessLogic.ProcesorUser;


namespace Services
{
    public class SessionHandler
    {
        public void makeSesionDataFields()
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["ID"] == null)
            {
                resetSesionData();
            }
        }
        public void setupSessionData(int ID)
        {
            HttpContext context = HttpContext.Current;
            try
            {
                User curent = RetreveUser(ID);
                context.Session["ID"] = curent.ID;
                context.Session["Name"] = curent.Username;
                context.Session["Coment"] = curent.allowComent;
                context.Session["Post"] = curent.allowPost;
            }
            catch
            {
                resetSesionData();
            }
        }
        public void resetSesionData()
        {
            HttpContext context = HttpContext.Current;
            context.Session["ID"] = 0;
            context.Session["Name"] = "";
            context.Session["Coment"] = false;
            context.Session["Post"] = false;
        }

    }
}
