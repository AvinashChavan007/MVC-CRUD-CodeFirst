using System.Data.Entity.Migrations;
using System.Linq;
using Core.Domains;
using Core.Helpers.Security;

namespace Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppContext context)
        {
            var users = context.Set<Account>();

            if (users.Any())
                return;

            // else seed your data here
            var salt = "";

            var user = new Account()
            {
                Username = "admin",
                PasswordHash = SecurityHelper.HashPassword("password", ref salt),
                PasswordSalt = salt
            };
            users.AddOrUpdate(user);
            context.SaveChanges();
        }
    }
}
