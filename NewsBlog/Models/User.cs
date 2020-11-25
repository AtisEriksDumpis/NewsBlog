using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsBlog.Models
{
    public class User
    {
        public int ID { get; set; }
        [Display(Name = "User name")]
        [Required(ErrorMessage = "Input user name.")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Input pasword.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "You need to provide a long enough password.")]
        public string Pasword { get; set; }
        
        [Display(Name = "What was your first pets name?")]
        [Required(ErrorMessage = "Input safty identifier")]
        public string saftyAnser { get; set; }
        public bool canMakePosts { get; set; }
        public bool Admin { get; set; }
    }
}