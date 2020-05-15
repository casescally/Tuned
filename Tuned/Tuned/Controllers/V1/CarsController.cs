using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Tuned.Models.Data;
using Tuned.Models.ViewModels;

namespace Tuned.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly IConfiguration _config;

        public CarsController(IConfiguration config)

        {
            _config = config;
        }

        public SqlConnection Connection

        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            using (SqlConnection conn = Connection)

            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        @"SELECT * FROM Cars";
                
                SqlDataReader reader = cmd.ExecuteReader();

                    List<Car> cars = new List<Car>();

                    try { 
                    while (reader.Read())
                    {
                            Car foundCar = new Car

                            {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Make = reader.GetString(reader.GetOrdinal("Make")),
                            Model = reader.GetString(reader.GetOrdinal("Model")),
                            Year = reader.GetInt32(reader.GetOrdinal("Year")),
                            ApplicationUserId = reader.GetString(reader.GetOrdinal("ApplicationUserId")),
                            VehicleTypeId = reader.GetInt32(reader.GetOrdinal("VehicleTypeId")),
                            CarPageCoverUrl = reader.GetString(reader.GetOrdinal("CarPageCoverUrl")),
                            CarDescription = reader.GetString(reader.GetOrdinal("CarDescription"))
                        };

                            cars.Add(foundCar);
                    }
                    } catch (Exception ex) { }
                       
                    reader.Close();

                    return Ok(cars);
                    
                }
            }
        }

        // GET: api/Cars/5
        [HttpGet("{id}", Name = "GetCar")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.Id, c.Name, c.Make, c.Model, c.Year, c.ApplicationUserId, c.VehicleTypeId, c.CarPageCoverUrl, c.CarDescription, c.ActiveCar, a.FirstName, a.LastName, a.StreetAddress, a.ProfilePicturePath, a.ProfileBackgroundPicturePath, a.Description, a.ProfileHeader, a.ActiveUser
                                        FROM Cars c
                                        LEFT JOIN AspNetUsers a
                                        ON c.ApplicationUserId = a.Id
                                        WHERE c.Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Car individualCar = null;

                    if (reader.Read())
                    {
                        individualCar = new Car
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Make = reader.GetString(reader.GetOrdinal("Make")),
                            Model = reader.GetString(reader.GetOrdinal("Model")),
                            Year = reader.GetInt32(reader.GetOrdinal("Year")),
                            ApplicationUserId = reader.GetString(reader.GetOrdinal("ApplicationUserId")),
                            VehicleTypeId = reader.GetInt32(reader.GetOrdinal("VehicleTypeId")),
                            CarPageCoverUrl = reader.GetString(reader.GetOrdinal("CarPageCoverUrl")),
                            CarDescription = reader.GetString(reader.GetOrdinal("CarDescription"))
                        };
                        reader.Close();

                        return Ok(individualCar);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Car newCar)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Cars (Name, Make, Model, Year, ApplicationUserId, VehicleTypeId, CarPageCoverUrl, CarDescription)
                                        OUTPUT INSERTED.Id
                                        VALUES (@name, @make, @model, @year, @applicationUserId, @vehicleTypeId, @carPageCoverUrl, @carDescription)";

                    cmd.Parameters.Add(new SqlParameter("@name", newCar.Name));
                    cmd.Parameters.Add(new SqlParameter("@make", newCar.Make));
                    cmd.Parameters.Add(new SqlParameter("@model", newCar.Model));
                    cmd.Parameters.Add(new SqlParameter("@year", newCar.Year));
                    cmd.Parameters.Add(new SqlParameter("@applicationUserId", newCar.ApplicationUserId));
                    cmd.Parameters.Add(new SqlParameter("@vehicleTypeId", newCar.VehicleTypeId));
                    cmd.Parameters.Add(new SqlParameter("@carPageCoverUrl", newCar.CarPageCoverUrl));
                    cmd.Parameters.Add(new SqlParameter("@carDescription", newCar.CarDescription));

                    int newId = (int)cmd.ExecuteScalar();
                    newCar.Id = newId;
                    return CreatedAtRoute("GetCar", new { id = newId}, newCar);
                }
            }
        }

        // PUT: api/Cars/5
        //Update an car
        [HttpPut("{id}")]
        public async Task<IActionResult>Put([FromRoute]int id, [FromBody] Car updatedCar)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Cars
                                            SET Name = @name,
                                            Make = @make,
                                            Model = @model,
                                            Year = @year,
                                            ApplicationUserId = @applicationUserId,
                                            VehicleTypeId = @vehicleTypeId,
                                            CarPageCoverUrl = @carPageCoverUrl,
                                            CarDescription = @carDescription,
                                            ActiveCar = @activeCar
                                            WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.Parameters.Add(new SqlParameter("@name", updatedCar.Name));
                    cmd.Parameters.Add(new SqlParameter("@make", updatedCar.Make));
                    cmd.Parameters.Add(new SqlParameter("@model", updatedCar.Model));
                    cmd.Parameters.Add(new SqlParameter("@year", updatedCar.Year));
                    cmd.Parameters.Add(new SqlParameter("@applicationUserId", updatedCar.ApplicationUserId));
                    cmd.Parameters.Add(new SqlParameter("@vehicleTypeId", updatedCar.VehicleTypeId));
                    cmd.Parameters.Add(new SqlParameter("@carPageCoverUrl", updatedCar.CarPageCoverUrl));
                    cmd.Parameters.Add(new SqlParameter("@carDescription", updatedCar.CarDescription));
                    cmd.Parameters.Add(new SqlParameter("@activeCar", updatedCar.ActiveCar));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return new StatusCodeResult(StatusCodes.Status204NoContent);
                        }
                        throw new Exception("No rows affected");
                    }
                }
            }
            catch (Exception ex)
            {
                if (!CarExists(id))
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
        public async Task<IActionResult>Delete([FromRoute] int id)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Cars
                                            SET ActiveCar = 1
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
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

         private bool CarExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Name
                        FROM Car
                        WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read();
                }
            }
        }

    }
}
