
Partial Class System_ViewLogs
    Inherits System.Web.UI.Page

    Protected Sub btnSeperator_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSeperator.Click
        cLogging.AddLog("--------------------------------", Nothing, cLogging.LogType.SYSTEM_LOG, Session.SessionID, Nothing, Nothing, Nothing)
        LoadGridView()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadGridView()
    End Sub

    Protected Sub gdvLogs_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gdvLogs.PageIndexChanging
        gdvLogs.PageIndex = e.NewPageIndex
        gdvLogs.DataBind()
    End Sub

    Private Sub LoadGridView()
        gdvLogs.DataSource = cDBManager.GetDataTable(New Data.SqlClient.SqlCommand("SELECT TOP (1000) tblLogType.TypeName, tblLogs.Stamp, tblLogs.IPLog AS [Public IP], tblLogs.Message FROM tblLogs INNER JOIN tblLogType ON tblLogs.Type = tblLogType.LogTypeID ORDER BY tblLogs.LogID DESC"))
        'gdvLogs.DataSource = cDBManager.GetDataTable(New Data.SqlClient.SqlCommand("SELECT TOP(1000) tblLogs.Stamp, tblLogs.Message, tblLogType.TypeName, tblLogs.IPLog, tblLogs.SessionID, tblLogs.SessionUserID, tblLogs.SessionUserType, tblLogs.SessionUserName FROM tblLogs INNER JOIN tblLogType ON tblLogs.Type = tblLogType.LogTypeID ORDER BY LogID DESC"))
        gdvLogs.DataBind()
    End Sub

    Protected Sub gdvLogs_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdvLogs.PreRender
        Const LOG_TYPE_COLUMN As Integer = 0

        gdvLogs.HeaderRow.Cells(LOG_TYPE_COLUMN).Text = ""
        For Each gvr As GridViewRow In gdvLogs.Rows
            Dim imgMessageType As New Image
            Dim MesType As String = gvr.Cells(LOG_TYPE_COLUMN).Text
            gvr.Cells(LOG_TYPE_COLUMN).Controls.Clear()
            imgMessageType.ImageUrl = "../../Images/Icons/" & MesType & ".png"
            imgMessageType.ToolTip = MesType
            gvr.Cells(LOG_TYPE_COLUMN).Controls.Add(imgMessageType)
        Next
    End Sub

    Protected Sub lnk20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk20.Click
        gdvLogs.PageSize = 20
        gdvLogs.DataBind()
    End Sub

    Protected Sub lnk35_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk35.Click
        gdvLogs.PageSize = 35
        gdvLogs.DataBind()
    End Sub

    Protected Sub lnk50_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk50.Click
        gdvLogs.PageSize = 50
        gdvLogs.DataBind()
    End Sub

    Protected Sub lnk100_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk100.Click
        gdvLogs.PageSize = 100
        gdvLogs.DataBind()
    End Sub

    Protected Sub lnk150_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk150.Click
        gdvLogs.PageSize = 150
        gdvLogs.DataBind()
    End Sub

    Protected Sub lnk250_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk250.Click
        gdvLogs.PageSize = 250
        gdvLogs.DataBind()
    End Sub
End Class
