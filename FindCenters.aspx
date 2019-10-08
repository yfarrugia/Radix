<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FindCenters.aspx.vb" Inherits="AllUsers_FindCenters" title="Untitled Page" %>

<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width:100%;">
        <tr>
            <td class="TextTitle">
                Our Centers</td>
        </tr>
        <tr>
            <td>
                <p>
                Radix Systems provides extended service world-wide and this is only achieved by 
                the dedicated support of our centers.
                </p>
                <p>
                Centers often offer a range of services, importantly however, they offer the 
                service of managing your account as an employee.&nbsp; This feature allows users 
                that do not yet have a freely availably Internet access point to have access 
                into our service.
                </p>
                <p>
                Below is a representation of our centers worldwide.
                </p>
                </td>
        </tr>
        <tr>
            <td>
                <br />
                <uc1:GoogleMapForASPNet ID="CentersGoogleMap" runat="server" />
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

