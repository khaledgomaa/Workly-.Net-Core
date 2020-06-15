using Microsoft.AspNetCore.Identity;
using Workly.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workly.Repository.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("User")]
        public int ClientId { get; set; }
        public User User { get; set; }
    }
}
