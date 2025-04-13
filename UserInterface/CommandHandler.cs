using MusicalCollection.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicalCollection.UserInterface;
namespace MusicalCollection.UserInterface
{
    public class CommandHandler
    {
        private readonly MusicCollectionService _service;
        private readonly int _userId;
        private readonly Dictionary<string, Action<string[]>> _commands;

        UserInterfaceService UI = new UserInterfaceService();
        public CommandHandler(MusicCollectionService service, int userId)
        {
            _service = service;
            _userId = userId;
            _commands = new Dictionary<string, Action<string[]>>
            {
                { "add-to-collection", parts =>
                    {
                        if (parts.Length == 2)
                            _service.AddToCollection(_userId, parts[1]);
                        else
                            UI.PrintFormatErrorMessage("add-to-collection", "AlbumName");
                    } },
                { "buy-album", parts =>
                    {
                        if (parts.Length == 2)
                            _service.BuyAlbum(_userId, parts[1]);
                        else
                            UI.PrintFormatErrorMessage("buy-album", "AlbumName");
                    } },
                { "add-to-playlist", parts =>
                    {
                        if (parts.Length == 3)
                            _service.AddToPlaylist(_userId, parts[1], parts[2]);
                        else
                            UI.PrintFormatErrorMessage("add-to-playlist", "TrackName", "PlaylistName");
                    } },
                { "add-new-playlist", parts =>
                    {
                        if (parts.Length == 2)
                            _service.AddNewPlaylist(_userId, parts[1]);
                        else
                            UI.PrintFormatErrorMessage("add-new-playlist", "PlaylistName");
                    } },
                { "rename-playlist", parts =>
                    {
                        if (parts.Length == 3)
                            _service.RenamePlaylist(_userId, parts[1], parts[2]);
                        else
                            UI.PrintFormatErrorMessage("rename-playlist", "OldPlaylistName", "NewPlaylistName");
                    }},
                { "set-rate", parts =>
                    {
                        if (parts.Length == 3 && int.TryParse(parts[2], out int rate)){
                            Console.Write("Enter your commentary> ");
                            string comment = Console.ReadLine();
                            _service.SetAlbumRating(_userId, parts[1], rate, comment);
                        }
                        else
                            UI.PrintFormatErrorMessage("set-rate", "AlbumName", "Rate (1-5)");
                    } },
                { "show-rates", parts =>
                    {
                        if (parts.Length == 1)
                            _service.ShowUserRatings(_userId);
                        else
                            UI.PrintFormatErrorMessage("show-rates");
                    } },
                { "show-playlist", parts =>
                    {
                        if (parts.Length == 2)
                            _service.ShowPlaylist(_userId, parts[1]);
                        else
                            UI.PrintFormatErrorMessage("show-playlist", "PlaylistName");
                    } },
                { "show-collection", parts =>
                    {
                        if (parts.Length == 1)
                            _service.ShowCollection(_userId);
                        else
                            UI.PrintFormatErrorMessage("show-collection");
                    } },
                { "show-my-playlists", parts =>
                    {
                        if (parts.Length == 1)
                            _service.ShowMyPlaylists(_userId);
                        else
                            UI.PrintFormatErrorMessage("show-my-playlists");
                    } },
                { "show-album", parts =>
                    {
                        if (parts.Length == 2)
                            _service.ShowAlbum(parts[1]);
                        else
                            UI.PrintFormatErrorMessage("show-album", "AlbumName");
                    } },
                { "show-albums", parts =>
                    {
                        if (parts.Length == 2)
                            _service.ShowAlbumsByArtist(parts[1]);
                        else
                            UI.PrintFormatErrorMessage("show-albums", "ArtistName");
                    } },
                { "search-track", parts =>
                    {
                        if (parts.Length == 2)
                            _service.SearchTrack(parts[1]);
                        else
                            UI.PrintFormatErrorMessage("search-track", "TrackName");
                    } },
                { "search-artist", parts =>
                    {
                        if (parts.Length == 2)
                            _service.SearchArtist(parts[1]);
                        else
                            UI.PrintFormatErrorMessage("search-artist", "ArtistName");
                    } },
                { "search-album", parts =>
                    {
                        if (parts.Length == 2)
                            _service.SearchAlbum(parts[1]);
                        else
                            UI.PrintFormatErrorMessage("search-album", "AlbumName");
                    } },
                { "search-albums-by-rate", parts =>
                    {
                        if (parts.Length == 2 && int.TryParse(parts[1], out int rate))
                            _service.SearchAlbumsByRate(rate);
                        else
                            UI.PrintFormatErrorMessage("search-albums-by-rate", "Rate (1-5)");
                    } },
                { "show-albums-by-genre", parts =>
                    {
                        if (parts.Length == 2)
                            _service.ShowAlbumsByGenre(parts[1]);
                        else
                            UI.PrintFormatErrorMessage("show-albums-by-genre", "GenreName");
                    } },
                { "remove-from-playlist", parts =>
                    {
                        if (parts.Length == 3)
                            _service.RemoveFromPlaylist(_userId, parts[1], parts[2]);
                        else
                            UI.PrintFormatErrorMessage("remove-from-playlist", "TrackName", "PlaylistName");
                    } },
                { "delete-playlist", parts =>
                    {
                        if (parts.Length == 2)
                            _service.DeletePlaylist(_userId, parts[1]);
                        else
                            UI.PrintFormatErrorMessage("delete-playlist", "PlaylistName");
                    } },
                { "show-wishlist", parts =>
                    {
                        if (parts.Length == 1)
                            _service.ShowWishlist(_userId);
                        else
                            UI.PrintFormatErrorMessage("show-wishlist");
                    } },
                { "show-bought", parts =>
                    {
                        if (parts.Length == 1)
                            _service.ShowBought(_userId);
                        else
                            UI.PrintFormatErrorMessage("show-bought");
                    } },
                { "help", parts =>
                    {
                        if (parts.Length == 1)
                            PrintHelp();
                        else
                            UI.PrintFormatErrorMessage("help");
                    } 
                },
                { "clear", parts =>
                    {
                        if (parts.Length == 1)
                            UI.ClearConsole();
                        else
                            UI.PrintFormatErrorMessage("help");
                    }
                }
            };
        }
        public void PrintHelp()
        {
            Console.WriteLine("Available Commands:");
            Console.WriteLine();

            UI.PrintBlueMessage("Search Commands:".PadRight(50) + "Rating Commands:");
            UI.PrintCyanMessage("  search-track TrackName".PadRight(50) + "  set-rate AlbumName Rate (1-5)");
            UI.PrintCyanMessage("  search-artist ArtistName".PadRight(50) + "  show-rates");
            UI.PrintCyanMessage("  search-album AlbumName".PadRight(50) + "");
            UI.PrintCyanMessage("  search-albums-by-rate Rate (1-5)".PadRight(50) + "");
            UI.PrintCyanMessage("  show-albums-by-genre GenreName".PadRight(50) + "");
            Console.WriteLine();

            UI.PrintBlueMessage("Playlist Commands:".PadRight(50) + "Collection Commands:");
            UI.PrintCyanMessage("  add-to-playlist TrackName PlaylistName".PadRight(50) + "add-to-collection AlbumName");
            UI.PrintCyanMessage("  add-new-playlist PlaylistName".PadRight(50) + "buy-album AlbumName");
            UI.PrintCyanMessage("  remove-from-playlist TrackName PlaylistName".PadRight(50) + "show-collection");
            UI.PrintCyanMessage("  delete-playlist PlaylistName".PadRight(50) + "show-bought");
            UI.PrintCyanMessage("  show-playlist PlaylistName".PadRight(50) + "show-wishlist");
            UI.PrintCyanMessage("  show-my-playlists");
            Console.WriteLine();


            UI.PrintBlueMessage("Other Commands:");
            UI.PrintCyanMessage("  show-album AlbumName");
            UI.PrintCyanMessage("  show-albums ArtistName");
            UI.PrintCyanMessage("  help");
            UI.PrintCyanMessage("  clear");
            UI.PrintCyanMessage("  exit");
        }
        public void HandleCommand(string input)
        {
            if (string.IsNullOrEmpty(input))
                return;

            try
            {
                var parts = ParseCommand(input);
                if (parts.Length == 0)
                    return;

                var command = parts[0].ToLower();
                if (_commands.TryGetValue(command, out var action))
                    action(parts);
                else
                    UI.PrintErrorMessage("Unknown command.");
            }
            catch (Exception ex)
            {
                UI.PrintErrorMessage($"Error: {ex.Message}");
            }
        }
        private string[] ParseCommand(string input)
        {
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 1) return parts;

            if (parts[0].ToLower() == "add-to-playlist" ||
                parts[0].ToLower() == "set-rate" ||
                parts[0].ToLower() == "remove-from-playlist")
            {
                if (parts.Length < 3) return parts;
                var name = string.Join(" ", parts, 1, parts.Length - 2);
                return new[] { parts[0], name, parts[^1] };
            }
            else if (parts[0].ToLower() == "add-to-collection" ||
                     parts[0].ToLower() == "buy-album" ||
                     parts[0].ToLower() == "add-new-playlist" ||
                     parts[0].ToLower() == "show-playlist" ||
                     parts[0].ToLower() == "show-album" ||
                     parts[0].ToLower() == "show-albums" ||
                     parts[0].ToLower() == "search-track" ||
                     parts[0].ToLower() == "search-artist" ||
                     parts[0].ToLower() == "search-album" ||
                     parts[0].ToLower() == "show-albums-by-genre" ||
                     parts[0].ToLower() == "search-albums-by-rate" ||
                     parts[0].ToLower() == "delete-playlist")
            {
                var name = string.Join(" ", parts, 1, parts.Length - 1);
                return new[] { parts[0], name };
            }
            else if (parts[0].ToLower() == "show-rates" ||
                     parts[0].ToLower() == "show-collection" ||
                     parts[0].ToLower() == "show-my-playlists" ||
                     parts[0].ToLower() == "show-wishlist" ||
                     parts[0].ToLower() == "show-bought" ||
                     parts[0].ToLower() == "help")
            {
                return new[] { parts[0] };
            }

            return parts;
        }
    }
}
