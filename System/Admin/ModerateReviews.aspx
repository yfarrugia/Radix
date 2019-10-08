<%@ Page Language="VB" MasterPageFile="~/System/Admin/SystemMasterPage.master" AutoEventWireup="false"
    CodeFile="ModerateReviews.aspx.vb" Inherits="System_Admin_ModerateReviews" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="TextTitle">
                Moderate Reviews
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblSuccess" runat="server" CssClass="GreenText" 
                    Text="Review has been successfully removed." Visible="False"></asp:Label>
                <asp:Label ID="lblError" runat="server" CssClass="RedText" 
                    Text="An error has occured while trying to remove a review.  Please try again." 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvReviews" runat="server" AllowPaging="True" PageSize="20" 
                    CssClass="GridView" 
                    EmptyDataText="No users are currently flagged and pending review moderation." 
                    GridLines="None" Width="95%">
                    <RowStyle CssClass="GridViewRow" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="GridViewHeaderRow" />
                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <br />
<%--                <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="False">
                    <ContentTemplate>--%>
                        <asp:Panel ID="ReviewDetailsArea" runat="server" Width="100%" 
                    Visible="False">
                        
                        <table width="100%">
                            <tr>
                                <td class="BlueTextBold">
                                    Review Details</td>
                            </tr>
                            <tr>
                                <td align="center"> 
                            <asp:DetailsView ID="dvReportedReivewDetails" runat="server" 
                                CssClass="DetailsView" GridLines="None" Width="65%" 
                                        EmptyDataText="No reviews have been selected.  Please select a review.">
                                <RowStyle CssClass="DetailsView" />
                                <FieldHeaderStyle CssClass="DetailsViewFieldHeader" />
                                    </asp:DetailsView>
                                    <br />
                                </td>
                                
                           </tr>
                           <tr>
                                <td align="center"> 
                            <asp:Button ID="btnMailUser" runat="server" Text="Contact Employee" 
                                        CssClass="ButtonLightBlue" Width="125px"/>&nbsp;
                                <asp:Button ID="btnMailEmployer" runat="server" Text="Contact Employer" 
                                        CssClass="ButtonLightBlue" Width="125px"/>&nbsp;
                                <asp:Button ID="btnRemoveReview" runat="server" Text="Remove Review" 
                                        CssClass="ButtonLightBlue" Width="125px"/>&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="ButtonLightBlue" 
                                        Width="125px"/>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
<%--                    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
</asp:Content>
