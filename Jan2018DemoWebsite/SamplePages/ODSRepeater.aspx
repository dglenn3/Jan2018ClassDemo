<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ODSRepeater.aspx.cs" Inherits="Jan2018DemoWebsite.SamplePages.ODSRepeater" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Repeater for nested Linq query</h1>
    <asp:CompareValidator ID="TrackCountLimitCompare" runat="server" ErrorMessage="Invalid limit value" ControlToValidate="TrackCountLimit" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
    <asp:RangeValidator ID="TrackCountLimitRange" ControlToValidate="TrackCountLimit" runat="server" ErrorMessage="Limit must be greater than 0" MinimumValue="0" MaximumValue ="100" Type="Integer"></asp:RangeValidator>
    <asp:Label ID="Label1" runat="server" Text="Enter playlist track lower limit" ></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    &nbsp;
    <asp:TextBox ID="TrackCountLimit" runat="server" TextMode="Number"></asp:TextBox>
    &nbsp;
    <asp:Button ID="DisplayClientPlaylist" runat="server" Text="Display Client Playlists" class="btn btn-primary"/>
    <br />
    <asp:Repeater ID="ClientPlaylist" runat="server" DataSourceID="ODSClientPlaylist" ItemType="Chinook.Data.DTOs.ClientPlaylist">
        <HeaderTemplate>
            <h3>Client Playlist</h3>
        </HeaderTemplate>
        <ItemTemplate>
            <h4><%#Item.playlistName %></h4>
            <asp:Repeater ID="PlaylistSongs" runat="server" DataSource="<%#Item.playlistTracks %>" ItemType="Chinook.Data.POCOs.TracksAndGenre">
                <ItemTemplate>
                    <%#Item.songTitle %> (<%#Item.songGenre %>)<br />
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <%#Item.songTitle %> (<%#Item.songGenre %>)<br />
                </AlternatingItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ODSClientPlaylist" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Playlist_ClientPlaylist" TypeName="ChinookSystem.BLL.PlaylistController">
        <SelectParameters>
            <asp:ControlParameter ControlID="TrackCountLimit" PropertyName="Text" Name="trackCountLimit" Type="Int32" DefaultValue="1"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
