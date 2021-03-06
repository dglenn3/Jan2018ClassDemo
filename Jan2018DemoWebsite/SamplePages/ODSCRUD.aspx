﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ODSCRUD.aspx.cs" Inherits="Jan2018DemoWebsite.SamplePages.ODSCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>ODS CRUD of Albums </h1>
    <asp:ListView ID="AlbumCRUD" runat="server" DataSourceID="AlbumCRUDODS" InsertItemPosition="FirstItem" DataKeyNames="AlbumId">
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="AlbumIdTextBox" runat="server" Text='<%# Bind("AlbumId") %>' Enabled ="false" width="75px"/>
                </td>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                </td>
                <td>
                    <asp:DropDownList ID="ArtistList" runat="server" DataSourceID="ArtistListODS" DataTextField="Name" DataValueField="ArtistId" SelectedValue='<%# Bind("ArtistId") %>' Width="200px"></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="ReleaseYearTextBox" runat="server" Text='<%# Bind("ReleaseYear") %>' width="50px"/>
                </td>
                <td>
                    <asp:TextBox ID="ReleaseLabelTextBox" runat="server" Text='<%# Bind("ReleaseLabel") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="AlbumIdTextBox" runat="server" Text='<%# Bind("AlbumId") %>' width="75px" Enabled="false"/>
                </td>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                </td>
                <td>
                    <asp:DropDownList ID="ArtistList" runat="server" DataSourceID="ArtistListODS" DataTextField="Name" DataValueField="ArtistId" SelectedValue='<%# Bind("ArtistId") %>' Width="200px"></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="ReleaseYearTextBox" runat="server" Text='<%# Bind("ReleaseYear") %>' width="50px"/>
                </td>
                <td>
                    <asp:TextBox ID="ReleaseLabelTextBox" runat="server" Text='<%# Bind("ReleaseLabel") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="AlbumIdLabel" runat="server" Text='<%# Eval("AlbumId") %>' width="75px"/>
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:DropDownList ID="ArtistList" runat="server" DataSourceID="ArtistListODS" DataTextField="Name" DataValueField="ArtistId" SelectedValue='<%# Eval("ArtistId") %>' Width="200px"></asp:DropDownList>
                    <%--<asp:Label ID="ArtistIdLabel" runat="server" Text='<%# Eval("ArtistId") %>' />--%>
                </td>
                <td>
                    <asp:Label ID="ReleaseYearLabel" runat="server" Text='<%# Eval("ReleaseYear") %>' width="50px"/>
                </td>
                <td>
                    <asp:Label ID="ReleaseLabelLabel" runat="server" Text='<%# Eval("ReleaseLabel") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server"></th>
                                <th runat="server">ID</th>
                                <th runat="server">Title</th>
                                <th runat="server">Artist</th>
                                <th runat="server">Year</th>
                                <th runat="server">Label</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="AlbumIdLabel" runat="server" Text='<%# Eval("AlbumId") %>' />
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:DropDownList ID="ArtistList" runat="server" DataSourceID="ArtistListODS" DataTextField="Name" DataValueField="ArtistId" SelectedValue='<%# Eval("ArtistId") %>' Width="200px"></asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="ReleaseYearLabel" runat="server" Text='<%# Eval("ReleaseYear") %>' width="50px"/>
                </td>
                <td>
                    <asp:Label ID="ReleaseLabelLabel" runat="server" Text='<%# Eval("ReleaseLabel") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>

    </asp:ListView>
    <asp:ObjectDataSource ID="AlbumCRUDODS" runat="server"
        DataObjectTypeName="Chinook.Data.Entities.Album"
        DeleteMethod="Albums_Delete" InsertMethod="Albums_Add"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="Album_List"
        TypeName="ChinookSystem.BLL.AlbumController"
        UpdateMethod="Albums_Update" >
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ArtistListODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="Artist_List"
        TypeName="ChinookSystem.BLL.ArtistController">
    </asp:ObjectDataSource>
</asp:Content>
