<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Star.aspx.vb" Inherits="LukeTestingFolder_Star" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../Styles.css" rel="stylesheet" type="text/css" />
    <title>Untitled Page</title>
    
    <style type="text/css">
    
    .star_rating {
    font-size: 0pt;
    width: 13px;
    height: 12px;
    margin: 0px;
    padding: 0px;
    cursor: pointer;
    display: block;
    background-repeat: no-repeat;
    }

    .star_filled {
    background-image: url(../Images/Icons/Stars_On.png);

    }

    .star_empty {
    background-image: url(../Images/Icons/Stars_Off.png);
    }

    .star_saved {
    background-image: url(../Images/Icons/Stars_Saved.png);
    }
        .style1
        {
            height: 32px;
        }
    </style>
</head>
<body>
    <p>
        <br />
    </p>
    <form id="form1" runat="server">
    <p>
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    
                    
                    
                </td>
                <td>
                
                
                
                   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<contenttemplate>
<ajaxToolkit:Rating
    ID="Rating1"
    runat="server"
    StarCssClass="star_rating"
    WaitingStarCssClass="star_saved"
    FilledStarCssClass="star_filled"
    EmptyStarCssClass="star_empty"
    OnChanged="Rating1_Changed"
    AutoPostBack="true"
    Tag="10"
    CurrentRating="2"
    MaxRating="5">
</ajaxToolkit:Rating>

<br />

<asp:Label ID="Label1" runat="server" Font-Size="16px"></asp:Label>
</contenttemplate>
</asp:UpdatePanel>--%></td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td class="style1">
                    
                    
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
                    <cc1:Rating ID="Rating1"
                        runat="server"
                        StarCssClass="star_rating"
                        WaitingStarCssClass="star_saved"
                        FilledStarCssClass="star_filled"
                        EmptyStarCssClass="star_empty"
                        OnChanged="Rating1_Changed"
                        AutoPostBack="true"
                        Tag="10"
                        CurrentRating="2"
                        MaxRating="5">
                    </cc1:Rating>
                    
                           &nbsp;
                    
                           <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        <br />
                        
                        
                                            
                    <br />
                    <cc1:Rating ID="Rating2" 
                    runat="server"
                        StarCssClass="star_rating"
                        WaitingStarCssClass="star_saved"
                        FilledStarCssClass="star_filled"
                        EmptyStarCssClass="star_empty"
                        OnChanged="Rating1_Changed"
                        AutoPostBack="true"
                        Tag="10"
                        CurrentRating="2"
                        MaxRating="5"
                    ReadOnly="True">
                    </cc1:Rating>
                    <br />
                        
                    </contenttemplate>
                    
              
                    
                    </asp:UpdatePanel>
                    
                    
                    
                </td>
                <td class="style1">
                
                
                
                    </td>
                <td class="style1">
                    </td>
            </tr>
            
            <tr>
                <td>
                    
                    
                   
                    
                    

                    
                    
                   
                    
                    
                    
                </td>
                <td>
                
                
                
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
        </table>
    </p>
    </form>
</body>
</html>
