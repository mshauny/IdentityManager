﻿/*
 * Copyright (c) Dominick Baier, Brock Allen.  All rights reserved.
 * see license
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Thinktecture.IdentityManager.Host
{
    public class Users
    {
        public static ICollection<InMemoryUser> Get(int random = 0)
        {
            var users = new HashSet<InMemoryUser>
            {
                new InMemoryUser{
                    Subject = Guid.Parse("081d965f-1f84-4360-90e4-8f6deac7b9bc").ToString(),
                    Username = "alice",
                    Password = "alice",
                    Email = "alice@email.com",
                    Mobile = "123",
                    Claims = new HashSet<Claim>{
                        new Claim("name", "Alice Smith"),
                        new Claim("department", "sales"),
                        new Claim("role", "employee"),
                        new Claim("role", "admin"),
                        new Claim("role", "manager"),
                    }
                },
                new InMemoryUser{
                    Subject = Guid.Parse("5f292677-d3d2-4bf9-a6f8-e982d08e1306").ToString(),
                    Username = "bob",
                    Password = "bob",
                    Email = "bob@email.com",
                    Claims = new HashSet<Claim>{
                        new Claim("name", "Bob Smith"),
                        new Claim("department", "IT"),
                        new Claim("role", "employee"),
                        new Claim("role", "developer"),
                    }
                },
            };

            for (var i = 0; i < random; i++)
            {
                var user = new InMemoryUser
                {
                    Username = GenName().ToLower()
                };
                user.Claims.Add(new Claim("name", GenName() + " " + GenName()));
                users.Add(user);
            }

            return users;
        }

        private static string GenName()
        {
            var firstChar = (char)((rnd.Next(26)) + 65);
            var username = firstChar.ToString();
            for (var j = 0; j < 6; j++)
            {
                username += Char.ToLower((char)(rnd.Next(26) + 65));
            }
            return username;
        }

        static Random rnd = new Random();
    }
}