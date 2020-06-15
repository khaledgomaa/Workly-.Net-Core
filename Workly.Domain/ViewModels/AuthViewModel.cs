using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Workly.Domain.ViewModels
{
    public class RegisterationModel
    {
        [Required]
        public User UserInfo { get; set; }

        [Required]
        public MyUserAspNet UserSecurity { get; set; }

        [Required]
        public UserAddress Address { get; set; }

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

    }

}
