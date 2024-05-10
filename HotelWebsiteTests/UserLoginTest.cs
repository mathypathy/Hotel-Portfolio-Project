using DontFlipIt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelWebsiteTests
{
    public class UserLoginTest
    {
        private readonly TestContext _testContext;
        private readonly IServiceProvider _serviceProvider;

        public UserLoginTest()
        {
            
            var options = new DbContextOptionsBuilder<TestContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
          

            var services = new ServiceCollection();


            // Lägger till en InMemory-databas
            services.AddDbContext<TestContext>(options =>
                options.UseInMemoryDatabase("TestDb"));
            services.AddLogging();
            // Konfigurerar Identity
            services.AddIdentity<HotelUserEntity, IdentityRole>()
                .AddEntityFrameworkStores<TestContext>()
            .AddDefaultTokenProviders();

            _serviceProvider = services.BuildServiceProvider();
            _testContext = _serviceProvider.GetRequiredService<TestContext>();

            // Initialisera databasen
            _testContext.Database.EnsureCreated();
        }

        [Fact]
        public async Task TestLogin_Successful()
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<HotelUserEntity>>();
            var signInManager = _serviceProvider.GetRequiredService<SignInManager<HotelUserEntity>>();

            var user = new HotelUserEntity { UserName = "testuser", Email = "test@example.com" };
            await userManager.CreateAsync(user, "Password123!");
            var loginResult = await signInManager.PasswordSignInAsync("testuser", "Password123!", false, false);

            Assert.True(loginResult.Succeeded);
        }

        [Fact]
        public async Task TestLogin_Failure()
        {
            var signInManager = _serviceProvider.GetRequiredService<SignInManager<HotelUserEntity>>();
            var loginResult = await signInManager.PasswordSignInAsync("nonexistentuser", "WrongPassword", false, false);

            Assert.False(loginResult.Succeeded);
        }

    }
}
