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
    public class EventImagesController : ControllerBase
    {
        
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        public static IWebHostEnvironment _environment;

                public SqlConnection Connection

        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        // GET: api/EventImages
        [HttpGet]
        [Route("image/get")]
        public IActionResult Get(string imageName)
        {
               //var filePath = _environment.WebRootPath + "\\Upload\\" + imageName;

            var filePath = imageName;

                Byte[] b = System.IO.File.ReadAllBytes(filePath);   // You can use your own method over here.       
            
                return File(b, "image/jpeg");

        }

        // GET: api/EventImages/5
        [HttpGet("{id}", Name = "GetEventImage")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT ei.Id, ei.EventId, ei.ImagePath
                                        FROM EventImages ei
                                        LEFT JOIN Events e
                                        ON ei.EventId = e.Id
                                        WHERE Active = 0";

                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    EventImage individualEventImage = null;

                    if (reader.Read())
                    {
                    
                        individualEventImage = new EventImage

                            {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            EventId = reader.GetInt32(reader.GetOrdinal("EventId")),
                            ImagePath = reader.GetString(reader.GetOrdinal("ImagePath")),

                        };        

                          
                        reader.Close();

                        return Ok(individualEventImage);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }

        // POST: api/EventImages
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/EventImages/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
