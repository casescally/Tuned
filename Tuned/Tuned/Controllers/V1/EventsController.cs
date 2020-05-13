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
    public class EventsController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventsController(IConfiguration config, UserManager<ApplicationUser> userManager)

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

        // GET: api/Events
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            using (SqlConnection conn = Connection)

            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =

                        @"SELECT e.Id, e.Name, e.Location, e.Date, e.Description, e.ImagePath, e.UserId, a.Id AS AdminId, a.UserName, a.FirstName, a.LastName
                          FROM Events e
                          INNER JOIN AspNetUsers a
                          ON e.UserId = a.Id";
                
                SqlDataReader reader = cmd.ExecuteReader();

                    List<Event> events = new List<Event>();

                    try {

                    while (reader.Read())
                    {
                            Event foundEvent = new Event

                            {

                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Location = reader.GetString(reader.GetOrdinal("Location")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            ImagePath = reader.GetString(reader.GetOrdinal("ImagePath")),

                            //Admin user
                            UserId = reader.GetString(reader.GetOrdinal("UserId")),

                        };        
                            if (!reader.IsDBNull(reader.GetOrdinal("UserId")))
                        {
                            foundEvent.AdminUser = new ApplicationUserViewModel { 

                                Id = reader.GetString(reader.GetOrdinal("AdminId")),
                                Username = reader.GetString(reader.GetOrdinal("UserName")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            };
                        };

                            events.Add(foundEvent);
                    }
                    } catch (Exception ex) { }
                       
                    reader.Close();

                    return Ok(events);
                    
                }
            }
        }

        // GET: api/Events/5
        [HttpGet("{id}", Name = "GetEvent")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        SELECT Id, Name, Location, Date, Description, ImagePath, UserId
                                        FROM Events
                                        WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Event individualEvent = null;

                    if (reader.Read())
                    {
                        individualEvent = new Event
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Location = reader.GetString(reader.GetOrdinal("Location")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            ImagePath = reader.GetString(reader.GetOrdinal("ImagePath")),
                            //Admin user
                            UserId = reader.GetString(reader.GetOrdinal("UserId")),
                        };
                        reader.Close();

                        return Ok(individualEvent);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Event newEvent)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Events (Name, Location, Date, Description, ImagePath)
                                        OUTPUT INSERTED.Id
                                        VALUES (@name, @location, @date, @description, @imagePath)";

                    cmd.Parameters.Add(new SqlParameter("@name", newEvent.Name));
                    cmd.Parameters.Add(new SqlParameter("@location", newEvent.Location));
                    cmd.Parameters.Add(new SqlParameter("@date", newEvent.Date));
                    cmd.Parameters.Add(new SqlParameter("@description", newEvent.Description));
                    cmd.Parameters.Add(new SqlParameter("@imagePath", newEvent.ImagePath));

                    int newId = (int)cmd.ExecuteScalar();
                    newEvent.Id = newId;
                    return CreatedAtRoute("GetEvent", new { id = newId}, newEvent);
                }
            }
        }

        // PUT: api/Events/5
        //Update an event
        [HttpPut("{id}")]
        public async Task<IActionResult>Put([FromRoute]int id, [FromBody] Event updatedEvent)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Events
                                            SET Name = @Name,
                                            Location = @Location,
                                            Date = @Date,
                                            Description = @Description,
                                            ImagePath = @ImagePath,
                                            ActiveEvent = @activeEvent,
                                            UserId = @UserId
                                            WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.Parameters.Add(new SqlParameter("@name", updatedEvent.Name));
                    cmd.Parameters.Add(new SqlParameter("@location", updatedEvent.Location));
                    cmd.Parameters.Add(new SqlParameter("@date", updatedEvent.Date));
                    cmd.Parameters.Add(new SqlParameter("@description", updatedEvent.Description));
                    cmd.Parameters.Add(new SqlParameter("@imagePath", updatedEvent.ImagePath));
                    cmd.Parameters.Add(new SqlParameter("@activeEvent", updatedEvent.ActiveEvent));
                    cmd.Parameters.Add(new SqlParameter("@userId", updatedEvent.UserId));

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
                if (!EventExists(id))
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
                        cmd.CommandText = @"UPDATE Events
                                            SET ActiveEvent = 1
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
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }


         private bool EventExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Name
                        FROM Event
                        WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read();
                }
            }
        }

    }
}
