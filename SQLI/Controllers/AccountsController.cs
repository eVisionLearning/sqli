using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SQLI.Data;
using SQLI.Models;

namespace SQLI.Controllers
{
    public class AccountsController (SQLIContext context) : Controller
    {
        private SQLIContext _context = context;
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            using (var sqlConnection = _context.Database.GetDbConnection() as SqlConnection)
            {
                sqlConnection.Open();

                //var sql = "SELECT LoginId, Password FROM Users WHERE LoginId = @LoginId AND Password = @Password";
                var sql = $"SELECT LoginId, Password FROM Users WHERE LoginId = '{model.LoginId}' AND Password = '{model.Password}'";
                using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    //sqlCommand.Parameters.AddWithValue("@LoginId", model.LoginId);
                    //sqlCommand.Parameters.AddWithValue("@Password", model.Password);

                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        var users = new List<LoginViewModel>();
                        while (reader.Read())
                        {
                            var user = new LoginViewModel
                            {
                                LoginId = reader["LoginId"].ToString(),
                                Password = reader["Password"].ToString()
                            };
                            users.Add(user);
                        }

                        ViewBag.users = users;
                        return View();
                    }
                }
            }
        }


        public IActionResult Logout()
        {
            return View();
        }
    }
}
