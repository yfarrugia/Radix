<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CenterRegistration.aspx.vb" Inherits="Anonymous_EmployeeRegistration" title="Employee Registration" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
                            Center Registration</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="Text">
                    Enter the details below to complete your registration; <b>bold field names</b> 
                    are required fields.</td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <br />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table width="750">
                            <tr>
                                <td>
                                    <asp:MultiView ID="RegistrationProcessView" runat="server">
                                        <asp:View ID="UserAccountView" runat="server">
                                            <table cellpadding="3" style="width:100%;">
                                                <tr>
                                                    <td align="center" class="BlueText" colspan="4">
                                                        <asp:Label ID="lblStep1_1" runat="server" Font-Bold="True" Text="Label"></asp:Label>
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
                                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="TextBox" MaxLength="20" 
                                                            Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left" class="style8">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                            ControlToValidate="txtUsername" CssClass="RedText" ErrorMessage="*" 
                                                            ForeColor="" ToolTip="Username is a required field." ValidationGroup="2"><img 
                                                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                                                            runat="server" ControlToValidate="txtUsername" CssClass="RedText" 
                                                            ErrorMessage="Invalid Username characters." ForeColor="" 
                                                            ToolTip="Invalid Username." ValidationExpression="([a-zA-Z0-9]{5,20})+" 
                                                            ValidationGroup="2"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                        <asp:Image ID="imgTick" runat="server" ImageUrl="~/Images/Icons/Tick_Small.png" 
                                                            ToolTip="Username Available" Visible="False" />
                                                        <asp:Image ID="imgCross" runat="server" ImageUrl="~/Images/Icons/Cross.png" 
                                                            ToolTip="Username Already Used" Visible="False" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkAvailability" runat="server" CssClass="GreenText">Check 
                                                        Availability</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;</td>
                                                    <td align="left" colspan="3">
                                                        <asp:Label ID="lblStrength" runat="server" CssClass="Text" Font-Italic="True" 
                                                            ForeColor="Gray" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblPassword" runat="server" CssClass="TextBold" Text="Password:"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" MaxLength="20" 
                                                            TextMode="Password" Width="150px" />
                                                        <cc1:PasswordStrength ID="txtPassword_PasswordStrength" runat="server" 
                                                            BarBorderCssClass="barIndicatorBorder" CalculationWeightings="25;25;15;35" 
                                                            DisplayPosition="RightSide" Enabled="True" HelpHandlePosition="AboveLeft" 
                                                            HelpStatusLabelID="lblStrength" MinimumNumericCharacters="1" 
                                                            MinimumSymbolCharacters="0" MinimumUpperCaseCharacters="1" 
                                                            PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="true" 
                                                            StrengthIndicatorType="BarIndicator" 
                                                            StrengthStyles="barIndicator_poor; barIndicator_weak; barIndicator_good; barIndicator_strong; barIndicator_excellent" 
                                                            TargetControlID="txtPassword" 
                                                            TextStrengthDescriptions="Poor; Weak; Good; Strong; Excellent">
                                                        </cc1:PasswordStrength>
                                                    </td>
                                                    <td align="left" class="RedText" colspan="2">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                            ControlToValidate="txtPassword" CssClass="RedText" ErrorMessage="*" 
                                                            ForeColor="" ToolTip="Password is a required field." ValidationGroup="2"><img 
                                                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" 
                                                            runat="server" ControlToValidate="txtPassword" CssClass="RedText" 
                                                            ErrorMessage="Invalid Username characters." ForeColor="" 
                                                            ToolTip="Invalid Password." 
                                                            ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{5,20})$" 
                                                            ValidationGroup="2"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblConfPassword" runat="server" CssClass="TextBold" 
                                                            Text="Re-Enter Password:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtConfPassword" runat="server" CssClass="TextBox" 
                                                            MaxLength="20" TextMode="Password" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left" colspan="2" valign="middle">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                            ControlToValidate="txtConfPassword" CssClass="RedText" ErrorMessage="*" 
                                                            ForeColor="" ToolTip="Re-Enter Password is a required field." 
                                                            ValidationGroup="2"><img src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                            ControlToCompare="txtPassword" ControlToValidate="txtConfPassword" 
                                                            CssClass="RedText" ErrorMessage="CompareValidator" ForeColor="" 
                                                            ToolTip="This field and the Password field do not match exactly." 
                                                            ValidationGroup="2"><img src="../Images/Icons/MismatchIcon_Small.png" /></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;</td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;</td>
                                                    <td align="left" colspan="2" valign="middle">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;</td>
                                                    <td align="left" colspan="3" valign="middle">
                                                        <asp:Button ID="btnClearPG1" runat="server" CssClass="ButtonLightBlue" 
                                                            Text="Clear" Width="75px" />
                                                        &nbsp;<asp:Button ID="btnContinueAccount" runat="server" CssClass="ButtonLightBlue" 
                                                            Text="Continue" ToolTip="Continue" ValidationGroup="2" Width="75px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="4">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="PersonalDetailsView" runat="server">
                                            <table cellpadding="3" style="width:100%;">
                                                <tr>
                                                    <td align="center" class="BlueText" colspan="3">
                                                        <asp:LinkButton ID="lblStep1_2" runat="server" CssClass="BlueText">LinkButton</asp:LinkButton>
                                                        &nbsp;<asp:Image ID="Image10" runat="server" ImageUrl="~/Images/NextStep.png" />
                                                        &nbsp;<asp:Label ID="lblStep2_2" runat="server" Font-Bold="True" Text="Label"></asp:Label>
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
                                                        <asp:TextBox ID="txtName" runat="server" CssClass="TextBox" MaxLength="30" 
                                                            Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                            ControlToValidate="txtName" CssClass="RedText" ErrorMessage="*" ForeColor="" 
                                                            ToolTip="Name is a required field." ValidationGroup="3"><img 
                                                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                                                            ControlToValidate="txtName" CssClass="RedText" 
                                                            ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                            ToolTip="Invalid Name Characters" ValidationExpression="([a-zA-Z\s]{3,30})+" 
                                                            ValidationGroup="3"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblSurname" runat="server" CssClass="TextBold" Text="Surname:"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtSurname" runat="server" CssClass="TextBox" MaxLength="30" 
                                                            Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                            ControlToValidate="txtSurname" CssClass="RedText" ErrorMessage="*" ForeColor="" 
                                                            ToolTip="Surname is a required field." ValidationGroup="3"><img 
                                                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                                                            ControlToValidate="txtSurname" CssClass="RedText" 
                                                            ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                            ToolTip="Invalid Surname Characters" ValidationExpression="([a-zA-Z\s]{3,30})+" 
                                                            ValidationGroup="3"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblGender" runat="server" CssClass="TextBold" Text="Gender:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:RadioButton ID="rdbMale" runat="server" Checked="True" CssClass="Text" 
                                                            GroupName="Gender" Text="Male" />
                                                        &nbsp;<asp:RadioButton ID="rdbFemale" runat="server" CssClass="Text" 
                                                            GroupName="Gender" Text="Female" />
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblDOB" runat="server" CssClass="TextBold" Text="Date Of Birth:"></asp:Label>
                                                    </td>
                                                    <td ID="img" align="left" valign="middle">
                                                        <asp:TextBox ID="txtDOB" runat="server" CssClass="TextBox" Width="116px"></asp:TextBox>
                                                        <cc1:MaskedEditExtender ID="txtDOB_MaskedEditExtender" runat="server" 
                                                            Mask="99/99/9999" MaskType="Date" PromptCharacter="_" TargetControlID="txtDOB">
                                                        </cc1:MaskedEditExtender>
                                                        &nbsp;<asp:Image ID="imgCalendar" runat="server" 
                                                            ImageUrl="~/Images/Icons/Calendar_Small.png" ToolTip="Calendar" />
                                                        <cc1:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" 
                                                            Format="dd/MM/yyyy" PopupButtonID="imgCalendar" TargetControlID="txtDOB">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                                                            ControlExtender="txtDOB_MaskedEditExtender" ControlToValidate="txtDOB" 
                                                            CssClass="RedText" EmptyValueMessage="Date is required" ForeColor="" 
                                                            InvalidValueMessage="Date is invalid" IsValidEmpty="False" 
                                                            TooltipMessage="Input a Date">
                                                            Please enter a date.
                                                        </cc1:MaskedEditValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="lblNationality" runat="server" CssClass="TextBold" 
                                                            Text="Nationality:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:DropDownList ID="ddlNationality" runat="server" CssClass="TextBox" 
                                                            Height="18px" Width="150px">
                                                        </asp:DropDownList>
                                                        <br />
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;</td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;</td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;</td>
                                                    <td align="left" colspan="2" valign="middle">
                                                        <asp:Button ID="btnBack" runat="server" CssClass="ButtonLightBlue" Text="Back" 
                                                            Width="75px" />
                                                        &nbsp;<asp:Button ID="btnContinuePersonal" runat="server" CssClass="ButtonLightBlue" 
                                                            Text="Continue" ValidationGroup="3" Width="75px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="ContactDetailsView" runat="server">
                                           <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>--%>
                                                    <table cellpadding="3" style="width:100%;">
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
                                                                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" 
                                                                    CssClass="TextBox" OnSelectedIndexChanged="ddlCountry_ChangedIndex" 
                                                                    Width="155px">
                                                                    <asp:ListItem Selected="True">None</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;</td>
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
                                                                <asp:Label ID="lblEmail" runat="server" CssClass="TextBold" 
                                                                    Text="E-Mail Address:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="150">
                                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" MaxLength="50" 
                                                                    Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                                                                    ControlToValidate="txtEmail" CssClass="RedText" ErrorMessage="*" ForeColor="" 
                                                                    ToolTip="Email is a required field." ValidationGroup="4"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                                    ControlToValidate="txtEmail" CssClass="RedText" 
                                                                    ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                                    ToolTip="Invalid E-Mail Format" 
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                                    ValidationGroup="4"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTelephone" runat="server" CssClass="Text" Text="Telephone:"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtTel" runat="server" CssClass="TextBox" MaxLength="20" 
                                                                    Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:RegularExpressionValidator ID="regexTelephone" runat="server" 
                                                                    ControlToValidate="txtTel" CssClass="RedText" 
                                                                    ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                                    ToolTip="Invalid Telephone Format" ValidationExpression="[0-9\-]+" 
                                                                    ValidationGroup="4"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                &nbsp;</td>
                                                            <td align="left" valign="middle">
                                                                &nbsp;</td>
                                                            <td align="left" valign="middle">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" valign="top">
                                                                <asp:Label ID="lblAddress" runat="server" CssClass="TextBold" Text="Address:"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="TextBox" MaxLength="50" 
                                                                    Rows="3" TextMode="MultiLine" Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                                    ControlToValidate="txtAddress" CssClass="RedText" ErrorMessage="*" ForeColor="" 
                                                                    ToolTip="Address is a required field." ValidationGroup="4"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                                    ControlToValidate="txtAddress" CssClass="RedText" 
                                                                    ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                                    ToolTip="Invalid E-Mail Format" ValidationExpression="[0-9a-zA-Z\-\s]+" 
                                                                    ValidationGroup="4"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblStreet" runat="server" CssClass="TextBold" Text="Street:"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:TextBox ID="txtStreet" runat="server" CssClass="TextBox" MaxLength="50" 
                                                                    Width="150px"></asp:TextBox>
                                                                <br />
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                                    ControlToValidate="txtStreet" CssClass="RedText" ErrorMessage="*" ForeColor="" 
                                                                    ToolTip="Street is a required field." ValidationGroup="4"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                                                    ControlToValidate="txtStreet" CssClass="RedText" 
                                                                    ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                                    ToolTip="Invalid E-Mail Format" ValidationExpression="[0-9a-zA-Z\-\s]+" 
                                                                    ValidationGroup="4"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblTown" runat="server" CssClass="TextBold" Text="Town:"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:TextBox ID="txtTown" runat="server" CssClass="TextBox" MaxLength="20" 
                                                                    Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                                    ControlToValidate="txtTown" CssClass="RedText" ErrorMessage="*" ForeColor="" 
                                                                    ToolTip="Town is a required field." ValidationGroup="4"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                                                                    ControlToValidate="txtTown" CssClass="RedText" 
                                                                    ErrorMessage="Invalid Town Characters" ForeColor="" 
                                                                    ToolTip="Invalid E-Mail Format" ValidationExpression="[0-9a-zA-Z\- ]+" 
                                                                    ValidationGroup="4"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblState" runat="server" CssClass="Text" Text="State:"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:TextBox ID="txtState" runat="server" CssClass="TextBox" MaxLength="20" 
                                                                    Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                                                                    ControlToValidate="txtState" CssClass="RedText" 
                                                                    ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                                    ToolTip="Invalid E-Mail Format" ValidationExpression="[0-9a-zA-Z\-]+" 
                                                                    ValidationGroup="4"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblCode" runat="server" CssClass="TextBold" Text="Post Code:"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:TextBox ID="txtPostCode" runat="server" CssClass="TextBox" MaxLength="10" 
                                                                    Width="150px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                                    ControlToValidate="txtPostCode" CssClass="RedText" ErrorMessage="*" 
                                                                    ForeColor="" ToolTip="Post Code is a required field." ValidationGroup="4"><img 
                                                                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="regexPostCode" runat="server" 
                                                                    ControlToValidate="txtPostCode" CssClass="RedText" 
                                                                    ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                                    ToolTip="Invalid Post Code Format" ValidationExpression="[0-9a-zA-Z\-]+" 
                                                                    ValidationGroup="4"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                &nbsp;</td>
                                                            <td align="left" valign="middle">
                                                                &nbsp;</td>
                                                            <td align="left" valign="middle">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                &nbsp;</td>
                                                            <td align="left" colspan="2" valign="middle">
                                                                <asp:Button ID="btnBackContact" runat="server" CssClass="ButtonLightBlue" 
                                                                    Text="Back" Width="75px" />
                                                                &nbsp;<asp:Button ID="btnContinueContact" runat="server" CssClass="ButtonLightBlue" 
                                                                    Text="Continue" ValidationGroup="4" Width="75px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                               <%-- </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                        </asp:View>
                                        <br />
                                        <asp:View ID="ViewCenterDetails" runat="server">
                                            <table cellpadding="3" style="width:100%;">
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
                                                    <td align="right" class="TextBold" width="40%">
                                                        Center Name:</td>
                                                    <td align="left" width="150">
                                                        <asp:TextBox ID="txtCenterName" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                                            ControlToValidate="txtCenterName" CssClass="RedText" ErrorMessage="*" 
                                                            ForeColor="" ToolTip="Center Name is a required field." ValidationGroup="5"><img 
                                                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator17" 
                                                            runat="server" ControlToValidate="txtCenterName" CssClass="RedText" 
                                                            ErrorMessage="Invalid Center Name Format" ForeColor="" 
                                                            ToolTip="Invalid Center Name" ValidationExpression="[0-9a-zA-Z\-\s]+" 
                                                            ValidationGroup="4"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        <asp:Label ID="Label3" runat="server" CssClass="TextBold" Text="Country:"></asp:Label>
                                                    </td>
                                                    <td align="left" width="150">
                                                        <asp:DropDownList ID="ddlCenterCountry" runat="server" AutoPostBack="True" 
                                                            CssClass="TextBox" OnSelectedIndexChanged="ddlCountry_ChangedIndex" 
                                                            Width="155px">
                                                            <asp:ListItem Selected="True">None</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3">
                                                        <asp:Label ID="lblInvalidCenter" runat="server" CssClass="RedText" 
                                                            Text="The center name is already in used for the selected country." 
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        &nbsp;</td>
                                                    <td align="left" width="150">
                                                        &nbsp;</td>
                                                    <td align="left">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        <asp:Label ID="Label5" runat="server" CssClass="TextBold" 
                                                            Text="E-Mail Address:"></asp:Label>
                                                    </td>
                                                    <td align="left" width="150">
                                                        <asp:TextBox ID="txtCenterEmail" runat="server" CssClass="TextBox" 
                                                            MaxLength="50" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                            ControlToValidate="txtCenterEmail" CssClass="RedText" ErrorMessage="*" 
                                                            ForeColor="" ToolTip="Email is a required field." ValidationGroup="5"><img 
                                                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                                            ControlToValidate="txtCenterEmail" CssClass="RedText" 
                                                            ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                            ToolTip="Invalid E-Mail Format" 
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                            ValidationGroup="4"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label6" runat="server" CssClass="Text" Text="Telephone:"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtCenterTel" runat="server" CssClass="TextBox" MaxLength="20" 
                                                            Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                                            ControlToValidate="txtCenterTel" CssClass="RedText" 
                                                            ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                            ToolTip="Invalid Telephone Format" ValidationExpression="[0-9\-]+" 
                                                            ValidationGroup="5"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;</td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;</td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" valign="top">
                                                        <asp:Label ID="Label7" runat="server" CssClass="TextBold" Text="Address:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtCenterAddress" runat="server" CssClass="TextBox" 
                                                            MaxLength="50" Rows="3" TextMode="MultiLine" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                            ControlToValidate="txtCenterAddress" CssClass="RedText" ErrorMessage="*" 
                                                            ForeColor="" ToolTip="Address is a required field." ValidationGroup="5"><img 
                                                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" 
                                                            runat="server" ControlToValidate="txtCenterAddress" CssClass="RedText" 
                                                            ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                            ToolTip="Invalid E-Mail Format" ValidationExpression="[0-9a-zA-Z\-\s]+" 
                                                            ValidationGroup="5"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label8" runat="server" CssClass="TextBold" Text="Street:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtCenterStreet" runat="server" CssClass="TextBox" 
                                                            MaxLength="50" Width="150px"></asp:TextBox>
                                                        <br />
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                            ControlToValidate="txtCenterStreet" CssClass="RedText" ErrorMessage="*" 
                                                            ForeColor="" ToolTip="Street is a required field." ValidationGroup="5"><img 
                                                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" 
                                                            runat="server" ControlToValidate="txtCenterStreet" CssClass="RedText" 
                                                            ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                            ToolTip="Invalid E-Mail Format" ValidationExpression="[0-9a-zA-Z\-\s]+" 
                                                            ValidationGroup="5"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label9" runat="server" CssClass="TextBold" Text="Town:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtCenterTown" runat="server" CssClass="TextBox" 
                                                            MaxLength="20" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                            ControlToValidate="txtCenterTown" CssClass="RedText" ErrorMessage="*" 
                                                            ForeColor="" ToolTip="Town is a required field." ValidationGroup="5"><img 
                                                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" 
                                                            runat="server" ControlToValidate="txtCenterTown" CssClass="RedText" 
                                                            ErrorMessage="Invalid Town Characters" ForeColor="" 
                                                            ToolTip="Invalid E-Mail Format" ValidationExpression="[0-9a-zA-Z\- ]+" 
                                                            ValidationGroup="5"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label10" runat="server" CssClass="Text" Text="State:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtCenterState" runat="server" CssClass="TextBox" 
                                                            MaxLength="20" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" 
                                                            runat="server" ControlToValidate="txtCenterState" CssClass="RedText" 
                                                            ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                            ToolTip="Invalid E-Mail Format" ValidationExpression="[0-9a-zA-Z\-]+" 
                                                            ValidationGroup="5"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label11" runat="server" CssClass="TextBold" Text="Post Code:"></asp:Label>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:TextBox ID="txtCenterPostCode" runat="server" CssClass="TextBox" 
                                                            MaxLength="10" Width="150px"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="middle">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                                            ControlToValidate="txtCenterPostCode" CssClass="RedText" ErrorMessage="*" 
                                                            ForeColor="" ToolTip="Post Code is a required field." ValidationGroup="5"><img 
                                                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" 
                                                            runat="server" ControlToValidate="txtCenterPostCode" CssClass="RedText" 
                                                            ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                                                            ToolTip="Invalid Post Code Format" ValidationExpression="[0-9a-zA-Z\-]+" 
                                                            ValidationGroup="5"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;</td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;</td>
                                                    <td align="left" valign="middle">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        &nbsp;</td>
                                                    <td align="left" colspan="2" valign="middle">
                                                        <asp:Button ID="Button1" runat="server" CssClass="ButtonLightBlue" Text="Back" 
                                                            Width="75px" />
                                                        &nbsp;<asp:Button ID="btnContinueCenter" runat="server" CssClass="ButtonLightBlue" 
                                                            Text="Continue" ValidationGroup="5" Width="75px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <br />
                                        <asp:View ID="SummaryView" runat="server">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td align="center" class="BlueText" colspan="2" width="40%">
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
                                                    <td align="justify" class="Text" colspan="2" width="40%">
                                                        Please verify the details you have entered; if all fields are valid please 
                                                        proceed to confirm.</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Username:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryUsername" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="BlueTextBold" width="40%">
                                                        Personal Details</td>
                                                    <td align="left" width="60%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Name:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryName" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Surname:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummarySurname" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Gender:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryGender" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Date of Birth:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryDOB" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Nationality:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryNationality" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Passport No.:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryPassport" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        &nbsp;</td>
                                                    <td align="left" width="60%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Country:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryCountry" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="BlueTextBold" width="40%">
                                                        Personal Contact Details</td>
                                                    <td align="left" width="60%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        E-Mail Address:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryEmail" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Telephone:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryTelephone" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        &nbsp;</td>
                                                    <td align="left" width="60%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" valign="top" width="40%">
                                                        Address:</td>
                                                    <td align="left" valign="top" width="60%">
                                                        <asp:Label ID="lblSummaryAddress" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Post Code:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryPostCode" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="BlueTextBold" width="40%">
                                                        Center Details</td>
                                                    <td align="left" width="60%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Center Name:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryCenterName" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Country:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryCenterCountry" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        &nbsp;</td>
                                                    <td align="left" width="60%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        E-Mail Address:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryCenterEmail" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Telephone:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryCenterTel" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        &nbsp;</td>
                                                    <td align="left" width="60%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" valign="top" width="40%">
                                                        Address:</td>
                                                    <td align="left" valign="top" width="60%">
                                                        <asp:Label ID="lblSummaryCenterAdress" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="Text" width="40%">
                                                        Post Code:</td>
                                                    <td align="left" width="60%">
                                                        <asp:Label ID="lblSummaryCenterCode" runat="server" CssClass="Text" 
                                                            ForeColor="#666666" Text="N/A"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" width="40%">
                                                        &nbsp;</td>
                                                    <td align="left" width="60%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" width="60%">
                                                        <asp:Button ID="btnModifyDetails" runat="server" CssClass="ButtonLightBlue" 
                                                            Text="Modify Details" Width="100px" />
                                                        &nbsp;<asp:Button ID="btnConfirmDetails" runat="server" CssClass="ButtonLightBlue" 
                                                            Text="Confirm Details" Width="100px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="SuccessfullView" runat="server">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td align="center" class="BlueTextBold">
                                                        Registration completed successfully.</td>
                                                </tr>
                                                <tr>
                                                    <td align="justify">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="Text">
                                                        Thank you for registering with Radix Systems. Shortly you will recieve an email 
                                                        with an authorization code. Kindly enter it in the next page to confirm your 
                                                        registration.</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:LinkButton ID="lnkAuth" runat="server" CssClass="Link">Proceed to Enter 
                                                        Authorization Code</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="FailedView" runat="server">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td align="center" class="RedText">
                                                        Sorry. An error has occured while trying to register your account. Please try 
                                                        again.</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="justify" class="Text">
                                                        Should you require any assistance do not hesitate to send us a feedback message 
                                                        and we will get back to you as soon as possible.</td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:LinkButton ID="lnkTryAgain" runat="server" CssClass="Link" 
                                                            PostBackUrl="~/Anonymous/Registration.aspx">Try Again?</asp:LinkButton>
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

