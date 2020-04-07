using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataModels;
using LinqToDB;
using LinqToDB.Data;
using TaskSite.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace TaskSite.Services
{
    public class UserService
    {
        private MainDb _db;
        public UserService(MainDb db)
        {
            _db = db;
        }
        public User GetUserByLogin(string username)
        {
            var q = from u in _db.Users
                    where u.Login == username || u.Email == username
                    select u;
            return q.FirstOrDefault();
        }

        public void EditUserInfo(UserModel user, string login)
        {
            _db.Users.Where(p => p.Login == login)
            .Set(p => p.Credentials, user.Credentials)
            .Set(p => p.Age, user.Age)
            .Set(p => p.Favfood, user.FavFood)
            .Set(p => p.Pet, user.Pet)
            .Update();
        }

        public UserModel ConvertDBToModel(User user)
        {
            UserModel userModel = new UserModel
            {
                Age = user.Age,
                FavFood = user.Favfood,
                Credentials = user.Credentials,
                Pet = user.Pet
            };
            return userModel;
        }
    }
}
