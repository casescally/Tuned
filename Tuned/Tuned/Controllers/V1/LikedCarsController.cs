using System;
using System.Collections.Generic;
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
    public class LikedCarsController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;

        public LikedCarsController(IConfiguration config, UserManager<ApplicationUser> userManager)

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

        // GET: api/LikedCars
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            using (SqlConnection conn = Connection)

            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =

                        @"SELECT lc.Id, lc.UserId, lc.CarId, a.Id, a.FirstName, a.LastName, a.StreetAddress, a.ProfilePicturePath, a.ProfileBackgroundPicturePath, a.Description, a.ProfileHeader
                          FROM LikedCars lc
                          LEFT JOIN AspNetUsers a
                          ON lc.UserId = a.Id
                          LEFT JOIN Cars c
                          ON lc.CarId = c.Id";
                
                SqlDataReader reader = cmd.ExecuteReader();

                    List<LikedCar> likedCars = new List<LikedCar>();

                    try {

                    while (reader.Read())
                    {
                            LikedCar foundLikedCar = new LikedCar

                            {

                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetString(reader.GetOrdinal("UserId")),

                        };        

                            foundLikedCar.User = new ApplicationUserViewModel { 

                                Id = reader.GetString(reader.GetOrdinal("AdminId")),
                                Username = reader.GetString(reader.GetOrdinal("UserName")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),

                        };

                            foundLikedCar.Car = new Car 
                            
                            {

                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Make = reader.GetString(reader.GetOrdinal("Make")),
                            Model = reader.GetString(reader.GetOrdinal("Model")),
                            Year = reader.GetInt32(reader.GetOrdinal("Year")),
                            Url = reader.GetInt32(reader.GetOrdinal("Url")),
                            ApplicationUserId = reader.GetString(reader.GetOrdinal("ApplicationUserId")),
                            VehicleTypeId = reader.GetInt32(reader.GetOrdinal("VehicleTypeId")),
                            CarPageCoverUrl = reader.GetString(reader.GetOrdinal("CarPageCoverUrl")),
                            CarDescription = reader.GetString(reader.GetOrdinal("CarDescription"))
                        };

                            likedCars.Add(foundLikedCar);
                    }
                    } catch (Exception ex) { }
                       
                    reader.Close();

                    return Ok(likedCars);
                    
                }
            }
        }

        // GET: api/LikedCars/5
        [HttpGet("{id}", Name = "GetLikedCar")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT lc.Id, lc.UserId, lc.CarId, a.Id, a.FirstName, a.LastName, a.StreetAddress, a.ProfilePicturePath, a.ProfileBackgroundPicturePath, a.Description, a.ProfileHeader
                                        FROM LikedCars lc
                                        LEFT JOIN AspNetUsers a
                                        ON lc.UserId = a.Id
                                        LEFT JOIN Cars c
                                        ON lc.CarId = c.Id";

                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    LikedCar individualLikedCar = null;

                    if (reader.Read())
                    {
                    
                        individualLikedCar = new LikedCar

                            {

                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetString(reader.GetOrdinal("UserId")),

                        };        

                            individualLikedCar.User = new ApplicationUserViewModel { 

                                Id = reader.GetString(reader.GetOrdinal("AdminId")),
                                Username = reader.GetString(reader.GetOrdinal("UserName")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),

                        };

                            individualLikedCar.Car = new Car 
                            
                            {

                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Make = reader.GetString(reader.GetOrdinal("Make")),
                            Model = reader.GetString(reader.GetOrdinal("Model")),
                            Year = reader.GetInt32(reader.GetOrdinal("Year")),
                            Url = reader.GetInt32(reader.GetOrdinal("Url")),
                            ApplicationUserId = reader.GetString(reader.GetOrdinal("ApplicationUserId")),
                            VehicleTypeId = reader.GetInt32(reader.GetOrdinal("VehicleTypeId")),
                            CarPageCoverUrl = reader.GetString(reader.GetOrdinal("CarPageCoverUrl")),
                            CarDescription = reader.GetString(reader.GetOrdinal("CarDescription"))
                        };
                        reader.Close();

                        return Ok(individualLikedCar);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }

        // POST: api/LikedCars
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LikedCar newLikedCar)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO LikedCars (UserId, CarId)
                                        OUTPUT INSERTED.Id
                                        VALUES (@userId, @carId)";

                    cmd.Parameters.Add(new SqlParameter("@name", newLikedCar.UserId));
                    cmd.Parameters.Add(new SqlParameter("@location", newLikedCar.CarId));

                    int newId = (int)cmd.ExecuteScalar();
                    newLikedCar.Id = newId;
                    return CreatedAtRoute("GetLikedCar", new { id = newId}, newLikedCar);
                }
            }
        }

        // PUT: api/LikedCars/5
        //Update an event
        [HttpPut("{id}")]
        public async Task<IActionResult>Put([FromRoute]int id, [FromBody] LikedCar updatedLikedCar)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE LikedCars
                                            SET Name = @Name,
                                            Location = @Location,
                                            Date = @Date,
                                            Description = @Description,
                                            ImagePath = @ImagePath,
                                            ActiveLikedCar = @activeLikedCar,
                                            UserId = @UserId
                                            WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@name", updatedLikedCar.UserId));
                    cmd.Parameters.Add(new SqlParameter("@location", updatedLikedCar.CarId));

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
                if (!LikedCarExists(id))
                { 
                    return NotFound();
                    } else
                {
                    throw;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        // Soft delete - sets the active event boolean to 1
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete([FromRoute] int id)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE LikedCars
                                            SET ActiveLikedCar = 1
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
                if (!LikedCarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }


         private bool LikedCarExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Name
                        FROM LikedCar
                        WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read();
                }
            }
        }

    }
}
