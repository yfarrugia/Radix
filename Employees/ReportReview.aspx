<%@ Page Language="VB" MasterPageFile="~/Employees/EmployeeMasterPage.master" AutoEventWireup="false"
    CodeFile="ReportReview.aspx.vb" Inherits="Employees_ReportReview" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td class="TextTitle">
                        Report Review
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" width="95%">
                            <tr>
                                <td colspan="2">
                                    <asp:DetailsView ID="dvReportReview" runat="server" Width="100%" CssClass="DetailsView"
                                        GridLines="None">
                                        <RowStyle CssClass="DetailsView" />
                                        <FieldHeaderStyle CssClass="DetailsViewFieldHeader" />
                                    </asp:DetailsView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="titlecell">
                                    Reason:
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtReportText" runat="server" Height="129px" TextMode="MultiLine"
                                        Width="400px" CssClass="TextBox" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                                <td align="left" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                                <td align="left" valign="top">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="ButtonLightBlue" />
                                    &nbsp;<asp:Button ID="btnReport" runat="server" Text="Report" CssClass="ButtonLightBlue" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="center" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
