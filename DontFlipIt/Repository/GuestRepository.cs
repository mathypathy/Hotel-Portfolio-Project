using DontFlipIt.Context;
using DontFlipIt.Models;
using DontFlipIt.Repository.IRepository;
using Microsoft.Identity.Client;

namespace DontFlipIt.Repository
{
    public class GuestRepository : Repository<HotelUserEntity>, IGuestRepository
    {
        // Implement additional methods specific to product repository
        public GuestRepository(HotelContext context) : base(context)
        {

        }
    }
}
