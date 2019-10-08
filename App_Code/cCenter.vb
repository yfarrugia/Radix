Imports Microsoft.VisualBasic
Imports System.Diagnostics
Imports System.Data.SqlClient
Imports System.Data

Public Class cCenter

    'Private _centerID As Integer
    Private _centerName As String
    Private _address As String
    Private _streetAddress As String
    Private _town As String
    Private _state As String
    Private _countryID As Integer
    Private _postCode As String
    Private _telephoneNo As String
    Private _emailAddress As String
    Private _latitude As Double
    Private _longitude As Double
    Private _stamp As Date = Now

#Region "Getters - Setters"
    Public Property centerName() As String
        Get
            Return _centerName

        End Get
        Set(ByVal value As String)
            _centerName = value
        End Set
    End Property

    Public Property address() As String
        Get
            Return _address

        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property

    Public Property streetAddress() As String
        Get
            Return _streetAddress

        End Get
        Set(ByVal value As String)
            _streetAddress = value
        End Set
    End Property

    Public Property town() As String
        Get
            Return _town

        End Get
        Set(ByVal value As String)
            _town = value
        End Set
    End Property

    Public Property state() As String
        Get
            Return _state

        End Get
        Set(ByVal value As String)
            _state = value
        End Set
    End Property

    Public Property countryID() As Integer
        Get
            Return _countryID

        End Get
        Set(ByVal value As Integer)
            _countryID = value
        End Set
    End Property

    Public Property postCode() As String
        Get
            Return _postCode
        End Get
        Set(ByVal value As String)
            _postCode = value
        End Set
    End Property

    Public Property telephoneNo() As String
        Get
            Return _telephoneNo
        End Get
        Set(ByVal value As String)
            _telephoneNo = value
        End Set
    End Property

    Public Property emailAddress() As String
        Get
            Return _emailAddress
        End Get
        Set(ByVal value As String)
            _emailAddress = value
        End Set
    End Property

    Public Property latitude() As Integer
        Get
            Return _latitude
        End Get
        Set(ByVal value As Integer)
            _latitude = value
        End Set
    End Property

    Public Property longitude() As Integer
        Get
            Return _longitude
        End Get
        Set(ByVal value As Integer)
            _longitude = value
        End Set
    End Property

    Public Property stamp() As Date
        Get
            Return _stamp
        End Get
        Set(ByVal value As Date)
            _stamp = value
        End Set
    End Property
#End Region

    ''' <summary>
    ''' Gets the center by user ID.
    ''' </summary>
    ''' <param name="CenterUserId">The center user id.</param>
    ''' <returns></returns>
    Public Shared Function getCenterByUserID(ByVal CenterUserId As Integer) As Integer
        Try
            Return Convert.ToInt32(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT CenterID FROM tblCenterAdmin WHERE CenterAdminID='{0}'", CenterUserId))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCenter.getCenterByUserID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets all center lat long.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetAllCenterLatLong() As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT tblCenter.Latitude, tblCenter.Longitude, tblCenter.CenterName, tblCountry.Country " & _
                                "FROM tblCenter INNER JOIN " & _
                                "tblCountry ON tblCenter.CountryID = tblCountry.CountryID"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCenter.GetAllCenterLatLong: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the center name by id.
    ''' </summary>
    ''' <param name="SelectedCountryID">The selected country ID.</param>
    ''' <returns></returns>
    Public Shared Function GetCenterNameById(ByVal SelectedCountryID As Integer) As String
        Try
            Return cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT CenterName FROM tblCenter WHERE CountryID = {0}", SelectedCountryID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCenter.GetCenterNameById: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the center location by id.
    ''' </summary>
    ''' <param name="SelectedCountryID">The selected country ID.</param>
    ''' <returns></returns>
    Public Shared Function GetCenterLocationById(ByVal SelectedCountryID As Integer) As String
        Try
            Return cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT tblCenter.Town + ' ' + tblCountry.Country  AS Location " & _
                                "FROM tblCenter INNER JOIN tblCountry ON tblCenter.CountryID = tblCountry.CountryID WHERE tblCenter.CenterID = {0}", SelectedCountryID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCenter.GetCenterNameById: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the centers.
    ''' </summary>
    ''' <param name="SelectedCountryID">The selected country ID.</param>
    ''' <returns></returns>
    Public Shared Function GetCenters(ByVal SelectedCountryID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT CenterName, CenterID FROM tblCenter " & _
                                "WHERE CountryID = {0} " & _
                                "ORDER BY CenterName ASC", SelectedCountryID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCenter.GetCenters: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Checks the center exists.
    ''' </summary>
    ''' <param name="CenterName">Name of the center.</param>
    ''' <param name="CenterCountry">The center country.</param>
    ''' <returns></returns>
    Public Shared Function CheckCenterExists(ByVal CenterName As String, ByVal CenterCountry As Integer) As Boolean
        Try
            If cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT CenterID FROM tblCenter " & _
                                "WHERE CenterName = '{0}' AND CountryID = {1} ", CenterName, CenterCountry))).Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCenter.CheckCenterExists: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the details.
    ''' </summary>
    ''' <param name="id">The id.</param>
    ''' <returns></returns>
    Public Shared Function getDetails(ByVal id As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT CenterName, Address, StreetAddress, PostCode, " & _
                                "Town, State, CountryID, TelephoneNo, EmailAddress FROM tblCenter WHERE (CenterID = {0})", id)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCenter.getDetails: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Updates the edit detials.
    ''' </summary>
    ''' <param name="CenterID">The center ID.</param>
    ''' <param name="Address">The address.</param>
    ''' <param name="StreetAddress">The street address.</param>
    ''' <param name="PostCode">The post code.</param>
    ''' <param name="Town">The town.</param>
    ''' <param name="State">The state.</param>
    ''' <param name="CountryID">The country ID.</param>
    ''' <param name="TelephoneNo">The telephone no.</param>
    ''' <param name="EmailAddress">The email address.</param>
    Public Shared Sub updateEditDetials(ByVal CenterID As Integer, _
                                           ByVal Address As String, _
                                           ByVal StreetAddress As String, _
                                           ByVal PostCode As String, _
                                           ByVal Town As String, _
                                           ByVal State As String, _
                                           ByVal CountryID As Integer, _
                                           ByVal TelephoneNo As String, _
                                           ByVal EmailAddress As String)

        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblCenter SET Address = '{1}', StreetAddress = '{2}', Town = '{3}', State = '{4}', CountryID  = {5}, PostCode = '{6}', TelephoneNo = '{7}', EmailAddress = '{8}' WHERE CenterID = {0}", 4, Address, StreetAddress, Town, State, CountryID, PostCode, TelephoneNo, EmailAddress)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCenter.updateEditDetials: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub
End Class