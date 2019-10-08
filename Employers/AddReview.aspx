<%@ Page Language="VB" MasterPageFile="~/Employers/EmployerMasterPage.master" AutoEventWireup="false"
    CodeFile="AddReview.aspx.vb" Inherits="Employers_AddReview" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <style type="text/css">
        .star_rating
        {
            font-size: 0pt;
            width: 13px;
            height: 12px;
            margin: 0px;
            padding: 0px;
            cursor: pointer;
            display: block;
            background-repeat: no-repeat;
        }
        .star_filled
        {
            background-image: url(../Images/Icons/Stars_On.png);
        }
        .star_empty
        {
            background-image: url(../Images/Icons/Stars_Off.png);
        }
        .star_saved
        {
            background-image: url(../Images/Icons/Stars_Saved.png);
        }
    </style>
    <table style="width: 100%;">
        <tr>
            <td class="TextTitle">
                Add Review Details
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td align="right" class="titlecell">
                            Review Recipients
                        </td>
                        <td align="left" valign="middle">
                            <asp:Label ID="lblUsers" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="titlecell">
                            Rating
                        </td>
                        <td align="left" valign="middle">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <cc1:Rating ID="Rating1" runat="server" StarCssClass="star_rating" WaitingStarCssClass="star_saved"
                                        FilledStarCssClass="star_filled" EmptyStarCssClass="star_empty" OnChanged="Rating1_Changed"
                                        AutoPostBack="true" Tag="10" CurrentRating="2" MaxRating="5">
                                    </cc1:Rating>
                                    <asp:Label ID="lblRating" runat="server" Text="3" Visible="False"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="titlecell">
                            Review Comment
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtReviewComment" runat="server" CssClass="TextBox" Height="100px"
                                TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" CssClass="ButtonLightBlue" Text="Submit" />&nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="ButtonLightBlue" Text="Cancel" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
