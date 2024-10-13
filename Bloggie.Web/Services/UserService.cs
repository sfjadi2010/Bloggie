using Bloggie.Web.DataContext;
using Bloggie.Web.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Services;

public class UserService : IUserService
{
    private readonly AuthDbContext _authDbContext;

    public UserService(AuthDbContext authDbContext)
    {
        _authDbContext = authDbContext;
    }

    public async Task<IEnumerable<IdentityUser>> GetAllAsync()
    {
        return await _authDbContext
            .Users
            .AsNoTracking()
            .Where(u => u.Id != "cd4bda95-a05b-449d-bb80-7ddfbecc1860")
            .ToListAsync();
    }

    public async Task<IdentityUser> GetAsync(string id)
    {
        return await _authDbContext
            .Users
            .AsNoTracking()
            .FirstAsync(u => u.Id == id);
    }
}
