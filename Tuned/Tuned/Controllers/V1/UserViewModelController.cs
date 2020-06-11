using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Tuned.Models.Data;
using Tuned.Models.ViewModels;

namespace Tuned.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(IConfiguration config, UserManager<ApplicationUser> userManager)

        {
            _config = config;
            _userManager = userManager;
        }

        public SqlConnection Connection

        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            using (SqlConnection conn = Connection)

            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =

                        @"SELECT Id, Username, FirstName, LastName
                          FROM AspNetUsers";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ApplicationUserViewModel> users = new List<ApplicationUserViewModel>();

                    try
                    {

                        while (reader.Read())
                        {
                            ApplicationUserViewModel foundUser = new ApplicationUserViewModel

                            {
                                Id = reader.GetString(reader.GetOrdinal("Id")),
                                //Username = reader.GetString(reader.GetOrdinal("Username")),
                                FirstName = reader.GetString(reader.GetOrdinal("Firstname")),
                                LastName = reader.GetString(reader.GetOrdinal("Lastname")),
                            };

                            users.Add(foundUser);
                        }
                    }
                    catch (Exception ex) { }

                    reader.Close();

                    return Ok(users);

                }
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Username, FirstName, LastName
                                        FROM AspNetUsers
                                        WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    ApplicationUserViewModel individualUser = null;

                    if (reader.Read())
                    {
                        individualUser = new ApplicationUserViewModel
                        {
                            Id = reader.GetString(reader.GetOrdinal("Id")),
                            //Username = reader.GetString(reader.GetOrdinal("Username")),
                            FirstName = reader.GetString(reader.GetOrdinal("Firstname")),
                            LastName = reader.GetString(reader.GetOrdinal("Lastname")),
                        };
                        reader.Close();

                        return Ok(individualUser);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }




        // DELETE: api/ApiWithActions/5
        // Soft delete - sets the active user boolean to 1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Users
                                            SET ActiveUser = 1
                                            WHERE Id = @id";

                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return new StatusCodeResult(StatusCodes.Status204NoContent);
                        }
                        throw new Exception("No rows affected");
                    }
                }
            }
            catch (Exception)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }


        private bool UserExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Username
                        FROM User
                        WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read();
                }
            }
        }

    }
}