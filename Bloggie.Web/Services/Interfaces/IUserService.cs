using Microsoft.AspNetCore.Identity;

namespace Bloggie.Web.Services.Interfaces;


/// <summary>
/// Represents the user service interface.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Gets all users asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of users.</returns>
    Task<IEnumerable<IdentityUser>> GetAllAsync();

    /// <summary>
    /// Gets a user by ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user.</returns>
    Task<IdentityUser> GetAsync(string id);
}
