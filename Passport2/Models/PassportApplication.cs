using System.ComponentModel.DataAnnotations;
namespace Passport2.Models
{
    public class PassportApplication
    {
        public int ApplicationID { get; set; }
        public int UserDetailsId { get; set; }
        public string Status { get; set; }
        public DateTime DateOfApplication { get; set; }

        // Initialize if needed
        public UserDetails UserDetails { get; set; } = new UserDetails();
    }
}