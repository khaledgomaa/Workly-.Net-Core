using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Workly.Domain.ViewModels
{
    public class RegisterationModelForUsers
    {
        [Required]
        public User UserInfo { get; set; }

        [Required]
        public MyUserAspNet UserSecurity { get; set; }

        [Required]
        public UserAddress Address { get; set; }

    }

    public class RegisterationModelForAgents
    {
        [Required]
        public Agent AgentInfo { get; set; }

        [Required]
        public MyUserAspNet UserSecurity { get; set; }

        [Required]
        public Job JobInfo { get; set; }

        [Required]
        public IEnumerable<Skill> Skills { get; set; }
    }

    public class MyUserAspNet
    {
        [Required]
        public string UserName { get; set; }


        [Required]
        public string Password { get; set; }
    }

    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
    
    public class LoginReturn
    {
        public string Token { get; set; }

        public string Role { get; set; }
    }
}
