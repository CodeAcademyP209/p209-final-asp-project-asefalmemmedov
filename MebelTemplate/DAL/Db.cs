using MebelTemplate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MebelTemplate.DAL
{
    public class Db:DbContext
    {
        public Db():base("Furniture")
        {
        }
        public virtual DbSet<HomeDTO>  Homes { get; set; }
        public virtual DbSet<ServicesDTO>  Services { get; set; }
        public virtual DbSet<CategoryDTO>  Categories { get; set; }
        public virtual DbSet<BannerDTO>  Banners { get; set; }
        public virtual DbSet<UserDTO>  Users { get; set; }
        public virtual DbSet<RoleDTO>  Roles { get; set; }
        public virtual DbSet<UserRolsDTO>  UserRols { get; set; }

        internal Task FirstOrDefaultAsync(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}