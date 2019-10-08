<%@ Page Title="" Language="VB" AutoEventWireup="false" CodeFile="CurrentlyEmployedByCountry.aspx.vb" Inherits="Reports_CurrentlyEmployedByCountry" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="Label1" runat="server" Text="Loading Please Wait..."></asp:Label>
        <br />
        
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="pnlLoading" runat="server" CssClass="LoadingPanel" >
                <table border="0" cellspacing="0" cellpadding="5" align="center">
                    <tr valign="middle">
                        <td align="center" width="5px" height="75">
                            <asp:Image ID="imgLoading" runat="server" ImageUrl="~/Images/Loading.gif"/>    
                        </td>
                        <td align="left">
                          <asp:Label ID="lblLoading" runat="server" Text="Loading please wait..." CssClass="BlueText"></asp:Label>  
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
    AutoDataBind="True" Height="50px"
    Width="350px" DisplayGroupTree="False" EnableTheming="True" HasCrystalLogo="False" 
                    HasToggleGroupTreeButton="False" HasViewList="False" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />

        </div>
    </form>
</body>
</html>