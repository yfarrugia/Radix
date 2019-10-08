Imports System.Xml
Imports Microsoft.VisualBasic

''' <summary>
''' Return the following information of the given IP.
''' Ip, Status, CountryCode , CountryName, RegionCode, RegionName, City, ZipPostalCode, Latitude, Longitude, Gmtoffset, Dstoffset, 
''' </summary>
''' <remarks>You can get the remote client ip by using the following syntax: 
''' Request.ServerVariables("REMOTE_ADDR")</remarks>
Public Class cIpDetails
    Private _Ip, _
        _CountryCode, _
        _CountryName, _
        _RegionName, _
        _City, _
        _ZipPostalCode, _
        _Latitude, _
        _Longitude, _
        _Gmtoffset, _
        _Dstoffset, _
        _RegionCode _
    As String


    Public ReadOnly Property getIP() As String
        Get
            Return _Ip
        End Get
    End Property

    Public ReadOnly Property getCountryCode() As String
        Get
            Return _CountryCode
        End Get
    End Property

    Public ReadOnly Property getCountryName() As String
        Get
            Return _CountryName
        End Get
    End Property

    Public ReadOnly Property getRegionName() As String
        Get
            Return _RegionName
        End Get
    End Property

    Public ReadOnly Property getCity() As String
        Get
            Return _City
        End Get
    End Property

    Public ReadOnly Property getZipPostalCode() As String
        Get
            Return _ZipPostalCode
        End Get
    End Property

    Public ReadOnly Property getRegionCode() As String
        Get
            Return _RegionCode
        End Get
    End Property

    Public ReadOnly Property getLatitude() As String
        Get
            Return _Latitude
        End Get
    End Property

    Public ReadOnly Property getLongitude() As String
        Get
            Return _Longitude
        End Get
    End Property

    Public ReadOnly Property getGmtoffset() As String
        Get
            Return _Gmtoffset
        End Get
    End Property

    Public ReadOnly Property getDstoffset() As String
        Get
            Return _Dstoffset

        End Get
    End Property

    Public Sub New(ByVal ip As String)
        Me._Ip = ip
        Parse(_Ip)
    End Sub


    'Ip - String
    'Status - String
    'CountryCode - String
    'CountryName - String
    'RegionCode - Int32
    'RegionName - String
    'City - String
    'ZipPostalCode - String
    'Latitude - string
    'Longitude - string
    'Gmtoffset - string
    'Dstoffset - string

    ''' <summary>
    ''' Parse the given IP through an API
    ''' </summary>
    ''' <param name="ip">IP to be passed</param>
    ''' <remarks>API used - http://ipinfodb.com/</remarks>
    Private Sub Parse(ByVal ip As String)
        Try
            Dim xRead As New XmlTextReader("http://ipinfodb.com/ip_query.php?ip=" & ip)
            Do While xRead.Read = True
                If xRead.IsStartElement = True Then
                    If xRead.Name = "CountryCode" Then
                        _CountryCode = xRead.ReadString()
                    End If
                    If xRead.Name = "CountryName" Then
                        _CountryName = xRead.ReadString()
                    End If
                    If xRead.Name = "RegionCode" Then
                        _RegionCode = xRead.ReadString()
                    End If
                    If xRead.Name = "RegionName" Then
                        _RegionName = xRead.ReadString()
                    End If
                    If xRead.Name = "City" Then
                        _City = xRead.ReadString()
                    End If
                    If xRead.Name = "ZipPostalCode" Then
                        _ZipPostalCode = xRead.ReadString()
                    End If
                    If xRead.Name = "Latitude" Then
                        _Latitude = xRead.ReadString()
                    End If
                    If xRead.Name = "Longitude" Then
                        _Longitude = xRead.ReadString()
                    End If
                    If xRead.Name = "Gmtoffset" Then
                        _Gmtoffset = xRead.ReadString()
                    End If
                    If xRead.Name = "Dstoffset" Then
                        _Dstoffset = xRead.ReadString()
                    End If
                End If
            Loop
        Catch ex As Exception
            cLogging.AddLog(String.Format("cIpDetails.Parse: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Returns a string representation of the Parsed IP object.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        With sb
            .Append(<b>IP: </b>)
            .Append(_Ip)
            .Append(<br/>)

            .Append(<b> CountryCode: </b>)
            .AppendLine(_CountryCode)
            .Append(<br/>)

            .Append(<b> CountryName: </b>)
            .AppendLine(_CountryName)
            .Append(<br/>)

            .Append(<b> RegionCode: </b>)
            .AppendLine(_RegionCode)
            .Append(<br/>)

            .Append(<b> RegionName: </b>)
            .AppendLine(_RegionName)
            .Append(<br/>)

            .Append(<b> City: </b>)
            .AppendLine(_City)
            .Append(<br/>)

            .Append(<b> ZipPostalCode: </b>)
            .AppendLine(_ZipPostalCode)
            .Append(<br/>)

            .Append(<b> Latitude: </b>)
            .AppendLine(_Latitude)
            .Append(<br/>)

            .Append(<b> Longitude: </b>)
            .AppendLine(_Longitude)
            .Append(<br/>)

            .Append(<b> Gmtoffset: </b>)
            .AppendLine(_Gmtoffset)
            .Append(<br/>)

            .Append(<b> Dstoffset: </b>)
            .AppendLine(_Dstoffset)
            .Append(<br/>)

        End With
        Return sb.ToString
    End Function
End Class