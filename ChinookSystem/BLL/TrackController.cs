using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.POCOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> Track_List()
        {
            //create a transaction instance of context class
            using (var context = new ChinookContext())
            {
                return context.Tracks.OrderBy(x => x.Name).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Track Track_Get(int trackid)
        {
            //create a transaction instance of context class
            using (var context = new ChinookContext())
            {
                return context.Tracks.Find(trackid);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> Track_GetByAlbumID(int albumid)
        {
            //create a transaction instance of context class
            using (var context = new ChinookContext())
            {
                return context.Tracks.Where(x => x.AlbumId == albumid).Select(x => x).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<TrackList> List_TracksForPlaylistSelection(string passedparameter, int argid)
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Tracks
                              orderby x.Name
                              where passedparameter.Equals("Artist") ? x.Album.ArtistId == argid :
                              passedparameter.Equals("MediaType") ? x.MediaType.MediaTypeId == argid :
                              passedparameter.Equals("Genre") ? x.Genre.GenreId == argid :
                              x.AlbumId == argid
                              select new TrackList
                              {
                                  TrackID = x.TrackId,
                                  Name = x.Name,
                                  Title = x.Album.Title,
                                  MediaName = x.MediaType.Name,
                                  GenreName = x.Genre.Name,
                                  Composer = x.Composer,
                                  Milliseconds = x.Milliseconds,
                                  Bytes = x.Bytes,
                                  UnitPrice = x.UnitPrice
                              };
                return results.ToList();
            }
        }//eom


    }//eoc
}
