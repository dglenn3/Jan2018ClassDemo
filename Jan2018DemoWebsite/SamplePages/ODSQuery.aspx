<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ODSQuery.aspx.cs" Inherits="Jan2018DemoWebsite.SamplePages.ODSQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>ODS Query</h3>
    <div class="row">
        <asp:GridView ID="AlbumList" runat="server" AutoGenerateColumns="False" DataSourceID="AlbumListODS" AllowPaging="True" BorderStyle="None" GridLines="Horizontal" CellPadding="5" CellSpacing="5" PageSize="15" RowStyle-Wrap="False" RowStyle-HorizontalAlign="NotSet" OnSelectedIndexChanged="AlbumList_SelectedIndexChanged">
            <Columns>
                <asp:CommandField SelectText="View" ShowSelectButton="True"></asp:CommandField>
                <asp:TemplateField HeaderText="Title" SortExpression="Title">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Title") %>' ID="Label2"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Artist" SortExpression="ArtistId">
                    <ItemTemplate>
                        <asp:DropDownList ID="ArtistList" runat="server" DataSourceID="ArtistListODS" DataTextField="Name" DataValueField="ArtistId" SelectedValue='<%# Eval("ArtistId") %>' Width="300px"></asp:DropDownList>
                        <%--<asp:Label runat="server" Text='<%# Bind("ArtistId") %>' ID="Label3"></asp:Label>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Year" SortExpression="ReleaseYear">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("ReleaseYear") %>' ID="Label4"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Label" SortExpression="ReleaseLabel">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("ReleaseLabel") %>' ID="Label5"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Id" SortExpression="AlbumId">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("AlbumId") %>' ID="AlbumId"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="AlbumListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Album_List" TypeName="ChinookSystem.BLL.AlbumController"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ArtistListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Artist_List" TypeName="ChinookSystem.BLL.ArtistController"></asp:ObjectDataSource>
    </div>
     <div class="row">
        <asp:Button ID="CountAlbums" runat="server" Text="Count Albums" OnClick="CountAlbums_Click"  />&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Number of Albums per Artist"></asp:Label>
    </div>
    <div>
        <asp:ListView ID="ArtistAlbumCountList" runat="server"
              ItemType="Chinook.Data.POCOs.ArtistAlbumCounts">
            <LayoutTemplate>
                <div >
                    <span runat="server" id="itemPlaceholder" />
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div>
                    <asp:DropDownList ID="ArtistList2" runat="server" 
                        DataSourceID="ArtistListODS" 
                        DataTextField="Name" DataValueField="ArtistId"
                         SelectedValue ='<%# Item.ArtistId %>'
                         Enabled="false">
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                    <%# Item.AlbumCount %> 
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
