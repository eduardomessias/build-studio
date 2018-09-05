using Microsoft.AspNetCore.Identity;

namespace BuildStudio.Models
{
    using Core.Data.Base;

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, IUserEntity
    {
        public string FullName { get; set; }
    }
}
