using EsercizioSettimanale4Marzo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsercizioSettimanale4Marzo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CheckUser(Addetti addetti)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT * FROM Addetti WHERE Username = @Username AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", addetti.Username);
                    cmd.Parameters.AddWithValue("@Password", addetti.Password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return View("Index");
                        }
                        else
                        {
                            return View("Error");
                        }
                    }
                }
            }

            return View();
        }

    }
}