Imports System.IO
Imports JCS

Public Class Form1
    Dim strColAutoCompleteList As New AutoCompleteStringCollection
    Dim strLiveStreamer1 As String = "livestreamer --hls-segment-threads 4 twitch.tv/"
    Dim strLiveStreamer2 As String = "livestreamer --hls-segment-threads 4 twitch.tv/"
    Dim strLiveStreamer3 As String = "livestreamer --hls-segment-threads 4 twitch.tv/"
    Dim strLiveStreamer4 As String = "livestreamer --hls-segment-threads 4 twitch.tv/"

    Dim strQuality1 As String = " source "
    Dim strQuality2 As String = " source "
    Dim strQuality3 As String = " source "
    Dim strQuality4 As String = " source "

    Dim strPathtoName1 As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\racer1.txt"
    Dim strPathtoName2 As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\racer2.txt"
    Dim strPathtoName3 As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\racer3.txt"
    Dim strPathtoName4 As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\racer4.txt"

    Dim strPathToScore1 As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\score1.txt"
    Dim strPathToScore2 As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\score2.txt"
    Dim strPathToScore3 As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\score3.txt"
    Dim strPathToScore4 As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\score4.txt"


    'Form load
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) & "\Livestreamer\livestreamer.exe") Then

            Dim boolLivestreamerInstall As Integer = MessageBox.Show("Livestreamer is not installed.  Would you like to install Livestreamer now?", "No Livestreamer isntallation detected", MessageBoxButtons.YesNo)
            If boolLivestreamerInstall = DialogResult.No Then
                Environment.Exit(0)
            ElseIf boolLivestreamerInstall = DialogResult.Yes Then
                Process.Start(Environment.SpecialFolder.ProgramFilesX86 + "\MacSG\MacSG\livestreamer-v1.12.2-win32-setup.exe")
            End If
        End If


        'Set ToggleSwitch renderer
        Dim customizedMetroRenderer1 = New ToggleSwitchMetroRenderer()
        Dim customizedMetroRenderer2 = New ToggleSwitchMetroRenderer()
        Dim customizedMetroRenderer3 = New ToggleSwitchMetroRenderer()
        Dim customizedMetroRenderer4 = New ToggleSwitchMetroRenderer()

        customizedMetroRenderer1.LeftSideColor = Color.FromArgb(59, 123, 179)
        customizedMetroRenderer1.LeftSideColorHovered = Color.FromArgb(72, 149, 217)
        customizedMetroRenderer1.LeftSideColorPressed = Color.FromArgb(84, 175, 255)
        customizedMetroRenderer1.RightSideColor = Color.FromArgb(100, 65, 165)
        customizedMetroRenderer1.RightSideColorHovered = Color.FromArgb(131, 85, 217)
        customizedMetroRenderer1.RightSideColorPressed = Color.FromArgb(155, 100, 255)

        customizedMetroRenderer2.LeftSideColor = Color.FromArgb(59, 123, 179)
        customizedMetroRenderer2.LeftSideColorHovered = Color.FromArgb(72, 149, 217)
        customizedMetroRenderer2.LeftSideColorPressed = Color.FromArgb(84, 175, 255)
        customizedMetroRenderer2.RightSideColor = Color.FromArgb(100, 65, 165)
        customizedMetroRenderer2.RightSideColorHovered = Color.FromArgb(131, 85, 217)
        customizedMetroRenderer2.RightSideColorPressed = Color.FromArgb(155, 100, 255)

        customizedMetroRenderer3.LeftSideColor = Color.FromArgb(59, 123, 179)
        customizedMetroRenderer3.LeftSideColorHovered = Color.FromArgb(72, 149, 217)
        customizedMetroRenderer3.LeftSideColorPressed = Color.FromArgb(84, 175, 255)
        customizedMetroRenderer3.RightSideColor = Color.FromArgb(100, 65, 165)
        customizedMetroRenderer3.RightSideColorHovered = Color.FromArgb(131, 85, 217)
        customizedMetroRenderer3.RightSideColorPressed = Color.FromArgb(155, 100, 255)

        customizedMetroRenderer4.LeftSideColor = Color.FromArgb(59, 123, 179)
        customizedMetroRenderer4.LeftSideColorHovered = Color.FromArgb(72, 149, 217)
        customizedMetroRenderer4.LeftSideColorPressed = Color.FromArgb(84, 175, 255)
        customizedMetroRenderer4.RightSideColor = Color.FromArgb(100, 65, 165)
        customizedMetroRenderer4.RightSideColorHovered = Color.FromArgb(131, 85, 217)
        customizedMetroRenderer4.RightSideColorPressed = Color.FromArgb(155, 100, 255)

        switchStream1.SetRenderer(customizedMetroRenderer1)
        switchStream2.SetRenderer(customizedMetroRenderer2)
        switchStream3.SetRenderer(customizedMetroRenderer3)
        switchStream4.SetRenderer(customizedMetroRenderer4)

        'Generaete autocomplete file
        If My.Settings.streamerFileLocation = "" Or File.Exists(My.Settings.streamerFileLocation) = False Then

            MsgBox("You must select an autocomplete file to use this program.  The file must be a text file with 1 username per line.")

            Dim fd As OpenFileDialog = New OpenFileDialog()

            fd.Title = "Select a file..."
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG"
            fd.Filter = "Text files (*.txt)|*.txt"
            fd.RestoreDirectory = True

            Select Case fd.ShowDialog
                Case DialogResult.Cancel
                    Close()
                Case DialogResult.OK
                    My.Settings.streamerFileLocation = fd.FileName
            End Select

        End If

        Using reader As New StreamReader(My.Settings.streamerFileLocation)
            strColAutoCompleteList.Clear()
            While Not reader.EndOfStream
                strColAutoCompleteList.Add(reader.ReadLine())
            End While
        End Using

        txtStream1.AutoCompleteCustomSource = strColAutoCompleteList
        txtStream2.AutoCompleteCustomSource = strColAutoCompleteList
        txtStream3.AutoCompleteCustomSource = strColAutoCompleteList
        txtStream4.AutoCompleteCustomSource = strColAutoCompleteList

    End Sub



    'CLose all VLC windows
    Private Sub vlcKill_Click(sender As Object, e As EventArgs) Handles btnKillVLC.Click

        Dim procKillVLC As New ProcessStartInfo("cmd.exe", "/c taskkill  /f /fi ""WindowTitle eq First - VLC Media Player"" & taskkill /f /fi ""WindowTitle eq Second - VLC Media Player"" & taskkill /f /fi ""WindowTitle eq Third - VLC Media Player"" & taskkill /f /fi ""WindowTitle eq Fourth - VLC Media Player""")
        procKillVLC.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(procKillVLC)

    End Sub

    'About this program
    Private Sub aboutCoNDORSGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles aboutCoNDORSGToolStripMenuItem.Click
        MessageBox.Show("Version 0.5.3 - by MacKirby" & vbCrLf & vbCrLf & "This program is provided free of use for managing stream captures for tournaments on Twitch.  Got feedback?  Drop me an email - mac@mackirby.tv", "About MacSG", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class