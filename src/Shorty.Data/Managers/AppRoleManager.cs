using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Shorty.Data.Managers
{
    public class AppRoleManager: RoleManager<IdentityRole>
    {
        public AppRoleManager(IRoleStore<IdentityRole, string> store) : base(store)
        {

        }

        public AppRoleManager(AppDbContext context) : base(new RoleStore<IdentityRole>(context))
        {
            
        }
    }
}
