<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="UserAuth.aspx.vb" Inherits="Anonymous_UserAuth" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                Confirmation</td>
        </tr>
        <tr>
            <td class="Text">
                Please enter the confirmation code that has been sent to your email account 
                below.</td>
        </tr>
        <tr>
            <td class="Text" align="center">
                <asp:Label ID="lblSuccess" runat="server" CssClass="BlueTextBold" 
                    Text="Authentication Successfull.  You may now login with your credentials." 
                    Visible="False"></asp:Label>
                <asp:Label ID="lblFail" runat="server" CssClass="RedText" 
                    Text="The authorization code you have entered is invalid or has expired." 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <table width="60%">
                    <tr>
                        <td align="right" class="titlecell">
                            Username</td>
                        <td align="left">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="TextBox" 
                                Width="185px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ErrorMessage="RequiredFieldValidator" ControlToValidate="txtUsername" 
                                ToolTip="Please enter an authorisation code." ValidationGroup="2"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="titlecell">
                            Authorisation Code</td>
                        <td align="left">
                            <asp:TextBox ID="txtAuth" runat="server" CssClass="TextBox" Width="300px"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAuth" 
                                ToolTip="Please enter an authorisation code." ValidationGroup="2"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" height="40">
                <asp:Button ID="btnSubmit" runat="server" CssClass="ButtonLightBlue" 
                    Text="Submit" ValidationGroup="2" />
            </td>
        </tr>
    </table>
</asp:Content>

