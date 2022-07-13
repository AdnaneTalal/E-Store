using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using E_Store.Models;

namespace E_Store.Extentions
{


    public static class IdentityExtensions 
    {

        public static string GetImage(this IIdentity identity)
        {
            var user = ((ClaimsIdentity)identity).FindFirst("Image");
            // Test for null to avoid issues during local testing
            return (user != null) ? user.Value : string.Empty;
        }
    }
}