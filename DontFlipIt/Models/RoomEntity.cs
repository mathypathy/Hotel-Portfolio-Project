using System.ComponentModel.DataAnnotations;

namespace DontFlipIt.Models
{
    public class RoomEntity
    {

        [Key]
        public int RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public string RoomDescription { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public int RoomSpecialPrice { get; set; } 
        public int RoomPrice { get; set; }
        public bool HasSeaView { get; set; } = false;


    }
}
