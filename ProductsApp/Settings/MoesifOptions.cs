using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Microsoft.Owin;
using Moesif.Api.Models;

namespace Moesif.WebApi.SelfHost.Example.Settings
{
    public class MoesifOptions
    {
        public static Func<IOwinRequest, IOwinResponse, string> IdentifyUser = (IOwinRequest req, IOwinResponse res) => {
            // Implement your custom logic to return user id
            return req?.Context?.Authentication?.User?.Identity?.Name;
        };

        public static Func<IOwinRequest, IOwinResponse, string> IdentifyCompany = (IOwinRequest req, IOwinResponse res) => {
            return req.Headers["X-Organization-Id"];
        };

        public static Func<IOwinRequest, IOwinResponse, string> GetSessionToken = (IOwinRequest req, IOwinResponse res) => {
            return req.Headers["Authorization"];
        };

        public static Func<IOwinRequest, IOwinResponse, Dictionary<string, object>> GetMetadata = (IOwinRequest req, IOwinResponse res) => {
            Dictionary<string, object> metadata = new Dictionary<string, object>
            {
                {"string_field", "value_1"},
                {"number_field", 0},
                {"object_field", new Dictionary<string, string> {
                    {"field_a", "value_a"},
                    {"field_b", "value_b"}
                    }
                }
            };
            return metadata;
        };

        public static Func<HttpRequestMessage, HttpResponseMessage, Dictionary<string, object>> GetMetadataOutgoing = (HttpRequestMessage req, HttpResponseMessage res) => {
            Dictionary<string, object> metadata = new Dictionary<string, object>
            {
                {"string_field", "value_1"},
                {"number_field", 0},
                {"object_field", new Dictionary<string, string> {
                    {"field_a", "value_a"},
                    {"field_b", "value_b"}
                    }
                }
            };
            return metadata;
        };

        static public Dictionary<string, object> moesifOptions = new Dictionary<string, object>
        {
            {"ApplicationId", "Your Moesif Application Id"},
            {"LocalDebug", true},
            {"LogBody", true},
            {"LogBodyOutgoing", true},
            {"ApiVersion", "1.1.0"},
            {"IdentifyUser", IdentifyUser},
            {"IdentifyCompany", IdentifyCompany},
            {"GetSessionToken", GetSessionToken},
            {"GetMetadata", GetMetadata},
            {"GetMetadataOutgoing", GetMetadataOutgoing},
            {"EnableBatching", false},
            {"BatchSize", 25}
        };
    }
}