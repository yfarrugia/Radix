<%@ Page Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master" AutoEventWireup="false"
    CodeFile="ReviewJobDetails.aspx.vb" Inherits="Employers_JobDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table align="right" style="width: 100%;">
        <tr>
            <td class="TextTitle">
                Job Details
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:DetailsView ID="dvJobDetails" runat="server" CssClass="DetailsView" 
                    Font-Italic="False" Width="95%" 
                    EmptyDataText="This job's details are not currently available." 
                    GridLines="None">
                    <RowStyle CssClass="DetailsView" />
                    <FieldHeaderStyle CssClass="DetailsViewFieldHeader" />
                    <EmptyDataRowStyle Font-Bold="False" />
                </asp:DetailsView>
            </td>
        </tr>
        <tr>
            <td class="BlueTextBold">
                Employees Associated With Job</td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gdvAddedEmployees" runat="server" CssClass="GridView" 
                    EmptyDataText="No employees are associated with this job." GridLines="None" 
                    Width="95%">
                    <RowStyle CssClass="GridViewRow" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbx" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="GridViewHeaderRow" />
                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnReview" runat="server" CssClass="ButtonLightBlue" Text="Review Selected Employee"
                    UseSubmitBehavior="False" Width="200px" />&nbsp;
                <asp:Button ID="btnCancle" runat="server" CssClass="ButtonLightBlue" Text="Cancel"
                    UseSubmitBehavior="False" />
            </td>
        </tr>
    </table>
</asp:Content>
