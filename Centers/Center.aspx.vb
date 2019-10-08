
Partial Class Centers_Default
    Inherits System.Web.UI.Page

    Dim gpCenterPoint As New GooglePoint
    Dim gpBrowserPoint As New GooglePoint
    Dim colour As New System.Drawing.ColorConverter

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Init_GMap()
            Init_Content()
            Init_PageStyle()
        End If

    End Sub

    Private Sub Init_GMap()

        With GoogleMapCenter.GoogleMapObject
            .APIKey = "ABQIAAAASxtC6aF3X8Yduz285l4ARRTlVViOkHY_dKOjlNl-N3o0umkYTxSEF7047wST9i1Xzh4CBoq-vGTuKg"
            .Width = "260px"
            .Height = "400px"
            .ZoomLevel = 14
            .CenterPoint = New GooglePoint("CenterPoint", 43.66619, -79.44268)
            .APIVersion = "2"
        End With

        CenterPushPin()
        UserPushPin()

    End Sub

    Private Sub CenterPushPin()

        With gpCenterPoint
            .ID = "CenterPoint"
            .Latitude = 43.65669
            .Longitude = -79.4327

            '.IconImage = "../Images/CenterBlue.png"
            .InfoHTML = lblCenterName.Text
        End With

        gpCenterPoint.IconImage = "/Images/CenterBlue.png"

        GoogleMapCenter.GoogleMapObject.Points.Add(gpCenterPoint)
    End Sub

    Private Sub UserPushPin()
        With gpBrowserPoint
            .ID = "UserPoint"
            .Latitude = 42.65669
            .Longitude = -78.4327

            .IconImage = "Images/YouAreHere.gif"
            .InfoHTML = "You are here."
        End With

        GoogleMapCenter.GoogleMapObject.Points.Add(gpBrowserPoint)
    End Sub

    Private Sub Init_Content()

        lblCenterRights.Text = "Berlin Center"

        With lblCenterName
            .Text = "Berlin Center"
            .Font.Size = 26
            .ForeColor = colour.ConvertFromString("#" + "606a79")
            .Font.Bold = True
            .Font.Italic = False
            .Font.Underline = False
            .Font.Strikeout = False
            .Font.Name = "Verdana"
        End With

        With lblCenterSlogan
            .Text = "Let Us Help You Shine"
            .Font.Size = 13
            .ForeColor = colour.ConvertFromString("#" + "FFFFFF")
            .Font.Bold = False
            .Font.Italic = True
            .Font.Underline = False
            .Font.Strikeout = False
            .Font.Name = "Verdana"
        End With

        With lblMarquee
            .Text = "Welcome to the " + "Center Name" + " Radix Systems Website."
            .Font.Size = 9
            .ForeColor = colour.ConvertFromString("#" + "959595")
            .Font.Bold = False
            .Font.Italic = False
            .Font.Underline = False
            .Font.Strikeout = False
            .Font.Name = "Verdana"
        End With

        With lblLeftTitle1
            .Text = "Left Title 1"
            .Font.Size = 9
            .ForeColor = colour.ConvertFromString("#" + "FFFFFF")
            .Font.Bold = True
            .Font.Italic = False
            .Font.Underline = False
            .Font.Strikeout = False
            .Font.Name = "Verdana"
        End With

        With lblLeftTitle2
            .Text = "Left Title 1"
            .Font.Size = 9
            .ForeColor = colour.ConvertFromString("#" + "FFFFFF")
            .Font.Bold = True
            .Font.Italic = False
            .Font.Underline = False
            .Font.Strikeout = False
            .Font.Name = "Verdana"
        End With

        With lblRightTitle1
            .Text = "Left Title 1"
            .Font.Size = 9
            .ForeColor = colour.ConvertFromString("#" + "FFFFFF")
            .Font.Bold = True
            .Font.Italic = False
            .Font.Underline = False
            .Font.Strikeout = False
            .Font.Name = "Verdana"
        End With

        With lblRightTitle2
            .Text = "Where Are We?"
            .Font.Size = 9
            .ForeColor = colour.ConvertFromString("#" + "FFFFFF")
            .Font.Bold = True
            .Font.Italic = False
            .Font.Underline = False
            .Font.Strikeout = False
            .Font.Name = "Verdana"
        End With

        With lblLeftContent1
            .Text = "asdasd"
            .Font.Size = 8
            .ForeColor = colour.ConvertFromString("#" + "FFFFFF")
            .Font.Bold = False
            .Font.Italic = False
            .Font.Underline = False
            .Font.Strikeout = False
            .Font.Name = "Verdana"
        End With

    End Sub

    Private Sub Init_PageStyle()

        BodyControl.Attributes.Add("bgcolor", "#" + "FFFFFF")

        pnlMain.BackColor = colour.ConvertFromString("#" + "606a79")

        With pnlMain_RoundedCornersExtender
            .BorderColor = colour.ConvertFromString("#" + "414d61")
            .Color = colour.ConvertFromString("#" + "606a79")
            .Corners = AjaxControlToolkit.BoxCorners.All
            .Radius = 5
        End With

        LeftContentTitlePanel1.BackColor = colour.ConvertFromString("#" + "2c3748")
        LeftContentTitlePanel2.BackColor = colour.ConvertFromString("#" + "2c3748")

        With LeftContentTitlePanel1_RoundedCornersExtender
            .BorderColor = colour.ConvertFromString("#" + "414d61")
            .Corners = AjaxControlToolkit.BoxCorners.All
            .Radius = 5
        End With

        With LeftContentTitlePanel2_RoundedCornersExtender
            .BorderColor = colour.ConvertFromString("#" + "414d61")
            .Corners = AjaxControlToolkit.BoxCorners.All
            .Radius = 5
        End With

    End Sub

End Class
