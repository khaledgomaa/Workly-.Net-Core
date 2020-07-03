using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Workly.Domain
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        [Required]
        public string Location { get; set; }

        public decimal Rate { get; set; }

        [ForeignKey("ApplicationUser")]
        [Required]
        public string AspNetUsersId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
