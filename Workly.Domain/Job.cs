using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Workly.Domain
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Agent> Agent { get; set; }
    }
}