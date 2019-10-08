<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ViewCenterEmployees.aspx.vb" Inherits="AllUsers_ViewCenterEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td colspan="3">
                                    <asp:Label ID="lblEmployeesCenter" runat="server" CssClass="TextTitle" 
                                        Text="Our Center Employees"></asp:Label>
                                </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td >
                <asp:GridView ID="gvCenterEmployees" runat="server" 
                    AutoGenerateSelectButton="True" CssClass="GridView" Width="90%" 
                    BorderStyle="None" GridLines="None">
                    <HeaderStyle CssClass="GridViewHeaderRow" />
                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

