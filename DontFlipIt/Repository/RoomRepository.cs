using DontFlipIt.Context;
using DontFlipIt.Models;
using DontFlipIt.Repository.IRepository;

namespace DontFlipIt.Repository
{
    public class RoomRepository : Repository<RoomEntity>, IRoomRepository
    {
        // Implement additional methods specific to product repository
        public RoomRepository(HotelContext context) : base(context)
        {

        }
    }
}
