using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Workly.Domain.ViewModels
{

    public class EditAgent
    {
        public EditAgentViewModel EditAgentInfo { get; set; }

        public List<Skill> EditSkills { get; set; }
    }

    public class EditAgentViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public string Experience { get; set; }
    }

    public class AgentSkillViewModel
    {
        public string Name { get; set; }
    }
}
