<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TestPopup.aspx.vb" Inherits="ChircopTest_TestPopup" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <br />
        <br />
    <asp:Button ID="Button1" runat="server" Text="Button" Height="26px" />
        <br />
        <br />
        <br />
        <br />
        
    <asp:Panel ID="Panel1" runat="server" BackColor="#6600FF">
        fdhsafhsadaosda<br />
        <br />
        asd<br />
        asda<br />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Button" />
    </asp:Panel>
        
        <cc1:PopupControlExtender ID="Panel1_PopupControlExtender" runat="server" 
            DynamicServicePath="" Enabled="True" ExtenderControlID="" 
            TargetControlID="Panel1"
            PopupControlID="Panel1">
        </cc1:PopupControlExtender>
        
        <br />
        <br />
    
    </form>
</body>
</html>
