<%@ Page Title="" Language="VB" MasterPageFile="~/Employees/EmployeeMasterPage.master"
    AutoEventWireup="false" CodeFile="UpdateCV.aspx.vb" Inherits="Employees_UpdateCV" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <br />
    <br />
    <cc1:TabContainer ID="TabContainerUpdateCV" runat="server" ActiveTabIndex="0" Width="100%"
        CssClass="ajax__myTab">
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Previous Job<">
            <HeaderTemplate>
                Previous Jobs
            </HeaderTemplate>
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <asp:Panel ID="pnlLoading" runat="server" CssClass="LoadingPanel">
                            <table border="0" cellspacing="0" cellpadding="5" align="center">
                                <tr valign="middle">
                                    <td align="center" width="5px" height="75">
                                        <asp:Image ID="imgLoading" runat="server" ImageUrl="~/Images/Loading.gif" />
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
                <table align="center" width="95%">
                    <tr>
                        <td align="center" style="height: 136px">
                            <br />
                            <asp:GridView ID="gvJobHistory" runat="server" CssClass="GridView" GridLines="None"
                                Width="100%" EmptyDataText="You currently have no jobs added to your job history.">
                                <RowStyle CssClass="GridViewRow" />
                                <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                <Columns>
                                    <asp:ButtonField ButtonType="Image" CommandName="PreviousJobE" ImageUrl="~/Images/Icons/Edit.png"
                                        Text="Edit Previous Job">
                                        <ItemStyle CssClass="GridViewIcons" />
                                    </asp:ButtonField>
                                </Columns>
                                <HeaderStyle CssClass="GridViewHeaderRow" />
                            </asp:GridView>
                            <br />
                            &#160;<asp:Button ID="btnAddJob" runat="server" CssClass="ButtonLightBlue" Text="Add Job" /><br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblSavedPreviousJob" runat="server" CssClass="GreenText" Text="Previous Job Saved Successfully"
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Panel ID="pnlJobHistory" runat="server" BackColor="White" Visible="False">
                    <table width="90%" align="center">
                        <tr>
                            <td class="titlecell">
                                <asp:Label ID="lblTitle" runat="server" Text="Job Title"></asp:Label>
                            </td>
                            <td align="left" width="5">
                                <asp:TextBox ID="txtTitle" runat="server" align="left" CssClass="TextBox" MaxLength="30"
                                    Width="150px"></asp:TextBox>
                            </td>
                            <td align="left">
                                &#160;&#160;
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                <asp:Label ID="lblDescription" runat="server" Text="Job Description"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDescription" runat="server" align="left" CssClass="TextBox" MaxLength="100"
                                    Width="150px"></asp:TextBox>
                            </td>
                            <td align="left">
                                &#160;&#160;
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                <asp:Label ID="lblCompanyName" runat="server" Text="Company Name"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCompany" runat="server" align="left" CssClass="TextBox" MaxLength="50"
                                    Width="150px"></asp:TextBox>
                            </td>
                            <td align="left">
                                &#160;&#160;
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="TextBox" Style="margin-bottom: 0px"
                                    Width="150px"></asp:TextBox><cc1:CalendarExtender ID="txtStartDate_CalendarExtender"
                                        runat="server" Enabled="True" Format="MM/dd/yyyy" PopupButtonID="imgStarting"
                                        TargetControlID="txtStartDate">
                                    </cc1:CalendarExtender>
                                <cc1:MaskedEditExtender ID="txtStartDate_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtStartDate">
                                </cc1:MaskedEditExtender>
                                <asp:Image ID="imgStarting" runat="server" ImageUrl="~/Images/Icons/Calendar_Small.png"
                                    ToolTip="Calendar" Visible="False" Width="25px" />
                            </td>
                            <td align="left">
                                <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="txtStartDate_MaskedEditExtender"
                                    ControlToValidate="txtStartDate" CssClass="RedText" EmptyValueMessage="Date is required"
                                    ErrorMessage="MaskedEditValidator1" ForeColor="" InvalidValueMessage="Date is invalid"
                                    IsValidEmpty="False" TooltipMessage="Input a Date" ValidationGroup="2"> &#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;Please enter a date. </cc1:MaskedEditValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="TextBox" Style="margin-bottom: 0px"
                                    Width="150px"></asp:TextBox><cc1:CalendarExtender ID="txtEndDate_CalendarExtender"
                                        runat="server" Enabled="True" Format="MM/dd/yyyy" PopupButtonID="imgEnding" TargetControlID="txtEndDate">
                                    </cc1:CalendarExtender>
                                <cc1:MaskedEditExtender ID="txtEndDate_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtEndDate">
                                </cc1:MaskedEditExtender>
                                <asp:Image ID="imgEnding" runat="server" ImageUrl="~/Images/Icons/Calendar_Small.png"
                                    ToolTip="Calendar" Visible="False" Width="25px" />
                            </td>
                            <td align="left">
                                <cc1:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="txtEndDate_MaskedEditExtender"
                                    ControlToValidate="txtEndDate" CssClass="RedText" EmptyValueMessage="Date is required"
                                    ErrorMessage="MaskedEditValidator1" ForeColor="" InvalidValueMessage="Date is invalid"
                                    IsValidEmpty="False" TooltipMessage="Input a Date" ValidationGroup="2"> &#160;&#160;&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;&#160;Please enter a date.&#160;&#160;&#160;&#160;&#160;&#160;Please enter a date. </cc1:MaskedEditValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell">
                                <asp:Label ID="lblIndustry" runat="server" Text="Industry"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlIndustry" runat="server" AutoPostBack="True" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                &#160;&#160;
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell" style="height: 15px">
                                <asp:Label ID="lblOccupation" runat="server" Text="Occupation"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlOccupation" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                &#160;&#160;
                            </td>
                        </tr>
                        <tr>
                            <td class="titlecell" style="height: 19px">
                                <asp:Label ID="lblJobType" runat="server" Text="Job Type"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlJobType" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                &#160;&#160;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &#160;&#160;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                <asp:Button ID="btnJobSave" runat="server" CssClass="ButtonLightBlue" Text="Save Previous Job"
                                    Visible="False" Width="150px" />&#160;<asp:Button ID="btnUpdateJob" runat="server"
                                        CssClass="ButtonLightBlue" Text="Update Previous Job" Visible="False" Width="150px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &#160;&#160;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" HeaderText="test" runat="server">
            <HeaderTemplate>
                Employee Qualifications
            </HeaderTemplate>
            <ContentTemplate>
                <br />
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                    <ProgressTemplate>
                        <asp:Panel ID="pnlLoading" runat="server" CssClass="LoadingPanel">
                            <table border="0" cellspacing="0" cellpadding="5" align="center">
                                <tr valign="middle">
                                    <td align="center" width="5px" height="75">
                                        <asp:Image ID="imgLoading" runat="server" ImageUrl="~/Images/Loading.gif" />
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
                        <br />
                        <table align="center" width="95%">
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="gvQualifications" runat="server" CssClass="GridView" GridLines="None"
                                        Width="100%">
                                        <RowStyle CssClass="GridViewRow" />
                                        <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                        <Columns>
                                            <asp:ButtonField ButtonType="Image" CommandName="QualificationE" ImageUrl="~/Images/Icons/Edit.png"
                                                Text="Edit Qualification">
                                                <ItemStyle CssClass="GridViewIcons" />
                                            </asp:ButtonField>
                                            <asp:ButtonField ButtonType="Image" CommandName="DeleteQualification" ImageUrl="~/Images/Icons/Delete.png"
                                                Text="Delete Qualification">
                                                <ItemStyle CssClass="GridViewIcons" />
                                            </asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle CssClass="GridViewHeaderRow" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnAddQualification" runat="server" CssClass="ButtonLightBlue" Text="Add Qualification"
                                        Width="130px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblQualiSaved" runat="server" CssClass="GreenText" Text="Qualification Saved Successfully"
                                        Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &#160;&#160;
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="pnlQualification" runat="server" Width="100%" Visible="False">
                            <table align="center" width="100%">
                                <tr>
                                    <td>
                                        &#160;&#160;
                                    </td>
                                    <td>
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="titlecell">
                                        Qualification
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtQualification" runat="server" CssClass="TextBox" MaxLength="50"
                                            Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvQuali" runat="server"
                                                ControlToValidate="txtQualification" ErrorMessage="Job Title Required" ToolTip="Job Title Required"
                                                ValidationGroup="2"><img src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                    ID="revQualification" runat="server" ControlToValidate="txtQualification" ErrorMessage="Invalid Qualificaion Entry"
                                                    ToolTip="Invalid Qualification" ValidationExpression="[0-9a-zA-Z\-\s]+" ValidationGroup="2"><img 
                        src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="titlecell">
                                        Awarding Body
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtQualiAwardingBody" runat="server" CssClass="TextBox" MaxLength="50"
                                            Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvQualiAwarding" runat="server"
                                                ControlToValidate="txtQualiAwardingBody" ErrorMessage="Job Title Required" ToolTip="Job Title Required"
                                                ValidationGroup="2"><img src="../Images/Icons/Warning_Small.png" /></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                    ID="revAwardingBody" runat="server" ControlToValidate="txtQualiAwardingBody"
                                                    ErrorMessage="Invalid Awarding Body Entry" ToolTip="Invalid Awarding Body" ValidationExpression="[0-9a-zA-Z\-\s]+"
                                                    ValidationGroup="2"><img 
                            src="../Images/Icons/ErrorCircle_Small.png" /></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="titlecell">
                                        &#160;Qualification Date
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtQualiDate" runat="server" Style="margin-bottom: 0px" Visible="False"
                                            Width="150px"></asp:TextBox><cc1:CalendarExtender ID="txtQualiDate_CalendarExtender"
                                                runat="server" Enabled="True" Format="MM/dd/yyyy" PopupButtonID="imgQualiDate"
                                                TargetControlID="txtQualiDate">
                                            </cc1:CalendarExtender>
                                        <cc1:MaskedEditExtender ID="txtQualiDate_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtQualiDate">
                                        </cc1:MaskedEditExtender>
                                        <asp:Image ID="imgQualiDate" runat="server" Height="25px" ImageUrl="~/Images/Icons/Calendar_Small.png"
                                            ToolTip="Calendar" Visible="False" Width="25px" /><cc1:MaskedEditValidator ID="MaskedEditValidator4"
                                                runat="server" ControlExtender="txtQualiDate_MaskedEditExtender" ControlToValidate="txtQualiDate"
                                                CssClass="RedText" EmptyValueMessage="Date is required" ErrorMessage="MaskedEditValidator1"
                                                ForeColor="" InvalidValueMessage="Date is invalid" IsValidEmpty="False" TooltipMessage="Input a Date"
                                                ValidationGroup="2">Please enter a date.</cc1:MaskedEditValidator><asp:Label ID="lblInvalidDate"
                                                    runat="server" CssClass="RedText" Text="Invalid Date" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnSaveQualification" runat="server" CssClass="ButtonLightBlue" Text="Save Qualification"
                                            ValidationGroup="2" Visible="False" Width="130px" />&#160;<asp:Button ID="btnSaveUpdates"
                                                runat="server" CssClass="ButtonLightBlue" Text="Save Updates" Visible="False"
                                                Width="130px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Job Preference<">
            <HeaderTemplate>
                Select Job Preference
            </HeaderTemplate>
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2" align="center">
                            <asp:GridView ID="gvPreferredJob" runat="server" CssClass="GridView" GridLines="None"
                                Width="95%">
                                <Columns>
                                    <asp:ButtonField ButtonType="Image" CommandName="JobPreferenceD" ImageUrl="~/Images/Icons/Delete.png"
                                        Text="Delete Job Preference" />
                                </Columns>
                                <AlternatingRowStyle CssClass="GridViewAlternateRow" />
                                <HeaderStyle CssClass="GridViewHeaderRow" />
                                <RowStyle CssClass="GridViewRow" />
                                <SelectedRowStyle CssClass="GridViewSelectedRow" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &#160;&#160;
                        </td>
                        <td>
                            &#160;&#160;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnAddJobPreference" runat="server" CssClass="ButtonLightBlue" Height="20px"
                                Text="Add Job Preference" Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="height: 17px">
                            <asp:Label ID="lblSaved" runat="server" CssClass="RedText" Text="Preferred Job Saved Successfully"
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Panel ID="pnlPreferredJob" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPrefIndustry" runat="server" CssClass="titlecell" Text="Preferred Industry"
                                    ToolTip="Preferred Industry" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPrefIndustry" runat="server" AutoPostBack="True" Visible="False"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPrefOccupation" runat="server" CssClass="titlecell" Text="Preferred Occupation"
                                    ToolTip="Preferred Occupation" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPrefOccupation" runat="server" Visible="False" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 17px">
                                <asp:Label ID="lblPrefJobType" runat="server" CssClass="titlecell" Text="Preferred Job Type"
                                    ToolTip="Preferred Job Type" Visible="False"></asp:Label>
                            </td>
                            <td style="height: 17px">
                                <asp:DropDownList ID="ddlPrefJobType" runat="server" Visible="False" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 17px">
                                &#160;&#160;
                            </td>
                            <td style="height: 17px">
                                &#160;&#160;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="height: 17px">
                                <asp:Button ID="btnSaveJobPreference" runat="server" CssClass="ButtonLightBlue" Height="20px"
                                    Text="Save Job Preference" Width="150px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
