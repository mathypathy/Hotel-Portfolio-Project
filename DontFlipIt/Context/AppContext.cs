using DontFlipIt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DontFlipIt.Context
{
    public class AppContext : IdentityDbContext<MemberEntity>
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        public DbSet<MemberEntity> Members { get; set; }



    }
}
