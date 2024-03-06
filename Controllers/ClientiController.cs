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
    public class ClientiController : Controller
    {
        public ActionResult InserisciCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InserisciClientee(Clienti clienti)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Clienti (NomeCliente, CF, PIVA) VALUES (@NomeCliente, @CF, @PIVA)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NomeCliente", clienti.NomeCliente);
                    //controllo se è null
                    if (clienti.CF == null)
                    {
                        cmd.Parameters.AddWithValue("@CF", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CF", clienti.CF);
                    }

                    if (clienti.PIVA == null)
                    {
                        cmd.Parameters.AddWithValue("@PIVA", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PIVA", clienti.PIVA);
                    }
                    
                    cmd.ExecuteNonQuery();
                }
                return View("InserisciCliente");
            }
                
        }

       

        
    }
}