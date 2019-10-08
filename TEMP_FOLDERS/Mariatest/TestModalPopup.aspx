<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="TestModalPopup.aspx.vb" Inherits="Mariatest_TestModalPopup" title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.modalBackground {
background-color:#fff;
filter:alpha(opacity=70);
opacity:0.7px;
} 
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <table style="width:100%;">
        <tr>
        <td>
            <asp:ScriptManager ID="asm" runat="server" />
        </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ClientButton" runat="server" Text="Launch Modal Popup (Client)" />
            </td>
            <td>
                <asp:Panel ID="ModalPanel" runat="server" Width="500px">
                    <asp:Label ID="lblLang" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Button ID="OKButton" runat="server" Text="Close" />
                    
                </asp:Panel>
            </td>
            <td>
                <cc1:ModalPopupExtender ID="mpe" runat="server" 
                        TargetControlId="ClientButton" PopupControlID="ModalPanel" 
                        BackgroundCssClass="modalBackground" 
                        OkControlID="OKButton">
                    </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

