using System;
using System.Linq;
using Pixie.Data.Entities;

namespace Pixie.Data.DAL.Access
{
    public static class UsersData
    {
        public static bool New(User user, out Exception exception)
        {
            bool result;
            exception = null;
            
            try
            {
                using (var ctx = new PixieContext())
                {
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                }

                result = true;
            }
            catch (Exception e)
            {
                result = false;
                exception = e;
            }

            return result;
        }

        public static User Get(string username)
        {
            User user;

            using (var ctx = new PixieContext())
            {
                user = (from u in ctx.Users where u.Username == username select u).FirstOrDefault();
            }

            return user;
        }
    }
}
