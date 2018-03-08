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
            //code to go here
           
        }

        protected void MoveDown_Click(object sender, EventArgs e)
        {
            //code to go here
        }

        protected void MoveUp_Click(object sender, EventArgs e)
        {
            //code to go here
        }

        protected void DeleteTrack_Click(object sender, EventArgs e)
        {
            //code to go here
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
                }, "Track Added", "The has been added, check your list below");
            }
        }

    }
}