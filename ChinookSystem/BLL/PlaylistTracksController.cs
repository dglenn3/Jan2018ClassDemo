using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
using ChinookSystem.DAL;
using System.ComponentModel;
using DMIT2018Common.UserControls;
#endregion

namespace ChinookSystem.BLL
{
    public class PlaylistTracksController
    {
        public List<UserPlaylistTrack> List_TracksForPlaylist(
            string playlistname, string username)
        {
            using (var context = new ChinookContext())
            {

                //what would happen if there is no match for the incoming parameter values?
                //validate that a playlist actually exists
                var results = (from x in context.Playlists where x.UserName.Equals(username) && x.Name.Equals(playlistname) select x).FirstOrDefault();
                if (results == null)
                {
                    return null;
                }
                else
                {
                    var theTracks = from x in context.PlaylistTracks
                                    where x.PlaylistId.Equals(results.PlaylistId)
                                    orderby x.TrackNumber
                                    select new UserPlaylistTrack
                                    {
                                        TrackID = x.TrackId,
                                        TrackNumber = x.TrackNumber,
                                        TrackName = x.Track.Name,
                                        Milliseconds = x.Track.Milliseconds,
                                        UnitPrice = x.Track.UnitPrice
                                    };
                    return theTracks.ToList();
                }

                
            }
        }//eom
        public void Add_TrackToPLaylist(string playlistname, string username, int trackid)
        {
            using (var context = new ChinookContext())
            {
                //this list of strings will be used with the BusinessRuleException
                List<string> reasons = new List<string>();
                //Part One
                //optional add of the new playlist
                //validate track is not on the existing playlist
                //determine if the playlist already exists on the database
                Playlist exists = context.Playlists.Where(x => x.Name.Equals(playlistname, StringComparison.OrdinalIgnoreCase) && x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)).Select(x => x).FirstOrDefault();
                PlaylistTrack newTrack = null;
                int tracknumber = 0;

                if (exists == null)
                {
                    //add the parent record (Playlist record)
                    //no tracks exists yet for the new playlist
                    //therefore, the track number is 1
                    exists = new Playlist();
                    exists.Name = playlistname;
                    exists.UserName = username;
                    exists = context.Playlists.Add(exists);
                    tracknumber = 1;
                }
                else
                {
                    //the playlist exists on the database
                    //the playlist may or may not have any tracks
                    //adjust the track number to be the next track
                    tracknumber = exists.PlaylistTracks.Count() + 1;
                    //will this be a duplicate track?
                    //look up the tracks of the playlist testing for the incoming trackid
                    newTrack = exists.PlaylistTracks.SingleOrDefault(x => x.TrackId == trackid);
                    //validation rule: track may only exist once on the playlist
                    if(newTrack != null)
                    {
                        //rule is violated
                        //track already exists on playlist
                        //throw exception to stop OLTP processing (rollback)
                        //this example will demonstrate using the BusinessRuleException
                        reasons.Add("Track already exists on the playlist");
                    }
                }
                //Part two
                //check if any errors were found
                if (reasons.Count > 0)
                {
                    //issue a BusinessRuleException
                    //a BusinessRuleException is an object that has been designed to hold multiple errors
                    throw new BusinessRuleException("Adding track to playlist", reasons);
                }
                else
                {
                    //add the track to the PlaylistTracks
                    newTrack = new PlaylistTrack();
                    newTrack.TrackNumber = tracknumber;
                    newTrack.TrackId = trackid;
                    //what about the foreign key to playlist?
                    //the parent entity has been set up with a Hashset
                    //therefore, if you add a child via the navigational property, 
                    //the Hashset will take care of filling the foreign key with the appropriate pKey value during .SaveChanges()
                    //add the new track to the playlist using the navigational property
                    exists.PlaylistTracks.Add(newTrack);
                    //physically place the record(s) on the database and commit the transaction (using) with .SaveChanges()
                    context.SaveChanges();
                }
            }
        }//eom
        public void MoveTrack(string username, string playlistname, int trackid, int tracknumber, string direction)
        {
            using (var context = new ChinookContext())
            {
                var exists = (from x in context.Playlists where x.Name.Equals(playlistname) && x.UserName.Equals(username) select x).FirstOrDefault();
                if(exists == null)
                {
                    throw new Exception("Playlist has been removed from the files");
                }
                else
                {
                    PlaylistTrack moveTrack = (from x in exists.PlaylistTracks where x.TrackId.Equals(trackid) select x).FirstOrDefault();
                    if(moveTrack == null)
                    {
                        throw new Exception("Playlist track has been removed from the files");
                    }
                    else
                    {
                        if(direction.Equals("up"))
                        {
                            //up
                        }
                        else
                        {
                            //down
                        }
                    }
                }
            }
        }//eom


        public void DeleteTracks(string username, string playlistname, List<int> trackstodelete)
        {
            using (var context = new ChinookContext())
            {
               //code to go here


            }
        }//eom
    }
}
