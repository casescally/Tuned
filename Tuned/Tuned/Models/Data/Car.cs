using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuned.Models.Data
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Url { get; set; }
        public int UserId { get; set; }
        public int VehicleTypeId { get; set; }
        public string CarPageCoverUrl { get; set; }
        public string CarDescription { get; set; }
    }
}
