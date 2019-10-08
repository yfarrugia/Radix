     <%@ Page Title="" Language="VB" MasterPageFile="~/Employees/EmployeeMasterPage.master" AutoEventWireup="false" CodeFile="UserProfile.aspx.vb" Inherits="AllRegisteredUsers_UserProfile" %>

    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
            Width="100%" CssClass="ajax__myTab">
            <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>Personal Details</HeaderTemplate><ContentTemplate><table style="width:100%;"><tr><td align="center"><br /><table 
                align="center" width="90%"><tr><td class="titlecell" width="250">Name</td><td><asp:TextBox 
                    ID="txtName" runat="server" CssClass="TextBox" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td>&#160;</td></tr><tr><td 
                class="titlecell">Surname</td><td><asp:TextBox ID="txtSurname" runat="server" 
                    CssClass="TextBox" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td><asp:RequiredFieldValidator 
                    ID="rfvSurname" runat="server" ControlToValidate="txtSurname" 
                    ErrorMessage="Surname Required" ToolTip="Surname Required."><img 
                    src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                    ID="revSurname" runat="server" ControlToValidate="txtSurname" 
                    ErrorMessage="Invalid surname entry" ToolTip="Invalid Surname Entry" 
                    ValidationExpression="([a-zA-Z\s]{3,30})+" ValidationGroup="2"><img 
                    src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                    class="titlecell">&#160;Date of Birth</td><td width="150"><asp:TextBox ID="txtDOB" 
                        runat="server" CssClass="TextBox" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td>&#160;</td></tr><tr><td 
                class="titlecell">&#160;Nationality</td><td><asp:TextBox ID="txtNationality" 
                    runat="server" CssClass="TextBox" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td>&#160;</td></tr><tr><td 
                align="center" colspan="3">&#160;</td></tr></table><br /><asp:Panel 
                ID="pnlEmployeeDetails" runat="server" align="center" 
                style="text-align: center" Visible="False" Width="90%"><table ID="tblEdit" 
                    runat="server" align="center" HorizontalAlign="Center" width="100%"><tr 
                        ID="TableRow1" runat="server"><td runat="server" class="titlecell" 
                            CssClass="titlecell">&#160;Currently Employed </td><td runat="server" 
                            align="left"><asp:CheckBox ID="chkEmployed" runat="server" align="right" 
                                CssClass="Text" Text="Are you currently employed?" /></td></tr><tr ID="TableRow2" runat="server"><td runat="server" class="titlecell" CssClass="titlecell">&#160;Employment </td><td runat="server" align="left"><asp:CheckBox ID="chkSeeking" 
                                runat="server" align="right" CssClass="Text" 
                                Text="Are currently seeking employment" /></td></tr><tr ID="TableRow3" runat="server"><td runat="server" class="titlecell" CssClass="titlecell">&#160;Sponsored </td><td runat="server" align="left"><asp:CheckBox ID="chkSponsored" 
                                runat="server" align="right" CssClass="Text" Text="Are you a sponsored?" /></td></tr></table></asp:Panel><br /></td></tr><tr><td align="center"><asp:Button ID="btnEditPersonalDetails" runat="server" 
                        CssClass="ButtonLightBlue" Text="Edit" Width="100px" />&#160;<asp:Button ID="btnSavePersonalDetails" runat="server" 
                        CssClass="ButtonLightBlue" Text="Save" Width="100px" /></td></tr></table></ContentTemplate></cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2"><HeaderTemplate>Contact Details</HeaderTemplate><ContentTemplate><asp:UpdatePanel 
                ID="UpdatePanel3" runat="server"><ContentTemplate><br /><table align="center" 
                    width="95%"><tr><td class="titlecell">&#160;Address</td><td align="left" width="50"><asp:TextBox 
                        ID="txtAddress" runat="server" CssClass="TextBox" ReadOnly="True" 
                        ValidationGroup="2" Width="150px">N/A</asp:TextBox></td><td align="left"><asp:RequiredFieldValidator 
                            ID="rfvAddress" runat="server" ControlToValidate="txtAddress" 
                            ErrorMessage="Address Required" ToolTip="Address Required."><img 
                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                            ID="revAddress" runat="server" ControlToValidate="txtAddress" 
                            ErrorMessage="Invalid Address Entry" ToolTip="Invalid Address" 
                            ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="2"><img 
                            src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">Street Address</td><td align="left"><asp:TextBox 
                            ID="txtStrAddress" runat="server" CssClass="TextBox" ReadOnly="True" 
                            Width="150px">N/A</asp:TextBox></td><td align="left"><asp:RequiredFieldValidator 
                            ID="rfvStrAddress" runat="server" ControlToValidate="txtStrAddress" 
                            ErrorMessage="Street Address Required" ToolTip="Surname Required."><img 
                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                            ID="revStrAddress" runat="server" ControlToValidate="txtStrAddress" 
                            ErrorMessage="Invalid Street Address" ToolTip="Invalid Street Address" 
                            ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="2"><img 
                            src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">&#160;Town</td><td align="left"><asp:TextBox ID="txtTown" 
                            runat="server" CssClass="TextBox" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td 
                        align="left"><asp:RegularExpressionValidator ID="revTown" runat="server" 
                            ControlToValidate="txtTown" ErrorMessage="Invalid Town Entry" 
                            ToolTip="Invalid Town" ValidationExpression="[0-9a-zA-Z\-]+" 
                            ValidationGroup="2"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">&#160;State</td><td align="left"><asp:TextBox ID="txtState" 
                            runat="server" CssClass="TextBox" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td 
                        align="left"><asp:RegularExpressionValidator ID="revState" runat="server" 
                            ControlToValidate="txtState" ErrorMessage="Invalid State" 
                            ToolTip="Invalid State" ValidationExpression="[0-9a-zA-Z\-]+" 
                            ValidationGroup="2"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">&#160;Post Code</td><td align="left"><asp:TextBox 
                            ID="txtPostCode" runat="server" CssClass="TextBox" ReadOnly="True" 
                            Width="150px">N/A</asp:TextBox></td><td align="left"><asp:RequiredFieldValidator 
                            ID="rfvPostCode" runat="server" ControlToValidate="txtPostCode" 
                            ErrorMessage="RequiredFieldValidator" ToolTip="Post Code Required."><img 
                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                            ID="revPostCode" runat="server" ControlToValidate="txtPostCode" 
                            ErrorMessage="Invalid Post Code Entry" ToolTip="Invalid Post Code" 
                            ValidationExpression="[0-9a-zA-Z\-]+" ValidationGroup="2"><img 
                            src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">&#160;Country</td><td align="left"><asp:DropDownList 
                            ID="ddlCountry" runat="server" CssClass="TextBox" Enabled="False" Width="150px"></asp:DropDownList></td><td align="left"><asp:RequiredFieldValidator ID="rfvCountry" runat="server" 
                            ControlToValidate="ddlCountry" ErrorMessage="RequiredFieldValidator" 
                            ToolTip="Country Required."> <img src="../Images/Icons/Warning_Small.png" /> </asp:RequiredFieldValidator></td></tr><tr><td class="titlecell">&#160;Telephone Number</td><td align="left"><asp:TextBox ID="txtTelephoneNo" 
                            runat="server" CssClass="TextBox" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td 
                        align="left"><asp:RegularExpressionValidator ID="revTelephone" runat="server" 
                            ControlToValidate="txtTelephoneNo" ErrorMessage="Invalid Telephone Number " 
                            ToolTip="Invalid Telephone Number " ValidationExpression="[0-9\-]+" 
                            ValidationGroup="2"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">Email Address</td><td align="left"><asp:TextBox 
                            ID="txtEmail" runat="server" CssClass="TextBox" ReadOnly="True" Width="150px">N/A</asp:TextBox></td><td 
                        align="left"><asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                            ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" 
                            ToolTip="Email Required."><img src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                            ID="revEmail" runat="server" ControlToValidate="txtEmail" 
                            ErrorMessage="Invalid Email Address" ToolTip="Invalid Email Address" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="2"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td><tr><td></td><td></td><td></td></tr><tr><td 
                        align="center" colspan="3"><asp:Button ID="btnEditContactDetails" 
                        runat="server" CssClass="ButtonLightBlue" Text="Edit" Width="100px" />&#160;<asp:Button ID="btnSaveContactDetails" runat="server" 
                        CssClass="ButtonLightBlue" Text="Save" Width="100px" /></td></tr></tr></table></ContentTemplate></asp:UpdatePanel>
            </ContentTemplate></cc1:TabPanel>
            
            
                   <cc1:TabPanel runat="server" HeaderText="TabPanel3" ID="TabPanel3" Visible="False"><HeaderTemplate>Center Details</HeaderTemplate><ContentTemplate><asp:UpdatePanel 
                ID="UpdatePanel2" runat="server"><ContentTemplate><br /><table 
                    style="width:100%;"><tr><td><table align="center" width="95%"><tr><td 
                        class="titlecell">Current Center </td><td><asp:TextBox ID="txtCenter" 
                            runat="server" CssClass="TextBox" ReadOnly="True" Width="150px">N/A</asp:TextBox></td></tr><tr><td 
                            class="titlecell">Center Location </td><td><asp:TextBox ID="txtCenterLocation" 
                                runat="server" CssClass="TextBox" ReadOnly="True" Width="150px">N/A</asp:TextBox></td></tr><tr><td 
                            align="center" colspan="2"><asp:Button ID="btnChangeCenter" runat="server" 
                            CssClass="ButtonLightBlue" Text="Change Center" /></td></tr></table></td></tr><tr><td align="center"><br /><asp:Panel ID="pnlCenter" runat="server" Visible="False" Width="95%"><table align="center" width="100%"><tr><td class="titlecell">Select Country</td><td align="left"><asp:DropDownList ID="ddlCenterCountry" 
                                            runat="server" AutoPostBack="True"></asp:DropDownList></td></tr><tr><td class="titlecell">Select Center</td><td align="left"><asp:DropDownList ID="ddlCenter" 
                                            runat="server"></asp:DropDownList></td></tr><tr><td align="center" colspan="2"><asp:Button ID="btnSaveCenter" runat="server" CssClass="ButtonLightBlue" 
                                            Text="Migrate Center" /></td></tr></table></asp:Panel></td></tr><tr><td>&#160;</td></tr></table><br /></ContentTemplate></asp:UpdatePanel><br /><br /></ContentTemplate></cc1:TabPanel>
            
            
            
               <cc1:TabPanel runat="server" HeaderText="TabPanel5" ID="TabPanel5" Visible="false"><HeaderTemplate>Company Details</HeaderTemplate><ContentTemplate><br /><asp:UpdatePanel 
                ID="UpdatePanel4" runat="server"><ContentTemplate><table align="center" 
                    width="95%"><tr><td class="titlecell">Company Name</td><td><asp:TextBox 
                        ID="txtCompanyName" runat="server" CssClass="TextBox" ReadOnly="True" 
                        Width="150px"></asp:TextBox></td></tr><tr><td class="titlecell">Company Address</td><td><asp:TextBox 
                        ID="txtCompanyAddress" runat="server" CssClass="TextBox" ReadOnly="True" 
                        Width="150px"></asp:TextBox><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtCompanyAddress" CssClass="RedText" ErrorMessage="*" 
                        ForeColor="" ToolTip="Address is a required field." ValidationGroup="5"><img 
                        src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                        ID="RegularExpressionValidator12" runat="server" 
                        ControlToValidate="txtCompanyAddress" CssClass="RedText" 
                        ErrorMessage="Invalid Company Address Format" ForeColor="" 
                        ToolTip="Invalid Company Address Format" 
                        ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="5"><img 
                        src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">Street Address</td><td><asp:TextBox ID="txtCompStreetAddress" 
                            runat="server" CssClass="TextBox" ReadOnly="True" Width="150px"></asp:TextBox><asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator12" runat="server" 
                            ControlToValidate="txtCompStreetAddress" CssClass="RedText" ErrorMessage="*" 
                            ForeColor="" ToolTip="Street is a required field." ValidationGroup="5"><img 
                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator13" runat="server" 
                            ControlToValidate="txtCompStreetAddress" CssClass="RedText" 
                            ErrorMessage="Invalid Street Address Format" ForeColor="" 
                            ToolTip="Invalid Street Address Format" ValidationExpression="[0-9a-zA-Z\-\s]+" 
                            ValidationGroup="5"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">Town</td><td align="left"><asp:TextBox ID="txtCompTown" 
                            runat="server" align="left" CssClass="TextBox" ReadOnly="True" Width="150px"></asp:TextBox><asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCompTown" 
                            CssClass="RedText" ErrorMessage="*" ForeColor="" 
                            ToolTip="Town is a required field." ValidationGroup="5"><img 
                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator14" runat="server" 
                            ControlToValidate="txtCompTown" CssClass="RedText" 
                            ErrorMessage="Invalid Town Characters" ForeColor="" 
                            ToolTip="Invalid Town Format" ValidationExpression="[0-9a-zA-Z\-]+" 
                            ValidationGroup="5"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">State</td><td><asp:TextBox ID="txtCompState" runat="server" 
                            CssClass="TextBox" ReadOnly="True" Width="150px"></asp:TextBox><asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator15" runat="server" 
                            ControlToValidate="txtCompState" CssClass="RedText" 
                            ErrorMessage="Invalid State Format" ForeColor="" ToolTip="Invalid State Format" 
                            ValidationExpression="[0-9a-zA-Z\-]+" ValidationGroup="5"><img 
                            src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">Registered Country</td><td><asp:DropDownList 
                            ID="ddlCompCountry" runat="server" CssClass="TextBox" ReadOnly="True" 
                            Width="150px"></asp:DropDownList></td></tr><tr><td class="titlecell">Post Code</td><td><asp:TextBox ID="txtCompPostCode" runat="server" 
                            CssClass="TextBox" ReadOnly="True" Width="150px"></asp:TextBox><asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator14" runat="server" 
                            ControlToValidate="txtCompPostCode" CssClass="RedText" ErrorMessage="*" 
                            ForeColor="" ToolTip="Post Code is a required field." 
                        ValidationGroup="5"><img 
                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator16" runat="server" 
                            ControlToValidate="txtCompPostCode" CssClass="RedText" 
                            ErrorMessage="Invalid Post Code Format" ForeColor="" 
                            ToolTip="Invalid Post Code Format" ValidationExpression="[0-9a-zA-Z\-]+" 
                            ValidationGroup="5"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">&#160;Telephone Number</td><td><asp:TextBox ID="txtCompanyTel" 
                            runat="server" CssClass="TextBox" ReadOnly="True" Width="150px"></asp:TextBox><asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="txtCompanyTel" CssClass="RedText" 
                            ErrorMessage="Invalid Telephone Number Format" ForeColor="" 
                            ToolTip="Invalid Telephone Format" ValidationExpression="[0-9\-]+" 
                            ValidationGroup="5"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">Email</td><td><asp:TextBox ID="txtCompEmail" runat="server" 
                            CssClass="TextBox" ReadOnly="True" Width="150px"></asp:TextBox><asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompEmail" 
                            CssClass="RedText" ErrorMessage="*" ForeColor="" 
                            ToolTip="Email is a required field." ValidationGroup="5"><img 
                            src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                            ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="txtCompEmail" CssClass="RedText" 
                            ErrorMessage="Invalid E-Mail Format" ForeColor="" 
                            ToolTip="Invalid E-Mail Format" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="4"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">VAT No</td><td><asp:TextBox ID="txtVatNo" runat="server" 
                            CssClass="TextBox" ReadOnly="True" Width="150px"></asp:TextBox></td></tr><tr><td 
                        class="titlecell">Registration No</td><td><asp:TextBox ID="txtRegNum" 
                            runat="server" CssClass="TextBox" ReadOnly="True" Width="150px"></asp:TextBox></td></tr><tr><td 
                        colspan="2">&#160;</td></tr><tr><td align="center" align="center" colspan="2"><asp:Button 
                        ID="btnEditCompany" runat="server" align="center" CssClass="ButtonLightBlue" 
                        Text="Edit Company Details" />&#160;<asp:Button ID="btnSaveCompany" runat="server" align="center" 
                        CssClass="ButtonLightBlue" Text="Save Changes" /></td></tr></table></ContentTemplate></asp:UpdatePanel><br /></ContentTemplate></cc1:TabPanel>
            
            
            
            
            
             <cc1:TabPanel runat="server" HeaderText="TabPanel4" ID="TabPanel4"><HeaderTemplate>User Account Details</HeaderTemplate><ContentTemplate><br /><asp:UpdatePanel 
                ID="UpdatePanel5" runat="server"><ContentTemplate><table align="center" 
                    width="95%"><tr><td class="titlecell">Username</td><td><asp:TextBox 
                        ID="txtUsername" runat="server" CssClass="TextBox" ReadOnly="True" 
                        Width="150px"></asp:TextBox></td></tr><tr><td class="titlecell">Old Password</td><td><asp:TextBox 
                        ID="txtOldPassword" runat="server" CssClass="TextBox" ReadOnly="True" 
                        TextMode="Password" Width="150px"></asp:TextBox>&#160;<asp:Label 
                        ID="lblIncorrect" runat="server" CssClass="RedText" 
                        Text="Incorrect Password Entered" Visible="False"></asp:Label></td></tr><tr><td>&#160;</td><td>&#160;</td></tr><tr><td 
                        class="titlecell">New Password</td><td><asp:TextBox 
                            ID="txtNewPassword" runat="server" CssClass="TextBox" ReadOnly="True" 
                            TextMode="Password" Width="150px"></asp:TextBox><asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtNewPassword" CssClass="RedText" ErrorMessage="*" 
                            ForeColor="" ToolTip="Password is a required field." 
                            ValidationGroup="2"><img src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                        ID="RegularExpressionValidator11" runat="server" 
                        ControlToValidate="txtNewPassword" CssClass="RedText" 
                        ErrorMessage="Invalid Username characters." ForeColor="" 
                        ToolTip="Invalid Password." 
                        ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{5,20})$" 
                        ValidationGroup="2"><img src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator></td></tr><tr><td 
                        class="titlecell">Confirm New Password</td><td><asp:TextBox 
                            ID="txtConfirmNewPassword" runat="server" CssClass="TextBox" ReadOnly="True" 
                            TextMode="Password" Width="150px"></asp:TextBox><asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtConfirmNewPassword" CssClass="RedText" ErrorMessage="*" 
                            ForeColor="" ToolTip="Re-Enter Password is a required field." 
                            ValidationGroup="2"><img src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:CompareValidator 
                            ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword" 
                            ControlToValidate="txtConfirmNewPassword" CssClass="RedText" 
                            ErrorMessage="CompareValidator" ForeColor="" 
                            ToolTip="This field and the Password field do not match exactly." 
                            ValidationGroup="2"><img src="../Images/Icons/MismatchIcon_Small.png" /></asp:CompareValidator></td></tr><tr><td>&#160;</td><td>&#160;</td></tr><tr><td>&#160;</td><td><asp:Button 
                    ID="btnChangePassword" runat="server" CssClass="ButtonLightBlue" 
                    Text="Change Password" Width="100px" /></td></tr></table></ContentTemplate></asp:UpdatePanel><br />
            </ContentTemplate></cc1:TabPanel>
            
          </cc1:TabContainer>
        <br />
            
        

    </asp:Content>

