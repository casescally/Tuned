using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuned.Models.Data;

namespace Tuned.Models.ViewModels
{
    public class CarCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public String ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public IFormFile ImageFile { get; set; }
        public string CarPageCoverUrl { get; set; }
        public string CarDescription { get; set; }
        public bool ActiveCar { get; set; }
    }
}
