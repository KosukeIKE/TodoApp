namespace TodoApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TodoApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoApp.Models.TodoesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;//列の編集を許可するためのもの
            ContextKey = "TodoApp.Models.TodoesContext";
        }

        //変更内容を自動的で実行されるもの
        protected override void Seed(TodoApp.Models.TodoesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            User admin = new User()
            {
                Id = 1,
                UserName = "admin",
                Password = "password",
                Roles = new List<Role>()

            };

            User kimura = new User()
            {
                Id= 2,
                UserName = "kimura",
                Password = "password",
                Roles = new List<Role>()
            };

            

            Role administrators = new Role()
            {
                Id = 1,
                RoleName = "Administrators",
                Users = new List<User>()

            };

            Role users = new Role()
            {
                Id = 2,
                RoleName = "Users",
                Users = new List<User>()

            };

            var membershipProvider = new CustomMembershipProvider();
            admin.Password = membershipProvider.GeneratePasswordHash(admin.UserName, admin.Password);
            kimura.Password = membershipProvider.GeneratePasswordHash(kimura.UserName, kimura.Password);

            admin.Roles.Add(administrators);
            administrators.Users.Add(admin);
            kimura.Roles.Add(administrators);
            administrators.Users.Add(kimura);

            context.Users.AddOrUpdate(user => user.Id, new User[] { admin});
            context.Roles.AddOrUpdate(role => role.Id, new Role[] { administrators, users });
        }
    }
}
