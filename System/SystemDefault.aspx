<%@ Page Language="VB" MasterPageFile="~/System/Admin/SystemMasterPage.master" AutoEventWireup="false" CodeFile="SystemDefault.aspx.vb" Inherits="System_SystemDefault" title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" src="clockp.js">
</script>
<script type="text/javascript" src="clockh.js">
</script> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table width="100%" cellpadding="5">
        <tr>
            <td height="150" valign="top" width="70%" colspan="2">
                <asp:Panel ID="pnlRadixNews" runat="server" BackColor="#F9F9F9" Height="240px" 
                    Width="100%">
                
                    <table style="width: 100%;" cellpadding="10px" border="0" cellspacing="0">
                        <tr>
                            <td class="BlueTextBold"  bgcolor="#f2f2f2">
                                Latest News</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlLatestNews" runat="server" Height="185px" 
                                    ScrollBars="Vertical" Width="100%">
                                    <table align="center" border="0" cellpadding="3" cellspacing="0" 
                                        style="width:100%;">
                                        <tr>
                                            <td align="left" class="BlueText" valign="top" width="25%">
                                                Radix Broadens Target</td>
                                            <td align="center" class="GrayText" valign="top" width="65px">
                                                25/09/2009</td>
                                            <td align="left" valign="top">
                                                Radix Systems has now expanded their market by opening braches in Brazil.</td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="BlueText" valign="top" width="25%">
                                                Banif Continues Fast Growth</td>
                                            <td align="center" class="GrayText" valign="top" width="65px">
                                                25/09/2009</td>
                                            <td align="left" valign="top">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="BlueText" valign="top" width="25%">
                                                New Employee</td>
                                            <td align="center" class="GrayText" valign="top" width="65px">
                                                23/09/2009</td>
                                            <td align="left" valign="top">
                                                Ellie has joined our support team.</td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="BlueText" valign="top" width="25%">
                                                Server Maintanence</td>
                                            <td align="center" class="GrayText" valign="top" width="65px">
                                                18/09/2009</td>
                                            <td align="left" valign="top">
                                                Server maintanence to be carried out between 20:00 and 21:00 today.&nbsp; Expect a 
                                                downtime of up to 20 minutes.</td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="BlueText" valign="top" width="25%">
                                                Statistics</td>
                                            <td align="center" class="GrayText" valign="top" width="65px">
                                                02/09/2009</td>
                                            <td align="left" valign="top">
                                                Statistics in the month of August 2009 show an increase in 10% from European countries</td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="BlueText" valign="top" width="25%">
                                                Employee of the Month</td>
                                            <td align="center" class="GrayText" valign="top" width="65px">
                                                29/08/2009</td>
                                            <td align="left" valign="top">
                                                Congratulations to Marielena Kost who has been elected as employee of the month for August 2009.</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlRadixNews_RoundedCornersExtender" 
                    runat="server" Enabled="True" TargetControlID="pnlRadixNews" 
                    BorderColor="225, 225, 225" Color="242, 242, 242">
                </cc1:RoundedCornersExtender>
            </td>
            <td valign="top" width="30%">
                <asp:Panel ID="pnlClock" runat="server" BackColor="#F9F9F9" Height="240px" 
                    Width="100%">
                    <table width="100%" cellpadding="10px" border="0" cellspacing="0">
                        <tr>
                            <td class="BlueTextBold" bgcolor="#f2f2f2">
                                Date & Time</td>
                        </tr>
                        <tr>
                            <td align="left" valign="middle">
                                <div id="clock_a">                                  
                                </div>  
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                
                <cc1:RoundedCornersExtender ID="pnlClock_RoundedCornersExtender" runat="server" 
                    Enabled="True" TargetControlID="pnlClock" BorderColor="225, 225, 225" 
                    Color="242, 242, 242">
                </cc1:RoundedCornersExtender>
                
                </td>
                <td>
                &nbsp;</td>
                  </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlVacancies" runat="server" BackColor="#F9F9F9" Height="290px" 
                    Width="100%">
                    <table width="100%" cellpadding=10px border="0" cellspacing="0">
                        <tr>
                            <td class="BlueTextBold" bgcolor="#f2f2f2">
                                &nbsp;Vacancies
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle">
                            
                                <table style="width:100%;">
                                    <tr>
                                        <td align="left" class="Text">
                                            Server Administrator</td>
                                        <td width="40">
                                            <asp:LinkButton ID="lnkApply1" runat="server" CssClass="Link">Apply</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="Text">
                                            System Administrator</td>
                                        <td width="40">
                                            <asp:LinkButton ID="lnkApply2" runat="server" CssClass="Link">Apply</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="Text">
                                            French Support Personnel</td>
                                        <td width="40">
                                            <asp:LinkButton ID="lnkApply3" runat="server" CssClass="Link">Apply</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="Text">
                                            Chinese Support Personnel</td>
                                        <td width="40">
                                            <asp:LinkButton ID="lnkApply4" runat="server" CssClass="Link">Apply</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                
                <cc1:RoundedCornersExtender ID="pnlVacancies_RoundedCornersExtender" 
                    runat="server" BorderColor="225, 225, 225" Enabled="True" 
                    TargetControlID="pnlVacancies" Color="242, 242, 242">
                </cc1:RoundedCornersExtender>
                
                </td>
            <td width="50%">
                <asp:Panel ID="pnlContactList" runat="server" BackColor="#F9F9F9" Height="290px" 
                    Width="100%">
                    <table width="100%" cellpadding=10px border="0" cellspacing="0">
                        <tr>
                            <td class="BlueTextBold" bgcolor="#f2f2f2">
                                Phonebook
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle">
                            
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table style="width:100%;">
                                            <tr>
                                                <td align="center" width="75%">
                                                    <asp:TextBox ID="txtContactSearch" runat="server" CssClass="TextBox" 
                                                        Width="95%"></asp:TextBox>
                                                    &nbsp;</td>
                                                <td align="left" class="GrayText" valign="middle">
                                                    <asp:LinkButton ID="lnkSearch" runat="server" CssClass="Link">Search</asp:LinkButton>
                                                    &nbsp;|
                                                    <asp:LinkButton ID="lnkViewAll" runat="server" CssClass="Link">View All</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:GridView ID="gdvContactList" runat="server" CssClass="GridView" 
                                                        EmptyDataText="No employees could be found matching your search." 
                                                        GridLines="None" Width="100%" Height="200px">
                                                        <RowStyle CssClass="GridViewRow" />
                                                        <HeaderStyle CssClass="GridViewHeaderRow" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                
                <cc1:RoundedCornersExtender ID="pnlContactList_RoundedCornersExtender" 
                    runat="server" BorderColor="225, 225, 225" Enabled="True" 
                    TargetControlID="pnlContactList" Color="242, 242, 242">
                </cc1:RoundedCornersExtender>
                
                </td>
            <td>
                <asp:Panel ID="pnlToDo" runat="server" BackColor="#F9F9F9" Height="290px" 
                    Width="100%">
                    <table width="100%" cellpadding=10px border="0" cellspacing="0">
                        <tr>
                            <td class="BlueTextBold" bgcolor="#f2f2f2">
                                Calendar</td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle">
                            
                                <asp:Calendar ID="Calendar1" runat="server" BorderColor="Black" 
                                    BorderStyle="None" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" 
                                    ForeColor="Black" Height="140px" NextPrevFormat="ShortMonth" Width="100%">
                                    <SelectedDayStyle BackColor="#414D61" ForeColor="White" />
                                    <WeekendDayStyle ForeColor="#666666" />
                                    <TodayDayStyle BackColor="#EBEBEB" BorderColor="#999999" BorderStyle="Solid" 
                                        BorderWidth="1px" Font-Bold="True" ForeColor="#414D61" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <DayStyle CssClass="Text" />
                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="Silver" />
                                    <DayHeaderStyle CssClass="BlueTextBold" Font-Bold="True" Height="20px" />
                                    <TitleStyle BackColor="#F9F9F9" Font-Bold="True" Font-Size="12pt" 
                                        ForeColor="#333333" Height="20px" />
                                </asp:Calendar>
                            
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlToDo_RoundedCornersExtender" runat="server" 
                    BorderColor="225, 225, 225" Enabled="True" TargetControlID="pnlToDo" 
                    Color="242, 242, 242">
                </cc1:RoundedCornersExtender>
                </td>
                <td>
                &nbsp;</td>
                    </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

