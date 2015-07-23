namespace Task_2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Task_2.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<Task_2.DAL.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Task_2.DAL.DataContext context)
        {
            Role role1 = new Role { RoleName = "Admin" };
            Role role2 = new Role { RoleName = "User" };

            User user1 = new User { Username = "admin", Email = "admin@ymail.com", FirstName = "Admin", Password = "123456", IsActive = true, CreateDate = DateTime.UtcNow, Roles = new List<Role>() };

            User user2 = new User { Username = "user1", Email = "user1@ymail.com", FirstName = "User1", Password = "123456", IsActive = true, CreateDate = DateTime.UtcNow, Roles = new List<Role>() };

            user1.Roles.Add(role1);
            user2.Roles.Add(role2);

            context.Users.Add(user1);
            context.Users.Add(user2);

        }
    }
}
