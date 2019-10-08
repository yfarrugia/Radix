<%@ Page Language="VB" MasterPageFile="~/Employees/EmployeeMasterPage.master" AutoEventWireup="false" CodeFile="Employee.aspx.vb" Inherits="Employees_Employee" title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
   
    <table style="width:100%;">
        <tr>
            <td class="TextTitle" align="left" valign="middle" width="95%">
                &nbsp;
                My Desk</td>
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
                                <asp:Label ID="lblLatestJobs" runat="server" CssClass="BlueTextBold" 
                                    Text="Latest Jobs"></asp:Label>
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
                                
                                <asp:GridView ID="gdvLatestJobs" runat="server" Width="95%" CssClass="GridView" 
                                    EmptyDataText="You do not have any job requests." GridLines="None">
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
                    </p> 
                    <p style="text-align:right">
                        <asp:LinkButton ID="lnkShowAllJobs" runat="server" CssClass="Link" 
                            PostBackUrl="~/Employees/JobRequestInbox.aspx">Show All...</asp:LinkButton>&nbsp;&nbsp;&nbsp;</p>

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
                                <asp:Label ID="lblLatestReviews" runat="server" CssClass="BlueTextBold" 
                                    Text="Latest Reviews"></asp:Label>
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
                                    <asp:GridView ID="gdvLatestReviews" runat="server" Width="95%" 
                                        CssClass="GridView" EmptyDataText="You currently have no reviews" 
                                        GridLines="None">
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
                    
                    <p align="right">
                        <asp:LinkButton ID="lnkShowAllReviews" runat="server" CssClass="Link" 
                            PostBackUrl="~/Employees/MyReviews.aspx">Show 
                        All...</asp:LinkButton>&nbsp;&nbsp;&nbsp;
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
                                    <asp:GridView ID="gdvMessages" runat="server" 
                                        AlternatingRowStyle-CssClass="GridViewAlternateRow" CssClass="GridView" 
                                        GridLines="None" HeaderStyle-CssClass="GridViewHeaderRow" Width="95%">
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
                <cc1:CollapsiblePanelExtender ID="Panel2_CollapsiblePanelExtender" 
                    runat="server" Enabled="True" TargetControlID="LatestMsgsContentPanel"
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

