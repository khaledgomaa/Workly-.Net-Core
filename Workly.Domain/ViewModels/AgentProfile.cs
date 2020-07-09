using System;
using System.Collections.Generic;
using System.Text;

namespace Workly.Domain.ViewModels
{
    public class AgentProfile
    {
        public string UserName { get; set; }

        public string ImagePath { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string Location { get; set; }

        public string JobName { get; set; }

        public IEnumerable<string> Skills { get; set; }

        public string Experience { get; set; }

        public decimal Rate { get; set; }
    }
}
