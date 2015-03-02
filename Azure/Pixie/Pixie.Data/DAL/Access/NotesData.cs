using System.Collections.Generic;
using System.Linq;
using Pixie.Data.Entities;

namespace Pixie.Data.DAL.Access
{
    public static class NotesData
    {
        public static List<Note> List(string username)
        {
            var result = new List<Note>();

            using (var ctx = new PixieContext())
            {
                var user = (from u in ctx.Users where u.Username == username select u).FirstOrDefault();
                if (user != null)
                    result = user.Notes.ToList();
            }

            return result;
        }
    }
}
