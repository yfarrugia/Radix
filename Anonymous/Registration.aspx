<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Registration.aspx.vb" Inherits="AllUsers_Registration" title="Register" %>

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
                                Register
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                </td>
            </tr>
            <tr>
                <td class="Text">
                    Select the type of registration you would like to perform from the 
                    options below.</td>
            </tr>
            <tr>
                <td>
                    <table align="center" width="700">
                        <tr>
                            <td align="center" width="140" rowspan="2">
                                <asp:Image ID="imgEmployers" runat="server" 
                                    ImageUrl="~/Images/Registration/Employer.png" />
                            </td>
                            <td valign="top">
                                <table style="width:100%;">
                                    <tr>
                                        <td class="TextBold">
                                            Looking for employees?</td>
                                    </tr>
                                    <tr>
                                        <td align="justify" class="Text" valign="top">
                                            Join our international recruitment service to bring the best possible employees 
                                            to your business.</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                <asp:LinkButton ID="lnkEmployerReg" runat="server" CssClass="Link" 
                                    ToolTip="Employer Registration" 
                                    PostBackUrl="~/Anonymous/EmployerRegistration.aspx">Employer 
                                Registration</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right" colspan="2" class="HorzSplitter">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" rowspan="2">
                                <asp:Image ID="imgEmployers0" runat="server" 
                                    ImageUrl="~/Images/Registration/Employee.png" />
                            </td>
                            <td valign="top">
                                <table style="width:100%;">
                                    <tr>
                                        <td class="TextBold">
                                            Seeking Employment?</td>
                                    </tr>
                                    <tr>
                                        <td align="justify" class="Text" valign="top">
                                            Interested in looking for a job?&nbsp; Select the types of jobs you are 
                                            interested in enrolling for and get contacted when an opportunity may arrise!</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                <asp:LinkButton ID="lnkEmployeeReg" runat="server" CssClass="Link" 
                                    PostBackUrl="~/Anonymous/EmployeeRegistration.aspx" 
                                    ToolTip="Employee Registration">Employee 
                                Registration</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right" colspan= 2 class="HorzSplitter">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" rowspan="2">
                                <asp:Image ID="imgEmployers1" runat="server" 
                                    ImageUrl="~/Images/Registration/Center.png" />
                            </td>
                            <td valign="top">
                                <table style="width:100%;">
                                    <tr>
                                        <td class="TextBold">
                                            Interested in extending our services?</td>
                                    </tr>
                                    <tr>
                                        <td align="justify" class="Text" valign="top">
                                            Does your organization already provide a service to the community?  Would you like to increase your target market by attracting Radix customers.</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                <asp:LinkButton ID="lnkCenterReg" runat="server" CssClass="Link" 
                                    ToolTip="Center Registration" 
                                    PostBackUrl="~/Anonymous/CenterRegistration.aspx">Center 
                                Registration</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                   
                </td>
            </tr>
            </table>
</asp:Content>

