<%@ Page Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master" AutoEventWireup="false"
    CodeFile="CreateMessage.aspx.vb" Inherits="AllRegisteredUsers_CreateMessage"
    Title="Untitled Page" %>

<%@ Register Namespace="RadixAjaxControls" TagPrefix="RadixControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="TextTitle" valign="middle" colspan="2">
                Compose Message</td>
        </tr>
        <tr>
            <td valign="middle">
                &nbsp;</td>
            <td valign="middle">
                <asp:Label ID="lblMessage" runat="server" CssClass="RedText"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="titlecell" valign="middle">
                To</td>
            <td valign="middle">
                <asp:UpdatePanel ID="upTo" runat="server">
                  <ContentTemplate>
                    <asp:TextBox ID="txtRecepients" runat="server" CssClass="TextBox" Width="350px"
                        ValidationGroup="1" ReadOnly="True"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="rfvRecepients" runat="server" ControlToValidate="txtRecepients"
                        ErrorMessage="*" ValidationGroup="1" CssClass="RedText" ForeColor="">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:Button ID="btnAddRecepients" runat="server" CssClass="ButtonLightBlue" Text="Add Recipients"
                        Width="104px" />
                        
                        <cc1:ModalPopupExtender ID="MpeUsers" 
                        runat="server" 
                        TargetControlID="btnAddRecepients"
                        OkControlID="btnClose" 
                        PopupControlID="plModal" 
                        CancelControlID="btnClose"
                        BackgroundCssClass="ModalBg" 
                        DropShadow="true">
                        </cc1:ModalPopupExtender>
                  </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="titlecell" valign="middle">
                Subject</td>
            <td valign="middle">
                <asp:TextBox ID="txtSubject" runat="server" CssClass="TextBox" MaxLength="50"
                    Width="440px" ValidationGroup="1"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject"
                    ErrorMessage="*" ValidationGroup="1" CssClass="RedText" ForeColor="">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="titlecell" valign="middle">
                Language</td>
            <td valign="middle">
                <asp:DropDownList ID="ddlLanguages" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="titlecell" valign="top">
                Message</td>
            <td>
                <RadixControl:cHTMLEditor ID="Message" runat="server" Width="100%" Height="300px" />
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
            </td>
            <td align="left" valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
            </td>
            <td align="left" valign="middle">
                <asp:Button ID="btnSend" runat="server" CssClass="ButtonLightBlue" Text="Send" Width="88px" ValidationGroup="1" />
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
            <td align="left" valign="middle">
                <asp:Panel ID="plModal" runat="server" Width="458px" CssClass="ModalPanel">
                    <table width="100%" >
                        <tr>
                            <td class="TextTitle">
                                Select Recipients</td>
                        </tr>
                        <tr>
                            <td class="Text">
                                To search for recipients please enter a Name, Surname or Country that you would 
                                like to filter by. <i>(Example: Italy) (Example: John)</i></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="upSearch" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="200">
                                                                <asp:TextBox ID="txtCriteria" runat="server" CssClass="TextBox" Width="250px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                                <asp:Button ID="btnSearch" runat="server" CssClass="ButtonLightBlue" 
                                                                    Text="Search" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <br />
                                                    <asp:GridView ID="GdvRecipients" runat="server" CssClass="GridView" 
                                                        EmptyDataText="No results have been found matching your search." 
                                                        GridLines="None" Width="95%">
                                                        <RowStyle CssClass="GridViewRow" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Add">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="cbx" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="GridViewHeaderRow" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                                    </asp:GridView>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Button ID="btnAddEmpl" runat="server" CssClass="ButtonLightBlue" 
                                                        Text="Add Selected Users" Width="120px" />
                                                    &nbsp;<input ID="btnClose" class="ButtonLightBlue" 
                                                        onclick="javascript: <%#getPostBack()%>;" type="button" value="Close" /></td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                
            </td>
        </tr>
    </table>
</asp:Content>
