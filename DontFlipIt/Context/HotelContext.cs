using DontFlipIt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DontFlipIt.Context
{
    public class HotelContext : IdentityDbContext<HotelUserEntity>
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<HotelUserEntity> HotelUsers { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }


    }
}
