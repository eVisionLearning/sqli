using SQLI.Data;

namespace SQLI.Models
{
    public static class SeedData
    {
        public static void Initialize(SQLIContext context)
        {
            context.Users.AddRange(
                new User { LoginId = "nasir", Password = "123456", Remarks = "User 2" },
                new User { LoginId = "abdul", Password = "09876", Remarks = "User 1" },
                new User { LoginId = "majeed", Password = "abcdef", Remarks = "User 2" },
                new User { LoginId = "hasnain", Password = "a1b2c3", Remarks = "User 2" },
                new User { LoginId = "saad", Password = "qwert", Remarks = "User 2" }
            );

            context.Admins.AddRange(
                new Admin { LoginId = "admin1", Password = "1@2@3", Roles = "Admin" },
                new Admin { LoginId = "super-guru", Password = "p!q@r", Roles = "Moderator" },
                new Admin { LoginId = "daniyal", Password = "!!1234!!", Roles = "Admin, Moderator" },
                new Admin { LoginId = "zunnorain", Password = "*(U*(U*(Y(", Roles = "Admin, SuperAdmin" }
            );

            context.SaveChanges();
        }
    }

}
