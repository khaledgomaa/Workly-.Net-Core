using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Workly.Domain.ViewModels
{
    public class OrderRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string AgentName { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
