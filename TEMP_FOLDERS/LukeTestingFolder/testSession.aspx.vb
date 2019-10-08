
Partial Class LukeTestingFolder_testSession
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write(Session.SessionID & "<br/>")
        Response.Write("<br/>")
        Response.Write(Request.ServerVariables.Count)
        With Response
            .Write("<table border=1>")

            .Write("<tr>")
            .Write("<td colspan=2 align='center'>")
            .Write("<B><span style='color: red;'>Server Variables</span></B><br/>")
            .Write("</td>")
            .Write("</tr>")

        End With
        For i As Integer = 1 To Request.ServerVariables.Count - 1
            'Response.Write(Request.ServerVariables(i) & "<br/>")

            With Response
                .Write("<tr>")
                .Write("<td>")
                .Write("<b>" & Request.ServerVariables.GetKey(i) & "</b>")
                .Write("</td>")
                .Write("<td>")
                .Write(Request.ServerVariables(Request.ServerVariables.GetKey(i)) & "<br/>")
                .Write("</td>")
                .Write("</tr>")
            End With


        Next
        With Response
            .Write("<tr>")
            .Write("<td colspan=2 align='center'>")
            .Write("<B><span style='color: red;'>Sessions Variables</span></B><br/>")
            .Write("</td>")
            .Write("</tr>")
        End With

        For Each i In Session.Contents
            With Response
                .Write("<tr>")
                .Write("<td>")
                .Write("<span style='color: blue;'>" & i & " </span>")
                .Write("</td>")
                .Write("<td>")
                .Write(Session.Item(i).ToString & "<br/>")
                .Write("</td>")
                .Write("</tr>")
            End With
        Next
        Response.Write("</table>")

    End Sub
End Class
