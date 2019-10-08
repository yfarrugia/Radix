Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.Web
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Partial Class Reports_OccupationsByIndustry
    Inherits System.Web.UI.Page

    Public ReportDocument As ReportDocument
    Public ReportTitle As String
    Public ReportFilename As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim pServerName As String
        Dim pDbName As String
        Dim pUserid As String
        Dim pPwd As String

        pServerName = "radixsystemdb.db.4677447.hostedresource.com"
        pDbName = "radixsystemdb"
        pUserid = "radixsystemdb"
        pPwd = "R4d1x2009"



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
        Filepath = Server.MapPath("crOccupationsGroupedByIndustry.rpt")
        ReportDocument = New ReportDocument()
        ReportDocument.Load(Filepath, OpenReportMethod.OpenReportByDefault)
        crTables = ReportDocument.Database.Tables

        For intCnt = 0 To crTables.Count - 1
            crTable = crTables.Item(intCnt)
            crTabLogonInfo = crTable.LogOnInfo
            crTabLogonInfo.ConnectionInfo = crConnectionInfo
            crTable.ApplyLogOnInfo(crTabLogonInfo)
        Next

        CrystalReportViewer1.ReportSource = ReportDocument
    End Sub
End Class
