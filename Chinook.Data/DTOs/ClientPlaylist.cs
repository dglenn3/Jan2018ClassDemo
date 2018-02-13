using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using Chinook.Data.POCOs;
#endregion
namespace Chinook.Data.DTOs
{
    public class ClientPlaylist
    {
        public string playlistName { get; set; }
        public List<TracksAndGenre> playlistTracks { get; set; }
    }
}
