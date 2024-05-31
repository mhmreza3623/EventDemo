﻿using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Identity.APIs.Configs
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1144",
                    Username = "mukesh",
                    Password = "mukesh",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Mukesh Murugan"),
                        new Claim(JwtClaimTypes.GivenName, "Mukesh"),
                        new Claim(JwtClaimTypes.FamilyName, "Murugan"),
                        new Claim(JwtClaimTypes.WebSite, "http://codewithmukesh.com"),
                    }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("monitoringApiScope"),
                new ApiScope("paymentApiscope"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("monitoringApi")
                {
                    Scopes = new List<string>{ "monitoringApiScope"},
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                },
                 new ApiResource("paymentApi")
                {
                    Scopes = new List<string>{ "paymentApiscope" },
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "paymentApiscope" }
                },
            };
    }
}