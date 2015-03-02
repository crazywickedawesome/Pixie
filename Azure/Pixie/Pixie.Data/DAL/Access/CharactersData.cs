using System;
using System.Collections.Generic;
using System.Linq;
using Pixie.Data.Entities;

namespace Pixie.Data.DAL.Access
{
    public static class CharactersData
    {
        public static List<Character> List()
        {
            List<Character> result;

            using (var ctx = new PixieContext())
            {
                result = (from c in ctx.Characters select c).ToList();
            }

            return result;
        }

        public static List<Character> List(string username)
        {
            List<Character> result;

            using (var ctx = new PixieContext())
            {
                result = (from c in ctx.Characters where c.User.Username == username select c).ToList();
            }

            return result;
        }

        public static bool New(Character item, out Exception exception)
        {
            bool result;
            exception = null;

            try
            {
                using (var ctx = new PixieContext())
                {
                    ctx.Characters.Add(item);
                    ctx.SaveChanges();
                }

                result = true;
            }
            catch (Exception e)
            {
                exception = e;
                result = false;
            }

            return result;
        }
    }
}
