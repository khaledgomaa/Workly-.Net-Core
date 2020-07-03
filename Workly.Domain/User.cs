using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workly.Domain
{
    public class User
    {
        public int Id { get; set; }

        [EmailAddress]
        [Required]
        public string Mail { get; set; }

        [ForeignKey("UserAddress")]
        public int UserAddressId { get; set; }
        public UserAddress UserAddress { get; set; }

        public int PhoneNumber { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [ForeignKey("ApplicationUser")]
        [Required]
        public string AspNetUsersId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
