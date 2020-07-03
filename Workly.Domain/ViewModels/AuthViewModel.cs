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
    }

    public class MyUserAspNet
    {
        [Required]
        public string UserName { get; set; }


        [Required]
        public string Password { get; set; }
    }


    

}
