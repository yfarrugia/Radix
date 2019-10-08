<%@ Page Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master" AutoEventWireup="false" CodeFile="Employer.aspx.vb" Inherits="Employers_Employer" title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
   
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                My Office</td>
        </tr>
        <tr>
            <td align="center">
                <table width="98%">
                    <tr>
                        <td align="center">
                        
                        
                <asp:Panel ID="LatestPendingTitlePanel" runat="server" CssClass="collapseHeaderBackground">
                    <table style="width:100%;">
                        <tr>
                            <td align="center" width="20">
                                <asp:Image ID="imgLatestPending" runat="server" ImageUrl="~/Images/collapse.png" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblLatestPending" runat="server" CssClass="BlueTextBold" 
                                    Text="Latest Pending Jobs"></asp:Label>
                            </td>
                            <td width="80">
                                <asp:Label ID="lblLatestPendingShow" runat="server" CssClass="GrayText" 
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
                    TargetControlID="LatestPendingContentPanel"
                    ExpandControlID="LatestPendingTitlePanel"
                    CollapseControlID="LatestPendingTitlePanel"
                    Collapsed ="true" 
                    TextLabelID="lblLatestPendingShow" 
                    ExpandedText="Hide..." 
                    CollapsedText="Show..."
                    ImageControlID="imgLatestPending" 
                    CollapsedImage="~/Images/collapse.png" 
                    ExpandedImage="~/Images/expand.png"
                    SuppressPostBack="true">
                </cc1:CollapsiblePanelExtender>
                
                <asp:Panel ID="LatestPendingContentPanel" runat="server" CssClass="collapsePanel">
                <div style="text-align:justify  ">
                 
                <p>
                    <table style="width:100%;">
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gdvPendingJobs" runat="server" Width="95%" 
                                    CssClass="GridView" EmptyDataText="You do not have any pending jobs." 
                                    GridLines="None">
                                    <RowStyle CssClass="GridViewRow" />
                                    <Columns>
                                        <asp:CommandField HeaderText="View Job Details" SelectText="View" 
                                            ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridViewHeaderRow" />
                                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    </p> 
                    <p style="text-align:right">
                        <asp:LinkButton ID="lnkShowAllPending" runat="server" CssClass="Link" 
                            PostBackUrl="~/Employers/MyPendingJobs.aspx">Show All...</asp:LinkButton>&nbsp;&nbsp;&nbsp;</p>

                </div>
                </asp:Panel>
                <br/>
         
                
                <%--<table width="98%">
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
                <p></p> 
                    <p align="center">
                        <table width = "100%">
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="gdvLatestReviews" runat="server" CellPadding="4" 
                                        ForeColor="#333333" GridLines="None" Width="95%">
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </p>
                    
                    <p align="right">
                        <asp:LinkButton ID="lnkShowAllReviews" runat="server" CssClass="Link">Show 
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
                <br />--%>
                
                
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
