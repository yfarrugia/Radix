Imports Microsoft.VisualBasic

Public Class cGeoCoder

#Region "Private Attributes"
    Private pLatitude As Double
    Private pLongitude As Double
#End Region

#Region "Public Attributes"
    Public ReadOnly Property Latitude() As Double
        Get
            Return pLatitude
        End Get
    End Property

    Public ReadOnly Property Longitude() As Double
        Get
            Return pLongitude
        End Get
    End Property
#End Region

    ''' <summary>
    ''' Initializes a new instance of the <see cref="cGeoCoder" /> class.
    ''' </summary>
    ''' <param name="StreetAddress">The street address.</param>
    ''' <param name="Town">The town.</param>
    ''' <param name="Country">The country.</param>
    Public Sub New(ByVal StreetAddress As String, ByVal Town As String, ByVal Country As String)
        Try
            Dim FullAddress As String = StreetAddress & ". " & Town & ". " & Country

            Dim sMapKey As String = "ABQIAAAASxtC6aF3X8Yduz285l4ARRTlVViOkHY_dKOjlNl-N3o0umkYTxSEF7047wST9i1Xzh4CBoq-vGTuKg" 'ConfigurationManager.AppSettings("googlemaps.subgurim.net")
            Dim gmap1 As New Subgurim.Controles.GMap

            Dim geocode As Subgurim.Controles.GeoCode = gmap1.getGeoCodeRequest(FullAddress, sMapKey)

            'geocode = gmap1.geoCodeRequest(FullAddress, sMapKey,
            pLatitude = geocode.Placemark.coordinates.lat
            pLongitude = geocode.Placemark.coordinates.lng
        Catch ex As Exception
            cLogging.AddLog(String.Format("cGeoCoder.StreetAddress: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub
End Class
