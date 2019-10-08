<%@ Page Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master" AutoEventWireup="false" CodeFile="JobDetails.aspx.vb" Inherits="Employers_JobDetails" title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
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
        
     <table id="Table1" align="center" width="100%" runat= "server">        
     <tr>
            <td class="TextTitle">
                Job Details</td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td align="center" width="25">
                            <asp:Image ID="imgAddEmployee" runat="server" 
                                ImageUrl="~/Images/Icons/AddEmployee.png" />
                        </td>
                        <td align="left" valign="middle" width="140">
                            <asp:LinkButton ID="lnkAddEmployees" runat="server" CssClass="Link">Associate 
                            Employee</asp:LinkButton>
                        </td>
                        <td align="center" width="25">
                            <asp:Image ID="imgManageEmployees" runat="server" 
                                ImageUrl="~/Images/Icons/AllEmployees.png" />
                        </td>
                        <td align="left" valign="middle" width="120">
                            <asp:LinkButton ID="lnkManageEmployees" runat="server" CssClass="Link">Manage 
                            Employees</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblInvalidDate" runat="server" CssClass="RedText" 
                    Text="Invalid Data.  The 'Job End Date' must be set to a date after the 'Job Starting Date'." 
                    Visible="False"></asp:Label>
            </td>
        </tr>
         <tr>
             <td align="center">
                 &nbsp;</td>
         </tr>
        </table>
        <table align="center" width="95%">
        <tr>
            <td align="right" class="titlecell">
                Job Title</td>
            <td align="left" width="20">
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="titlecell" valign="top">
                Description</td>
            <td align="left">
                <asp:TextBox ID="txtDesc" runat="server" CssClass="TextBox" 
                    TextMode="MultiLine" Width="383px"></asp:TextBox>
            </td>
            <td align="left" valign="top">
                <asp:RegularExpressionValidator ID="revDescribtion" runat="server" ErrorMessage="Invalid Job Describtion Entry"
                            ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="2" ControlToValidate="txtDesc"
                            ToolTip="Invalid Job Describtion"><img 
                            src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator>
                    </td>
        </tr>
        <tr>
            <td align="right" class="titlecell" valign="top">
                Requirements</td>
            <td align="left">
                <asp:TextBox ID="txtReq" runat="server" CssClass="TextBox" 
                    TextMode="MultiLine" Width="383px" ReadOnly="True"></asp:TextBox>
            </td>
            <td align="left" valign="top">
                <asp:RegularExpressionValidator ID="revAddress0" runat="server" ErrorMessage="Invalid Requirements Entry"
                            ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="2" ControlToValidate="txtReq"
                            ToolTip="Invalid Requirements"><img 
                            src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator>
                    </td>
        </tr>
        <tr>
            <td align="right" class="titlecell">
                Date Posted</td>
            <td align="left">
                <asp:Label ID="lblPostDate" runat="server"></asp:Label>
            </td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="titlecell">
                Closing Date</td>
            <td align="left">
                        <asp:TextBox ID="txtClosingDate" runat="server" Style="margin-bottom: 0px" 
                            Width="150px" ReadOnly="True" CssClass="TextBox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtClosingDate_CalendarExtender" 
                    runat="server" Enabled="True"
                            Format="MM/dd/yyyy" PopupButtonID="imgClosing" 
                            TargetControlID="txtClosingDate">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="txtClosingDate_MaskedEditExtender" 
                    runat="server" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True" Mask="99/99/9999" MaskType="Date" 
                            TargetControlID="txtClosingDate" 
                            ErrorTooltipEnabled="True">
                        </cc1:MaskedEditExtender>
                        &nbsp;<asp:Image ID="imgClosing" runat="server" ImageUrl="~/Images/Icons/Calendar_Small.png"
                            ToolTip="Calendar" Width="25px" Height="25px" Visible="False" />
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                            ControlExtender="txtClosingDate_MaskedEditExtender" 
                            ControlToValidate="txtClosingDate" CssClass="RedText" 
                            EmptyValueMessage="Date is required" ForeColor="" 
                            InvalidValueMessage="Date is invalid" IsValidEmpty="False" 
                            TooltipMessage="Input a Date" ValidationGroup="2" Font-Bold="False">Please enter 
                            a date.</cc1:MaskedEditValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="titlecell">
                Starting Date</td>
            <td align="left">
                        <asp:TextBox ID="txtStartingDate" runat="server" Width="150px" 
                    ReadOnly="True" CssClass="TextBox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtStartingDate_CalendarExtender" 
                    runat="server" Format="MM/dd/yyyy"
                            PopupButtonID="imgStarting" TargetControlID="txtStartingDate">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="txtStartingDate_MaskedEditExtender" 
                    runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txtStartingDate">
                        </cc1:MaskedEditExtender>
                        &nbsp;<asp:Image ID="imgStarting" runat="server" ImageUrl="~/Images/Icons/Calendar_Small.png"
                            ToolTip="Calendar" Width="25px" Visible="False" />
                        <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" 
                            ControlExtender="txtStartingDate_MaskedEditExtender" 
                            ControlToValidate="txtStartingDate" CssClass="RedText" 
                            EmptyValueMessage="Date is required" ForeColor="" 
                            InvalidValueMessage="Date is invalid" IsValidEmpty="False" 
                            TooltipMessage="Input a Date" ValidationGroup="2" Font-Bold="False">Please enter a date.</cc1:MaskedEditValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="titlecell">
                End Date</td>
            <td align="left" valign="middle">
                        <asp:TextBox ID="txtEndingDate" runat="server" Width="150px" 
                    ReadOnly="True" CssClass="TextBox"></asp:TextBox>
                        &nbsp;<cc1:CalendarExtender ID="txtEndingDate_CalendarExtender" 
                    runat="server" Format="MM/dd/yyyy"
                            PopupButtonID="imgEnding" TargetControlID="txtEndingDate">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="txtEndingDate_MaskedEditExtender" 
                    runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txtEndingDate">
                        </cc1:MaskedEditExtender>
                        <asp:Image ID="imgEnding" runat="server" ImageUrl="~/Images/Icons/Calendar_Small.png"
                            ToolTip="Calendar" Width="25px" Visible="False" />
                        <cc1:MaskedEditValidator ID="MaskedEditValidator3" runat="server" 
                            ControlExtender="txtEndingDate_MaskedEditExtender" 
                            ControlToValidate="txtEndingDate" CssClass="RedText" 
                            EmptyValueMessage="Date is required" ForeColor="" 
                            InvalidValueMessage="Date is invalid" IsValidEmpty="False" 
                            TooltipMessage="Input a Date" ValidationGroup="2" Font-Bold="False">Please enter a date.</cc1:MaskedEditValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr> 
         <tr>
             <td align="right" class="titlecell">
                 Job Type</td>
             <td align="left">
                 <asp:DropDownList ID="ddlJobType" runat="server" Enabled="False">
                 </asp:DropDownList>
             </td>
             <td>
                 <asp:RequiredFieldValidator ID="rfvJobType" runat="server" 
                     ControlToValidate="ddlJobType" ErrorMessage="Job Type Required" 
                     ToolTip="Job Type Required."><img src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
             <td align="right" class="titlecell">
                 No. of Employees Required
             </td>
             <td align="left">
                 <asp:TextBox ID="txtNoEmp" runat="server" CssClass="TextBox" ReadOnly="True" 
                     Width="383px"></asp:TextBox>
             </td>
             <td>
                 <asp:RegularExpressionValidator ID="revNoEmp" runat="server" 
                     ControlToValidate="txtNoEmp" ErrorMessage="Invalid Number of Employees" 
                     ToolTip="Invalid Number of Employees" ValidationExpression="[0-9]+" 
                     ValidationGroup="2"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
             </td>
         </tr>
         <tr>
             <td align="right" class="titlecell">
                 Job Status</td>
             <td align="left">
                 <asp:Label ID="lblJobStatus" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
       </table>
        
            
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
        <ProgressTemplate>
            <asp:Panel ID="pnlLoading2" runat="server" CssClass="LoadingPanel" >
                <table border="0" cellspacing="0" cellpadding="5" align="center">
                    <tr valign="middle">
                        <td align="center" width="5px" height="75">
                            <asp:Image ID="imgLoading2" runat="server" ImageUrl="~/Images/Loading.gif"/>    
                        </td>
                        <td align="left">
                          <asp:Label ID="lblLoading2" runat="server" Text="Loading please wait..." CssClass="BlueText"></asp:Label>  
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
            
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <table width="96%" align="center">
                        <tr>
                            <td class="titlecell" width="240">
                                Industry</td>
                            <td>
                                <asp:TextBox ID="txtIndustry" runat="server"></asp:TextBox>
                                <%--<asp:DropDownList ID="ddlIndustry" runat="server" AutoPostBack="True" 
                                    Enabled="False">
                                </asp:DropDownList>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                Occupation</td>
                            <td>
                                <asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox>
                                <%--<asp:DropDownList ID="ddlOccupation" runat="server" Enabled="False">
                                </asp:DropDownList>--%>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
       
       
        
        
        <table id="Table3" align="center" width="100%" runat= "server">
        <tr>
            <td align="center" width="265">
                &nbsp;</td>
            <td align="left">
                <asp:Button ID="btnEdit" runat="server" CssClass="ButtonLightBlue" Text="Edit" 
                    Width="100px" />
                &nbsp;<asp:Button ID="btnSave" runat="server" CssClass="ButtonLightBlue" 
                    Text="Save Changes" Visible="False" Width="100px" />
            </td>
        </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        <tr>
            <td colspan="2" class="BlueTextBold">
                Associated Employees</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="gdvAddedEmployees" runat="server" CssClass="GridView" 
                    EmptyDataText="No employees are currently associated with this job." 
                    GridLines="None" Width="95%">
                    <RowStyle CssClass="GridViewRow" />
                    <Columns>
                        <asp:CommandField SelectText="View CV" 
                            ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="GridViewHeaderRow" />
                    <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

