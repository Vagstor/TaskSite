using DataModels;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskSite.Services
{
    public class SiteService
    {
        private MainDb _db;

        public SiteService(MainDb db)
        {
            _db = db;
        }
        public void AddNewUser(string login, string password, string email)
        {
            User user = new User();
            user.Email = email;
            user.Id = Guid.NewGuid();
            user.Login = login;
            user.Password = password;
            _db.Insert(user);
        }

        public List<String> CheckLogin(string username, string password)
        {
            var users = new List<User>();
            users = _db.Users.ToList();
            foreach (var user in users)
            {
                if ((username == user.Login) && (password == user.Password))
                {
                    return new List<String> { user.Login, user.Password, Convert.ToString(user.Id) };
                }
                else
                    if ((username == user.Email) && (password == user.Password))
                {
                    return new List<String> { user.Login, user.Password, Convert.ToString(user.Id) };
                }
            }
            return null;
        }

        public User GetByLogin(string username)
        {
            var q = from u in _db.Users
                    where u.Login == username || u.Email == username
                    select u;
            return q.FirstOrDefault();
        }

        public bool CheckIfEmailVacant(string email)
        {
            var q = from u in _db.Users
                    where u.Email == email
                    select u;
            if (q.FirstOrDefault() == null)
            {
                return true;
            }
            else
                return false;
        }

        public void DeleteUserAccount(string login)
        {
            _db.Users.Where(p => p.Login == login)
            .Delete();
        }

        public bool CheckIfLoginVacant(string login)
        {
            var q = from u in _db.Users
                    where u.Login == login
                    select u;
            if (q.FirstOrDefault() == null)
            {
                return true;
            }
            else
                return false;
        }

    }
}
