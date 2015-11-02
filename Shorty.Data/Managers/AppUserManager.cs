using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shorty.Data.DataObjects;

namespace Shorty.Data.Managers
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
