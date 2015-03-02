using System.Data.Entity;
using Pixie.Data.Entities;

namespace Pixie.Data.DAL
{
    public class PixieContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public PixieContext()
            : base("Server=.;Database=PixieDB;Trusted_Connection=Yes;")
        {
            
        }
    }
}
