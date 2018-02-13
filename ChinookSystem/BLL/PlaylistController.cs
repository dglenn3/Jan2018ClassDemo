using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class PlaylistController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ClientPlaylist> Playlist_ClientPlaylist(int trackCountLimit)
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Playlists
                              where x.PlaylistTracks.Count() >= trackCountLimit
                              select new ClientPlaylist
                              {
                                  playlistName = x.Name,
                                  playlistTracks = (from y in x.PlaylistTracks
                                                    select new TracksAndGenre
                                                    {
                                                        songTitle = y.Track.Name,
                                                        songGenre = y.Track.Genre.Name
                                                    }).ToList()
                              };
                return results.ToList();
            }
        }
    }
}
