using System.Threading.Tasks;
using Tuned.Models.ViewModels;

namespace Tuned.Models.Data
{
    public class UserImage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ApplicationUserViewModel ApplicationUserViewModel{ get; set; }
        public string ImagePath { get; set; }
        public bool Active { get; set; }
    }
}
