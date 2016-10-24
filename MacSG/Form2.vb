Imports System.IO

Public Class Form2
    Dim lstStreamerList As New List(Of String)

    Public Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim p As Point
        p = Form1.Location

        Me.Location = New Point(p.X + 10, p.Y + 10)

        Using srReader As IO.StreamReader = New IO.StreamReader(My.Settings.strPathToStreamerFile)
            Dim line As String
            line = srReader.ReadLine

            Do While (Not line Is Nothing)
                lstStreamerList.Add(line)
                dgdStreamerList.Rows.Add(line)
                line = srReader.ReadLine
            Loop
        End Using

    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As EventArgs) Handles Me.FormClosing

        dgdStreamerList.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        For i = 0 To dgdStreamerList.Rows.Count - 2
            If dgdStreamerList.Rows(i).ToString = "" Then
                dgdStreamerList.Rows.Remove(dgdStreamerList.Rows(i))
            End If
        Next

        dgdStreamerList.SelectAll()

        IO.File.WriteAllText(My.Settings.strPathToStreamerFile, dgdStreamerList.GetClipboardContent().GetText.TrimEnd)
        dgdStreamerList.ClearSelection()

        Form1.setupAutocompleteSources()

    End Sub

End Class