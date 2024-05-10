namespace DontFlipIt.Repository.IRepository
{
    public interface IUnitOfWork 
    {
    
        IGuestRepository GuestRepository { get; }
        IRoomRepository RoomRepository { get; }
        // Add other repository properties as needed
    }
}
