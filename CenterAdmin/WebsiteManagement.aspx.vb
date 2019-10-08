
Partial Class CenterAdmin_WebsiteManagement
    Inherits System.Web.UI.Page

    Dim Color As New System.Drawing.ColorConverter
    Dim BannerUrl As String = "../Centers/Images/Banners/"
    Dim BannerSelected As String
    Dim LogoUrl As String = "../Centers/Images/Logos/"
    Dim LogoSelected As String

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        'initialize global variables of selected banner and selected logo.

        If Not Page.IsPostBack Then
            BannerSelected = "Banner1.png"
            LogoSelected = "Logo1.png"

            lblSlogan.Text = "Rise above the rest!"

            lblMarquee.Text = "This is the moving text."
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            InitPresets()
            TabContainerWebpageManagement.ActiveTabIndex = 0
            CheckForRedirect()
        End If
    End Sub

    Private Sub InitPresets()
        'pnlPreviewPanel_RoundedCornersExtender.Corners.

        'DISPLAY TABS
        mvContent.SetActiveView(vTopLeft)
        mvHeader.SetActiveView(vChangeBanner)
        mvAppearance.SetActiveView(vContentStyles)


        imgBanner.ImageUrl = BannerUrl + BannerSelected
        imgCenterLogo.ImageUrl = LogoUrl + LogoSelected

        lblSlogan.Font.Size = 20

        lblCenterName.Text = "Balzan Center"
        lblCenterName.Font.Size = 40
        lblCenterName.Font.Name = "Comic Sans Serif"

        ''''Styles Tab Init
        'Center Name
        lblFontSizeCenter.Text = 30
        lblCenterNamePreview.Text = lblCenterName.Text
        lblCenterNamePreview.Font.Size = lblFontSizeCenter.Text
        lblCenterNamePreview.Font.Name = lblCenterName.Font.Name
        ddlFontsCenterName.Items.Add(lblCenterNamePreview.Font.Name)
        ddlFontsCenterName.SelectedValue = lblCenterNamePreview.Font.Name

        'Center Slogan
        lblFontSizeSlogan.Text = 20
        lblCenterSloganPreview.Text = lblSlogan.Text
        txtSlogan.Text = lblCenterSloganPreview.Text
        lblCenterSloganPreview.Font.Size = lblFontSizeSlogan.Text
        lblCenterSloganPreview.Font.Name = lblSlogan.Font.Name
        ddlFontsCenterSlogan.Items.Add(lblCenterSloganPreview.Font.Name)
        ddlFontsCenterSlogan.SelectedValue = lblCenterSloganPreview.Font.Name

        'Center Headline
        lblCenterHeadlines.Text = lblMarquee.Text
        Headline.Content = lblCenterHeadlines.Text
        lblFontSizeHeadline.Text = 14
        lblCenterHeadlines.Font.Size = lblFontSizeHeadline.Text

        ''''Content Tab Init
        'Top Left Panel
        txtTopLeftTitle.Text = ""
        HtmlTopLeftContent.Content = ""

        'Bottom Left Panel
        txtBottomLeftTitle.Text = ""
        HtmlBottomLeftContent.Content = ""

        'Top Right Panel
        txtTopLeftTitle.Text = ""
        HtmlTopLeftContent.Content = ""

        ''''General Appearance

        'Content Panel Styles
        SampleContentTitlePanel.BackColor = Drawing.Color.AliceBlue
        SampleContentTitlePanel_RoundedCornersExtender.Radius = 10
        SampleContentTitlePanel_RoundedCornersExtender.BorderColor = Drawing.Color.Chartreuse

        lblFontSizeContentPanel.Text = 11
        lblFontSizeContentTitle.Text = 11

        lblCornerRadiusContentPanel.Text = 10

        'Page Styles
        lblCornerRadiusMainPanel.Text = 5

    End Sub

    Protected Sub lnkBanner_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBanner.Click, lnkBanner2.Click
        mvHeader.SetActiveView(vChangeBanner)
    End Sub

    Protected Sub lnkLogo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogo.Click, lnkLogo2.Click
        mvHeader.SetActiveView(vCenterLogo)
    End Sub

    Protected Sub lnkStyle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkStyle.Click, lnkStyle2.Click
        mvHeader.SetActiveView(vStyles)
    End Sub

    Protected Sub imgbtnUp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnUp.Click
        lblFontSizeCenter.Text += 1
        lblCenterNamePreview.Font.Size = lblFontSizeCenter.Text
    End Sub

    Protected Sub imgbtnDown_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnDown.Click
        lblFontSizeCenter.Text -= 1
        lblCenterNamePreview.Font.Size = lblFontSizeCenter.Text
    End Sub

    Protected Sub txtForecolorCenter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtForecolorCenter.TextChanged
        lblCenterNamePreview.ForeColor = Color.ConvertFromString("#" + txtForecolorCenter.Text)
    End Sub

    Protected Sub chkBold_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBold.CheckedChanged
        lblCenterNamePreview.Font.Bold = Not (lblCenterNamePreview.Font.Bold)
    End Sub

    Protected Sub chkItalic_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkItalic.CheckedChanged
        lblCenterNamePreview.Font.Italic = Not (lblCenterNamePreview.Font.Italic)
    End Sub

    Protected Sub chkUnderline_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUnderline.CheckedChanged
        lblCenterNamePreview.Font.Underline = Not (lblCenterNamePreview.Font.Underline)
    End Sub

    Protected Sub chkStrikeout_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkStrikeout.CheckedChanged
        lblCenterNamePreview.Font.Strikeout = Not (lblCenterNamePreview.Font.Strikeout)
    End Sub

    Protected Sub imgbtnUp0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnUp0.Click
        lblFontSizeSlogan.Text += 1
        lblCenterSloganPreview.Font.Size = lblFontSizeSlogan.Text
    End Sub

    Protected Sub imgbtnDown0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnDown0.Click
        lblFontSizeSlogan.Text -= 1
        lblCenterSloganPreview.Font.Size = lblFontSizeSlogan.Text
    End Sub

    Protected Sub txtForecolorSlogan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtForecolorSlogan.TextChanged
        lblCenterSloganPreview.ForeColor = Color.ConvertFromString("#" + txtForecolorSlogan.Text)
    End Sub

    Protected Sub btnPreviewHtmlHeadline_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreviewHtmlHeadline.Click
        lblCenterHeadlines.Text = Headline.Content
    End Sub

    Protected Sub imgbtnDown1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnDown1.Click
        lblFontSizeHeadline.Text -= 1
        lblCenterHeadlines.Font.Size = lblFontSizeHeadline.Text
    End Sub

    Protected Sub imgbtnUp1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnUp1.Click
        lblFontSizeHeadline.Text += 1
        lblCenterHeadlines.Font.Size = lblFontSizeHeadline.Text
    End Sub

    Protected Sub btnUpdateHeader_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateHeader.Click
        If rdbA.Checked Then
            imgBanner.ImageUrl = BannerUrl + "Banner1.png"
        ElseIf rdbB.Checked Then
            imgBanner.ImageUrl = BannerUrl + "Banner2.png"
        ElseIf rdbC.Checked Then
            imgBanner.ImageUrl = BannerUrl + "Banner3.png"
        ElseIf rdbD.Checked Then
            imgBanner.ImageUrl = BannerUrl + "Banner4.png"
        ElseIf rdbE.Checked Then
            imgBanner.ImageUrl = BannerUrl + "Banner5.png"
        ElseIf rdbF.Checked Then
            imgBanner.ImageUrl = BannerUrl + "Banner6.png"
        End If
    End Sub

    Protected Sub btnApplyChanges_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApplyChanges.Click
        lblMarquee.Text = lblCenterHeadlines.Text
        lblMarquee.Font.Size = lblFontSizeHeadline.Text
    End Sub

    Protected Sub chkContactDetails_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkContactDetails.CheckedChanged
        If chkContactDetails.Checked Then
            txtTopRightTitle.Text = "Contact Us"
            HtmlTopRightContent.Content = "Our Contact Details"
        Else
            txtTopRightTitle.Text = ""
            HtmlTopRightContent.Content = ""
        End If
    End Sub

    Protected Sub lnkTopLeft_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTopLeft.Click
        mvContent.SetActiveView(vTopLeft)
    End Sub

    Protected Sub lnkBottomLeft_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBottomLeft.Click
        mvContent.SetActiveView(vBottomLeft)
    End Sub

    Protected Sub lnkTopRight_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkTopRight.Click
        mvContent.SetActiveView(vTopRight)
    End Sub

    Protected Sub lnkContentStyles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkContentStyles.Click
        mvAppearance.SetActiveView(vContentStyles)
    End Sub

    Protected Sub txtForecolorContentTitle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtForecolorContentTitle.TextChanged
        lblSampleTitle.ForeColor = Color.ConvertFromString("#" + txtForecolorContentTitle.Text)
    End Sub

    Protected Sub txtBackgroundContentTitle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBackgroundContentTitle.TextChanged
        SampleContentTitlePanel.BackColor = Color.ConvertFromString("#" + txtBackgroundContentTitle.Text)
    End Sub

    Protected Sub txtBorderContentTitle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBorderContentTitle.TextChanged
        SampleContentTitlePanel_RoundedCornersExtender.BorderColor = Color.ConvertFromString("#" + txtBorderContentTitle.Text)
    End Sub

    Protected Sub chkBoldContentTitle_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBoldContentTitle.CheckedChanged
        lblSampleTitle.Font.Bold = Not (lblSampleTitle.Font.Bold)
    End Sub

    Protected Sub chkItalicContentTitle_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkItalicContentTitle.CheckedChanged
        lblSampleTitle.Font.Italic = Not (lblSampleTitle.Font.Italic)
    End Sub

    Protected Sub chkUnderlineContentTitle_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkUnderlineContentTitle.CheckedChanged
        lblSampleTitle.Font.Underline = Not (lblSampleTitle.Font.Underline)
    End Sub

    Protected Sub chkStrikeoutContentTitle_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkStrikeoutContentTitle.CheckedChanged
        lblSampleTitle.Font.Strikeout = Not (lblSampleTitle.Font.Strikeout)
    End Sub

    Protected Sub imgbtnUp2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnUp2.Click
        lblFontSizeContentTitle.Text += 1
        lblSampleTitle.Font.Size = lblFontSizeContentTitle.Text
    End Sub

    Protected Sub imgbtnDown2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnDown2.Click
        lblFontSizeContentTitle.Text -= 1
        lblSampleTitle.Font.Size = lblFontSizeContentTitle.Text
    End Sub

    Protected Sub imgbtnUp5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnUp5.Click
        lblCornerRadiusContentPanel.Text += 1
        SampleContentTitlePanel_RoundedCornersExtender.Radius = lblCornerRadiusContentPanel.Text
    End Sub

    Protected Sub imgbtnDown5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnDown5.Click
        lblCornerRadiusContentPanel.Text -= 1
        SampleContentTitlePanel_RoundedCornersExtender.Radius = lblCornerRadiusContentPanel.Text
    End Sub

    Protected Sub imgbtnUp4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnUp4.Click
        lblFontSizeContentPanel.Text += 1
        lblSampleContent.Font.Size = lblFontSizeContentPanel.Text
    End Sub

    Protected Sub imgbtnDown4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnDown4.Click
        lblFontSizeContentPanel.Text -= 1
        lblSampleContent.Font.Size = lblFontSizeContentPanel.Text
    End Sub

    Protected Sub lnkPageColours_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPageColours.Click
        mvAppearance.SetActiveView(vPageStyles)
    End Sub

    Protected Sub txtBackgroundMainPanel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBackgroundMainPanel.TextChanged
        pnlPreviewPanel.BackColor = Color.ConvertFromString("#" + txtBackgroundMainPanel.Text)
    End Sub

    Protected Sub txtBorderMainPanel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBorderMainPanel.TextChanged
        pnlPreviewPanel_RoundedCornersExtender.BorderColor = Color.ConvertFromString("#" + txtBorderMainPanel.Text)
    End Sub

    Protected Sub txtPanelStripesMainPanel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPanelStripesMainPanel.TextChanged
        pnlPreviewPanel_RoundedCornersExtender.Color = Color.ConvertFromString("#" + txtPanelStripesMainPanel.Text)
    End Sub

    Protected Sub txtBackgroundPage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBackgroundPage.TextChanged
        tblSamplePage.BackColor = Color.ConvertFromString("#" + txtBackgroundPage.Text)
    End Sub

    Protected Sub chkRedirectUsers_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRedirectUsers.CheckedChanged
        CheckForRedirect()
    End Sub

    Private Sub CheckForRedirect()
        TabContainerWebpageManagement.Tabs.Item(1).Enabled = Not chkRedirectUsers.Checked
        TabContainerWebpageManagement.Tabs.Item(2).Enabled = Not chkRedirectUsers.Checked
        TabContainerWebpageManagement.Tabs.Item(3).Enabled = Not chkRedirectUsers.Checked

        txtCustomUrl.Enabled = chkRedirectUsers.Checked
        btnCustomUrlSubmit.Enabled = txtCustomUrl.Enabled
    End Sub

    Protected Sub btnUpdateLogo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateLogo.Click
        If rdbLogoA.Checked Then
            imgCenterLogo.ImageUrl = LogoUrl + "Logo1.png"
        ElseIf rdbLogoB.Checked Then
            imgCenterLogo.ImageUrl = LogoUrl + "Logo2.png"
        ElseIf rdbLogoC.Checked Then
            imgCenterLogo.ImageUrl = LogoUrl + "Logo3.png"
        End If
    End Sub
End Class
