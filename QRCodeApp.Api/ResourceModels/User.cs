using System;
using System.ComponentModel.DataAnnotations;

namespace QrCodeApp.Api.ResourceModels;

public class User
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
}