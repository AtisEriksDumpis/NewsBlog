using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public static class StaticUser
    {

        public static User fCurentUser { get; set; } = new User();
    }
}