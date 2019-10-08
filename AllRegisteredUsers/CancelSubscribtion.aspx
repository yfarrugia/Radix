<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="CancelSubscribtion.aspx.vb" Inherits="AllUsers_CancelSubscribtion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:MultiView ID="CancelSubscribtionMultiView" runat="server">
        <asp:View ID="UserAccountView" runat="server">
            <br />

                    <table align="center" width="60%">
                        <tr>
                            <td align="center" class="BlueText" colspan="3">
                                <asp:Label ID="lblStep1_1" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                                &nbsp;<asp:Image ID="Image7" runat="server" ImageUrl="~/Images/NextStep.png" />
                                &nbsp;<asp:Label ID="lblStep2_1" runat="server" Text="Label"></asp:Label>
                                &nbsp;<asp:Image ID="Image8" runat="server" ImageUrl="~/Images/NextStep.png" />
                                &nbsp;<asp:Label ID="lblStep3_1" runat="server" Text="Label"></asp:Label>
                                &nbsp;
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="titlecell">
                                Current Password</td>
                            <td align="left" width="10">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" 
                                    TextMode="Password" ValidationGroup="2" Width="150px" />
                            </td>
                            <td align="left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtPassword" ErrorMessage="*" ValidationGroup="2">
                                <asp:Image ID="Image1" runat="server" 
                                    ImageUrl="~/Images/Icons/Warning_Small.png" />
                                </asp:RequiredFieldValidator>
                                </td>
                        </tr>
                        <tr>
                            <td align="right" class="titlecell">
                                Date of Birth</td>
                            <td align="left">
                                <asp:TextBox ID="txtDOB" runat="server" CssClass="TextBox" ValidationGroup="2" 
                                    Width="150px" />
                                <cc1:MaskedEditExtender ID="txtDOB_MaskedEditExtender" runat="server" 
                                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                    CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                    Mask="99/99/9999" MaskType="Date" TargetControlID="txtDOB"></cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" PopupButtonID="imgCalendar" 
                                    TargetControlID="txtDOB"></cc1:CalendarExtender>
                                &nbsp;<asp:Image ID="imgCalendar" runat="server" 
                                    ImageUrl="~/Images/Icons/Calendar_Small.png" ToolTip="Calendar" />
                            </td>
                            <td align="left">
                                &nbsp;
                                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                                    ControlExtender="txtDOB_MaskedEditExtender" ControlToValidate="txtDOB" 
                                    CssClass="RedText" EmptyValueMessage="Date is required" ForeColor="" 
                                    InvalidValueMessage="Date is invalid" IsValidEmpty="False" 
                                    TooltipMessage="Input a Date" ValidationGroup="2"> Please enter a date.</cc1:MaskedEditValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td align="left">
                                <asp:Label ID="lblWarning" runat="server" CssClass="RedText"></asp:Label>
                            </td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td align="left" colspan="2">
                                <asp:Button ID="btnClearView1" runat="server" CssClass="ButtonLightBlue" 
                                    Text="Clear" />
                                &nbsp;<asp:Button ID="btnContinueView1" runat="server" CssClass="ButtonLightBlue" 
                                    Text="Continue" ValidationGroup="2" />
                            </td>
                        </tr>
                    </table>
        </asp:View>
        <asp:View ID="FeedbackUserView" runat="server">
            <table align="center" width="60%">
                <tr>
                    <td align="center" class="BlueText" colspan="2">
                        <asp:Label ID="lblStep1_3" runat="server" Text="Label"></asp:Label>
                        &nbsp;<asp:Image ID="Image4" runat="server" ImageUrl="~/Images/NextStep.png" />
                        &nbsp;<asp:Label ID="lblStep2_3" runat="server" style="font-weight: 700" 
                            Text="Label"></asp:Label>
                        &nbsp;<asp:Image ID="Image5" runat="server" ImageUrl="~/Images/NextStep.png" />
                        &nbsp;<asp:Label ID="lblStep3_3" runat="server" Font-Bold="False" Text="Label"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="titlecell">
                        Reason</td>
                    <td align="left">
                        <asp:DropDownList ID="DropDownList2" runat="server" Height="19px" Width="160px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="titlecell" valign="top">
                        Additional Comments</td>
                    <td align="left">
                        <asp:TextBox ID="txtFeedbackBody" runat="server" CssClass="TextBox" Height="135px" 
                            TextMode="MultiLine" Width="254px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td align="left">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="ButtonLightBlue" 
                            Text="Submit" ToolTip="Submit Comments" ValidationGroup="2" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="center">
                        &nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="ConfirmUserView" runat="server">
            <table align="center" width="60%">
                <tr>
                    <td align="center" class="BlueText" colspan="2">
                        <asp:Label ID="lblStep1_2" runat="server" Text="Label"></asp:Label>
                        &nbsp;<asp:Image ID="Image10" runat="server" ImageUrl="~/Images/NextStep.png" />
                        &nbsp;<asp:Label ID="lblStep2_2" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                        &nbsp;<asp:Image ID="Image11" runat="server" ImageUrl="~/Images/NextStep.png" />
                        &nbsp;<asp:Label ID="lblStep3_2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="titlecell">
                        Confirmation Code</td>
                    <td align="left">
                        <asp:TextBox ID="txtCode" runat="server" CssClass="TextBox" Width="300px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td align="justify">
                        <asp:Label ID="lblCodeWarning" runat="server" CssClass="RedText" Enabled="False"
                            Text="Invalid Code"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="justify">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnContinueView2" runat="server" CssClass="ButtonLightBlue" Text="Confirm"
                            ValidationGroup="2" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <br />
        <br />
    </asp:MultiView>
</asp:Content>
