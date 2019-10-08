<%@ Page Language="VB" MasterPageFile="~/Employees/EmployeeMasterPage.master" AutoEventWireup="false" CodeFile="CreateTicket.aspx.vb" Inherits="AllRegisteredUsers_CreateTicket" title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                Support Ticket</td>
        </tr>
        <tr>
            <td>
               <asp:MultiView ID="mvTickets" runat="server">
    <asp:View ID="vwCreate" runat="server">
       <table style="width:100%;">
        <tr>
            <td class="TextTitle" colspan="2">
                Create Ticket</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtSubject" CssClass="RedText" 
                    ErrorMessage="Please enter a subject." ForeColor="" ValidationGroup="2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="titlecell">
                Subject</td>
            <td>
                <asp:TextBox ID="txtSubject" runat="server" Width="350px" 
                    CssClass="TextBox" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
           <tr>
               <td align="right">
                   &nbsp;</td>
               <td>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                       ControlToValidate="txtMessage" CssClass="RedText" 
                       ErrorMessage="Please enter a message." ForeColor="" ValidationGroup="2"></asp:RequiredFieldValidator>
               </td>
           </tr>
        <tr>
            <td align="right" class="titlecell" valign="top">
                Message</td>
            <td>
                <asp:TextBox ID="txtMessage" runat="server" Height="100px" TextMode="MultiLine" 
                    Width="350px" CssClass="TextBox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="titlecell" valign="middle">
                Priority</td>
            <td>
                <asp:RadioButtonList ID="rdblPriority" runat="server" 
                    RepeatDirection="Horizontal" Width="300px">
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                </asp:RadioButtonList>
                
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" CssClass="ButtonLightBlue" 
                    Text="Submit" ValidationGroup="2" />
            </td>
           </tr>
          </table>
         </asp:View>
         <asp:View ID="vwTicketRegistered" runat="server">
            <table style="width:100%;" cellpadding="5" cellspacing="0" border="0">
                <tr>
                    <td align="center" class="BlueTextBold">
                    Thank you for contacting our Radix Customer Support Service.
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        An email has been sent to your account with your Ticket ID and our Customer Service team will be responding to you as soon as possible.
                    </td>                
                </tr>
                 <tr>
                    <td align="center">
                        <br />
                        <table width="500px" border="0" cellpadding="0" cellspacing="0" bgcolor="#EBEBEB">
                            <tr>
                                <td height="50" valign="middle" align="center">
                                    <asp:Label ID="lblTicketID" runat="server" CssClass="Text"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>                
                </tr>
            </table>
         </asp:View>
        </asp:MultiView>
        </td>
    </tr>
    </table>
    
</asp:Content>

