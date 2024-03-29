﻿using Microsoft.AspNetCore.Authorization;

namespace SimpleAPI.Api.Attributes
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public AuthAttribute(params RoleTypes[] roles)
        {
            var rolesList = new List<RoleTypes>(roles).Select(x => x.ToString());

            var aloweRoles = "";
            foreach (var r in rolesList)
            {
                aloweRoles += r;
            }
            Roles = aloweRoles;
        }

        public enum RoleTypes
        {
            None = 0,
            User = 1
        }
    }
}
