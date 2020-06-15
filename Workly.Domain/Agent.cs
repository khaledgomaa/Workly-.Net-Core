using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Workly.Domain
{
    public class Agent
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }

        public decimal Rate { get; set; }
    }
}
