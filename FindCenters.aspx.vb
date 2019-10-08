Imports System.Data

Partial Class AllUsers_FindCenters
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Init_GMap()
            Init_CenterPushpins()
        End If
    End Sub

    Private Sub Init_GMap()


        With CentersGoogleMap.GoogleMapObject
            '.APIKey = "ABQIAAAALdOOMuN2gxWEYvn2N6Y6ahTlVViOkHY_dKOjlNl-N3o0umkYTxSP0TL_BYXArjdNVvKXgUlb2ihUow"
            .APIKey = "ABQIAAAASxtC6aF3X8Yduz285l4ARRTlVViOkHY_dKOjlNl-N3o0umkYTxSEF7047wST9i1Xzh4CBoq-vGTuKg"
            .Width = "100%"
            .Height = "450px"
            .ZoomLevel = 1.5
            .MapType = GoogleMapType.SATELLITE_MAP

            '.CenterPoint = New GooglePoint("CenterPoint", 30.0, 0.0)
            '.CenterPoint = New GooglePoint("CenterPoint", 43.66619, -79.44268)
            .APIVersion = "2"
        End With

    End Sub

    Private Sub Init_CenterPushpins()
        Dim dtCenters As DataTable = cCenter.GetAllCenterLatLong()
        Dim dr As DataRow

        For Each dr In dtCenters.Rows
            Dim gpCenterPoint As New GooglePoint

            With gpCenterPoint
                .ID = dr("CenterName")
                .Latitude = dr("Latitude")
                .Longitude = dr("Longitude")
                .IconImage = PushPinIcon(dr("Latitude"), dr("Longitude"))

                Dim url As String = "http://radix-systems.net/Centers/Center.aspx"

                .InfoHTML = dr("CenterName") & "<p/>" & "<a href=" & url & " target=""_blank"">Visit Website</a>" & "<p/>" & dr("Country")
            End With
            CentersGoogleMap.GoogleMapObject.Points.Add(gpCenterPoint)
        Next
       
        CentersGoogleMap.GoogleMapObject.CenterPoint.Latitude = 30.0
        CentersGoogleMap.GoogleMapObject.CenterPoint.Longitude = 0.0

    End Sub

    Public Function NoWhiteSpace(ByVal strText As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(strText, " ", _
        "%20", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function

    Private Function PushPinIcon(ByVal Lat As Double, ByVal Lon As Double) As String

        If (Lat > 10.0) And (Lon < -20.0) Then
            'North America
            Return "Centers/Images/CenterGrey.png"
        ElseIf (Lat < 10.0) And (Lon < -20.0) Then
            'South America
            Return "Centers/Images/CenterGreen.png"
        ElseIf (Lat > 35.0) And (Lon > -20.0 And Lon < 50.0) Then
            'Europe
            Return "Centers/Images/CenterBlue.png"
        ElseIf (Lat < 35.0) And (Lon > -20.0 And Lon < 60.0) Then
            'Africa
            Return "Centers/Images/CenterOrange.png"
        ElseIf (Lat > 35.0) And (Lon > 50.0) Then
            'USSR
            Return "Centers/Images/CenterRed.png"
        ElseIf (Lat < 35.0) And (Lon > 60.0) Then
            'Australia/New Zealand etc
            Return "Centers/Images/CenterYellow.png"
        Else
            Return "Centers/Images/CenterBlue.png"
        End If



        Return "abc"
    End Function

End Class
