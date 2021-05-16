using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArkadeBackendApi.Models;

namespace ARKADE_API0._001.Data
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext (DbContextOptions<AplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<ArkadeBackendApi.Models.Client> ClIENTS { get; set; }
        public DbSet<UserLogin> USERSLOGIN { get; set; }
        public DbSet<Models.UserInfo> USERSINFO { get; set; }

    }
}
