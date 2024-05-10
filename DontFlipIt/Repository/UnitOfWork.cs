using DontFlipIt.Context;
using DontFlipIt.Models;
using DontFlipIt.Repository.IRepository;

namespace DontFlipIt.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelContext _context;
        
        public UnitOfWork(HotelContext context)
        {

            _context = context;

            GuestRepository = new GuestRepository(_context);
            RoomRepository = new RoomRepository(_context);
            
        }

        public IGuestRepository GuestRepository { get; private set; }
        public IRoomRepository RoomRepository { get; private set; }
        // Other repository properties

   
    }

}
