﻿namespace Bloggie.Web.Models.ViewModels;

public sealed class RegisterViewModel
{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
