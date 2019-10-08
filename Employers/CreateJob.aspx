<%@ Page Title="" Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master"
    AutoEventWireup="false" CodeFile="CreateJob.aspx.vb" Inherits="Employers_CreateJob" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table align="center" width="100%" runat= "server">
               </tr>
                <tr>
                                    <td colspan="2" class="TextTitle">
                                        Create a Job Posting</td>
               </tr>
                <tr>
                   <td class="Text" colspan="2" align="center" >
                        <asp:Label ID="lblInvalidDate" runat="server" CssClass="RedText" 
                            Text="Invalid Data.  The 'Job End Date' must be set to a date after the 'Job Starting Date' and 'Job Closing Date'." 
                            Visible="False"></asp:Label>
                        </td>
               </tr>
                <tr>
                   <td class="titlecell">
                        Company</td>
                    <td align="left">
                        <asp:Label ID="lblCompany" runat="server"></asp:Label>
                    </td>
               </tr>
                <tr>
                   <td class="titlecell">
                        Job Title</td>
                    <td align="left">
                        <asp:TextBox ID="txtJobTitle" runat="server" MaxLength="30" Width="253px" CssClass="TextBox"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="rfvTitle" runat="server" ErrorMessage="Job Title Required"
                            ToolTip="Job Title Required" ControlToValidate="txtJobTitle" 
                            ValidationGroup="2"><img  src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                    </td>
               </tr>
                <tr>
                  <td class="titlecell" valign="top">
                        Job Description</td>
                   <td valign="top" align="left">
                        <asp:TextBox ID="txtDescription" runat="server" MaxLength="100" 
                            TextMode="MultiLine" CssClass="TextBox" Columns="40" Rows="10"></asp:TextBox>
                        &nbsp;<asp:RegularExpressionValidator ID="revDescribtion" runat="server" ErrorMessage="Invalid Job Describtion Entry"
                            ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="2" ControlToValidate="txtDescription"
                            ToolTip="Invalid Job Describtion"><img src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator>
                    </td>
               </tr>
                <tr>
                   <td class="titlecell" valign="top">
                        Job Requirements</td>
                    <td>
                        <asp:TextBox ID="txtRequirements" runat="server" MaxLength="100" 
                            TextMode="MultiLine" CssClass="TextBox" Columns="40" Rows="10"></asp:TextBox>
                        &nbsp;<asp:RegularExpressionValidator ID="revAddress0" runat="server" ErrorMessage="Invalid Requirements Entry"
                            ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="2" ControlToValidate="txtRequirements"
                            ToolTip="Invalid Requirements"><img src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator>
                    </td>
               </tr>
                <tr>
                   <td class="titlecell">
                        Post Closing Date</td>
                   <td align="left">
                        <asp:TextBox ID="txtClosingDate" runat="server" Style="margin-bottom: 0px" 
                            Width="150px" CssClass="TextBox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtClosingDate_CalendarExtender" runat="server" Enabled="True"
                            Format="MM/dd/yyyy" PopupButtonID="imgClosing" TargetControlID="txtClosingDate">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="txtClosingDate_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True" Mask="99/99/9999" MaskType="Date" 
                            TargetControlID="txtClosingDate" 
                            ErrorTooltipEnabled="True">
                        </cc1:MaskedEditExtender>
                        &nbsp;<asp:Image ID="imgClosing" runat="server" ImageUrl="~/Images/Icons/Calendar_Small.png"
                            ToolTip="Calendar" Width="25px" Height="25px" />
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                            ControlExtender="txtClosingDate_MaskedEditExtender" 
                            ControlToValidate="txtClosingDate" CssClass="RedText" 
                            EmptyValueMessage="Date is required" ForeColor="" 
                            InvalidValueMessage="Date is invalid" IsValidEmpty="False" 
                            TooltipMessage="Input a Date" ValidationGroup="2">Please enter a date.</cc1:MaskedEditValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="revClosing" runat="server" 
                            ControlToValidate="txtClosingDate" CssClass="RedText" 
                            ErrorMessage="Valid Date Format: mm/dd/yyyy" ForeColor="" 
                            ValidationExpression="((^(10|12|0?[13578])([/])(3[01]|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(11|0?[469])([/])(30|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(2[0-8]|1[0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(29)([/])([2468][048]00)$)|(^(0?2)([/])(29)([/])([3579][26]00)$)|(^(0?2)([/])(29)([/])([1][89][0][48])$)|(^(0?2)([/])(29)([/])([2-9][0-9][0][48])$)|(^(0?2)([/])(29)([/])([1][89][2468][048])$)|(^(0?2)([/])(29)([/])([2-9][0-9][2468][048])$)|(^(0?2)([/])(29)([/])([1][89][13579][26])$)|(^(0?2)([/])(29)([/])([2-9][0-9][13579][26])$))"></asp:RegularExpressionValidator>
&nbsp;
                    </td>
               </tr>
                <tr>
                    <td class="titlecell">
                        Job Starting Date</td>
                   <td align="left">
                        <asp:TextBox ID="txtStartingDate" runat="server" Width="150px" 
                            CssClass="TextBox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtStartingDate_CalendarExtender" runat="server" Format="MM/dd/yyyy"
                            PopupButtonID="imgStarting" TargetControlID="txtStartingDate">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="txtStartingDate_MaskedEditExtender" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txtStartingDate">
                        </cc1:MaskedEditExtender>
                        &nbsp;<asp:Image ID="imgStarting" runat="server" ImageUrl="~/Images/Icons/Calendar_Small.png"
                            ToolTip="Calendar" Width="25px" />
                        <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" 
                            ControlExtender="txtStartingDate_MaskedEditExtender" 
                            ControlToValidate="txtStartingDate" CssClass="RedText" 
                            EmptyValueMessage="Date is required" ForeColor="" 
                            InvalidValueMessage="Date is invalid" IsValidEmpty="False" 
                            TooltipMessage="Input a Date" ValidationGroup="2">Please enter a date.</cc1:MaskedEditValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="revStarting" runat="server" 
                            ControlToValidate="txtStartingDate" CssClass="RedText" 
                            ErrorMessage="Valid Date Format: mm/dd/yyyy" ForeColor="" 
                            ValidationExpression="((^(10|12|0?[13578])([/])(3[01]|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(11|0?[469])([/])(30|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(2[0-8]|1[0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(29)([/])([2468][048]00)$)|(^(0?2)([/])(29)([/])([3579][26]00)$)|(^(0?2)([/])(29)([/])([1][89][0][48])$)|(^(0?2)([/])(29)([/])([2-9][0-9][0][48])$)|(^(0?2)([/])(29)([/])([1][89][2468][048])$)|(^(0?2)([/])(29)([/])([2-9][0-9][2468][048])$)|(^(0?2)([/])(29)([/])([1][89][13579][26])$)|(^(0?2)([/])(29)([/])([2-9][0-9][13579][26])$))"></asp:RegularExpressionValidator>
&nbsp;
                    </td>
               </tr>
                <tr>
                    <td class="titlecell">
                        Job Ending Date</td>
                   <td align="left">
                        <asp:TextBox ID="txtEndingDate" runat="server" Width="150px" CssClass="TextBox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtEndingDate_CalendarExtender" runat="server" Format="MM/dd/yyyy"
                            PopupButtonID="imgEnding" TargetControlID="txtEndingDate">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="txtEndingDate_MaskedEditExtender" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txtEndingDate">
                        </cc1:MaskedEditExtender>
                        &nbsp;<asp:Image ID="imgEnding" runat="server" ImageUrl="~/Images/Icons/Calendar_Small.png"
                            ToolTip="Calendar" Width="25px" />
                        <cc1:MaskedEditValidator ID="MaskedEditValidator3" runat="server" 
                            ControlExtender="txtEndingDate_MaskedEditExtender" 
                            ControlToValidate="txtEndingDate" CssClass="RedText" 
                            EmptyValueMessage="Date is required" ForeColor="" 
                            InvalidValueMessage="Date is invalid" IsValidEmpty="False" 
                            TooltipMessage="Input a Date" ValidationGroup="2">Please enter a date.</cc1:MaskedEditValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="revEnding" runat="server" 
                            ControlToValidate="txtEndingDate" CssClass="RedText" 
                            ErrorMessage="Valid Date Format: mm/dd/yyyy" ForeColor="" 
                            ValidationExpression="((^(10|12|0?[13578])([/])(3[01]|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(11|0?[469])([/])(30|[12][0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(2[0-8]|1[0-9]|0?[1-9])([/])((1[8-9]\d{2})|([2-9]\d{3}))$)|(^(0?2)([/])(29)([/])([2468][048]00)$)|(^(0?2)([/])(29)([/])([3579][26]00)$)|(^(0?2)([/])(29)([/])([1][89][0][48])$)|(^(0?2)([/])(29)([/])([2-9][0-9][0][48])$)|(^(0?2)([/])(29)([/])([1][89][2468][048])$)|(^(0?2)([/])(29)([/])([2-9][0-9][2468][048])$)|(^(0?2)([/])(29)([/])([1][89][13579][26])$)|(^(0?2)([/])(29)([/])([2-9][0-9][13579][26])$))"></asp:RegularExpressionValidator>
&nbsp;
                    </td>
               </tr>
                 <tr>
                     <td class="titlecell">
                         Job Type</td>
                     <td align="left">
                         <asp:DropDownList ID="ddlJobType" runat="server" Width="150px">
                         </asp:DropDownList>
                         &nbsp;<asp:RequiredFieldValidator ID="rfvJobType" runat="server" 
                             ControlToValidate="ddlJobType" ErrorMessage="Job Type Required" 
                             ToolTip="Job Type Required." ValidationGroup="2"><img src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                     </td>
                </tr>
                <tr>
                    <td class="titlecell">
                        Number of Required Employees</td>
                    <td align="left">
                        <asp:TextBox ID="txtNoEmp" runat="server" Width="150px" CssClass="TextBox"></asp:TextBox>
                        &nbsp;<asp:RegularExpressionValidator ID="revNoEmp" runat="server" 
                            ControlToValidate="txtNoEmp" ErrorMessage="Invalid Number of Employees" 
                            ToolTip="Invalid Number of Employees" ValidationExpression="[0-9]+" 
                            ValidationGroup="2"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                    </td>
                </tr>
                 </table>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
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
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <table runat="server" align="center" width="100%">
                        <tr>
                            <td class="titlecell" width="277">
                                Industry</td>
                            <td>
                                <asp:DropDownList ID="ddlIndustry" runat="server" AutoPostBack="True" 
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                Occupation</td>
                            <td>
                                <asp:DropDownList ID="ddlOccupation" runat="server" Width="150px">
                                </asp:DropDownList>
                                &nbsp;<asp:RequiredFieldValidator ID="rfvOccupation" runat="server" 
                                    ControlToValidate="ddlOccupation" ErrorMessage="Occupation Required" 
                                    ToolTip="Occupation Required." ValidationGroup="2"><img 
                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
                <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="ButtonLightBlue" 
                            Text="Submit" ValidationGroup="2" />
                        </td>
               </tr>
             
             </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
