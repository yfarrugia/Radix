<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="UserProfile.aspx.vb" Inherits="AllUsers_UserProfile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style15
        {
            height: 26px;
        }
        .style17
        {
            height: 23px;
        }

        .style19
        {
            height: 26px;
        }
        .style20
        {
            width: 345px;
            height: 24px;
        }
        .style21
        {
            height: 24px;
        }
        .style22
        {
            width: 345px;
            height: 28px;
        }
        .style23
        {
            height: 28px;
        }
        .style18
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
    <table style="width:100%;">
        <tr>
            <td colspan="3">
                                    <asp:Label ID="lblEmployeeProfile" runat="server" CssClass="TextTitle" 
                                        Text="Employee Profile"></asp:Label>
                                </td>
        </tr>
        <tr>
            <td class="style18">
                &nbsp;</td>
            <td width="150px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style18">
               <b><asp:Label ID="lblDetails" runat="server" CssClass="TextSubTitle" 
                                        Text="Employee Details"></asp:Label></b>     
                                </td>
            <td class="Text">
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td class="style18">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style18" >
                <asp:Label ID="lblName" runat="server" CssClass="BlueText" Text="Name:" 
                    ToolTip="Employee Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" ReadOnly="True" Width="150px">N/A</asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15" >
                <asp:Label ID="lblSurname" runat="server" CssClass="BlueText" Text="Surname:" 
                    ToolTip="Employee Surname"></asp:Label>
            </td>
            <td class="style15">
                <asp:TextBox ID="txtSurname" runat="server" ReadOnly="True" Width="150px">N/A</asp:TextBox>
            </td>
            <td class="style15">
                <asp:RequiredFieldValidator ID="rfvSurname" runat="server" 
                    ErrorMessage="Surname Required" ToolTip="Surname Required." 
                    ControlToValidate="txtSurname"><img  src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revSurname" runat="server" 
                    ErrorMessage="Invalid surname entry" 
                    ValidationExpression="([a-zA-Z\s]{3,30})+" ValidationGroup="2" 
                    ControlToValidate="txtSurname" ToolTip="Invalid Surname Entry"><img src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator></td></tr><tr>
            <td class="style18">
                <asp:Label ID="lblDOB" runat="server" CssClass="BlueText" Text="Date of Birth:" 
                    ToolTip="Employee Date of Birth"></asp:Label></td><td width="150">
                <asp:TextBox ID="txtDOB" runat="server" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td>
                &nbsp;</td></tr><tr>
            <td class="style18">
                <asp:Label ID="lblNationality" runat="server" CssClass="BlueText" Text="Nationality:" 
                    ToolTip="Employee Nationality"></asp:Label></td><td>
                <asp:TextBox ID="txtNationality" runat="server" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td>
                &nbsp;</td></tr><tr>
            <td class="style18">
                <asp:Label ID="lblEmployeed" runat="server" CssClass="BlueText" Text="Currently Employed:" 
                    ToolTip="Employed"></asp:Label></td><td>
                <asp:CheckBox ID="chkEmployed" runat="server" CssClass="Text" Enabled="False" />
              </td>
            <td>
                &nbsp;</td></tr><tr>
            <td class="style18">
                <asp:Label ID="lblSeeking" runat="server" CssClass="BlueText" Text="Currently seeking Employment:" 
                    ToolTip="Employee Seeking Employment"></asp:Label></td><td>
                <asp:CheckBox ID="chkSeeking" runat="server" CssClass="Text" Enabled="False" />
              </td>
            <td>
                &nbsp;</td></tr><tr>
            <td class="style18">
                <asp:Label ID="lblSponsored" runat="server" CssClass="BlueText" Text="Is Employee Currently Sponsored:" 
                    ToolTip="Employee Sponsor"></asp:Label></td><td>
                <asp:CheckBox ID="chkSponsored" runat="server" CssClass="Text" 
                    Enabled="False" />
              </td><td>
                &nbsp;</td></tr><tr>
            <td class="style18">
                &nbsp;</td><td>
                &nbsp;</td><td>
                &nbsp;</td></tr><tr>
            <td class="style18">
                                    <b><asp:Label ID="lblContactDetails" runat="server" CssClass="TextSubTitle" 
                                        Text="Employee Contact Details"></asp:Label></b></td><td>
                &nbsp;</td><td>
                &nbsp;</td></tr><tr>
            <td class="style18">
                &nbsp;</td><td>
                &nbsp;</td><td>
                &nbsp;</td></tr><tr>
            <td class="style18">
                <asp:Label ID="lblAddress" runat="server" CssClass="BlueText" Text="Address:" 
                    ToolTip="Employee Address"></asp:Label></td><td>
                <asp:TextBox ID="txtAddress" runat="server" ReadOnly="True" Width="150px" 
                    ValidationGroup="2">N/A</asp:TextBox></td><td>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                    ErrorMessage="Address Required" ToolTip="Address Required." 
                    ControlToValidate="txtAddress"><img  src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revAddress" runat="server" 
                    ErrorMessage="Invalid Address Entry" 
                    ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="2" 
                    ControlToValidate="txtAddress" ToolTip="Invalid Address"><img src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator>
            </td></tr><tr>
            <td class="style18">
                <asp:Label ID="lblStrAddress" runat="server" CssClass="BlueText" Text="Street Address:" 
                    ToolTip="Employee Street Address"></asp:Label></td><td>
                <asp:TextBox ID="txtStrAddress" runat="server" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td>
                <asp:RequiredFieldValidator ID="rfvStrAddress" runat="server" 
                    ErrorMessage="Street Address Required" ToolTip="Surname Required." 
                    ControlToValidate="txtStrAddress"><img  src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revStrAddress" runat="server" 
                    ErrorMessage="Invalid Street Address" 
                    ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="2" 
                    ControlToValidate="txtStrAddress" ToolTip="Invalid Street Address"><img src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
              <td class="style18">
                <asp:Label ID="lblTown" runat="server" CssClass="BlueText" Text="Town:" 
                    ToolTip="Employee Town"></asp:Label></td><td >
                <asp:TextBox ID="txtTown" runat="server" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td >
                <asp:RegularExpressionValidator ID="revTown" runat="server" 
                    ErrorMessage="Invalid Town Entry" 
                    ValidationExpression="[0-9a-zA-Z\-]+" ValidationGroup="2" 
                    ControlToValidate="txtTown" ToolTip="Invalid Town"><img src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
              <td class="style18">
                <asp:Label ID="lblState" runat="server" CssClass="BlueText" Text="State:" 
                    ToolTip="Employee State"></asp:Label></td><td >
                <asp:TextBox ID="txtState" runat="server" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td >
                <asp:RegularExpressionValidator ID="revState" runat="server" 
                    ErrorMessage="Invalid State" 
                    ValidationExpression="[0-9a-zA-Z\-]+" ValidationGroup="2" 
                    ControlToValidate="txtState" ToolTip="Invalid State"><img src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
              <td class="style18">
                <asp:Label ID="lblPostCode" runat="server" CssClass="BlueText" Text="Post Code:" 
                    ToolTip="Employee Post code"></asp:Label></td><td >
                <asp:TextBox ID="txtPostCode" runat="server" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td>
                <asp:RequiredFieldValidator ID="rfvPostCode" runat="server" 
                    ErrorMessage="RequiredFieldValidator" ToolTip="Post Code Required." 
                      ControlToValidate="txtPostCode"><img  src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPostCode" runat="server" 
                    ErrorMessage="Invalid Post Code Entry" 
                    ValidationExpression="[0-9a-zA-Z\-]+" ValidationGroup="2" 
                    ControlToValidate="txtPostCode" ToolTip="Invalid Post Code"><img src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="style18">
                <asp:Label ID="lblCountry" runat="server" CssClass="BlueText" Text="Country:" 
                    ToolTip="Employee Country"></asp:Label></td><td>
                <asp:DropDownList ID="ddlCountry" runat="server" Enabled="False" Width="150px">
                </asp:DropDownList>
            </td><td>
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" 
                    ErrorMessage="RequiredFieldValidator" ToolTip="Country Required." 
                      ControlToValidate="ddlCountry"><img  src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                </td></tr><tr>
              <td class="style18">
                <asp:Label ID="lblTelephoneNo" runat="server" CssClass="BlueText" Text="Telephone Number:" 
                    ToolTip="Employee TelephoneNo"></asp:Label></td><td>
                <asp:TextBox ID="txtTelephoneNo" runat="server" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td class="style15" >
                <asp:RegularExpressionValidator ID="revTelephone" runat="server" 
                    ErrorMessage="Invalid Telephone Number " 
                    ValidationExpression="[0-9\-]+" ValidationGroup="2" 
                    ControlToValidate="txtTelephoneNo" ToolTip="Invalid Telephone Number "><img src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
              <td class="style18">
                <asp:Label ID="lblEmail" runat="server" CssClass="BlueText" Text="Email Address:" 
                    ToolTip="Employee Email:"></asp:Label></td><td>
                <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                    ErrorMessage="RequiredFieldValidator" ToolTip="Email Required." 
                      ControlToValidate="txtEmail"><img  src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                    ErrorMessage="Invalid Email Address" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="2" 
                    ControlToValidate="txtEmail" ToolTip="Invalid Email Address"><img src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator></td></tr><tr>
              <td class="style17">
                  </td><td class="style17">
                </td><td class="style17">
                </td></tr><tr>
              <td colspan="3" align = "center">
                  <asp:Button ID="btnEdit" runat="server" Text="Edit" 
                    CssClass="ButtonLightBlue" Width="100px" />
                  &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" 
                    CssClass="ButtonLightBlue" Width="100px" />
                  </td>
          </tr>
          <tr>
              <td class="style18">
                  <b><asp:Label ID="lblQualifications" runat="server" CssClass="TextSubTitle" 
                                        Text="Employee Qualifications"></asp:Label></b></td><td class="style17">
                &nbsp;</td><td class="style17">
                &nbsp;</td></tr><tr>
              <td class="style18" colspan="3" align="center">

                <asp:GridView ID="gvQualifications" runat="server" CssClass="BlueText">
                </asp:GridView>

               </td>
        </tr>
        <tr>
              <td align="center" colspan="3">
                <asp:Button ID="btnQualification" runat="server" Text="Add Qualification" 
                    CssClass="ButtonLightBlue" Width="100px" Height="20px" />
                &nbsp;</td>
        </tr>
        <tr>
              <td class="style19">
                  &nbsp;</td>
            <td class="style15" align="center">
                &nbsp;</td>
            <td class="style15">
                &nbsp;</td>
        </tr>
        <tr>
              <td class="style20">
                <asp:Label ID="lblQualiAdd" runat="server" CssClass="BlueText" Text="Qualification:" 
                    ToolTip="Qualification:" Visible="False"></asp:Label>
                  </td>
            <td class="style21">
                <asp:TextBox ID="txtQualification" runat="server" Width="150px" 
                    Visible="False"></asp:TextBox></td>
            <td class="style21">
                <asp:RequiredFieldValidator ID="rfvQualification" runat="server" 
                    ErrorMessage="RequiredFieldValidator" ToolTip="Qualification Required." 
                      ControlToValidate="txtQualification" ValidationGroup="2"><img  src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revQualification" runat="server" 
                    ErrorMessage="Invalid Qualification Entry" 
                    ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="2" 
                    ControlToValidate="txtQualification" ToolTip="Invalid Qualfication"><img src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
              <td class="style22">
                <asp:Label ID="lblAwardingBody" runat="server" CssClass="BlueText" Text="Awarding Body:" 
                    ToolTip="Awarding Body" Visible="False"></asp:Label>
                  </td>
            <td class="style23">
                <asp:TextBox ID="txtQualiAwardingBody" runat="server" 
                    Width="150px" Visible="False" CssClass="TextBox"></asp:TextBox></td>
            <td class="style23">
                <asp:RequiredFieldValidator ID="rfvAwardingBody" runat="server" 
                    ErrorMessage="RequiredFieldValidator" ToolTip="Awarding Body Required." 
                      ControlToValidate="txtQualiAwardingBody" ValidationGroup="2"><img  src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revQualiAwardingBody" runat="server" 
                    ErrorMessage="Invalid Awarding Body Entry" 
                    ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="2" 
                    ControlToValidate="txtQualiAwardingBody" ToolTip="Invalid Awarding Body"><img src="../Images/Icons/ErrorCircle_Small.png"/></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
              <td class="style19">
                <asp:Label ID="lblQualiDate" runat="server" CssClass="BlueText" Text="Date of Qualification:" 
                    ToolTip="Date of Qualification" Visible="False"></asp:Label>
                  </td>
             <td align="left" valign="middle" id="img">
                                                        <asp:TextBox ID="txtQualiDate" runat="server" CssClass="TextBox" Width="116px" 
                                                            Visible="False"></asp:TextBox>
                                                        <cc1:MaskedEditExtender ID="txtQualiDate_MaskedEditExtender" runat="server" 
                                                    MaskType="Date" 
                                                    TargetControlID="txtQualiDate" 
                                                    Mask="99/99/9999"
                                                    PromptCharacter="_"></cc1:MaskedEditExtender>
                                                        &nbsp;<asp:Image ID="imgCalendar" runat="server" 
                                                    ImageUrl="~/Images/Icons/Calendar_Small.png" ToolTip="Calendar" Visible="False" />
                                                        <cc1:CalendarExtender ID="txtQualiDate_CalendarExtender" runat="server" 
                                                    Format="dd/MM/yyyy" PopupButtonID="imgCalendar" TargetControlID="txtQualiDate"></cc1:CalendarExtender>
                                                    </td>
            <td>
                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                                                    ControlExtender="txtQualiDate_MaskedEditExtender"
                                                    ControlToValidate="txtQualiDate" 
                                                    CssClass="RedText" 
                                                    EmptyValueMessage="Date is required"
                                                    InvalidValueMessage="Date is invalid"
                                                    IsValidEmpty="False"
                                                    TooltipMessage="Input a Date" ForeColor="" 
                    ValidationGroup="2">Please enter a date.</cc1:MaskedEditValidator>
                </td>
        </tr>
        <tr>
              <td class="style18">
                  &nbsp;</td><td>
                &nbsp;</td><td>
                &nbsp;</td></tr><tr align="center">
              <td class="style18" colspan="3">
                <asp:Button ID="btnCancelCenter" runat="server" Text="Center Cancel" 
                    CssClass="ButtonLightBlue" Width="119px" Height="20px" />
                  &nbsp;<asp:Button ID="btnQualiAdd" runat="server" CssClass="ButtonLightBlue" 
                      Text="Add Qualification" ValidationGroup="2" Width="134px" />
&nbsp;<asp:Button ID="btnCancelSub" runat="server" Text="Cancel Subscribtion" 
                    CssClass="ButtonLightBlue" Width="119px" />
                  &nbsp;<asp:Button ID="btnViewCV" runat="server" Text="View CV" 
                    CssClass="ButtonLightBlue" Width="119px" />
                  </td>
        </tr>
    </table>
</asp:Content>

