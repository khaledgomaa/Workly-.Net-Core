using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Workly.Domain
{
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        public int? BuildingNumber { get; set; }

        public int? FlatNumber { get; set; }
    }
}
