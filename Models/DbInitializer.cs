using System;
using System.Linq;

namespace tenorchem.Models
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context){
            
            context.Database.EnsureCreated();

            if (context.Users.Any()){
                return;
            }

            var users = new User[]
            {
                new User {userName="天健管理员",passWord="tenorchem",isAdmin=true}
            };
            
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
        }
    }
}