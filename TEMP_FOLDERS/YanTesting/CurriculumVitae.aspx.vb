Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.Web
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine


Partial Class AllRegisteredUsers_CurriculumVitae
    Inherits System.Web.UI.Page

    Public ReportDocument As ReportDocument
    Public ReportTitle As String
    Public ReportFilename As String

    Private _EmployeeID As Integer

    Private Property EmployeeID() As Integer
        Get
            Return _EmployeeID
        End Get
        Set(ByVal value As Integer)
            _EmployeeID = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        CrystalReportViewer1.Visible = True
        Dim pServerName As String
        Dim pDbName As String
        Dim pUserid As String
        Dim pPwd As String

        pServerName = "radixsystemdb.db.4677447.hostedresource.com"
        pDbName = "radixsystemdb"
        pUserid = "radixsystemdb"
        pPwd = "R4d1x2009"

        Session("SelectedUserID") = 8

       


        Dim crTable As Table
        Dim crTables As Tables

        Dim crTabLogonInfo As TableLogOnInfo

        '/*** Information provider for connection with the Database ***/
        Dim crConnectionInfo As New ConnectionInfo()

        Dim intCnt As Integer

        crConnectionInfo.ServerName = pServerName
        crConnectionInfo.DatabaseName = pDbName
        crConnectionInfo.UserID = pUserid
        crConnectionInfo.Password = pPwd


        '/*** To get the Database object ***/
        Dim Filepath As String
        Filepath = Server.MapPath("CrystalReport.rpt")
        ReportDocument = New ReportDocument()

        ReportDocument.Load(Filepath, OpenReportMethod.OpenReportByDefault)
        ReportDocument.SetParameterValue("UserID", Request.QueryString("UserID"))

        crTables = ReportDocument.Database.Tables

        For intCnt = 0 To crTables.Count - 1
            crTable = crTables.Item(intCnt)
            crTabLogonInfo = crTable.LogOnInfo
            crTabLogonInfo.ConnectionInfo = crConnectionInfo
            crTable.ApplyLogOnInfo(crTabLogonInfo)
        Next

        CrystalReportViewer1.ReportSource = ReportDocument

        CrystalReportViewer1.ToolbarStyle.CssClass = "SitePathBackground"


    End Sub

End Class
