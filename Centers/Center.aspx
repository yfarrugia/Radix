<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Center.aspx.vb" Inherits="Centers_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../Styles.css" rel="stylesheet" type="text/css" />

</head>
<body id="BodyControl" runat="server" >

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width = "100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <table width="780">
                    <tr>
                        <td>
                            <table style="width:100%;">
                                <tr>
                                    <td align="left" valign="middle" height="90">
                                        <table width="100%">
                                            <tr>
                                                <td align="center" valign="middle" width="80">
                                        <asp:Image ID="imgCenterLogo" runat="server" 
                                            ImageUrl="~/Centers/Images/Logos/Logo1.png" />
                                                </td>
                                                <td align="left" valign="middle">
                                        <asp:Label ID="lblCenterName" runat="server" Text="Center Name" 
                                            Font-Size="26pt"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblSupported" runat="server" Text="Supported By:" 
                                            CssClass="DarkBlueText" Font-Bold="True" Font-Italic="True"></asp:Label>
                                        &nbsp;<asp:ImageButton ID="img" runat="server" 
                                            ImageUrl="~/Centers/Images/RadixLogo.png" />&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center" valign="top">
                                            <asp:Table id="tblBanner" width="779px" Height="177px" runat="server" 
                                                BackImageUrl="~/Centers/Images/Banners/Banner1.png">
                                                <asp:TableRow Height= "80%">
                                                    <asp:TableCell>
                                                        &nbsp;</asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell HorizontalAlign="Left">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Label ID="lblCenterSlogan" runat="server" Text="This is my slogan"></asp:Label>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell>
                                                        &nbsp;</asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                            <br />
                                            
                                            <marquee id="MovingText" runat="server" direction="left" scrollamount = 2 scrolldelay=175>
                                            <asp:Label ID="lblMarquee" runat="server" Text="Label"></asp:Label></marquee>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:100%">
                            <asp:Panel ID="pnlMain" runat="server" BackColor="#CCCCCC" 
                                Width="780px">
                                <br />
                                
                                <table cellpadding="3" width="98%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <asp:Panel ID="pnlLeftPanel" runat="server" Width="98%">
                                                
                                                <table width="98%">
                    <tr>
                        <td align="center">
                        <asp:Panel ID="LeftContentTitlePanel1" runat="server" >
                            <table width="100%">
                                <tr>
                                    <td align="center" width="20">
                                        <asp:Image ID="imgCollapse" runat="server" ImageUrl="~/Images/collapse.png" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblLeftTitle1" runat="server" CssClass="BlueTextBold" 
                                            Text="Latest Jobs" ForeColor="White"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                                <cc1:RoundedCornersExtender ID="LeftContentTitlePanel1_RoundedCornersExtender" 
                                runat="server" Enabled="True" TargetControlID="LeftContentTitlePanel1"></cc1:RoundedCornersExtender>
                                </td>
                            </tr>
                        </table>              
                        <cc1:CollapsiblePanelExtender ID="LeftContentPanel1_CollapsiblePanelExtender" 
                            runat="server" Enabled="True" 
                            TargetControlID="LeftContentPanel1"
                            ExpandControlID="LeftContentTitlePanel1"
                            CollapseControlID="LeftContentTitlePanel1"
                            Collapsed ="false" 
                            ImageControlID="imgCollapse" 
                            CollapsedImage="~/Images/collapse.png" 
                            ExpandedImage="~/Images/expand.png"
                            SuppressPostBack="true"></cc1:CollapsiblePanelExtender>
                        
                        <asp:Panel ID="LeftContentPanel1" runat="server">
                        <div style="text-align:justify  ">
                         
                            <table width="98%">
                                <tr>
                                    <td align="justify">
                                        <br />
                                        <asp:Label ID="lblLeftContent1" runat="server" 
                                            Text="Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label  &lt;p/&gt; asdasdasdsadLabel Label Label Label Label Label"></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        </asp:Panel>
                        <br/>
                                                        
                                              
                                              <table width="98%">
                            <tr>
                                <td align="center">
                        <asp:Panel ID="LeftContentTitlePanel2" runat="server" >
                            <table style="width:100%;">
                                <tr>
                                    <td align="center" width="20">
                                        <asp:Image ID="imgCollapse2" runat="server" ImageUrl="~/Images/collapse.png" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblLeftTitle2" runat="server" CssClass="BlueTextBold" 
                                            Text="Latest Jobs" ForeColor="White"></asp:Label>
                                    </td>
                                    <td width="80">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                                    <cc1:RoundedCornersExtender ID="LeftContentTitlePanel2_RoundedCornersExtender" 
                                        runat="server" Enabled="True" TargetControlID="LeftContentTitlePanel2"></cc1:RoundedCornersExtender>
                                </td>
                            </tr>
                        </table>              
                        
                        <asp:Panel ID="LeftContentPanel2" runat="server" >
                        <div style="text-align:justify">
                         
                            <table style="width:100%;">
                                <tr>
                                    <td align="justify">
                                        <br />
                                        <asp:Label ID="lblLeftContent2" runat="server" 
                                            
                                            Text="Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label  &lt;p/&gt; asdasdasdsadLabel Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        </asp:Panel>
                        <cc1:CollapsiblePanelExtender ID="LeftContentPanel2_CollapsiblePanelExtender" 
                            runat="server" Enabled="True" 
                            TargetControlID="LeftContentPanel2"
                            ExpandControlID="LeftContentTitlePanel2"
                            CollapseControlID="LeftContentTitlePanel2"
                            Collapsed ="true" 
                            ImageControlID="imgCollapse2" 
                            CollapsedImage="~/Images/collapse.png" 
                            ExpandedImage="~/Images/expand.png"
                            SuppressPostBack="true"></cc1:CollapsiblePanelExtender>
                                            </asp:Panel>
                                            </td>
                                        <td align="center" valign="top" width="37%">
                                            <table style="width:100%;" border="0" cellpadding="5" cellspacing="0">
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <asp:Label ID="lblRightTitle1" runat="server" Text="Contact Us" 
                                                            CssClass="BlueTextBold" ForeColor="White"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <asp:Label ID="lblRightContent1" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        <asp:Label ID="lblRightTitle2" runat="server" Text="Where Are We?" 
                                                            CssClass="BlueTextBold" ForeColor="White"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="10px">
                                                        <br />
                                                        
                                                        <br />
                                                        <br />
                                                    </td>
                                                    <td align="center">
                                                        <uc1:GoogleMapForASPNet ID="GoogleMapCenter" runat="server" 
                                                            ShowControls="False" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <cc1:RoundedCornersExtender ID="pnlMain_RoundedCornersExtender" runat="server" 
                                Enabled="True" Radius="15" TargetControlID="pnlMain" BorderColor="White" 
                                Color="96, 106, 121">
                            </cc1:RoundedCornersExtender>
                            <br />
                                                    </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblCenterRights" runat="server" CssClass="GrayText" 
                                Text="Center Name"></asp:Label>
                            <br />
                            <asp:Label ID="lblCopyRight" runat="server" CssClass="GrayText" 
                                Text="Copyrights Radix Systems 2009. All Rights Reserved.  "></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

    </table>

</form>

</body>
</html>
