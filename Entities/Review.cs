using MusicalCollection.Entities.Enums;

namespace MusicalCollection.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public StarRating Rating { get; set; }
        public string? Comment { get; set; }
    }
}