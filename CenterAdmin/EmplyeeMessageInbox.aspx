<%@ Page Language="VB" MasterPageFile="~/CenterAdmin/CenterAdminMasterPage.master" AutoEventWireup="false" CodeFile="EmplyeeMessageInbox.aspx.vb" Inherits="CenterAdmin_EmplyeeMessageInbox" title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">&nbsp;
   
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                <asp:Label ID="lblCenterEmployee" runat="server" CssClass="TextTitle"></asp:Label>
                &#39;s Message Inbox</td>
        </tr>
        <tr>
            <td align="center">
                <table width="98%">
                    <tr>
                        <td align="center">
                <asp:Panel ID="LatestJobsTitlePanel" runat="server" CssClass="collapseHeaderBackground">
                    <table style="width:100%;">
                        <tr>
                            <td align="center" width="20">
                                <asp:Image ID="imgLatestJobs" runat="server" ImageUrl="~/Images/collapse.png" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblJobs" runat="server" CssClass="BlueTextBold" 
                                    Text="Jobs"></asp:Label>
                            </td>
                            <td width="80">
                                <asp:Label ID="lblLatestJobsShow" runat="server" CssClass="GrayText" 
                                    Text="Show..."></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                        </td>
                    </tr>
                </table>              
                <cc1:CollapsiblePanelExtender ID="TitlePanel_CollapsiblePanelExtender" 
                    runat="server" Enabled="True" 
                    TargetControlID="LatestJobsContentPanel"
                    ExpandControlID="LatestJobsTitlePanel"
                    CollapseControlID="LatestJobsTitlePanel"
                    Collapsed ="true" 
                    TextLabelID="lblLatestJobsShow" 
                    ExpandedText="Hide..." 
                    CollapsedText="Show..."
                    ImageControlID="imgLatestJobs" 
                    CollapsedImage="~/Images/collapse.png" 
                    ExpandedImage="~/Images/expand.png"
                    SuppressPostBack="true">
                </cc1:CollapsiblePanelExtender>
                
                <asp:Panel ID="LatestJobsContentPanel" runat="server" CssClass="collapsePanel">
                <div style="text-align:justify  ">
                 
                <p>
                    <table style="width:100%;">
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gdvJobs" runat="server" GridLines="None" Width="95%" 
                                    CssClass="GridView" EmptyDataText="You do not have any job requests.">
                                    <RowStyle CssClass="GridViewRow" />
                                    <Columns>
                                        <asp:CommandField SelectText="View Details" ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridViewHeaderRow" />
                                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    &nbsp;&nbsp;&nbsp;</p> 

                </div>
                </asp:Panel>
                <br/>
         
                
                <table width="98%">
                    <tr>
                        <td align="center">
                <asp:Panel ID="LatestReviewsTitlePanel" runat="server" CssClass="collapseHeaderBackground">
                    <table style="width:100%;">
                        <tr>
                            <td align="center" width="20">
                                <asp:Image ID="imgLatestReviews" runat="server" ImageUrl="~/Images/collapse.png" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblReviews" runat="server" CssClass="BlueTextBold" 
                                    Text="Reviews"></asp:Label>
                            </td>
                            <td width="80">
                                <asp:Label ID="lblLatestReviewsShow" runat="server" CssClass="GrayText" 
                                    Text="Show..."></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                        </td>
                    </tr>
                </table>              
                <asp:Panel ID="LatestReviewsContentPanel" runat="server" CssClass="collapsePanel">
                <div style="text-align:justify  ">
                    <p align="center">
                        <table width = "100%">
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="gdvReviews" runat="server" GridLines="None" Width="95%" 
                                        CssClass="GridView" EmptyDataText="You currently have no reviews">
                                        <RowStyle CssClass="GridViewRow" />
                                        <Columns>
                                            <asp:CommandField SelectText="Report" ShowSelectButton="True" />
                                        </Columns>
                                        <HeaderStyle CssClass="GridViewHeaderRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </p>
                    
                </div>
                </asp:Panel>
                <cc1:CollapsiblePanelExtender ID="LatestReviewsContentPanel_CollapsiblePanelExtender" 
                    runat="server" Enabled="True" TargetControlID="LatestReviewsContentPanel"
                    ExpandControlID="LatestReviewsTitlePanel"
                    CollapseControlID="LatestReviewsTitlePanel"
                    Collapsed ="true" 
                    TextLabelID="lblLatestReviewsShow" 
                    ExpandedText="Hide..." 
                    CollapsedText="Show..."
                    ImageControlID="imgLatestReviews" 
                    CollapsedImage="~/Images/collapse.png" 
                    ExpandedImage="~/Images/expand.png"
                    SuppressPostBack="true">
                </cc1:CollapsiblePanelExtender>
                <br />
                
                
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
                                <asp:Label ID="lblMsgs" runat="server" CssClass="BlueTextBold" 
                                    Text="Messages"></asp:Label>
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
                <asp:Panel ID="MsgsContentPanel" runat="server" CssClass="collapsePanel">
                <div style="text-align:justify  " align="center">
                    <p align="center">
                        <table width = "100%">
                            <tr>
                                <td>
                                    <asp:GridView ID="gdvMessages" runat="server" GridLines="None" Width="95%" 
                                        AlternatingRowStyle-CssClass="GridViewAlternateRow" CssClass="GridView" 
                                        HeaderStyle-CssClass="GridViewHeaderRow">
                                        <RowStyle CssClass="GridViewRow" />
                                        <Columns>
                                            <asp:CommandField SelectText="View" ShowSelectButton="True" 
                                                HeaderText="View Message" ShowHeader="False" />
                                        </Columns>
                                        <HeaderStyle CssClass="GridViewHeaderRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </p>
                </div>
                </asp:Panel>
                <cc1:CollapsiblePanelExtender ID="Panel2_CollapsiblePanelExtender" 
                    runat="server" Enabled="True" TargetControlID="MsgsContentPanel"
                    ExpandControlID="LatestMsgsTitlePanel"
                    CollapseControlID="LatestMsgsTitlePanel"
                    Collapsed ="true" 
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