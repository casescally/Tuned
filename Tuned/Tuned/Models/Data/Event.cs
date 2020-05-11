using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuned.Models.ViewModels;

namespace Tuned.Models.Data
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        //Admin user
        public string UserId { get; set; }
        public ApplicationUserViewModel AdminUser { get; set; }

    }
}
