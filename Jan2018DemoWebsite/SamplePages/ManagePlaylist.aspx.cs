using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ChinookSystem.BLL;
using Chinook.Data.POCOs;
#endregion

namespace Jan2018DemoWebsite.SamplePages
{
    public partial class ManagePlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TracksSelectionList.DataSource = null;
        }

       

        protected void ArtistFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                TracksBy.Text = "Artist";
                SearchArgID.Text = ArtistDDL.SelectedValue;
                TrackSelectionListODS.DataBind();
            },"Tracks by artist","Add an artist track to your playlist by clicking on the + (plus sign)");
        }

        protected void MediaTypeFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                TracksBy.Text = "MediaType";
                SearchArgID.Text = MediaTypeDDL.SelectedValue;
                TrackSelectionListODS.DataBind();
            }, "Tracks by media type", "Add a media type track to your playlist by clicking on the + (plus sign)");
        }

        protected void GenreFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                TracksBy.Text = "Genre";
                SearchArgID.Text = GenreDDL.SelectedValue;
                TrackSelectionListODS.DataBind();
            }, "Tracks by genre", "Add a genre track to your playlist by clicking on the + (plus sign)");
        }

        protected void AlbumFetch_Click(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                TracksBy.Text = "Album";
                SearchArgID.Text = AlbumDDL.SelectedValue;
                TrackSelectionListODS.DataBind();
            }, "Tracks by album", "Add an album track to your playlist by clicking on the + (plus sign)");
        }

        protected void PlayListFetch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Required data", "Playlist name is required to retrieve tracks");
            }
            else
            {
                string username = "HansenB";
                string playlistname = PlaylistName.Text;
                MessageUserControl.TryRun(() =>
                {
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    List<UserPlaylistTrack> results = sysmgr.List_TracksForPlaylist(playlistname, username);
                    if(results.Count() == 0)
                    {
                        MessageUserControl.ShowInfo("Check playlist name");
                    }
                    PlayList.DataSource = results;
                    PlayList.DataBind();
                });
            }
        }

        protected void MoveDown_Click(object sender, EventArgs e)
        {
            if (PlayList.Rows.Count == 0)
            {
                MessageUserControl.ShowInfo("Warning", "You must have a playlist showing. Fetch your playlist");
            }
            else
            {
                if (string.IsNullOrEmpty(PlaylistName.Text))
                {
                    MessageUserControl.ShowInfo("Warning", "You must have a playlist name. Enter your playlist name");
                    //optionally, you might wish to empty the Playlist GridView
                }
                else
                {
                    //check that a single track has been selected (checked)
                    //if so, extract the needed data from the selected GridView row
                    //the trackID is a hidden column on the GridView row
                    int trackid = 0;
                    int tracknumber = 0;
                    int rowselected = 0;
                    CheckBox playlistselection = null;
                    for (int rowindex = 0; rowindex < PlayList.Rows.Count; rowindex++)
                    {
                        //access the control on the selected GridView row
                        //pointer to the checkbox
                        playlistselection = PlayList.Rows[rowindex].FindControl("Selected") as CheckBox;
                        //is the CheckBox on?
                        if (playlistselection.Checked)
                        {
                            rowselected++; //counter for number of checked items
                            //save necessary data for moving a track
                            trackid = int.Parse((PlayList.Rows[rowindex].FindControl("TrackID") as Label).Text);
                            tracknumber = int.Parse((PlayList.Rows[rowindex].FindControl("TrackNumber") as Label).Text);
                        }
                    }//eof
                    //how many tracks were checked?
                    if (rowselected != 1)
                    {
                        MessageUserControl.ShowInfo("Warning", "Select one track to move");
                    }
                    else
                    {
                        //is the selected track the first track?
                        if (tracknumber == PlayList.Rows.Count)
                        {
                            MessageUserControl.ShowInfo("Warning", "Track cannot be moved up");
                        }
                        else
                        {
                            //move the track
                            MoveTrack(trackid, tracknumber, "down");
                        }
                    }
                }
            }
        }

        protected void MoveUp_Click(object sender, EventArgs e)
        {
            if(PlayList.Rows.Count == 0)
            {
                MessageUserControl.ShowInfo("Warning", "You must have a playlist showing. Fetch your playlist");
            }
            else
            {
                if(string.IsNullOrEmpty(PlaylistName.Text))
                {
                    MessageUserControl.ShowInfo("Warning", "You must have a playlist name. Enter your playlist name");
                    //optionally, you might wish to empty the Playlist GridView
                }
                else
                {
                    //check that a single track has been selected (checked)
                    //if so, extract the needed data from the selected GridView row
                    //the trackID is a hidden column on the GridView row
                    int trackid = 0;
                    int tracknumber = 0;
                    int rowselected = 0;
                    CheckBox playlistselection = null;
                    for(int rowindex = 0; rowindex < PlayList.Rows.Count; rowindex++ )
                    {
                        //access the control on the selected GridView row
                        //pointer to the checkbox
                        playlistselection = PlayList.Rows[rowindex].FindControl("Selected") as CheckBox;
                        //is the CheckBox on?
                        if (playlistselection.Checked)
                        {
                            rowselected++; //counter for number of checked items
                            //save necessary data for moving a track
                            trackid = int.Parse((PlayList.Rows[rowindex].FindControl("TrackID") as Label).Text);
                            tracknumber = int.Parse((PlayList.Rows[rowindex].FindControl("TrackNumber") as Label).Text);
                        }
                    }//eof
                    //how many tracks were checked?
                    if(rowselected != 1)
                    {
                        MessageUserControl.ShowInfo("Warning", "Select one track to move");
                    }
                    else
                    {
                        //is the selected track the first track?
                        if(tracknumber == 1)
                        {
                            MessageUserControl.ShowInfo("Warning", "Track cannot be moved up");
                        }
                        else
                        {
                            //move the track
                            MoveTrack(trackid, tracknumber, "up");
                        }
                    }
                }
            }
        }

        protected void MoveTrack(int trackid, int tracknumber, string direction)
        {
            //call BLL to move track
            MessageUserControl.TryRun(() =>
            {
                PlaylistTracksController sysmgr = new PlaylistTracksController();
                sysmgr.MoveTrack("HansenB", PlaylistName.Text, trackid, tracknumber, direction);
                List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(PlaylistName.Text, "HansenB");
                PlayList.DataSource = info;
                PlayList.DataBind();
            },"Moved", "Track has been moved " + direction);
        }

        protected void DeleteTrack_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Enter a playlist name");
            }
            else
            {
                if(PlayList.Rows.Count == 0)
                {
                    MessageUserControl.ShowInfo("Playlist has no tracks to delete");
                }
                else
                {
                    //gather all selected rows
                    List<int> trackstodelete = new List<int>();
                    int rowsselected = 0;
                    CheckBox playlistselection;
                    for(int rowindex = 0; rowindex < PlayList.Rows.Count; rowindex++)
                    {
                        playlistselection = PlayList.Rows[rowindex].FindControl("Selected") as CheckBox;
                        if(playlistselection.Checked)
                        {
                            rowsselected++;
                            trackstodelete.Add(int.Parse((PlayList.Rows[rowindex].FindControl("TrackID") as Label).Text));
                        }
                    }
                    //was at least one track selected?
                    if(rowsselected == 0)
                    {
                        //nothing was selected
                        MessageUserControl.ShowInfo("Warning", "Select tracks to delete");
                    }
                    else
                    {
                        //send the list of tracks to the BLL to delete
                        MessageUserControl.TryRun(() => 
                        {
                            PlaylistTracksController sysmgr = new PlaylistTracksController();
                            sysmgr.DeleteTracks("HansenB", PlaylistName.Text, trackstodelete);
                            List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(PlaylistName.Text, "HansenB");
                            PlayList.DataSource = info;
                            PlayList.DataBind();
                        },"Removed", "Tracks have been removed");
                    }
                }
            }
        }

        protected void TracksSelectionList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //this method will only execute if the user has pressed the plus sign on a visible row from the display
           if(string.IsNullOrEmpty(PlaylistName.Text))
            {
                MessageUserControl.ShowInfo("Playlist Name", "You must supply a playlist name"); 
            }
            else
            {
                //via security, one can obtain the username
                string username = "HansenB";
                string playlistname = PlaylistName.Text;

                //the trackid is attached to each listview row via the CommandArgument parameter
                //access to the trackid is done via the ListViewCommandEventArgs e parameter
                //the e parameter is treated as an object
                //some e parameters need to be cast as strings
                int trackid = int.Parse(e.CommandArgument.ToString());
                //all required data can now be sent to the BLL for further processing
                //user friendly error handling
                MessageUserControl.TryRun(() => 
                {
                    //connect to BLL
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    sysmgr.Add_TrackToPLaylist(playlistname, username, trackid);
                    //code to retrieve the up to date playlist and tracks for refreshing the playlist track list
                    List<UserPlaylistTrack> info = sysmgr.List_TracksForPlaylist(playlistname, username);
                    PlayList.DataSource = info;
                    PlayList.DataBind();
                }, "Track Added", "The track has been added, check your list below");
            }
        }

    }
}