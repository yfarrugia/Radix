<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        'Session("LAST_ERROR_tmp") = String.Format("{0} {1} {2}", Me.Server.GetLastError.InnerException.Message.ToString, Me.Server.GetLastError.InnerException.StackTrace.ToString, Me.Server.GetLastError.InnerException.Source.ToString)
        Session("LAST_ERROR") = Me.Server.GetLastError.InnerException
        System.Diagnostics.Debug.Write(String.Format("PAGE_LEVEL_ERROR: {0} {1}", Me.Server.GetLastError.InnerException.Message, Me.Server.GetLastError.InnerException.StackTrace))
        Me.Server.ClearError()
        Response.Redirect("~\ErrorPages\Error%20Page.aspx")
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub
    

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
       
</script>