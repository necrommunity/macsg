Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    Partial Friend Class MyApplication

        Private Sub MyApplication_StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            Dim f = Application.MainForm
            '  use YOUR actual form class name:
            If f.GetType Is GetType(frmMain) Then
                CType(f, frmMain).cliStartup(e.CommandLine.ToArray)
            End If
        End Sub

    End Class
End Namespace