using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuned.Models.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public String AdminUserId { get; set; }
        public ApplicationUser AdminUser { get; set; }
        public string ImagePath { get; set; }
    }
}
