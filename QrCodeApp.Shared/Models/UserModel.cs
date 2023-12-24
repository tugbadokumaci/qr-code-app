using System;
using System.ComponentModel.DataAnnotations;

namespace QrCodeApp.Shared.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

}

