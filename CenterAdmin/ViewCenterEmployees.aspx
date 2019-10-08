  <%@ Page Title="" Language="VB" MasterPageFile="~/CenterAdmin/CenterAdminMasterPage.master" AutoEventWireup="false" CodeFile="ViewCenterEmployees.aspx.vb" Inherits="AllUsers_ViewCenterEmployees" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <br />
    <table style="width: 100%;">
        <tr>
            <td>
                                    <asp:Label ID="lblEmployeesCenter" runat="server" CssClass="TextTitle" 
                                        Text="Our Center Employees"></asp:Label>
                                </td>
        </tr>
        <tr>
            <td >
                </td>
        </tr>
        <tr>

                <td align="center">
              
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvCenterEmployees" runat="server" CssClass="GridView" 
    Width="95%" GridLines="None">
                                <RowStyle CssClass="GridViewRow" />
                                <Columns>
                                    <asp:ButtonField Text="View Profile" CommandName="Profile" />
                                    <asp:ButtonField Text="View Inbox" CommandName="Inbox" />
                                    <asp:ButtonField CommandName="CV" Text="View CV" />
                                    <asp:ButtonField CommandName="Report" 
                                        ImageUrl="~/Images/Icons/Flagged_On.png" Text="Report" />
                                </Columns>
                                <HeaderStyle CssClass="GridViewHeaderRow" />
                                <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                                           
            </td>
                       
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

