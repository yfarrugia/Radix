<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="EmployerRegistration.aspx.vb" Inherits="Anonymous_EmployeeRegistration"
    Title="Employee Registration" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .barIndicatorBorder {
        border:solid 0px #c0c0c0;
        width:200px;
        }

        .barIndicator_poor {
        background-color:#e2e2e2;
        }

        .barIndicator_weak {
        background-color:#88a2b9;
        }

        .barIndicator_good {
        background-color:#617e9a;
        }

        .barIndicator_strong {
        background-color:#315070;
        }

        .barIndicator_excellent {
        background-color:#414d61;   
        }
        .style8
        {
            width: 66px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;" cellpadding="3">
        <tr>
            <td>
                <table style="width: 60%;" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="7">
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/TitleIcon.png" />
                        </td>
                        <td align="left" class="TextTitle">
                            Employer Registration
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Text">
                Enter the details below to complete your registration; <b>bold field names</b> are
                required fields.
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table width="750">
                            <tr>
                                <td>
                                    <asp:MultiView ID="RegistrationProcessView" runat="server">
                                        <asp:View ID="UserAccountView" runat="server">
                                            <table cellpadding="3" style="width: 100%;">
                                                <tr>
                                                    <td align="center" class="BlueText" colspan="4">
                                                        <asp:Label ID="lblStep1_1" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image7" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep2_1" runat="server" Text="Label"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image8" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep3_1" runat="server" Text="Label"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image9" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep4_1" runat="server" Text="Label"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image19" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep5_1" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        <asp:Label ID="lblUsername" runat="server" CssClass="TextBold" Text="Username:"></asp:Label>
                                                    </td>
                                                    <td align="left" width="150">
                                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="TextBox" Width="150px" MaxLength="20"></asp:TextBox>
                                                        <cc1:HoverMenuExtender ID="txtUsername_HoverMenuExtender" runat="server" DynamicServicePath=""
                                                            Enabled="True" TargetControlID="txtUsername" HoverDelay="50" OffsetY="5" PopDelay="50"
                                                            PopupControlID="pnlUsernameTips" PopupPosition="Bottom"></cc1:HoverMenuExtender>
                                                    </td>
                                                    <td align="left" class="style8">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUsername"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Username is a required field."
                                                            ValidationGroup="2"><img 
                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                            ControlToValidate="txtUsername" CssClass="RedText" ErrorMessage="Invalid Username characters."
                                                            ForeColor="" ToolTip="Invalid Username." ValidationExpression="([a-zA-Z0-9]{5,20})+"
                                                            ValidationGroup="2"><img 
                                                            src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                        <asp:Image ID="imgTick" runat="server" ImageUrl="~/Images/Icons/Tick_Small.png" ToolTip="Username Available"
                                                            Visible="False" />
                                                        <asp:Image ID="imgCross" runat="server" ImageUrl="~/Images/Icons/Cross.png" ToolTip="Username Already Used"
                                                            Visible="False" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkAvailability" runat="server" CssClass="GreenText">Check Availability</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lblStrength" runat="server" CssClass="Text" Font-Italic="True" ForeColor="Gray"
                                                            Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblPassword" runat="server" CssClass="TextBold" Text="Password:"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" Width="150px" TextMode="Password"
                                                            MaxLength="20" />
                                                            <cc1:PasswordStrength ID="txtPassword_PasswordStrength" runat="server" 
                                                            Enabled="True" 
                                                            TargetControlID="txtPassword"
                                                            DisplayPosition="RightSide"
                                                            MinimumSymbolCharacters="0"
                                                            MinimumUpperCaseCharacters="1"
                                                            PreferredPasswordLength="10"
                                                            CalculationWeightings="25;25;15;35"
                                                            RequiresUpperAndLowerCaseCharacters="true"
                                                            TextStrengthDescriptions="Poor; Weak; Good; Strong; Excellent"
                                                            HelpStatusLabelID="lblStrength"
                                                            StrengthIndicatorType="BarIndicator"
                                                            HelpHandlePosition="AboveLeft"
                                                            BarBorderCssClass="barIndicatorBorder"
                                                            StrengthStyles="barIndicator_poor; barIndicator_weak; barIndicator_good; barIndicator_strong; barIndicator_excellent" 
                                                            MinimumNumericCharacters="1">
                                                        </cc1:PasswordStrength>
                                                    </td>
                                                    <td align="left" class="RedText" colspan="2">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Password is a required field."
                                                            ValidationGroup="2"><img 
                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                            ControlToValidate="txtPassword" CssClass="RedText" ErrorMessage="Invalid Username characters."
                                                            ForeColor="" ToolTip="Invalid Password." ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{5,20})$"
                                                            ValidationGroup="2"><img 
                                                            src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblConfPassword" runat="server" CssClass="TextBold" Text="Re-Enter Password:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtConfPassword" runat="server" CssClass="TextBox" TextMode="Password"
                                                            Width="150px" MaxLength="20"></asp:TextBox>
                                                    </td>
                                                    <td align="left" colspan="2" valign="middle">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfPassword"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Re-Enter Password is a required field."
                                                            ValidationGroup="2"><img 
                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                                                            ControlToValidate="txtConfPassword" CssClass="RedText" ErrorMessage="CompareValidator"
                                                            ForeColor="" ToolTip="This field and the Password field do not match exactly."
                                                            ValidationGroup="2"><img 
                                                    src="../Images/Icons/MismatchIcon_Small.png" /></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" colspan="2" valign="middle">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" colspan="3" valign="middle">
                                                        <asp:Button ID="btnClearPG1" runat="server" CssClass="ButtonLightBlue" Text="Clear"
                                                            Width="75px" />
                                                        &nbsp;<asp:Button ID="btnContinueAccount" runat="server" CssClass="ButtonLightBlue"
                                                            Text="Continue" ValidationGroup="2" Width="75px" ToolTip="Continue" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="4">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="PersonalDetailsView" runat="server">
                                            <table cellpadding="3" style="width: 100%;">
                                                <tr>
                                                    <td align="center" class="BlueText" colspan="3">
                                                        <asp:LinkButton ID="lblStep1_2" runat="server" CssClass="BlueText">LinkButton</asp:LinkButton>
                                                        &nbsp;<asp:Image ID="Image10" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep2_2" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image11" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep3_2" runat="server" Text="Label"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image12" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep4_2" runat="server" Text="Label"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image20" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep5_2" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        <asp:Label ID="lblName" runat="server" CssClass="TextBold" Text="Name:"></asp:Label>
                                                    </td>
                                                    <td align="left" width="150">
                                                        <asp:TextBox ID="txtName" runat="server" CssClass="TextBox" Width="150px" MaxLength="30"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtName"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Name is a required field."
                                                            ValidationGroup="3"><img 
                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtName"
                                                            CssClass="RedText" ErrorMessage="Invalid E-Mail Format" ForeColor="" ToolTip="Invalid Name Characters"
                                                            ValidationExpression="([a-zA-Z\s]{3,30})+" ValidationGroup="3"><img 
                                                            src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblSurname" runat="server" CssClass="TextBold" Text="Surname:"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtSurname" runat="server" CssClass="TextBox" Width="150px" MaxLength="30"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSurname"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Surname is a required field."
                                                            ValidationGroup="3"><img 
                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtSurname"
                                                            CssClass="RedText" ErrorMessage="Invalid E-Mail Format" ForeColor="" ToolTip="Invalid Surname Characters"
                                                            ValidationExpression="([a-zA-Z\s]{3,30})+" ValidationGroup="3"><img 
                                                            src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblGender" runat="server" CssClass="TextBold" Text="Gender:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:RadioButton ID="rdbMale" runat="server" Checked="True" CssClass="Text" GroupName="Gender"
                                                            Text="Male" />
                                                        &nbsp;<asp:RadioButton ID="rdbFemale" runat="server" CssClass="Text" GroupName="Gender"
                                                            Text="Female" />
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblDOB" runat="server" CssClass="TextBold" Text="Date Of Birth:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle" id="img">
                                                        <asp:TextBox ID="txtDOB" runat="server" CssClass="TextBox" Width="116px"></asp:TextBox>
                                                        <cc1:MaskedEditExtender ID="txtDOB_MaskedEditExtender" runat="server" MaskType="Date"
                                                            TargetControlID="txtDOB" Mask="99/99/9999" PromptCharacter="_"></cc1:MaskedEditExtender>
                                                        &nbsp;<asp:Image ID="imgCalendar" runat="server" ImageUrl="~/Images/Icons/Calendar_Small.png"
                                                            ToolTip="Calendar" />
                                                        <cc1:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                                            PopupButtonID="imgCalendar" TargetControlID="txtDOB"></cc1:CalendarExtender>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="txtDOB_MaskedEditExtender"
                                                            ControlToValidate="txtDOB" CssClass="RedText" EmptyValueMessage="Date is required"
                                                            InvalidValueMessage="Date is invalid" IsValidEmpty="False" TooltipMessage="Input a Date"
                                                            ForeColor=""> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Please enter a date. </cc1:MaskedEditValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblNationality" runat="server" CssClass="TextBold" Text="Nationality:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:DropDownList ID="ddlNationality" runat="server" Width="150px" Height="18px"
                                                            CssClass="TextBox">
                                                        </asp:DropDownList>
                                                        <br />
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" colspan="2" valign="middle">
                                                        <asp:Button ID="btnBack" runat="server" CssClass="ButtonLightBlue" Text="Back" Width="75px" />
                                                        &nbsp;<asp:Button ID="btnContinuePersonal" runat="server" CssClass="ButtonLightBlue"
                                                            Text="Continue" ValidationGroup="3" Width="75px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="ContactDetailsView" runat="server">
                                            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>--%>
                                                    <table cellpadding="3" style="width: 100%;">
                                                        <tr>
                                                            <td align="center" class="BlueText" colspan="3">
                                                                <asp:LinkButton ID="lblStep1_3" runat="server" CssClass="BlueText">LinkButton</asp:LinkButton>
                                                                &nbsp;<asp:Image ID="Image13" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                                &nbsp;<asp:Label ID="lblStep2_3" runat="server" Text="Label"></asp:Label>
                                                                &nbsp;<asp:Image ID="Image14" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                                &nbsp;<asp:Label ID="lblStep3_3" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                                                                &nbsp;<asp:Image ID="Image15" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                                &nbsp;<asp:Label ID="lblStep4_3" runat="server" Text="Label"></asp:Label>
                                                                &nbsp;<asp:Image ID="Image21" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                                &nbsp;<asp:Label ID="lblStep5_3" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" width="40%">
                                                                <asp:Label ID="lblCountry" runat="server" CssClass="TextBold" Text="Country:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="150">
                                                                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" CssClass="TextBox"
                                                                    OnSelectedIndexChanged="ddlCountry_ChangedIndex" Width="155px">
                                                                    <asp:ListItem Selected="True">None</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" width="40%">
                                                            </td>
                                                            <td align="left" width="150">
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" width="40%">
                                                                <asp:Label ID="lblEmail" runat="server" CssClass="TextBold" Text="E-Mail Address:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="150">
                                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" MaxLength="50" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                                                    CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Email is a required field."
                                                                    ValidationGroup="4"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                                                    CssClass="RedText" ErrorMessage="Invalid E-Mail Format" ForeColor="" ToolTip="Invalid E-Mail Format"
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="4"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTelephone" runat="server" CssClass="Text" Text="Telephone:"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtTel" runat="server" CssClass="TextBox" MaxLength="20" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:RegularExpressionValidator ID="regexTelephone" runat="server" ControlToValidate="txtTel"
                                                                    CssClass="RedText" ErrorMessage="Invalid E-Mail Format" ForeColor="" ToolTip="Invalid Telephone Format"
                                                                    ValidationExpression="[0-9\-]+" ValidationGroup="4"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" valign="top">
                                                                <asp:Label ID="lblAddress" runat="server" CssClass="TextBold" Text="Address:"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="TextBox" MaxLength="50" Rows="3"
                                                                    TextMode="MultiLine" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAddress"
                                                                    CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Address is a required field."
                                                                    ValidationGroup="4"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAddress"
                                                                    CssClass="RedText" ErrorMessage="Invalid E-Mail Format" ForeColor="" ToolTip="Invalid E-Mail Format"
                                                                    ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="4"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblStreet" runat="server" CssClass="TextBold" Text="Street:"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:TextBox ID="txtStreet" runat="server" CssClass="TextBox" MaxLength="50" Width="150px"></asp:TextBox>
                                                                <br />
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtStreet"
                                                                    CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Street is a required field."
                                                                    ValidationGroup="4"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtStreet"
                                                                    CssClass="RedText" ErrorMessage="Invalid E-Mail Format" ForeColor="" ToolTip="Invalid E-Mail Format"
                                                                    ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="4"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTown" runat="server" CssClass="TextBold" Text="Town:"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:TextBox ID="txtTown" runat="server" CssClass="TextBox" MaxLength="20" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtTown"
                                                                    CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Town is a required field."
                                                                    ValidationGroup="4"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtTown"
                                                                    CssClass="RedText" ErrorMessage="Invalid Town Characters" ForeColor="" ToolTip="Invalid E-Mail Format"
                                                                    ValidationExpression="[0-9a-zA-Z\-]+" ValidationGroup="4"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblState" runat="server" CssClass="Text" Text="State:"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:TextBox ID="txtState" runat="server" CssClass="TextBox" MaxLength="20" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtState"
                                                                    CssClass="RedText" ErrorMessage="Invalid E-Mail Format" ForeColor="" ToolTip="Invalid E-Mail Format"
                                                                    ValidationExpression="[0-9a-zA-Z\-]+" ValidationGroup="4"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCode" runat="server" CssClass="TextBold" Text="Post Code:"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:TextBox ID="txtPostCode" runat="server" CssClass="TextBox" MaxLength="10" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPostCode"
                                                                    CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Post Code is a required field."
                                                                    ValidationGroup="4"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="regexPostCode" runat="server" ControlToValidate="txtPostCode"
                                                                    CssClass="RedText" ErrorMessage="Invalid E-Mail Format" ForeColor="" ToolTip="Invalid Post Code Format"
                                                                    ValidationExpression="[0-9a-zA-Z\-]+" ValidationGroup="4"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left" colspan="2" valign="middle">
                                                                <asp:Button ID="btnBackContact" runat="server" CssClass="ButtonLightBlue" Text="Back"
                                                                    Width="75px" />
                                                                &nbsp;<asp:Button ID="btnContinueContact" runat="server" CssClass="ButtonLightBlue"
                                                                    Text="Continue" ValidationGroup="4" Width="75px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                       <%--         </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                        </asp:View>
                                        <br />
                                        <asp:View ID="ViewCompanyDetails" runat="server">
                                            <table cellpadding="3" style="width: 100%;">
                                                <tr>
                                                    <td align="center" class="BlueText" colspan="3">
                                                        <asp:LinkButton ID="lblStep1_5" runat="server" CssClass="BlueText">LinkButton</asp:LinkButton>
                                                        &nbsp;<asp:Image ID="Image22" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep2_5" runat="server" Text="Label"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image23" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep3_5" runat="server" Font-Bold="False" Text="Label"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image24" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep4_5" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image25" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep5_5" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%" class="TextBold">
                                                        Company Name:
                                                    </td>
                                                    <td align="left" width="150">
                                                        <asp:TextBox ID="txtCompanyName" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtCompanyName"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Company Name is a required field."
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                                            ControlToValidate="txtCompanyName" CssClass="RedText" ErrorMessage="Invalid E-Mail Format"
                                                            ForeColor="" ToolTip="Invalid Company Name" ValidationExpression="[0-9a-zA-Z\-\s]+"
                                                            ValidationGroup="4"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="TextBold" width="40%">
                                                        VAT No.:
                                                    </td>
                                                    <td align="left" width="150">
                                                        <asp:TextBox ID="txtVATNo" runat="server" CssClass="TextBox" MaxLength="20" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtVATNo"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Company Name is a required field."
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server"
                                                            ControlToValidate="txtVATNo" CssClass="RedText" ErrorMessage="Invalid E-Mail Format"
                                                            ForeColor="" ToolTip="Invalid Company Name" ValidationExpression="[0-9a-zA-Z\-]+"
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="TextBold" width="40%">
                                                        Registration No.:
                                                    </td>
                                                    <td align="left" width="150">
                                                        <asp:TextBox ID="txtRegNo" runat="server" CssClass="TextBox" MaxLength="20" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtRegNo"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Company Name is a required field."
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server"
                                                            ControlToValidate="txtRegNo" CssClass="RedText" ErrorMessage="Invalid E-Mail Format"
                                                            ForeColor="" ToolTip="Invalid Company Name" ValidationExpression="[0-9a-zA-Z\-]+"
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3">
                                                        <asp:Label ID="lblInvalidCompany" runat="server" Text="The company details entered do not appear to be valid."
                                                            CssClass="RedText" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        <asp:Label ID="Label3" runat="server" CssClass="TextBold" Text="Country:"></asp:Label>
                                                    </td>
                                                    <td align="left" width="150">
                                                        <asp:DropDownList ID="ddlCompanyCountry" runat="server" AutoPostBack="True" CssClass="TextBox"
                                                            OnSelectedIndexChanged="ddlCountry_ChangedIndex" Width="155px">
                                                            <asp:ListItem Selected="True">None</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                    </td>
                                                    <td align="left" width="150">
                                                    </td>
                                                    <td align="left">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        <asp:Label ID="Label5" runat="server" CssClass="TextBold" Text="E-Mail Address:"></asp:Label>
                                                    </td>
                                                    <td align="left" width="150">
                                                        <asp:TextBox ID="txtCompanyEmail" runat="server" CssClass="TextBox" MaxLength="50"
                                                            Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompanyEmail"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Email is a required field."
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCompanyEmail"
                                                            CssClass="RedText" ErrorMessage="Invalid E-Mail Format" ForeColor="" ToolTip="Invalid E-Mail Format"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="4"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label6" runat="server" CssClass="Text" Text="Telephone:"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtCompanyTel" runat="server" CssClass="TextBox" MaxLength="20"
                                                            Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtCompanyTel"
                                                            CssClass="RedText" ErrorMessage="Invalid E-Mail Format" ForeColor="" ToolTip="Invalid Telephone Format"
                                                            ValidationExpression="[0-9\-]+" ValidationGroup="5"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" valign="top">
                                                        <asp:Label ID="Label7" runat="server" CssClass="TextBold" Text="Address:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtCompanyAddress" runat="server" CssClass="TextBox" MaxLength="50"
                                                            Rows="3" TextMode="MultiLine" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCompanyAddress"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Address is a required field."
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                            ControlToValidate="txtCompanyAddress" CssClass="RedText" ErrorMessage="Invalid E-Mail Format"
                                                            ForeColor="" ToolTip="Invalid E-Mail Format" ValidationExpression="[0-9a-zA-Z\-\s]+"
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label8" runat="server" CssClass="TextBold" Text="Street:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtCompanyStreet" runat="server" CssClass="TextBox" MaxLength="50"
                                                            Width="150px"></asp:TextBox>
                                                        <br />
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCompanyStreet"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Street is a required field."
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                            ControlToValidate="txtCompanyStreet" CssClass="RedText" ErrorMessage="Invalid E-Mail Format"
                                                            ForeColor="" ToolTip="Invalid E-Mail Format" ValidationExpression="[0-9a-zA-Z\-\s]+"
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label9" runat="server" CssClass="TextBold" Text="Town:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtCompanyTown" runat="server" CssClass="TextBox" MaxLength="20"
                                                            Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCompanyTown"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Town is a required field."
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                                            ControlToValidate="txtCompanyTown" CssClass="RedText" ErrorMessage="Invalid Town Characters"
                                                            ForeColor="" ToolTip="Invalid E-Mail Format" ValidationExpression="[0-9a-zA-Z\-]+"
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label10" runat="server" CssClass="Text" Text="State:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtCompanyState" runat="server" CssClass="TextBox" MaxLength="20"
                                                            Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                            ControlToValidate="txtCompanyState" CssClass="RedText" ErrorMessage="Invalid E-Mail Format"
                                                            ForeColor="" ToolTip="Invalid E-Mail Format" ValidationExpression="[0-9a-zA-Z\-]+"
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label11" runat="server" CssClass="TextBold" Text="Post Code:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtCompanyPostCode" runat="server" CssClass="TextBox" MaxLength="10"
                                                            Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtCompanyPostCode"
                                                            CssClass="RedText" ErrorMessage="*" ForeColor="" ToolTip="Post Code is a required field."
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                                            ControlToValidate="txtCompanyPostCode" CssClass="RedText" ErrorMessage="Invalid E-Mail Format"
                                                            ForeColor="" ToolTip="Invalid Post Code Format" ValidationExpression="[0-9a-zA-Z\-]+"
                                                            ValidationGroup="5"><img 
                                                                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" colspan="2" valign="middle">
                                                        <asp:Button ID="Button1" runat="server" CssClass="ButtonLightBlue" Text="Back" Width="75px" />
                                                        &nbsp;<asp:Button ID="btnContinueCompany" runat="server" CssClass="ButtonLightBlue"
                                                            Text="Continue" ValidationGroup="5" Width="75px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <br />
                                        <asp:View ID="SummaryView" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td align="center" colspan="2" width="40%" class="BlueText">
                                                        <asp:LinkButton ID="lblStep1_6" runat="server" CssClass="BlueText">LinkButton</asp:LinkButton>
                                                        &nbsp;<asp:Image ID="Image26" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep2_6" runat="server" Text="Label"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image27" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep3_6" runat="server" Font-Bold="False" Text="Label"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image28" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep4_6" runat="server" Text="Label"></asp:Label>
                                                        &nbsp;<asp:Image ID="Image29" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep5_6" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="Text" width="40%" colspan="2">
                                                        Please verify the details you have entered; if all fields are valid please proceed
                                                        to confirm.
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Username:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryUsername" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="BlueTextBold" width="40%">
                                                        Personal Details
                                                    </td>
                                                    <td align="left" width="60%">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Name:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryName" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Surname:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummarySurname" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Gender:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryGender" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Date of Birth:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryDOB" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Nationality:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryNationality" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Passport No.:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryPassport" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" width="60%">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Country:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryCountry" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="BlueTextBold" width="40%">
                                                        Personal Contact Details
                                                    </td>
                                                    <td align="left" width="60%">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        E-Mail Address:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryEmail" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Telephone:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryTelephone" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" width="60%">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%" class="Text" valign="top">
                                                        Address:
                                                    </td>
                                                    <td align="left" width="60%" valign="top">
                                                        <asp:Label ID="lblSummaryAddress" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Post Code:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryPostCode" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="BlueTextBold" width="40%">
                                                        Company Details
                                                    </td>
                                                    <td align="left" width="60%">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Company Name:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryCompName" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%" class="Text">
                                                        VAT No.:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryVAT" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Registration No.:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryReg" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" width="60%">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%" class="Text">
                                                        Country:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryCompCountry" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" width="60%">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%" class="Text">
                                                        E-Mail Address:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryCompEmail" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Telephone:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryCompTel" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" width="60%">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%" class="Text" valign="top">
                                                        Address:
                                                    </td>
                                                    <td align="left" width="60%" valign="top">
                                                        <asp:Label ID="lblSummaryCompAdress" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Post Code:
                                                    </td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryCompanyCode" runat="server" CssClass="Text" ForeColor="#666666"
                                                            Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" width="60%">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" width="60%" colspan="2">
                                                        <asp:Button ID="btnModifyDetails" runat="server" CssClass="ButtonLightBlue" Text="Modify Details"
                                                            Width="100px" />
                                                        &nbsp;<asp:Button ID="btnConfirmDetails" runat="server" CssClass="ButtonLightBlue"
                                                            Text="Confirm Details" Width="100px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="SuccessfullView" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td class="BlueTextBold" align="center">
                                                        Registration completed successfully.
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="justify">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="Text">
                                                        Thank you for registering with Radix Systems. Shortly you will recieve an email
                                                        with an authorization code. Kindly enter it in the next page to confirm your registration.
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:LinkButton ID="lnkAuth" runat="server" CssClass="Link" 
                                                            PostBackUrl="~/Anonymous/UserAuth.aspx">Proceed to Enter 
                                                            Authorization Code</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="FailedView" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td class="RedText" align="center">
                                                        Sorry. An error has occured while trying to register your account. Please try again.
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="Text">
                                                        Should you require any assistance do not hesitate to send us a feedback message
                                                        and we will get back to you as soon as possible.
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:LinkButton ID="lnkTryAgain" runat="server" CssClass="Link" PostBackUrl="~/Anonymous/Registration.aspx">Try Again?</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
              </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
