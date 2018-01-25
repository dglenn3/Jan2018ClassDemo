using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jan2018DemoWebsite.SamplePages
{
    public partial class ODSQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AlbumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //first, we wish to access the specific row that was selected by pressing the View link which is the select command button of the gridview
            //remember, the View link is a Command Button
            GridViewRow agvrow = AlbumList.Rows[AlbumList.SelectedIndex];
            //access the data from the GridView Template control
            //use the .FindControl("IdControlName") to access the desired control
            string albumid = (agvrow.FindControl("AlbumId") as Label).Text;
            //send the extracted value to another specified page
            //pagename?parameterset&parameterset
            //? parameter set following
            //parameter set idlabel=value
            //& separates multiple parameter sets
            Response.Redirect("AlbumDetails.aspx?aid=" + albumid);
        }
    }
}