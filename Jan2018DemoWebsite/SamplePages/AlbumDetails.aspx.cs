using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jan2018DemoWebsite.SamplePages
{
    public partial class AlbumDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //do the following on the first time through this page
            if(!Page.IsPostBack)
            {
                //Response.Redirect sent a value to this page
                //Request.QueryString["labelid"] will obtain the value sent by Redirect
                //The value is a string
                //If no value was sent, the value will be null
                string albumid = Request.QueryString["aid"];
                if(string.IsNullOrEmpty(albumid))
                {
                    Response.Redirect("ODSQuery.aspx");
                }
                else
                {
                    AlbumIDArg.Text = albumid;
                }
            }
        }

        protected void AlbumTracks_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //ListViewCommandEventArgs e contains the value that was attached to the link on the ListView row
            //The property that you need to access is CommandArgument
            //It is not a string, it has to be converted
            CommandArgID.Text = e.CommandArgument.ToString();
            //Extract a value from a column on the ListView item (row)
            ColumnID.Text = (e.Item.FindControl("TrackIdLabel") as Label).Text;
        }

        protected void Totals_Click(object sender, EventArgs e)
        {
            double time = 0;
            double size = 0;

            //use foreach to cycle through the listview
            foreach(ListViewItem item in this.AlbumTracks.Items)
            {
                time += double.Parse((item.FindControl("MillisecondsLabel") as Label).Text);
                size += double.Parse((item.FindControl("BytesLabel") as Label).Text);

                TracksTime.Text = time.ToString();
                TracksSize.Text = size.ToString();
            }
        }
    }
}