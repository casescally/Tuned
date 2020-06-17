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
    public class UserEventController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserEventController(IConfiguration config, UserManager<ApplicationUser> userManager)

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

        // GET: api/UserEvent
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            using (SqlConnection conn = Connection)

            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =

                        @"SELECT ue.Id AS Id, ue.UserId AS UserId, ue.Eventd AS EventId
                          FROM UserEvent ue
                          LEFT JOIN AspNetUsers a
                          ON ue.UserId = a.Id
                          LEFT JOIN Events e
                          ON ue.EventId = e.Id";
                
                SqlDataReader reader = cmd.ExecuteReader();

                    List<UserEvent> userEvents = new List<UserEvent>();

                    try {

                    while (reader.Read())
                    {
                            UserEvent foundUserEvent = new UserEvent

                            {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            EventId = reader.GetInt32(reader.GetOrdinal("EventId")),
                            UserId = reader.GetString(reader.GetOrdinal("UserId")),

                        };        

                            foundUserEvent.ApplicationUser = new ApplicationUserViewModel { 

                                Id = reader.GetString(reader.GetOrdinal("UserId")),

                        };

                            foundUserEvent.Event = new Event 
                            
                            {

                            Id = reader.GetInt32(reader.GetOrdinal("Id")),

                        };

                            userEvents.Add(foundUserEvent);
                    }
                    } catch (Exception ex) { }
                       
                    reader.Close();

                    return Ok(userEvents);
                    
                }
            }
        }

        // GET: api/UserEvents/5
        [HttpGet("{id}", Name = "GetUserEvent")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =  @"SELECT ue.Id AS Id, ue.UserId AS UserId, ue.Eventd AS EventId
                                        FROM UserEvent ue
                                        LEFT JOIN AspNetUsers a
                                        ON ue.UserId = a.Id
                                        LEFT JOIN Events e
                                        ON ue.EventId = e.Id";

                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    UserEvent individualUserEvent = null;

                    if (reader.Read())
                    {
                    
                        individualUserEvent = new UserEvent

                            {

                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetString(reader.GetOrdinal("UserId")),

                        };        

                            individualUserEvent.ApplicationUser = new ApplicationUserViewModel { 

                                Id = reader.GetString(reader.GetOrdinal("Id")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),

                        };

                            individualUserEvent.Event = new Event 
                            
                            {

                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };
                        reader.Close();

                        return Ok(individualUserEvent);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }

        // POST: api/UserEvents
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserEvent newUserEvent)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserEvents (UserId, EventId)
                                        OUTPUT INSERTED.Id
                                        VALUES (@userId, @eventId)";

                    cmd.Parameters.Add(new SqlParameter("@userId", newUserEvent.UserId));
                    cmd.Parameters.Add(new SqlParameter("@eventId", newUserEvent.EventId));

                    int newId = (int)cmd.ExecuteScalar();
                    newUserEvent.Id = newId;
                    return CreatedAtRoute("GetUserEvent", new { id = newId}, newUserEvent);
                }
            }
        }

        // PUT: api/UserEvents/5
        //Update an event
        [HttpPut("{id}")]
        public async Task<IActionResult>Put([FromRoute]int id, [FromBody] UserEvent updatedUserEvent)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE UserEvents
                                            SET UserId = @userId,
                                                EventId = @eventId
                                            WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("@userId", updatedUserEvent.UserId));
                    cmd.Parameters.Add(new SqlParameter("@eventId", updatedUserEvent.EventId));

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
                if (!UserEventExists(id))
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
                        cmd.CommandText = @"DELETE FROM UserEvent
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
                if (!UserEventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }


         private bool UserEventExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Name
                        FROM UserEvent
                        WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read();
                }
            }
        }

    }
}
