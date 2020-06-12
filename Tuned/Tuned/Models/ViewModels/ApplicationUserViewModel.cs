using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuned.Models.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
     //   public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicturePath { get; set; }
        public string ProfileBackgroundPicturePath { get; set; }
        public string Description { get; set; }
        public string ProfileHeader { get; set; }
    }
}
