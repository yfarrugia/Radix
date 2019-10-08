Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class cCompany

#Region "Private Attributes"

    Private pCompanyID As Integer
    Private pCompanyName As String
    Private pAddress As String
    Private pStreetAddress As String
    Private pTown As String
    Private pState As String
    Private pCountryID As Integer
    Private pPostCode As String
    Private pTelephoneNo As String
    Private pEmail As String
    Private pVATNo As String
    Private pRegistrationNo As String
    Private pEmployerID As Integer

#End Region

#Region "Public Attributes"

    Public ReadOnly Property CompanyID() As Integer
        Get
            Return pCompanyID
        End Get
    End Property

    Public ReadOnly Property CompanyName() As String
        Get
            Return pCompanyName
        End Get
    End Property

    Public ReadOnly Property Address() As String
        Get
            Return pAddress
        End Get
    End Property

    Public ReadOnly Property StreetAddresss() As String
        Get
            Return pStreetAddress
        End Get
    End Property

    Public ReadOnly Property Town() As String
        Get
            Return pTown
        End Get
    End Property

    Public ReadOnly Property State() As String
        Get
            Return pState
        End Get
    End Property

    Public ReadOnly Property CountryID() As Integer
        Get
            Return pCountryID
        End Get
    End Property

    Public ReadOnly Property PostCode() As String
        Get
            Return pPostCode
        End Get
    End Property

    Public ReadOnly Property TelephoneNo() As String
        Get
            Return pTelephoneNo
        End Get
    End Property

    Public ReadOnly Property Email() As String
        Get
            Return pEmail
        End Get
    End Property

    Public ReadOnly Property VATNo() As String
        Get
            Return pVATNo
        End Get
    End Property

    Public ReadOnly Property RegistrationNo() As String
        Get
            Return pRegistrationNo
        End Get
    End Property

    Public ReadOnly Property EmployerID() As Integer
        Get
            Return pEmployerID
        End Get
    End Property

#End Region

    Public Sub New(ByVal CompanyName As String, _
                    ByVal Address As String, _
                    ByVal StreetAddress As String, _
                    ByVal Town As String, _
                    ByVal State As String, _
                    ByVal CountryID As Integer, _
                    ByVal PostCode As String, _
                    ByVal TelNo As String, _
                    ByVal Email As String, _
                    ByVal VatNo As String, _
                    ByVal RegNo As String, _
                    ByVal EmployerID As Integer)

        pCompanyName = CompanyName
        pAddress = Address
        pStreetAddress = StreetAddress
        pTown = Town
        pState = State
        pCountryID = CountryID
        pPostCode = PostCode
        pTelephoneNo = TelephoneNo
        pEmail = Email
        pVATNo = VatNo
        pRegistrationNo = RegNo
        pEmployerID = EmployerID

    End Sub

    Public Sub New(ByVal datatable As Data.DataTable)
        ParseDataTableDetails(datatable)
    End Sub

    Public Sub New()

    End Sub

    ''' <summary>
    ''' Parses the data table details with the following fields:
    ''' CompanyID, CompanyName, Address, StreetAddress, Town, State, CountryID, PostCode, TelephoneNo, 
    ''' EmailAddress, VATNo, RegistrationNo, EmployerID. 
    ''' </summary>
    ''' <param name="dataTable">The data table.</param>
    Public Sub ParseDataTableDetails(ByVal dataTable As Data.DataTable)
        Try
            pCompanyID = dataTable.Rows(0).Item("CompanyID")
            pCompanyName = dataTable.Rows(0).Item("CompanyName")
            pAddress = dataTable.Rows(0).Item("Address")
            pStreetAddress = dataTable.Rows(0).Item("StreetAddress")
            pTown = dataTable.Rows(0).Item("Town")
            pState = dataTable.Rows(0).Item("State")
            pCountryID = dataTable.Rows(0).Item("CountryID")
            pPostCode = dataTable.Rows(0).Item("PostCode")
            pTelephoneNo = dataTable.Rows(0).Item("TelephoneNo")
            pEmail = dataTable.Rows(0).Item("EmailAddress")
            pVATNo = dataTable.Rows(0).Item("VATNo")
            pRegistrationNo = dataTable.Rows(0).Item("RegistrationNo")
            pEmployerID = dataTable.Rows(0).Item("EmployerID")

        Catch ex As Exception
            cLogging.AddLog(String.Format("cCompany.ParseDataTableDetails: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' Updates the company.
    ''' </summary>
    ''' <param name="Address">The address.</param>
    ''' <param name="StreetAddress">The street address.</param>
    ''' <param name="Town">The town.</param>
    ''' <param name="State">The state.</param>
    ''' <param name="CountryID">The country ID.</param>
    ''' <param name="PostCode">The post code.</param>
    ''' <param name="TelephoneNo">The telephone no.</param>
    ''' <param name="EmailAddress">The email address.</param>
    ''' <param name="EmployerID">The employer ID.</param>
    ''' <param name="CompanyID">The company ID.</param>
    Public Sub updateCompany(ByVal Address As String, _
                             ByVal StreetAddress As String, _
                             ByVal Town As String, _
                             ByVal State As String, _
                             ByVal CountryID As Integer, _
                             ByVal PostCode As String, _
                             ByVal TelephoneNo As String, _
                             ByVal EmailAddress As String, _
                             ByVal EmployerID As Integer, _
                             ByVal CompanyID As Integer)

        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblCompany " & _
                                                                    "SET Address = '{0}', StreetAddress = '{1}', Town  = '{2}', State  = '{3}', " & _
                                                                    "CountryID  = '{4}', PostCode   = '{5}', TelephoneNo  = '" & _
                                                                    "{6}',EmailAddress ='{7}', EmployerID='{8}'" & _
                                                                    "WHERE CompanyID = '{9}'", _
                                                                    Address, StreetAddress, Town, State, CountryID, PostCode, TelephoneNo, _
                                                                    EmailAddress, EmployerID, CompanyID)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCompany.ParseDataTableDetails: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Gets the company by employer.
    ''' </summary>
    ''' <param name="Employer">The employer.</param>
    ''' <returns></returns>
    Public Shared Function getCompanyByEmployer(ByVal Employer As cUser) As String
        Try
            Return cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT CompanyName FROM tblCompany WHERE EmployerID = '{0}'", Employer.userId)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCompany.getCompanyByEmployer: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the company details by employer.
    ''' </summary>
    ''' <param name="EmployerId">The employer id.</param>
    ''' <returns></returns>
    Public Shared Function getCompanyDetailsByEmployer(ByVal EmployerId As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT tblCompany.CompanyName, tblCompany.Address, tblCompany.StreetAddress, " & _
                                                                    "tblCompany.Town, tblCompany.State, tblCountry.Country, tblCompany.PostCode, " & _
                                                                    "tblCompany.TelephoneNo, tblCompany.EmailAddress, tblCompany.VATNo, tblCompany.RegistrationNo " & _
                                                                    "FROM tblCompany " & _
                                                                    "INNER JOIN tblCountry ON tblCompany.CountryID = tblCountry.CountryID " & _
                                                                    "WHERE EmployerID = '{0}'", EmployerId)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCompany.getCompanyByEmployer: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the company ID.
    ''' </summary>
    ''' <param name="CompanyName">Name of the company.</param>
    ''' <param name="EmployerID">The employer ID.</param>
    ''' <returns></returns>
    Public Shared Function getCompanyID(ByVal CompanyName As String, ByVal EmployerID As Integer) As Integer
        Try
            Return Convert.ToInt64(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT CompanyID " & _
                                                                    "FROM tblCompany " & _
                                                                    "WHERE CompanyName = '{0}' AND EmployerID = '{1}'", CompanyName, EmployerID))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCompany.getCompanyID: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Verifies the company.
    ''' </summary>
    ''' <param name="CompanyName">Name of the company.</param>
    ''' <param name="VatNo">The vat no.</param>
    ''' <param name="RegNo">The reg no.</param>
    ''' <param name="Country">The country.</param>
    ''' <returns></returns>
    Public Shared Function VerifyCompany(ByVal CompanyName As String, ByVal VatNo As String, ByVal RegNo As String, ByVal Country As String) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT RegistrationNumber " & _
                                                                    "FROM tblCompanyRegistry WHERE CompanyName = '{0}' AND VATNumber = '{1}' " & _
                                                                    "AND RegistrationNumber = '{2}'", _
                                                                    CompanyName, VatNo, RegNo)))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCompany.VerifyCompany: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the connection string by country.
    ''' </summary>
    ''' <param name="Country">The country.</param>
    ''' <returns></returns>
    Private Shared Function GetConnectionStringByCountry(ByVal Country As String) As cDBManager.CONNECTION_STRINGS
        Try
            Select Case Country
                Case "Germany"
                    Return cDBManager.CONNECTION_STRINGS.GERMANY
                Case "Singapore"
                    Return cDBManager.CONNECTION_STRINGS.SINGAPORE
                Case "Canada"
                    Return cDBManager.CONNECTION_STRINGS.CANADA
                Case "India"
                    Return cDBManager.CONNECTION_STRINGS.INDIA
            End Select
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCompany.GetConnectionStringByCountry: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the employer for company.
    ''' </summary>
    ''' <param name="companyID">The company ID.</param>
    ''' <returns></returns>
    Public Shared Function GetEmployerForCompany(ByVal companyID As Integer) As Integer
        Try
            Return Convert.ToInt64(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT EmployerID FROM tblCompany WHERE CompanyID = {0}", companyID))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCompany.GetEmployerForCompany: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Gets the name of the company.
    ''' </summary>
    ''' <param name="CompanyID">The company ID.</param>
    ''' <returns></returns>
    Public Shared Function getCompanyName(ByVal CompanyID As Integer) As String
        Try
            Return Convert.ToString(cDBManager.GetExecuteScalar(New SqlCommand(String.Format("SELECT CompanyName FROM tblCompany WHERE CompanyID = {0}", CompanyID))))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cCompany.getCompanyByEmployer: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class