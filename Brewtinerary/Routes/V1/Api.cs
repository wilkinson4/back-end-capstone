using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Routes.V1
{
    public static class Api
    {
        internal const string Root = "api";
        internal const string Version = "v1";
        internal const string Base = Root + "/" + Version;

        public static class User
        {
            public const string Login = Base + "/Auth/Login";
            public const string Register = Base + "/Auth/Register";
            public const string Refresh = Base + "/Auth/Refresh";
        }

        public static class Itineraries
        {
            public const string GetAll = Base + "/Itineraries";
            public const string Get = Base + "/Itineraries/{id}";
            public const string Delete = Base + "/Itineraries/{id}";
            public const string Put = Base + "/Itineraries/{id}";
            public const string Post = Base + "/Itineraries/Create";
        }

        public static class Breweries
        {
            public const string GetAll = Base + "/Breweries";
            public const string Get = Base + "/Breweries/{id}";
            public const string Post = Base + "/Breweries/Create/{itineraryId}";
        }
    }
}
