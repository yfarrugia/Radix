<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Error Page.aspx.vb" Inherits="ErrorPages_Error_Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table width="100%">
            <tr>
                <td height="70" valign="middle" width="100%">
                    &nbsp;</td>
            </tr>
        </table>
        <table align="center" width="700" 
            style="border: 1px solid #CCCCCC; vertical-align:middle" bgcolor="#F4F4F4" 
            border="0" cellpadding="10" cellspacing="0">
            <tr>
                <td class="TextTitle">
                                        Ooops! An error seems to have occured</td>
            </tr>
            <tr>
                <td>
                    A error seems to have occured on the page you were browsing.<br />
                    <br />
                    Sorry for the inconvenience this has caused.&nbsp; To help us improve our service please send us your error by clicking on the Report Error button.</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnReturnRadix" runat="server" CssClass="ButtonLightBlue" 
                        PostBackUrl="~/Default.aspx" Text="Go Back" />
                    </td>
            </tr>
            <tr>
                <td>
                <asp:Panel ID="ErrorTitlePanel" runat="server" BackColor="#EAEAEA" CssClass="collapseHeaderErrorReport ">
                    <table style="width:100%;">
                        <tr>
                            <td align="center" width="20">
                                <asp:Image ID="imgCollapse" runat="server" ImageUrl="~/Images/collapse.png" />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblErrorTitle" runat="server" CssClass="GrayText" 
                                    Text="Advanced" Font-Bold="True"></asp:Label>
                            </td>
                            <td width="80">
                            
                                <asp:Label ID="lblErrorShow" runat="server" CssClass="GrayText" 
                                    Text="Show..."></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                        <cc1:RoundedCornersExtender ID="ErrorTitlePanel_RoundedCornersExtender" 
                        runat="server" Enabled="True" TargetControlID="ErrorTitlePanel">
                    </cc1:RoundedCornersExtender>
                <asp:Panel ID="ErrorContentPanel" runat="server">
                <div style="text-align:justify  " align="center">
                    <p align="center">
                        <table width = "100%">
                            <tr>
                                <td align="center">
                                
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="right" class="titlecell" valign="top">
                                                Message</td>
                                            <td align="left">
                                                <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="titlecell" valign="top">
                                                Stack Trace</td>
                                            <td align="left">
                                                <asp:Label ID="lblStackTrace" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td align="left">
                                                <asp:Button ID="btnClearSession" runat="Server" Text="Clear Session" 
                                                    CssClass="ButtonLightBlue" />
                                                &nbsp;<asp:Button ID="btnSendReport" runat="Server" CssClass="ButtonLightBlue" 
                                                    Text="Send Report" />
                                            </td>
                                        </tr>
                                    </table>
                                                                
                                
                                </td>
                            </tr>
                        </table>
                    </p>
                </div>
                </asp:Panel>
                    
                    <cc1:RoundedCornersExtender ID="ErrorContentPanel_RoundedCornersExtender" 
                        runat="server" Corners="Bottom" Enabled="True" 
                        TargetControlID="ErrorContentPanel">
                    </cc1:RoundedCornersExtender>
                    
                    <cc1:CollapsiblePanelExtender ID="ErrorContentPanel_CollapsiblePanelExtender" 
                            runat="server" 
                            Enabled="True" 
                            TargetControlID="ErrorContentPanel"
                            ExpandControlID="ErrorTitlePanel"
                            CollapseControlID="ErrorTitlePanel" 
                            TextLabelID="lblErrorShow" 
                            ExpandedText="Hide..." 
                            CollapsedText="Show..."
                            ImageControlID="imgCollapse" 
                            CollapsedImage="~/Images/collapse.png" 
                            ExpandedImage="~/Images/expand.png"
                            SuppressPostBack="true" 
                            Collapsed="True">
                    </cc1:CollapsiblePanelExtender>
                    
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
