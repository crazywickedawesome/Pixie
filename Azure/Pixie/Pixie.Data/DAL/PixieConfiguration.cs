using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Pixie.Data.Entities;
using Pixie.Data.Utils;

namespace Pixie.Data.DAL
{
    public class PixieConfiguration : DbConfiguration
    {
        public PixieConfiguration()
        {
            SetDatabaseInitializer(new PixieDbInitializer());
            SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());
            SetDefaultConnectionFactory(new SqlConnectionFactory("Server=.;Database=PixieDB;User Id=IIS"));
        }
    }

    public class PixieDbInitializer : DropCreateDatabaseIfModelChanges<PixieContext>
    {
        protected override void Seed(PixieContext context)
        {
            var users = DataUtils.LoadUsers();

            context.Users.AddRange(users.Select(x => new User {Username = x}));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}