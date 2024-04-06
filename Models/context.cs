using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace user_Identity.Models
{
    public class context:IdentityDbContext<ApplicationUser>
    {

        public DbSet<ApplicationUser> users {  get; set; }
        public context(DbContextOptions<context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new
            {
                Id = Guid.NewGuid().ToString()
                ,
                Name = "Admin",
                NormalizedName = "admin",
                ConcurrencyStamp = Guid.NewGuid().ToString()



            });

            builder.Entity<IdentityRole>().HasData(new
            {
                Id = Guid.NewGuid().ToString()
              ,
                Name = "User",
                NormalizedName = "user",
                ConcurrencyStamp = Guid.NewGuid().ToString()



            });




            base.OnModelCreating(builder);
        }
    }
}
