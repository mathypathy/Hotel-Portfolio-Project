namespace DontFlipIt.ViewModels
{
    public class RoomsAndSuitsViewModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public string RoomDescription { get; set;} = string.Empty;
        public string RoomType { get; set;} = string.Empty;

        public int RoomPrice { get; set; }

    }
}
