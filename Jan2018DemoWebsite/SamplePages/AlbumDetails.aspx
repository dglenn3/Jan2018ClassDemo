﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumDetails.aspx.cs" Inherits="Jan2018DemoWebsite.SamplePages.AlbumDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Passing Data</h3>
    <asp:Label ID="Label1" runat="server" Text="You passed album ID: "></asp:Label>
    &nbsp;&nbsp;
    <asp:Label ID="AlbumIDArg" runat="server"></asp:Label>
    <div class="row">
        <asp:ListView ID="AlbumTracks" runat="server" DataSourceID="AlbumTracksODS" OnItemCommand="AlbumTracks_ItemCommand">
            <AlternatingItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label Text='<%# Eval("TrackId") %>' runat="server" ID="TrackIdLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("AlbumId") %>' runat="server" ID="AlbumIdLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("MediaTypeId") %>' runat="server" ID="MediaTypeIdLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("GenreId") %>' runat="server" ID="GenreIdLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Composer") %>' runat="server" ID="ComposerLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Milliseconds") %>' runat="server" ID="MillisecondsLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Bytes") %>' runat="server" ID="BytesLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("UnitPrice") %>' runat="server" ID="UnitPriceLabel" /></td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="Pick" CommandName="Select" CommandArgument='<%# Eval("TrackId") %>'/>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label Text='<%# Eval("TrackId") %>' runat="server" ID="TrackIdLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("AlbumId") %>' runat="server" ID="AlbumIdLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("MediaTypeId") %>' runat="server" ID="MediaTypeIdLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("GenreId") %>' runat="server" ID="GenreIdLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Composer") %>' runat="server" ID="ComposerLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Milliseconds") %>' runat="server" ID="MillisecondsLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Bytes") %>' runat="server" ID="BytesLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("UnitPrice") %>' runat="server" ID="UnitPriceLabel" /></td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="Pick" CommandName="Select" CommandArgument='<%# Eval("TrackId") %>'/>
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                <tr runat="server" style="">
                                    <th runat="server">Id</th>
                                    <th runat="server">Name</th>
                                    <th runat="server">Media</th>
                                    <th runat="server">Genre</th>
                                    <th runat="server">Composer</th>
                                    <th runat="server">Milliseconds</th>
                                    <th runat="server">Bytes</th>
                                    <th runat="server">Price</th>
                                    <th runat="server"></th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager runat="server" ID="DataPager1">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            </asp:ListView>
        <asp:ObjectDataSource ID="AlbumTracksODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Track_GetByAlbumID" TypeName="ChinookSystem.BLL.TrackController">
            <SelectParameters>
                <asp:ControlParameter ControlID="AlbumIDArg" PropertyName="Text" DefaultValue="0" Name="albumid" Type="Int32"></asp:ControlParameter>
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <div class="row">
        <asp:Label ID="Label3" runat="server" Text="Total time and size"></asp:Label>&nbsp;&nbsp;
        <asp:LinkButton ID="Totals" runat="server" OnClick="Totals_Click" >Totals</asp:LinkButton>&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Time: "></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="TracksTime" runat="server" ></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Text="Size: "></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="TracksSize" runat="server" ></asp:Label>
    </div>
     <div class="row">
        <asp:Label ID="Label2" runat="server" Text="You picked track id: "></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Command Arg: "></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="CommandArgID" runat="server" ></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Column : "></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="ColumnID" runat="server" ></asp:Label>
    </div>
</asp:Content>
