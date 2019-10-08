<%@ Page Language="VB" MasterPageFile="~/CenterAdmin/CenterAdminMasterPage.master"
    AutoEventWireup="false" CodeFile="CenterProfile.aspx.vb" Inherits="CenterAdmin_CenterProfile"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="CenterName" runat="server" class="TextTitle">
                *NO_CENTER_TITLE*
            </div>
                    <table class="detailViewEdit" align="center" width="95%">
                        <tr>
                            <td class="titlecell">
                                Address
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="TextBox" Visible="False"></asp:TextBox>
                                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                Street Address
                            </td>
                            <td>
                                <asp:TextBox ID="txtStreetAddress" runat="server" CssClass="TextBox" Visible="False"></asp:TextBox>
                                <asp:Label ID="lblStreetAddress" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                Post Code
                            </td>
                            <td>
                                <asp:TextBox ID="txtPostCode" runat="server" CssClass="TextBox" Visible="False"></asp:TextBox>
                                <asp:Label ID="lblPostCode" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                Town
                            </td>
                            <td>
                                <asp:TextBox ID="txtTown" runat="server" CssClass="TextBox" Visible="False"></asp:TextBox>
                                <asp:Label ID="lblTown" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                State
                            </td>
                            <td>
                                <asp:TextBox ID="txtState" runat="server" CssClass="TextBox" Visible="False"></asp:TextBox>
                                <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                Country
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCountry" runat="server" Enabled="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                Contact Number
                            </td>
                            <td>
                                <asp:TextBox ID="txtContactNumber" runat="server" CssClass="TextBox" Visible="False"></asp:TextBox>
                                <asp:Label ID="lblContactNumber" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                E-Mail
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Visible="False"></asp:TextBox>
                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
            <br />
            
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="ButtonLightBlue" />
                &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" CssClass="ButtonLightBlue" Visible="false" />
                <span style="padding: 5px;"></span>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="ButtonLightBlue" Visible="false" />
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
