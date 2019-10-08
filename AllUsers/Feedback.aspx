<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Feedback.aspx.vb" Inherits="AllUsers_Feedback" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td colspan="3" class="TextTitle">
            Feedback</td>
    </tr>
    <tr>
        <td colspan="3" class="Text">
            Any feedback provided will be greatly appreciated, this allows us to provide you 
            with a better qaulity of service.</td>
    </tr>
    <tr>
        <td colspan="3" align="center">
            <asp:Label ID="lblSuccess" CssClass="GreenText" runat="server" 
                Text="Thank You.  Your feedback has been successfully submited." 
                Visible="False"></asp:Label><asp:Label ID="lblError" runat="server" 
                CssClass="RedText" 
                Text="Sorry.  An error error has occured while trying to submit your feedback.  Please try again." 
                Visible="False"></asp:Label>
            </td>
    </tr>
    <tr>
        <td align="right" class="titlecell">
            Name:</td>
        <td width="20">
            <asp:TextBox ID="txtName" runat="server" CssClass="TextBox" Width="250px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="titlecell">
            E-Mail:</td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Width="300px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="txtEmail" CssClass="RedText" 
                ErrorMessage="Please enter an email address" ForeColor="" ValidationGroup="2"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtEmail" CssClass="RedText" 
                ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="2"></asp:RegularExpressionValidator>
&nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="titlecell">
            Subject:</td>
        <td>
            <asp:TextBox ID="txtSubject" runat="server" CssClass="TextBox" Width="300px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="txtSubject" CssClass="RedText" 
                ErrorMessage="Please enter a subject" ForeColor="" ValidationGroup="2"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="titlecell" valign="top">
            Message:</td>
        <td valign="top">
            <asp:TextBox ID="txtMessage" runat="server" CssClass="TextBox" Width="300px" 
                Height="250px" TextMode="MultiLine"></asp:TextBox>
        &nbsp;</td>
        <td valign="top">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="txtMessage" CssClass="RedText" 
                ErrorMessage="Please enter a message" ForeColor="" ValidationGroup="2"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="right">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSubmitFeedback" runat="server" Text="Submit Feedback" 
                CssClass="ButtonLightBlue" ValidationGroup="2" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

