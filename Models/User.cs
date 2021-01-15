using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit;

namespace Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Input pasword.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "You need to provide a long enough password.")]
        public string Pasword { get; set; }
        [Display(Name = "What was your first pets name?")]
        [Required(ErrorMessage = "Input safty identifier")]
        public string saftyAnswer { get; set; }
        public bool allowPost { get; set; }
        public bool allowComent { get; set; }
        public bool Admin { get; set; }
        public byte[] PaswordSalt { get; set; } 
        public byte[] HashedPasword { get; set; }
        public string PaswordHash { get; set; }
    }
}