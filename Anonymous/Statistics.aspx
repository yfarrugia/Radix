<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Statistics.aspx.vb" Inherits="Anonymous_Statistics" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;" cellpadding="3">
            <tr>
                <td>
                    <table style="width:60%;" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="7">
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/TitleIcon.png" />
                            </td>
                            <td align="left" class="TextTitle">
                                Statistics</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="Text">
                    Select a report to view detailed information about the statistics of Radix</td>
            </tr>
            <tr>
                <td>
                    <table align="center" width="700">
                        <tr>
                            <td valign="top">
                                <table style="width:100%;">
                                    <tr>
                                        <td class="TextBold">
                                            The number of Employees, currently employeed for each Country</td>
                                    </tr>
                                    <tr>
                                        <td align="justify" class="Text" valign="top">
                                            The following report shows the number of employees in each registered country 
                                            are currently&nbsp; employed through the Radix System. </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                <asp:LinkButton ID="lnkCurrentlyEmployedRPT" runat="server" CssClass="Link" 
                                    PostBackUrl="~/Reports/CurrentlyEmployedByCountry.aspx" 
                                    ToolTip="Number of employees currently employed">Number of employees 
                                currently employed</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right" class="HorzSplitter">
                                <a href="javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(">&nbsp;</a></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table style="width:100%;">
                                    <tr>
                                        <td class="TextBold">
                                            Yearly number of employees, employed through Radix System</td>
                                    </tr>
                                    <tr>
                                        <td align="justify" class="Text" valign="top">
                                            The following report displays the number of employees employed Yearly through 
                                            Radix for each registered Country</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                <asp:LinkButton ID="lnkEmployeeYearlyRPT" runat="server" CssClass="Link" 
                                    PostBackUrl="~/Reports/EmployeeEmployeedByYear.aspx" 
                                    ToolTip="Yearly Employment rate per Country">Yearly Employment rate per 
                                Country</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right" class="HorzSplitter">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table style="width:100%;">
                                    <tr>
                                        <td class="TextBold">
                                            Yearly number of jobs created for each type of Job Type</td>
                                    </tr>
                                    <tr>
                                        <td align="justify" class="Text" valign="top">
                                            The following report shows the amount of jobs created yearly for each type of 
                                            job type (ex: Part Time, Full Time)</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                <asp:LinkButton ID="lnkJobTypeRPT" runat="server" CssClass="Link" 
                                    ToolTip="Yearly Amount of jobs created categorised by Job Type" 
                                    PostBackUrl="~/Reports/NumberOfJobByJobType.aspx">Yearly Amount of jobs 
                                created categorised by Job Type</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                   
                </td>
            </tr>
            </table>
</asp:Content>

