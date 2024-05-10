using DontFlipIt.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelWebsiteTests
{
    internal class TestContext : IdentityDbContext<HotelUserEntity>
    {
        public TestContext(DbContextOptions<TestContext> options) : base (options) 
        {

        }

        public DbSet<HotelUserEntity> hotelUserEntities { get; set; }

    }
}
