using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using Typer.Database.Models;

namespace Typer.Web
{
    public class AppUserStore :
       UserStore<DbAppUser, DbAppRole, string,
           DbAppUserLogin, DbAppUserRole,
           DbAppUserClaim>, IUserStore<DbAppUser>,
       IDisposable
    {
        public AppUserStore()
            : this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public AppUserStore(DbContext context)
            : base(context)
        {
        }
    }


    public class ApplicationRoleStore
        : RoleStore<DbAppRole, string, DbAppUserRole>,
        IQueryableRoleStore<DbAppRole, string>,
        IRoleStore<DbAppRole, string>, IDisposable
    {
        public ApplicationRoleStore()
            : base(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}
