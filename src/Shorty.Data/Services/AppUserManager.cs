using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shorty.Core.Data;
using Shorty.Data;
using Shorty.Data.Data.Objects;

namespace Shorty.Core.Services
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {
        }

        public AppUserManager(AppDbContext context)
            : base(new UserStore<AppUser>(context))
        {

        }
    }
}
