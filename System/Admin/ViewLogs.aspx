<%@ Page Language="VB" MasterPageFile="~/System/Admin/SystemMasterPage.master" AutoEventWireup="false" CodeFile="ViewLogs.aspx.vb" Inherits="System_ViewLogs" title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="pnlLoading" runat="server" CssClass="LoadingPanel" >
                <table border="0" cellspacing="0" cellpadding="5" align="center">
                    <tr valign="middle">
                        <td align="center" width="5px" height="75">
                            <asp:Image ID="imgLoading" runat="server" ImageUrl="~/Images/Loading.gif"/>    
                        </td>
                        <td align="left">
                          <asp:Label ID="lblLoading" runat="server" Text="Loading please wait..." CssClass="BlueText"></asp:Label>  
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table border="0" cellpadding="10" cellspacing="0" width="100%">
        <tr>
            <td class="TextTitle">
                System Logs</td>
        </tr>
        <tr>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td width="30%">
                            <asp:Button ID="btnSeperator" runat="server" CssClass="ButtonLightBlue" 
                                Text="Insert Marker" />
                            &nbsp;<asp:Button ID="btnRefresh" runat="server" CssClass="ButtonLightBlue" 
                                Text="Refresh" />
                        </td>
                        <td align="right">
                            <table width="500">
                                <tr>
                                    <td align="right" class="GrayText">
                                        &nbsp; Results per page:
                                        <asp:LinkButton ID="lnk250" runat="server" CssClass="Link">250</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="lnk150" runat="server" CssClass="Link">150</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="lnk100" runat="server" CssClass="Link">100</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="lnk50" runat="server" CssClass="Link">50</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="lnk35" runat="server" CssClass="Link">35</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="lnk20" runat="server" CssClass="Link">20</asp:LinkButton>
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
    
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
    
        <asp:GridView ID="gdvLogs" runat="server" 
            GridLines="None" AllowPaging="True" PageSize="50" CssClass="GridView" 
        Width="98%">
            <RowStyle CssClass="GridViewRow" />
            <HeaderStyle CssClass="GridViewHeaderRow" />
            <AlternatingRowStyle CssClass="GridViewAlternateRow" />
        </asp:GridView>
                <br />
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    
    
    
    </asp:Content>

