<%@ Page Language="VB" MasterPageFile="~/CenterAdmin/CenterAdminMasterPage.master" AutoEventWireup="false" CodeFile="CenterAdmin.aspx.vb" Inherits="CenterAdmin_CenterAdmin" title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">


    <table width = "100%">
        <tr>
            <td class="TextTitle">
                My Desk</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                
                                <table width="98%">
                    <tr>
                        <td align="center">
                <asp:Panel ID="LatestMsgsTitlePanel" runat="server" CssClass="collapseHeaderBackground">
                    <table style="width:100%;">
                        <tr>
                            <td align="center" width="20">
                                <asp:Image ID="imgLatestMsgs" runat="server" ImageUrl="~/Images/collapse.png" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblLatestMsgs" runat="server" CssClass="BlueTextBold" 
                                    Text="Latest Messages"></asp:Label>
                            </td>
                            <td width="80">
                            
                                <asp:Label ID="lblLatestMsgsShow" runat="server" CssClass="GrayText" 
                                    Text="Show..."></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                        </td>
                    </tr>
                </table>              
                <asp:Panel ID="LatestMsgsContentPanel" runat="server" CssClass="collapsePanel">
                <div style="text-align:justify  " align="center">
                    <p align="center">
                        <table width = "100%">
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="gdvMessages" runat="server" Width="95%" CssClass="GridView" 
                                        GridLines="None" AlternatingRowStyle-CssClass="GridViewAlternateRow" 
                                        HeaderStyle-CssClass="GridViewHeaderRow">
                                        <RowStyle CssClass="GridViewRow" />
                                        <Columns>
                                            <asp:CommandField HeaderText="View Message" SelectText="View" 
                                                ShowHeader="False" ShowSelectButton="True" />
                                        </Columns>
                                        <HeaderStyle CssClass="GridViewHeaderRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </p>
                    <p align="right">
                        &nbsp;<asp:LinkButton ID="lnkShowAllMessages" runat="server" CssClass="Link" 
                            PostBackUrl="~/AllRegisteredUsers/MessageInbox.aspx">Show 
                        All...</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;</p>
                </div>
                </asp:Panel>
                <cc1:CollapsiblePanelExtender ID="LatestMsgsContentPanel_CollapsiblePanelExtender" 
                    runat="server" Enabled="True" TargetControlID="LatestMsgsContentPanel"
                    ExpandControlID="LatestMsgsTitlePanel"
                    CollapseControlID="LatestMsgsTitlePanel" 
                    TextLabelID="lblLatestMsgsShow" 
                    ExpandedText="Hide..." 
                    CollapsedText="Show..."
                    ImageControlID="imgLatestMsgs" 
                    CollapsedImage="~/Images/collapse.png" 
                    ExpandedImage="~/Images/expand.png"
                    SuppressPostBack="true">
                </cc1:CollapsiblePanelExtender>
                <br />
                
                </td>
        </tr>
    </table>


</asp:Content>

