Imports Microsoft.VisualBasic
Imports AjaxControlToolkit.HTMLEditor

Namespace RadixAjaxControls
    Public Class cHTMLEditor
        Inherits Editor

        Protected Overrides Sub FillBottomToolbar()
            'MyBase.FillBottomToolbar()
            'BottomToolbar.Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.DesignMode())
        End Sub

        ''' <summary>
        ''' Fills the top toolbar.
        ''' </summary>
        Protected Overrides Sub FillTopToolbar()
            Try
                With TopToolbar
                    .Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.Bold())
                    .Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.Italic())
                    .Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.Underline())

                    .Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.ForeColor)
                    .Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.ForeColorSelector())

                    .Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator)

                    .Buttons.Add(New AjaxControlToolkit.HTMLEditor.ToolbarButton.InsertLink)
                End With
            Catch ex As Exception
                cLogging.AddLog(String.Format("cHTMLEditor.FillTopToolbar: {0}", ex.Message), Nothing, cLogging.LogType.ERROR_LOG, Nothing, Nothing, Nothing, Nothing)
                Throw ex
            End Try
        End Sub
    End Class
End Namespace

