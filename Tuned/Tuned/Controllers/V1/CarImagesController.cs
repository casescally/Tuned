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
using Tuned.Models.Data;
using Tuned.Models.ViewModels;

namespace Tuned.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        public static IWebHostEnvironment _environment;

        public CarImagesController(IConfiguration config, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)

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

        // GET: api/CarImages
        [HttpGet]
        [Route("image/get")]
        public IActionResult Get(string imageName)
        {
               // var filePath = _environment.WebRootPath + "\\Upload\\" + imageName;

            var filePath = imageName;

                Byte[] b = System.IO.File.ReadAllBytes(filePath);   // You can use your own method over here.       
            
                return File(b, "image/jpeg");

        }

        // GET: api/CarImages/5
        [HttpGet("{id}", Name = "GetCarImage")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT ci.Id, ci.CarId, ci.ImagePath
                                        FROM CarImages ci
                                        LEFT JOIN Cars c
                                        ON ci.CarId = c.Id
                                        WHERE Active = 0";

                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    CarImage individualCarImage = null;

                    if (reader.Read())
                    {
                    
                        individualCarImage = new CarImage

                            {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            CarId = reader.GetInt32(reader.GetOrdinal("CarId")),
                            ImagePath = reader.GetString(reader.GetOrdinal("ImagePath")),

                        };        

                          
                        reader.Close();

                        return Ok(individualCarImage);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }

        // POST: api/CarImages
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarImage newCarImage)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO CarImages (CarId, ImagePath, Active)
                                        OUTPUT INSERTED.Id
                                        VALUES (@carId, @imagePath, @active)";

                    cmd.Parameters.Add(new SqlParameter("@carId", newCarImage.CarId));
                    cmd.Parameters.Add(new SqlParameter("@imagePath", newCarImage.ImagePath));
                    cmd.Parameters.Add(new SqlParameter("@active", newCarImage.Active));

                    int newId = (int)cmd.ExecuteScalar();
                    newCarImage.Id = newId;
                    return CreatedAtRoute("GetCarImage", new { id = newId}, newCarImage);
                }
            }
        }

        // PUT: api/CarImages/5
        //Update a car image
        [HttpPut("{id}")]
        public async Task<IActionResult>Put([FromRoute]int id, [FromBody] CarImage updatedCarImage)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE CarImages
                                            SET CarId = @carId,
                                            ImagePath = @imagePath,
                                            WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@carId", updatedCarImage.CarId));
                    cmd.Parameters.Add(new SqlParameter("@imagePath", updatedCarImage.ImagePath));

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
                if (!CarImageExists(id))
                { 
                    return NotFound();
                    } else
                {
                    throw;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        // Soft delete - sets the active car image boolean to 1
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
                        cmd.CommandText = @"UPDATE CarImages
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
                if (!CarImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }


         private bool CarImageExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, CarId
                        FROM CarImages
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
