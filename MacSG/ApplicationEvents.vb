Imports Microsoft.VisualBasic.ApplicationServices

Namespace My

    Public Event StartupNextInstance(
   ByVal sender As Object,
   ByVal e As StartupNextInstanceEventArgs
)

    Partial Friend Class MyApplication

        Private Sub MyApplication_StartupNextInstance(sender As Object,
                e As StartupNextInstanceEventArgs) _
                     Handles Me.StartupNextInstance

            Dim f = Application.MainForm
            '  use YOUR actual form class name:
            If f.GetType Is GetType(frmMain) Then
                CType(f, frmMain).NewArgumentsReceived(e.CommandLine.ToArray)
            End If

        End Sub
    End Class

End Namespace