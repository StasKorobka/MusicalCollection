using Microsoft.EntityFrameworkCore;
using MusicalCollection.Entities.Enums;
using MusicalCollection.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicalCollection.UserInterface;

namespace MusicalCollection.Data
{
    public class MusicCollectionService
    {
        //stars representation in console
        public readonly Dictionary<int, string> starDictionary = new Dictionary<int, string>
        {
            { (int)StarRating.OneStar,      "★☆☆☆☆" },
            { (int)StarRating.TwoStars,     "★★☆☆☆" },
            { (int)StarRating.ThreeStars,   "★★★☆☆" },
            { (int)StarRating.FourStars,    "★★★★☆" },
            { (int)StarRating.FiveStars,    "★★★★★" }
        };
        
        private readonly MusicalCollectionDbContext _dbContext;
        private UserInterfaceService UI = new UserInterfaceService();
        public MusicCollectionService(MusicalCollectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Validation methods
        public bool CheckRate(int rate)
        {
            if (rate < 1 || rate > 5)
            {
                UI.PrintErrorMessage("Rate must be between 1 and 5.");
                return false;
            }
            return true;
        }
        public bool CheckAlbum(Album album, string albumName)
        {
            if (album == null)
            {
                UI.PrintErrorMessage($"Album '{albumName}' not found.");
                return false;
            }

            return true;
        }
        
        //Main comands
        public void AddToCollection(int userId, string albumName)
        {
            //Searching for album
            var album = _dbContext.Albums
                 .Include(a => a.Artist)
                 .AsEnumerable()
                 .FirstOrDefault(a => a.Title.Equals(albumName, StringComparison.OrdinalIgnoreCase));

            if (!CheckAlbum(album, albumName))
                return;

            var existing = _dbContext.UserCollections
                .Any(uc => uc.UserId == userId && uc.AlbumId == album.AlbumId);

            if (existing)
            {
                UI.PrintSuccessMessage($"Album '{albumName}' is already in your collection.");
                return;
            }

            var userCollection = new UserCollection
            {
                UserId = userId,
                AlbumId = album.AlbumId,
                AdditionDate = DateTime.UtcNow,
                Status = CollectionStatus.Wishlist // Automatically set to Wishlist
            };

            _dbContext.UserCollections.Add(userCollection);
            _dbContext.SaveChanges();

            UI.PrintSuccessMessage($"Added '{albumName}' to your collection with wished status");
        }
        public void BuyAlbum(int userId, string albumName)
        {
            var album = _dbContext.Albums
                .Include(a => a.Artist)
                .AsEnumerable()
                .FirstOrDefault(a => a.Title.Equals(albumName, StringComparison.OrdinalIgnoreCase));

            if (!CheckAlbum(album, albumName))
                return ;

            var existingCollection = _dbContext.UserCollections
                .FirstOrDefault(uc => uc.UserId == userId && uc.AlbumId == album.AlbumId);

            if (existingCollection != null)
            {
                if (existingCollection.Status == CollectionStatus.Purchased)
                {
                    UI.PrintWarningMessage($"Album '{albumName}' is already purchased.");
                    return;
                }

                // Update status to Purchased
                existingCollection.Status = CollectionStatus.Purchased;
                UI.PrintSuccessMessage($"Updated '{albumName}' to purchased status.");
            }
            else
            {
                // Add new entry with Purchased status
                var userCollection = new UserCollection
                {
                    UserId = userId,
                    AlbumId = album.AlbumId,
                    AdditionDate = DateTime.UtcNow,
                    Status = CollectionStatus.Purchased
                };
                _dbContext.UserCollections.Add(userCollection);
                UI.PrintSuccessMessage($"Added '{albumName}' to your collection as purchased.");
            }

            _dbContext.SaveChanges();
        }
        public void AddToPlaylist(int userId, string trackName, string playlistName)
        {
            //searching for playlist
            var playlist = _dbContext.Playlists
               .AsEnumerable()
               .FirstOrDefault(p => p.UserId == userId && p.PlaylistName.Equals(playlistName, StringComparison.OrdinalIgnoreCase));


            if (playlist == null)
            {
                UI.PrintErrorMessage($"Playlist '{playlistName}' not found.");
                return;
            }
            //checking track
            var track = _dbContext.Tracks
               .Include(t => t.Album)
               .ThenInclude(a => a.Artist)
               .AsEnumerable()
               .FirstOrDefault(t => t.Title.Equals(trackName, StringComparison.OrdinalIgnoreCase));

            if (track == null)
            {
                UI.PrintErrorMessage($"Track '{trackName}' not found.");
                return;
            }

            var existing = _dbContext.PlaylistTracks
                .Any(pt => pt.PlaylistId == playlist.PlaylistId && pt.TrackId == track.TrackId);

            if (existing)
            {
                UI.PrintWarningMessage($"Track '{trackName}' is already in playlist '{playlistName}'.");
                return;
            }

            var maxPosition = _dbContext.PlaylistTracks
                .Where(pt => pt.PlaylistId == playlist.PlaylistId)
                .Select(pt => (int?)pt.Position) // making it nullable int
                .Max() ?? 0; // if thre's no tracks, return 0

            var nextPosition = maxPosition + 1;

            var playlistTrack = new PlaylistTrack
            {
                PlaylistId = playlist.PlaylistId,
                TrackId = track.TrackId,
                Position = nextPosition
            };

            _dbContext.PlaylistTracks.Add(playlistTrack);
            _dbContext.SaveChanges();

            UI.PrintSuccessMessage($"Added '{trackName}' to playlist '{playlistName}'.");
        }
        public void AddNewPlaylist(int userId, string playlistName)
        {
            var existing = _dbContext.Playlists
               .AsEnumerable()
               .Any(p => p.UserId == userId && p.PlaylistName.Equals(playlistName, StringComparison.OrdinalIgnoreCase));

            if (existing)
            {
                UI.PrintWarningMessage($"Playlist '{playlistName}' already exists.");
                return;
            }

            var playlist = new Playlist
            {
                PlaylistName = playlistName,
                UserId = userId,
                CreationDate = DateTime.UtcNow
            };

            _dbContext.Playlists.Add(playlist);
            _dbContext.SaveChanges();

            UI.PrintSuccessMessage($"Created new playlist '{playlistName}'.");
        }
        public void SetAlbumRating(int userId, string albumName, int rate, string commentary)
        {
            if(!CheckRate(rate))
                return;

            // Search for album
            var album = _dbContext.Albums
                .AsEnumerable()
                .FirstOrDefault(a => a.Title.Equals(albumName, StringComparison.OrdinalIgnoreCase));

            if (!CheckAlbum(album, albumName))
                return;

            // checking wheather user already rated the album
            var existingReview = _dbContext.Reviews
                .FirstOrDefault(r => r.UserId == userId && r.AlbumId == album.AlbumId);

            if (existingReview != null)
            {
                // updating existing rate
                existingReview.Rating = (StarRating)rate;
                existingReview.Comment = commentary;
                UI.PrintSuccessMessage($"Updated rating for '{albumName}' to {rate} stars.");
            }
            else
            {
                // adding new review
                var review = new Review
                {
                    UserId = userId,
                    AlbumId = album.AlbumId,
                    Rating = (StarRating)rate,
                    Comment = commentary 
                };
                _dbContext.Reviews.Add(review);
                UI.PrintSuccessMessage($"Set rating for '{albumName}' to {starDictionary[(int)review.Rating]} stars.");
            }

            _dbContext.SaveChanges();
        }
        public void ShowUserRatings(int userId)
        {
            var reviews = _dbContext.Reviews
                .Include(r => r.Album)
                .ThenInclude(a => a.Artist)
                .Where(r => r.UserId == userId)
                .ToList();

            if (!reviews.Any())
            {
                UI.PrintWarningMessage("You haven't rated any albums yet.");
                return;
            }

            Console.WriteLine("Your album ratings:");
            foreach (var review in reviews)
            {
                UI.PrintSuccessMessage($"- '{review.Album.Title}' by {review.Album.Artist.Name}: {starDictionary[(int)review.Rating]} stars");
                if (!string.IsNullOrEmpty(review.Comment))
                    Console.WriteLine($"  Comment: {review.Comment}");
            }
        }
        public void ShowPlaylist(int userId, string playlistName)
        {
            var playlist = _dbContext.Playlists
                .Include(p => p.PlaylistTracks)
                .ThenInclude(pt => pt.Track)
                .ThenInclude(t => t.Album)
                .ThenInclude(a => a.Artist)
                .AsEnumerable()
                .FirstOrDefault(p => p.UserId == userId && p.PlaylistName.Equals(playlistName, StringComparison.OrdinalIgnoreCase));

            if (playlist == null)
            {
                UI.PrintErrorMessage($"Playlist '{playlistName}' not found.");
                return;
            }

            if (!playlist.PlaylistTracks.Any())
            {
                UI.PrintErrorMessage($"Playlist '{playlistName}' is empty.");
                return;
            }

            Console.WriteLine($"Tracks in playlist '{playlistName}':");
            var sortedTracks = playlist.PlaylistTracks.OrderBy(pt => pt.Position).ToList();
            foreach (var playlistTrack in sortedTracks)
            {
                var track = playlistTrack.Track;
                UI.PrintSuccessMessage($"- {track.Title} by {track.Album.Artist.Name} (from '{track.Album.Title}')");
            }
        }
        public void ShowMyPlaylists(int userId)
        {
            var playlists = _dbContext.Playlists
                .Where(p => p.UserId == userId)
                .ToList();

            if (!playlists.Any())
            {
                UI.PrintWarningMessage("You haven't created any playlists yet.");
                return;
            }

            Console.WriteLine("Your playlists:");
            foreach (var playlist in playlists)
            {
                var trackCount = _dbContext.PlaylistTracks
                    .Count(pt => pt.PlaylistId == playlist.PlaylistId);
                UI.PrintSuccessMessage($"- '{playlist.PlaylistName}' (Created: {playlist.CreationDate.ToShortDateString()}, Tracks: {trackCount})");
            }
        }
        public void ShowCollection(int userId)
        {
            var collections = _dbContext.UserCollections
                .Include(uc => uc.Album)
                .ThenInclude(a => a.Artist)
                .Include(uc => uc.User)
                .ThenInclude(u => u.Reviews)
                .Where(uc => uc.UserId == userId)
                .ToList();

            if (!collections.Any())
            {
                UI.PrintWarningMessage("Your collection is empty.");
                return;
            }

            Console.WriteLine("Your collection:");
            foreach (var collection in collections)
            {
                var album = collection.Album;
                var rating = collection.User.Reviews
                    .FirstOrDefault(r => r.AlbumId == album.AlbumId)?.Rating;

                var ratingText = rating.HasValue ? $"Rated: {(int)rating} stars" : "Not rated";
                UI.PrintSuccessMessage($"- '{album.Title}' by {album.Artist.Name} ({collection.Status}) - {ratingText}");
            }
        }
        public void ShowAlbum(string albumName)
        {
            var album = _dbContext.Albums
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .AsEnumerable()
                .FirstOrDefault(a => a.Title.Equals(albumName, StringComparison.OrdinalIgnoreCase));

            if (!CheckAlbum(album, albumName))
                return;

            Console.WriteLine($"Album: '{album.Title}' by {album.Artist.Name}");
            Console.WriteLine($"Genres: {string.Join(", ", album.Genres)}");
            Console.WriteLine($"Release Date: {album.ReleaseDate}");
            Console.WriteLine($"Number of Tracks: {album.NumberOfTracks}");
            Console.WriteLine($"Totale length : {album.Length:mm\\:ss}");
            Console.WriteLine($"Label: {album.Label}");
            Console.WriteLine($"Format: {album.Format}");

            if (!album.Tracks.Any())
            {
                UI.PrintErrorMessage("No tracks found for this album.");
                return;
            }

            Console.WriteLine("Tracks:");
            var sortedTracks = album.Tracks.OrderBy(t => t.PositionInAlbum).ToList();
            foreach (var track in sortedTracks)
            {
                UI.PrintSuccessMessage($"- {track.PositionInAlbum}. {track.Title} ({track.Length:mm\\:ss})");
            }
        }
        public void ShowAlbumsByArtist(string artistName)
        {
            var artist = _dbContext.Artists
                .Include(a => a.Albums)
                .AsEnumerable()
                .FirstOrDefault(a => a.Name.Equals(artistName, StringComparison.OrdinalIgnoreCase));
            
            if (artist == null)
            {
                UI.PrintErrorMessage($"Artist '{artistName}' not found.");
                return;
            }

            if (!artist.Albums.Any())
            {
                UI.PrintErrorMessage($"No albums found for '{artist.Name}'.");
                return;
            }

            Console.WriteLine($"Albums by '{artist.Name}':");
            foreach (var album in artist.Albums.OrderBy(a => a.ReleaseDate))
            {
                UI.PrintSuccessMessage($"- '{album.Title}' (Released: {album.ReleaseDate} - Total length : ({album.Length:mm\\:ss}), Format: {album.Format})");
            }
        }
        public void SearchTrack(string trackName)
        {
            var tracks = _dbContext.Tracks
                .Include(t => t.Album)
                .ThenInclude(a => a.Artist)
                .Where(t => t.Title.ToLower().Contains(trackName.ToLower()))
                .ToList();

            if (!tracks.Any())
            {
                UI.PrintErrorMessage($"No tracks found matching '{trackName}'.");
                return;
            }

            Console.WriteLine($"Tracks matching '{trackName}':");
            foreach (var track in tracks)
            {
                UI.PrintSuccessMessage($"- '{track.Title}' by {track.Album.Artist.Name} (Album: '{track.Album.Title}', Length: {track.Length:mm\\:ss}, Position: {track.PositionInAlbum})");
                if (!string.IsNullOrEmpty(track.Songwriters))
                    Console.WriteLine($"  Songwriters: {track.Songwriters}");
            }
        }
        public void SearchArtist(string artistName)
        {
            var artists = _dbContext.Artists
                .Where(a => a.Name.ToLower().Contains(artistName.ToLower()))
                .ToList();

            if (!artists.Any())
            {
                UI.PrintErrorMessage($"No artists found matching '{artistName}'.");
                return;
            }

            Console.WriteLine($"Artists matching '{artistName}':");
            foreach (var artist in artists)
            {
                var activeYears = artist.DisbandDate.HasValue
                    ? $"{artist.FormationDate.Year} - {artist.DisbandDate.Value.Year}"
                    : $"{artist.FormationDate.Year} - Present";
                UI.PrintSuccessMessage($"- '{artist.Name}' (Country: {artist.Country}, Active: {activeYears}, Genres: {artist.Genres})");
                
                if (!string.IsNullOrEmpty(artist.Biography))
                    Console.WriteLine($"  Biography: {artist.Biography}");
            }
        }
        public void SearchAlbum(string albumName) 
        {
            var albums = _dbContext.Albums
                .Include(a => a.Artist)
                .Where(a => a.Title.ToLower().Contains(albumName.ToLower()))
                .ToList();


            if (!albums.Any())
            {
                UI.PrintErrorMessage($"No albums found matching '{albumName}'.");
                return;
            }

            Console.WriteLine($"Albums matching '{albumName}':");
            foreach(var album in albums)
            {
                UI.PrintSuccessMessage($"- {album.Title} - {album.Artist.Name} - Total length : {album.Length:mm\\:ss} - Tracks : {album.NumberOfTracks}");
            }
        }
        public void SearchAlbumsByRate(int rate)
        {
            if(!CheckRate(rate))
                return;

            var albums = _dbContext.Reviews
                .Where(r => (int)r.Rating == rate)
                .Include(r => r.Album)
                .ThenInclude(a => a.Artist)
                .Select(r => r.Album)
                .Distinct()
                .ToList();

            if (!albums.Any())
            {
                UI.PrintErrorMessage($"No albums found with a rating of {rate} stars.");
                return;
            }

            Console.WriteLine($"Albums with a rating of {rate} stars:");
            foreach (var album in albums)
            {
                UI.PrintSuccessMessage($"- '{album.Title}' by {album.Artist.Name} (Released: {album.ReleaseDate}, Format: {album.Format})");
            }
        }
        public void ShowAlbumsByGenre(string genreName)
        {
            var albums = _dbContext.Albums
            .Include(a => a.Artist)
            .ToList()
            .Where(a => a.Genres
                .Any(g => g != null && g.ToLower() == genreName.ToLower()))
            .ToList();

            if (!albums.Any())
            {
                UI.PrintErrorMessage($"No albums found for genre '{genreName}'.");
                return;
            }

            Console.WriteLine($"Albums in genre '{genreName}':");
            foreach (var album in albums)
            {
                UI.PrintSuccessMessage($"- '{album.Title}' by {album.Artist.Name} (Released: {album.ReleaseDate}, Format: {album.Format})");
            }
        }
        public void RemoveFromPlaylist(int userId, string trackName, string playlistName)
        {
            var playlist = _dbContext.Playlists
                .AsEnumerable()
                .FirstOrDefault(p => p.UserId == userId && p.PlaylistName.Equals(playlistName, StringComparison.OrdinalIgnoreCase));

            if (playlist == null)
            {
                Console.WriteLine($"Playlist '{playlistName}' not found.");
                return;
            }

            var track = _dbContext.Tracks
                .Include(t => t.Album)
                .ThenInclude(a => a.Artist)
                .AsEnumerable()
                .FirstOrDefault(t => t.Title.Equals(trackName, StringComparison.OrdinalIgnoreCase));

            if (track == null)
            {
                Console.WriteLine($"Track '{trackName}' not found.");
                return;
            }

            var playlistTrack = _dbContext.PlaylistTracks
                .FirstOrDefault(pt => pt.PlaylistId == playlist.PlaylistId && pt.TrackId == track.TrackId);

            if (playlistTrack == null)
            {
                Console.WriteLine($"Track '{trackName}' is not in playlist '{playlistName}'.");
                return;
            }

            // deleting track from playlisr
            _dbContext.PlaylistTracks.Remove(playlistTrack);

            // get new number for all the rest tracks
            var remainingTracks = _dbContext.PlaylistTracks
                .Where(pt => pt.PlaylistId == playlist.PlaylistId)
                .OrderBy(pt => pt.Position)
                .ToList();

            for (int i = 0; i < remainingTracks.Count; i++)
            {
                remainingTracks[i].Position = i + 1;
            }

            _dbContext.SaveChanges();
            UI.PrintSuccessMessage($"Removed '{trackName}' from playlist '{playlistName}'.");
        }
        public void DeletePlaylist(int userId, string playlistName)
        {
            var playlist = _dbContext.Playlists
                .AsEnumerable()
                .FirstOrDefault(p => p.UserId == userId &&
                p.PlaylistName.Equals(playlistName, StringComparison.OrdinalIgnoreCase));

            if (playlist == null)
            {
                UI.PrintWarningMessage($"Playlist '{playlistName}' not found.");
                return;
            }

            // deleting all related PlaylistTracks
            var playlistTracks = _dbContext.PlaylistTracks
                .Where(pt => pt.PlaylistId == playlist.PlaylistId)
                .ToList();
            _dbContext.PlaylistTracks.RemoveRange(playlistTracks);

            // deleting the playlist itself
            _dbContext.Playlists.Remove(playlist);

            _dbContext.SaveChanges();
            UI.PrintSuccessMessage($"Deleted playlist '{playlistName}'.");
        }
        public void RenamePlaylist(int userId, string OldPlaylistName, string newPlaylistName)
        {
            var playlist = _dbContext.Playlists
                .AsEnumerable()
                .FirstOrDefault(p => p.UserId == userId &&
                p.PlaylistName.Equals(OldPlaylistName, StringComparison.OrdinalIgnoreCase));
            
            if (playlist == null)
            {
                UI.PrintErrorMessage($"Playlist '{OldPlaylistName}' not found.");
                return;
            }

            if (newPlaylistName == null) 
            {
                UI.PrintErrorMessage($"Enter correct NewPlaylistName");
                return;
            }

            playlist.PlaylistName = newPlaylistName;
            _dbContext.SaveChanges();
            UI.PrintSuccessMessage("The name changed successfully!");
        }
        public void ShowWishlist(int userId)
        {
            var wishlist = _dbContext.UserCollections
                .Include(uc => uc.Album)
                .ThenInclude(a => a.Artist)
                .Include(uc => uc.User)
                .ThenInclude(u => u.Reviews)
                .Where(uc => uc.UserId == userId && uc.Status == CollectionStatus.Wishlist)
                .ToList();

            if (!wishlist.Any())
            {
                UI.PrintWarningMessage("Your wishlist is empty.");
                return;
            }

            Console.WriteLine("Your wishlist:");
            foreach (var collection in wishlist)
            {
                var album = collection.Album;
                var rating = collection.User.Reviews
                    .FirstOrDefault(r => r.AlbumId == album.AlbumId)?.Rating;
                var ratingText = rating.HasValue ? $"Rated: {(int)rating} stars" : "Not rated";
                UI.PrintSuccessMessage($"- '{album.Title}' by {album.Artist.Name} - {ratingText}");
            }
        }

        public void ShowBought(int userId)
        {
            var bought = _dbContext.UserCollections
                .Include(uc => uc.Album)
                .ThenInclude(a => a.Artist)
                .Include(uc => uc.User)
                .ThenInclude(u => u.Reviews)
                .Where(uc => uc.UserId == userId && uc.Status == CollectionStatus.Purchased)
                .ToList();

            if (!bought.Any())
            {
                UI.PrintWarningMessage("You haven't purchased any albums yet.");
                return;
            }

            Console.WriteLine("Your purchased albums:");
            foreach (var collection in bought)
            {
                var album = collection.Album;
                var rating = collection.User.Reviews
                    .FirstOrDefault(r => r.AlbumId == album.AlbumId)?.Rating;
                var ratingText = rating.HasValue ? $"Rated: {(int)rating} stars" : "Not rated";
                UI.PrintSuccessMessage($"- '{album.Title}' by {album.Artist.Name} - {ratingText}");
            }
        }
    }
}