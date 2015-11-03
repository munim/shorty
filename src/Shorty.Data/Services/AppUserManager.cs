using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shorty.Core.Data;
using Shorty.Core.Data.Objects;
using Shorty.Data;

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
