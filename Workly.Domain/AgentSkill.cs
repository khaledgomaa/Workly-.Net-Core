using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Workly.Domain
{
    public class AgentSkill
    {
        [ForeignKey("Agent")]
        public int AgentId { get; set; }
        public Agent Agent { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
