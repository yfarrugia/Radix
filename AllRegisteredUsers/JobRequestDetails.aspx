<%@ Page Language="VB" MasterPageFile="~/Employees/EmployeeMasterPage.master" AutoEventWireup="false" CodeFile="JobRequestDetails.aspx.vb" Inherits="Employees_JobRequestDetails" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                Job
                Request Details</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" CssClass="RedText"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DetailsView ID="dtvRequest" runat="server" GridLines="None" Width="97%" 
                    EmptyDataText="Job details are currently not available.">
                    <RowStyle CssClass="DetailsView" />
                    <FieldHeaderStyle CssClass="DetailsViewFieldHeader" Font-Bold="True" />
                </asp:DetailsView>
            </td>
        </tr>
        <tr>
            <td id="btn">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Panel ID="plInterested" runat="server">
                    <asp:Button ID="btnInterested" runat="server" 
    CssClass="ButtonLightBlue" Text="Interested" />
                    &nbsp;<asp:Button ID="btnNotInterested" runat="server" 
                        CssClass="ButtonLightBlue" Text="Not Interested" />
                    &nbsp;<asp:Button ID="btnEnquire" runat="server" CssClass="ButtonLightBlue" 
                        Text="Enquire" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td id="btn">
                <asp:Panel ID="plAcceptDeny" runat="server">
                    <asp:Button ID="btnAccept" runat="server" Text="Accept" 
                        CssClass="ButtonLightBlue" />
                    &nbsp;<asp:Button ID="btnDeny" runat="server" CssClass="ButtonLightBlue" 
                        Text="Deny" />
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

