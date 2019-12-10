﻿using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Capstone.Helpers
{
    public static class Extensions
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            if (httpContext.User == null) return string.Empty;

            return httpContext.User.Claims.Single(c => c.Type == "id").Value;
        }
    }
}
