using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Tuned.Models.Data;
using Tuned.Models.ViewModels;


namespace Tuned.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserImagesController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        public static IWebHostEnvironment _environment;

                public UserImagesController(IConfiguration config, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)

        {
            _config = config;
            _userManager = userManager;
            _environment = environment;
        }
        
        public SqlConnection Connection

        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        // GET: api/UserImages
        [HttpGet]
        public IActionResult Get(string imageName)
        {
            var filePath = imageName;

                Byte[] b = System.IO.File.ReadAllBytes(filePath);   // You can use your own method over here.       
            
                return File(b, "image/jpeg");

        }

        // GET: api/UserImages/5
        [HttpGet("{id}", Name = "GetUserUmage")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT ui.Id, ui.UserId, ui.ProfileBackgroundImagePath
                                        FROM UserImages ui
                                        LEFT JOIN ui.ApplicationUserId ON ui.Id
                                        WHERE Active = 0";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    UserImage individualUserImage = null;

                    if (reader.Read())
                    {
                        individualUserImage = new UserImage
                            {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId =  reader.GetInt32(reader.GetOrdinal("UserId")),
                            ImagePath = reader.GetString(reader.GetOrdinal("ImagePath")),
                        };
                        reader.Close();

                        return Ok(individualUserImage );
                    }
                        else
                        {
                           return NotFound();
                        
                    }
                }
            }
        }

        // POST: api/UserImages
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserImage newUserImage)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserImages (UserId, ImagePath, Active)
                                        OUTPUT INSERTED.Id
                                        VALUES (@userId, @imagePath, @active)";

                    cmd.Parameters.Add(new SqlParameter("@userId", newUserImage.UserId));
                    cmd.Parameters.Add(new SqlParameter("@imagePath", newUserImage.ImagePath));
                    cmd.Parameters.Add(new SqlParameter("@active", newUserImage.Active));

                    int newId = (int)cmd.ExecuteScalar();
                    newUserImage.Id = newId;
                    return CreatedAtRoute("GetUserImage", new { id = newId}, newUserImage);
                }
            }
        }

        // PUT: api/UserImages/5
        [HttpPut("{id}")]
        public async Task<IActionResult>Put([FromRoute]int id, [FromBody] UserImage updatedUserImage)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE UserImages
                                            SET UserId = @userId,
                                            ImagePath = @imagePath,
                                            WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@userId", updatedUserImage.UserId));
                    cmd.Parameters.Add(new SqlParameter("@imagePath", updatedUserImage.ImagePath));

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
                if (!UserImageExists(id))
                { 
                    return NotFound();
                    } else
                {
                    throw;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
              try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE UserImages
                                            SET Active = 1
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
                if (!UserImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool UserImageExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, CarId
                        FROM UserImages
                        WHERE Id = @id
                        AND Active = 1";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read();
                }
            }
            
        }
    }
}
