Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Data

''' <summary>
''' Handels the qualification operations
''' </summary>
Public Class cQualification
    Inherits cJob


#Region "Private Attributes"

    Private pQualificationID As Integer
    Private pQualification As String
    Private pAwardedDate As String
    Private pAwardingBody As String
    Private pEmployeeID As Integer

#End Region

#Region "Public Attributes"


    Public ReadOnly Property QualificationID() As Integer
        Get
            Return pQualificationID
        End Get
    End Property

    Public ReadOnly Property Qualification() As String
        Get
            Return pQualification
        End Get
    End Property


    Public ReadOnly Property AwardedDate() As Date
        Get
            Return pAwardedDate
        End Get
    End Property


    Public ReadOnly Property AwardingBody() As String
        Get
            Return pAwardingBody
        End Get
    End Property

    Public ReadOnly Property EmployeeID() As Integer
        Get
            Return pEmployeeID
        End Get
    End Property


#End Region

    Public Sub New(ByVal datatable As Data.DataTable)
        ParseDataTableDetailsQualification(datatable)
    End Sub

    Public Sub New()
        'default constructor
    End Sub

    ''' <summary>
    ''' Saves the qualification.
    ''' </summary>
    ''' <param name="Qualification">The qualification.</param>
    ''' <param name="DateAwarded">The date awarded.</param>
    ''' <param name="AwardingBody">The awarding body.</param>
    ''' <param name="EmployeeID">The employee ID.</param>
    Public Sub saveQualification(ByVal Qualification As String, ByVal DateAwarded As Date, ByVal AwardingBody As String, ByVal EmployeeID As Integer)
        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("INSERT INTO tblQualification " & _
                             "VALUES ('{0}','{1}','{2}','{3}')", Qualification, DateAwarded, AwardingBody, EmployeeID)))
            cLogging.AddLog("Successfully Saved Qualification", Nothing, cLogging.LogType.INFORMATION_LOG, Nothing, EmployeeID, Nothing, Nothing)
        Catch ex As Exception
            cLogging.AddLog("saveQualification: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Updates the qualification.
    ''' </summary>
    ''' <param name="Qualification">The qualification.</param>
    ''' <param name="DateAwarded">The date awarded.</param>
    ''' <param name="AwardingBody">The awarding body.</param>
    ''' <param name="QualificationID">The qualification ID.</param>
    Public Sub updateQualification(ByVal Qualification As String, ByVal DateAwarded As Date, ByVal AwardingBody As String, ByVal QualificationID As Integer)
        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("UPDATE tblQualification " & _
                             "SET Qualification = '{0}', DateAwarded  = '{1}', AwardingBody = '{2}' " & _
                             "WHERE QualificationID = '{3}'", Qualification, DateAwarded, AwardingBody, QualificationID)))
        Catch ex As Exception
            cLogging.AddLog("updateQualification: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Deletes the qualification.
    ''' </summary>
    ''' <param name="QualificationID">The qualification ID.</param>
    Public Shared Sub deleteQualification(ByVal QualificationID As Integer)
        Try
            cDBManager.ExecuteNonQuery(New SqlCommand(String.Format("DELETE FROM tblQualification WHERE QualificationID = '{0}'", QualificationID)))
        Catch ex As Exception
            cLogging.AddLog("deleteQualification: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Parses the data table details with the follwing fields: QualificationID, Qualification, AwardedDate, AwardingBody, EmployeeID.
    ''' </summary>
    ''' <param name="dataTable">The data table.</param>
    Public Sub ParseDataTableDetailsQualification(ByVal dataTable As Data.DataTable)
        Try
            pQualificationID = dataTable.Rows(0).Item("QualificationID")
            pQualification = dataTable.Rows(0).Item("Qualification")
            pAwardedDate = dataTable.Rows(0).Item("AwardedDate")
            pAwardingBody = dataTable.Rows(0).Item("AwardingBody")
            pEmployeeID = dataTable.Rows(0).Item("EmployeeID")
        Catch ex As Exception
            cLogging.AddLog("ParseDataTableDetailsQualification: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Gets the qualifications by ID.
    ''' </summary>
    ''' <param name="QualiID">The quali ID.</param>
    ''' <returns></returns>
    Public Shared Function getQualificationsByID(ByVal QualiID As Integer) As DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand(String.Format("SELECT * FROM tblQualification WHERE QualificationID ='{0}'", QualiID)))
        Catch ex As Exception
            cLogging.AddLog("getQualificationsByID: " & ex.Message, Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
