<%@ Page Language="VB" MasterPageFile="~/Employees/EmployeeMasterPage.master" AutoEventWireup="false" CodeFile="Message.aspx.vb" Inherits="AllRegisteredUsers_Message" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Namespace="RadixAjaxControls" TagPrefix="RadixControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
    <table width="100%">
        <tr>
            <td colspan="2">
            
            <table width="100%" border="0" cellpadding="3" cellspacing="0">
                <tr valign="middle" align="left">
                    <td width="3">
                        <asp:Image ID="Image1" runat="server" 
                            ImageUrl="~/Images/Icons/ReplyMessage.png" ToolTip="Reply" />
                    </td>
                    <td align="left" width="55">
                        <asp:LinkButton ID="lnkReply" runat="server" CssClass="Link">Reply</asp:LinkButton>
                    </td>
                    <td width="5">
                        <asp:Image ID="Image2" runat="server" 
                            ImageUrl="~/Images/Icons/CloseMessage.png" ToolTip="Close Message" />
                    </td>
                    <td align="left" width="115">
                        <asp:LinkButton ID="lnkClose" runat="server" CssClass="Link">Close Message</asp:LinkButton>
                    </td>
                    <td width="5">
                        <asp:Image ID="Image3" runat="server" 
                            ImageUrl="~/Images/Icons/DeleteMessage.png" ToolTip="Delete Message" />
                    </td>
                    <td align="left">
                        <asp:LinkButton ID="lnkDelete" runat="server" CssClass="Link">Delete Message</asp:LinkButton>
                    </td>
                </tr>
            </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="plTicketFunctionality" runat="server" Visible="False">
                    
                    <table width="100%" border="0" cellpadding="3" cellspacing="0">
                <tr valign="middle" align="left">
                    <td width="3">
                        <asp:Image ID="Image4" runat="server" 
                            ImageUrl="~/Images/Icons/TicketUnassigned.png" 
                            ToolTip="Un-Assign Ticket" />
                    </td>
                    <td align="left" width="115">
                        <asp:LinkButton ID="lnkUnAssign" runat="server" CssClass="Link">Un-Assign Ticket</asp:LinkButton>
                    </td>
                    <td width="5">
                        <asp:Image ID="Image5" runat="server" 
                            ImageUrl="~/Images/Icons/TicketEscalated.png" ToolTip="Escalate Ticket" />
                    </td>
                    <td align="left" width="110">
                        <asp:LinkButton ID="lnkEscalate" runat="server" CssClass="Link">Escalate Ticket</asp:LinkButton>
                    </td>
                    <td width="5">
                        <asp:Image ID="Image6" runat="server" 
                            ImageUrl="~/Images/Icons/TicketSolved.png" ToolTip="Solved Ticket" />
                    </td>
                    <td align="left">
                        <asp:LinkButton ID="lnkSolved" runat="server" CssClass="Link">Solved Ticket</asp:LinkButton>
                    </td>
                </tr>
            </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="titlecell">
                Translate To</td>
            <td>
                <asp:DropDownList ID="ddlLanguages" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblSuccess" runat="server" CssClass="GreenText" 
                    Text="Your message has been sent successfully." Visible="False"></asp:Label>
                <asp:Label ID="lblTranslateError" runat="server" CssClass="RedText" 
                    
                    Text="Unfortunately an error has occured while trying to translate your message.  Please try again." 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <cc1:Accordion ID="Accmessages" runat="server" 
                    SelectedIndex="0"
                    TransitionDuration="100" 
                    FramesPerSecond="350" 
                    FadeTransitions="true" 
                    RequireOpenedPane="false"
                    HeaderCssClass="acc-header"
                    ContentCssClass="acc-content"
                    HeaderSelectedCssClass="acc-selected"
                    SuppressHeaderPostbacks="true"
                    AutoSize="None">
                    <HeaderTemplate>
                        <div>
                            <table width="681px" style="height:33px;" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="middle" align="left" style="padding-left:15px;" class="BlueTextBold">
                                        <%#DataBinder.Eval(Container.DataItem, "Subject")%>
                                    </td>
                                    <td valign="middle" align="right" style="padding-right:15px; font-weight:normal;"  class="GrayText">
                                        <%#DataBinder.Eval(Container.DataItem, "DateSent")%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div style="float:left; margin:8px;">
                        
                            <table style="width: 100%;">
                                <tr valign="top">
                                    <td class="titlecell">
                                        From
                                    </td>
                                    <td>
                                        <%#DataBinder.Eval(Container.DataItem, "Sender")%>
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td class="titlecell" >
                                        Message
                                    </td>
                                    <td>
                                        <%#DataBinder.Eval(Container.DataItem, "Message")%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </cc1:Accordion>
                
            </td>
        </tr>
        
        <tr>
            <td colspan="2" align="center" valign="top">
            <asp:Panel ID="plReply" runat="server" Visible="false" BackColor="#f9f9f9" Width="95%">
                <table width="95%" align="center">
                    <tr>
                        <td class="TextTitle" colspan="2" align="left">
                            Reply To...
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Label ID="lblError" runat="server" CssClass="RedText" Visible="False">Your 
                            message has not been sent successfully. Please try again.</asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="titlecell">
                            Subject </td>
                        <td align="left">
                            <asp:TextBox ID="txtSubject" runat="server" CssClass="TextBox" Text="Re:" 
                                Width="350px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="titlecell">
                            Language</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlLanguageSavingTo" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblInvalid" runat="server" 
                                Text="The subject and message are both required fields and must not be left empty." 
                                CssClass="RedText" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="titlecell">
                            Message </td>
                        <td align="left" valign="top">
                            <RadixControl:cHTMLEditor ID="Message" runat="server" Height="300px" 
                                Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;</td>
                        <td align="left">
                            <asp:Button ID="btnSend" runat="server" CssClass="ButtonLightBlue" 
                                Text="Send" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="plReply_RoundedCornersExtender" runat="server" 
                    Enabled="True" TargetControlID="plReply" BorderColor="225, 225, 225" 
                    Radius="10">
                </cc1:RoundedCornersExtender>
            </td>
        
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
    
</asp:Content>

