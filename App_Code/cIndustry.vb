Imports Microsoft.VisualBasic
Imports System.Data.SqlClient


Public Class cIndustry
    Public Shared Function GetAllIndustries() As Data.DataTable
        Try
            Return cDBManager.GetDataTable(New SqlCommand("SELECT JobIndustry,JobIndustryID FROM tblJobIndustry"))
        Catch ex As Exception
            cLogging.AddLog(String.Format("cIndustry.GetAllIndustries: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
            Throw ex
        End Try
    End Function
End Class
