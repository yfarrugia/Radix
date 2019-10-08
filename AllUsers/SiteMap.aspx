<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SiteMap.aspx.vb" Inherits="AllUsers_SiteMap" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                Site Map</td>
        </tr>
        <tr>
            <td style="padding-left: 15px">
                <asp:TreeView ID="tvSiteMap" runat="server" DataSourceID="SiteMapDataSource" 
                    ImageSet="BulletedList2" ShowExpandCollapse="False" Width="100%">
                    <ParentNodeStyle Font-Bold="True" ForeColor="#606A79" />
                    <HoverNodeStyle Font-Bold="True" Font-Underline="False" ForeColor="#92C62E" />
                    <SelectedNodeStyle Font-Italic="False" Font-Underline="False" />
                    <RootNodeStyle Font-Bold="True" ForeColor="#606A79" />
                    <NodeStyle CssClass="Text" HorizontalPadding="10px" NodeSpacing="0px" 
                        VerticalPadding="0px" />
                </asp:TreeView>
                <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

