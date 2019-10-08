<%@ Page Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master" AutoEventWireup="false" CodeFile="AddEmployeeToJob.aspx.vb" Inherits="Employers_AddEmployeeToJob" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
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
    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td class="TextTitle">
                        Associate Employee</td>
                </tr>
                <tr>
                    <td>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" frame="border" 
                            width="100%">
                            <tr>
                                <td class="Text">
                                    Please select from the options below what kind of filter you would like to apply 
                                    to your search.</td>
                            </tr>
                            <tr>
                                <td class="BlueTextBold">
                                    Employee Preferences</td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxOccupation" runat="server" CssClass="Text" 
                                                    Text="Filter employees based on their preferred occupation. &lt;i&gt;(Ex: Architect)&lt;/i&gt;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxJobType" runat="server" CssClass="Text" 
                                                    Text="Filter employees on their preferred job type. &lt;i&gt;(Example: Full Time, Part Time, Temporary or Sub-Contracted)" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="BlueTextBold">
                                    Employee Status</td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center" border="0" cellpadding="5" cellspacing="0" width="90%">
                                        <tr class="Text">
                                            <td class="titlecell">
                                                Sponsored</td>
                                            <td>
                                                <asp:RadioButtonList ID="rdblSponsored" runat="server" CssClass="Text" 
                                                    RepeatDirection="Horizontal" Width="400px" RepeatColumns="3">
                                                    <asp:ListItem>Sponsored</asp:ListItem>
                                                    <asp:ListItem>Not Sponsored</asp:ListItem>
                                                    <asp:ListItem Selected="True">Both</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr class="Text">
                                            <td class="titlecell">
                                                Seeking Employment</td>
                                            <td>
                                                <asp:RadioButtonList ID="rdblSeeking" runat="server" 
                                                    RepeatDirection="Horizontal" Width="400px" RepeatColumns="3">
                                                    <asp:ListItem>Is Seeking</asp:ListItem>
                                                    <asp:ListItem>Not Seeking</asp:ListItem>
                                                    <asp:ListItem Selected="True">Both</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr class="Text">
                                            <td class="titlecell">
                                                Employment Status</td>
                                            <td>
                                                <asp:RadioButtonList ID="rdblEmployed" runat="server" 
                                                    RepeatDirection="Horizontal" Width="400px">
                                                    <asp:ListItem>Employed</asp:ListItem>
                                                    <asp:ListItem>Not Employed</asp:ListItem>
                                                    <asp:ListItem Selected="True">Both</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnFilter" runat="server" CssClass="ButtonLightBlue" 
                                        Text="Apply Filter" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblError" runat="server" CssClass="RedText" 
                            Text="You must first select an employee." Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblSuccess" runat="server" CssClass="GreenText"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gdvEmployees" runat="server" CssClass="GridView" 
                            EmptyDataText="No employees have been found matching your filter or job industry type." 
                            GridLines="None" Width="95%">
                            <RowStyle CssClass="GridViewRow" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbx" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:CommandField SelectText="View CV" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle CssClass="GridViewHeaderRow" />
                            <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnAddEmployees" runat="server" CssClass="ButtonLightBlue" 
                            Text="Add Employees" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;</td>
                </tr>
            </table>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

