﻿using Microsoft.AspNetCore.Identity;

namespace Bloggie.Web.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName => $"{FirstName} {LastName}";
}
