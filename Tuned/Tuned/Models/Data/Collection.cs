using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuned.Models.Data
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
