using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using ArtyGeek.Common.Enums;
using ArtyGeek.Operations.Contexts;

namespace ArtyGeek.Api.Provider
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        public int CurrentUserId
        {
            get
            {
                if (HttpContext.Current.User == null)
                    return -1;
                var user = (ClaimsIdentity)HttpContext.Current.User.Identity;
                var id = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                return int.Parse(id);
            }
        }

        public string CurrentUserEmail
        {
            get
            {
                if (HttpContext.Current.User == null)
                    return string.Empty;
                var user = (ClaimsIdentity)HttpContext.Current.User.Identity;
                var email = user.FindFirst(ClaimTypes.Email).Value;
                return email;
            }
        }

        public Role CurrentUserRole
        {
            get
            {
                if (HttpContext.Current.User == null)
                    return Role.User;
                var user = (ClaimsIdentity)HttpContext.Current.User.Identity;
                var role = (Role)Enum.Parse(typeof(Role), user.FindFirst(ClaimTypes.Role).Value, true);
                return role;
            }
        }
    }
}