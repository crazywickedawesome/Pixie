using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Pixie.Data.DAL;

namespace Pixie.Data.Utils
{
    public static class DataUtils
    {
        public static void SaveUsers()
        {
            var ctx = new PixieContext();
            if (!ctx.HasPendingChanges()) return;
            var usernames = new FiledUsers{Usernames = new List<string>()};

            foreach (var item in ctx.Users)
                usernames.Usernames.Add(item.Username);

            using (var stream = File.Open(ConfigurationManager.AppSettings["appBasePath"] + "App_Data/users.bin", FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(stream, usernames);
            }
        }

        public static List<string> LoadUsers()
        {
            var result = new FiledUsers();

            using (
                var stream = File.Open(ConfigurationManager.AppSettings["appBasePath"] + "App_Data/users.bin",
                    FileMode.Open))
            {
                var bf = new BinaryFormatter();
                result = (FiledUsers)bf.Deserialize(stream);
            }

            return result.Usernames;
        }
    }

    public static class DbContextExtensions
    {
        public static Boolean HasPendingChanges(this DbContext context)
        {
            return context.ChangeTracker.Entries()
                          .Any(e => e.State == EntityState.Added
                                 || e.State == EntityState.Deleted
                                 || e.State == EntityState.Modified);
        }
    }

    [Serializable]
    class FiledUsers
    {
        public List<string> Usernames { get; set; }
    }
}