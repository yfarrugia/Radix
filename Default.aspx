<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default"  StyleSheetTheme="" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table style="width:98%;" class="Text" align="center" cellpadding="5">
            <tr>
                <td align="right">
                    <table style="width:100%;" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="7">
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/TitleIcon.png" />
                            </td>
                            <td align="left" class="TextTitle">
                    Our Philosophy&nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                </td>
                <td align="right">
                    <table style="width:100%;" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="7">
                    <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/TitleIcon.png" />
                            </td>
                            <td align="left" class="TextTitle">
                    Our Centers</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td rowspan="5" align="justify" class="Text" valign="top" style="width:60%;">
                    Radix is a system based on the 8th UN Millennium development Goal which is; 
                    <p style="text-align:center;">
                    ‘Developing a global partnership for development’ 
                    </p>
                    <p>
                    Our integrated web based 
                    software will be helping global partnership through the least privileged illegal 
                    immigrants who are in search of a better future. This is achieved through an 
                    easy to use website where people from all over the world could easily interact, 
                    showing initiative to use their skills and capabilities in other countries. We 
                    would like to offer them genuine workplaces which would act as stepping stone 
                    for a better future. 
                    </p>
                    <p>
                    In the future we would like to take this project a step 
                    further by implementing a translator which would facilitate the registration and 
                    usage of this system. Also we would like to implement a Business Intelligent 
                    Reporting system which would easily and clearly indicate statistics to NGOS and 
                    organizations managing this project on a global basis.
                    </p>
                    <p>
                        <br />
                        <i>The Radix Team</i>
                    </p>
                    <td align="justify" class="Text" valign="top">
                    Our integrated web based 
                    software will be helping global partnership through the least privileged illegal 
                    immigrants who are in search of a better future. This is achieved through an 
                    easy to use website where people from all over the world could easily interact, 
                    showing initiative to use their skills and capabilities in other countries. We 
                    would like to offer them genuine workplaces which would act as stepping stone 
                    for a better future. 
                    </td>
            </tr>
            <tr>
                    <td align="right" valign="top">
                        <asp:LinkButton ID="lnkFindCenter" runat="server" CssClass="Link" 
                            PostBackUrl="~/FindCenters.aspx">Find Centers</asp:LinkButton>
                    </td>
            </tr>
            <tr>
                <td align="right">
                    <table style="width:100%;" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="7">
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/TitleIcon.png" />
                            </td>
                            <td align="left" class="TextTitle">
                                Statistics
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/Graph.png" />
                    </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    <asp:LinkButton ID="lnkStats" runat="server" CssClass="Link" 
                        PostBackUrl="~/Anonymous/Statistics.aspx">Click here for more statistics...</asp:LinkButton>
                    </td>
            </tr>
        </table>
</asp:Content>

