Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports Microsoft.Win32
Imports System.Security.Principal
Imports Microsoft.VisualBasic.ApplicationServices


Public Class frmMain
    Dim strColAutoCompleteList As New AutoCompleteStringCollection

    Private txtArray As TextBox()
    Private switchArray As JCS.ToggleSwitch()
    Private trkbrArray As TrackBar()
    Private btnArray As Button()
    Private chkArray As CheckBox()
    Public boolFirstLoad As Boolean = True
    Dim minuteCount As Integer = 0

    Public Event StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs)

    'Form load
    Public Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.strPathToStreamerFile <> "*.conf" Then
            My.Settings.strPathToStreamerFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\streamerlist.conf"
        End If

        Dim x As Integer = Screen.PrimaryScreen.WorkingArea.Width - Height
        Dim y As Integer = Screen.PrimaryScreen.WorkingArea.Height - Width
        Location = New Point(x, y)

        setupLivestreamerCheck()
        setupAutocompleteSources()
        setupTwitchOAuth()
        ControlArrayItems()

        Dim args As String() = Environment.GetCommandLineArgs
        If args.Length > 1 Then
            args(0) = args(1)
            cliStartup(args:=args)
        End If

    End Sub

    Public Sub ControlArrayItems()
        txtArray = {txtStream1, txtStream2, txtStream3, txtStream4}
        trkbrArray = {trkbrStream1, trkbrStream2, trkbrStream3, trkbrStream4}
        btnArray = {btnStream1Gen, btnStream2Gen, btnStream3Gen, btnStream4Gen}
        chkArray = {chkStream1, chkStream2, chkStream3, chkStream4}
    End Sub

    'Check that livestreamer is installed in the Program Files (x86) folder
    Public Sub setupLivestreamerCheck()
        If Not File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) & "\Livestreamer\livestreamer.exe") Then
            Dim boolLivestreamerInstall As Integer = MessageBox.Show("Livestreamer is not installed, and is necessary for this program to run.  Would you like to download and install Livestreamer now?", "No Livestreamer installation detected", MessageBoxButtons.YesNoCancel)

            If boolLivestreamerInstall = DialogResult.No Or boolLivestreamerInstall = DialogResult.Cancel Then
                Close()

            ElseIf boolLivestreamerInstall = DialogResult.Yes Then
                Dim client As New WebClient()
                AddHandler client.DownloadProgressChanged, AddressOf ShowDownloadProgress
                AddHandler client.DownloadFileCompleted, AddressOf DownloadFileCompleted

                client.DownloadFileAsync(New Uri("https://github.com/chrippa/livestreamer/releases/download/v1.12.2/livestreamer-v1.12.2-win32-setup.exe"), Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\livestreamer-v1.12.2-win32-setup.exe")

                For Each ctrl As Control In Controls
                    ctrl.Enabled = False
                Next

            End If
        End If

    End Sub

    'Handler for Livestreamer download progress bar
    Private Sub ShowDownloadProgress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        ProgressBar1.Visible = True
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    'Runs Livestreamer after it has finished downloading; throws error if download fails.
    Public Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        If Not e.Cancelled AndAlso e.Error Is Nothing Then
            ProgressBar1.Visible = False
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\livestreamer-v1.12.2-win32-setup.exe")
            For Each ctrl As Control In Controls
                ctrl.Enabled = True
            Next

        Else
            MessageBox.Show("There was an error downloading Livestreamer.  Please try running the application as an Administrator and try again.")
            ProgressBar1.Visible = False
        End If
    End Sub

    'Defines autocomplete sources for all textboxes
    Public Sub setupAutocompleteSources()

        Using reader As New StreamReader(My.Settings.strPathToStreamerFile)
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

    'Requests value for My.Settings.strTwitchOAuthKey
    Public Sub setupTwitchOAuth()
        If My.Settings.strTwitchClientID = "Client-ID=jzkbprff40iqj646a697cyrvl0zt2m6" Then
            statusLabel1.Text = "Twitch playback enabled with Livestreamer Client ID."
        Else
            statusLabel1.Text = "Twitch playback disabled"
        End If
    End Sub



    'Move and resize all windows
    Private Sub moveResize_Click(sender As Object, e As EventArgs) Handles btnMoveResize.Click
        If My.Settings.strWindowSize = "" Then
            My.Settings.strWindowSize = InputBox("You must define a window size for VLC - the default (for 1920x1080 ) is already entered below.  Enter the resolution as ""width height"".", "Define window size...", "877 518")
            If My.Settings.strWindowSize = "" Then My.Settings.strWindowSize = "877 518"
        End If

        Dim strXPos = My.Settings.strWindowSize.Split(" "c)(0)
        Dim strYPos = My.Settings.strWindowSize.Split(" "c)(1)

        Dim intXPos = Integer.Parse(strXPos) + 15
        Dim intYPos = Integer.Parse(strYPos) - 15

        Dim procCmdow1 As New ProcessStartInfo("cmd.exe", "/c %appdata%\MacSG\cmdow ""First - VLC media player"" /mov 5 5 /siz " & My.Settings.strWindowSize)
        procCmdow1.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(procCmdow1)

        Dim procCmdow2 As New ProcessStartInfo("cmd.exe", "/c %appdata%\MacSG\cmdow ""Second - VLC media player"" /mov " & Convert.ToString(intXPos) & " 5 /siz " & My.Settings.strWindowSize)
        procCmdow2.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(procCmdow2)

        Dim procCmdow3 As New ProcessStartInfo("cmd.exe", "/c %appdata%\MacSG\cmdow ""Third - VLC media player"" /mov 5 " & Convert.ToString(intYPos) & " /siz " & My.Settings.strWindowSize)
        procCmdow3.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(procCmdow3)

        Dim procCmdow4 As New ProcessStartInfo("cmd.exe", "/c %appdata%\MacSG\cmdow ""Fourth - VLC media player"" /mov " & Convert.ToString(intXPos) & " " & Convert.ToString(intYPos) & " /siz " & My.Settings.strWindowSize)
        procCmdow4.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(procCmdow4)

    End Sub

    'Close all VLC windows
    Private Sub vlcKill_Click(sender As Object, e As EventArgs) Handles btnKillVLC.Click

        Dim procKillVLC As New ProcessStartInfo("cmd.exe", "/c taskkill  /f /fi ""WindowTitle eq First - VLC Media Player"" & taskkill /f /fi ""WindowTitle eq Second - VLC Media Player"" & taskkill /f /fi ""WindowTitle eq Third - VLC Media Player"" & taskkill /f /fi ""WindowTitle eq Fourth - VLC Media Player""")
        procKillVLC.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(procKillVLC)

    End Sub

    'Generate all streams by "clicking" the 4 buttons
    Private Sub btnGenAll_Click(sender As Object, e As EventArgs) Handles btnGenAll.Click

        btnStream1Gen.PerformClick()
        btnStream2Gen.PerformClick()
        btnStream3Gen.PerformClick()
        btnStream4Gen.PerformClick()

    End Sub



    'Select file to use as autocomplete source
    Private Sub selectAutocompleteFile_Click(sender As Object, e As EventArgs) Handles tsmiSelectAutocompleteFile.Click

        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Select a file..."
        fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG"
        fd.Filter = "Config files (*.conf)|*.conf"
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            My.Settings.strPathToStreamerFile = fd.FileName

            Call frmMain_Load(Me, e)

            txtStream1.Text = ""
            txtStream2.Text = ""
            txtStream3.Text = ""
            txtStream4.Text = ""
        End If
    End Sub

    'About this program
    Private Sub tsmiAbout_Click(sender As Object, e As EventArgs) Handles tsmiAbout.Click
        MessageBox.Show("Version 0.9 - by MacKirby" & vbCrLf & vbCrLf & "This program is provided free of use for managing stream captures for tournaments on Twitch.  Got feedback?  Drop me an email - mac@mackirby.tv", "About MacSG", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'Change window size for CMDOW
    Private Sub tsmiChangeVLCWindowSize_Click(sender As Object, e As EventArgs) Handles tsmiChangeVLCWindowSize.Click
        My.Settings.strWindowSize = InputBox("Define window size for VLC - enter the resolution as ""width height"".  Recommended sizes:" & vbCrLf & "1920x1080: 882x520" & vbCrLf & "1440x900: 642x385", "Define window size...", "882 520")
    End Sub

    'Edit autcomplete file
    Public Sub tsmiEditAutocompleteFile_Click(sender As Object, e As EventArgs) Handles tsmiEditAutocompleteFile.Click
        Dim frmEditStreamerList As New frmEditStreamerList()
        frmEditStreamerList.Show()
    End Sub



    'Unattached subs
    Public Sub genStream(streamer As String, quality As String, source As String, windowTitle As String, configFile As String)

        Dim strLivestreamerProcess As New ProcessStartInfo("cmd.exe", "/k title " & windowTitle & " & " & source & streamer & quality & "--player-args "" --config %AppData%\MacSG\" & configFile & " {filename}")
        strLivestreamerProcess.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(strLivestreamerProcess)

    End Sub

    Public Sub writeNameToFile(streamer As String, file As String)

        Dim strPathtoName As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\streamer" & file & ".txt"
        Dim swstreamer As System.IO.StreamWriter
        swstreamer = My.Computer.FileSystem.OpenTextFileWriter(strPathtoName, False)
        swstreamer.WriteLine(streamer.ToLower)
        swstreamer.Close()

    End Sub

    Public Sub writeNameToAutocomplete(streamer As String)

        Dim streamers = File.ReadLines(My.Settings.strPathToStreamerFile)

        If Not streamers.Contains(streamer.ToLower) Then
            Using w As New StreamWriter(My.Settings.strPathToStreamerFile, append:=True)
                w.WriteLine(streamer.ToLower())
            End Using
        End If

        setupAutocompleteSources()

    End Sub

    'Write udStream control values to text files
    Sub updControls_Changed(sender As Object, e As EventArgs) Handles updStream1.ValueChanged, updStream2.ValueChanged, updStream3.ValueChanged, updStream4.ValueChanged

        Dim updIndex As String = DirectCast(sender, Control).Name.Remove(0, 9)

        Using swScore As New StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\MacSG\score" & updIndex & ".txt")
            swScore.Write(DirectCast(sender, NumericUpDown).Value)
        End Using

    End Sub

    'Handles CLI startup
    Public Sub cliStartup(args As String())
        btnKillVLC.PerformClick()

        If args.Length > 0 Then

            Dim splitArgs As String() = args(0).Split(New Char() {","c})
            splitArgs(0) = splitArgs(0).Replace("macsg:", "")

            If splitArgs.Length > 5 Then
                ReDim Preserve splitArgs(4)
            End If

            If splitArgs(0) = "twitch" Then
                For i = 0 To (splitArgs.Length - 2)
                    chkArray(i).Checked = True
                Next

            ElseIf splitArgs(0) = "rtmp" Then
                For i = 0 To (splitArgs.Length - 2)
                    chkArray(i).Checked = False
                Next

            Else
                MsgBox("Invalid command line arguments, exiting...")
                Application.Exit()
                Exit Sub
            End If

            For i = 1 To (splitArgs.Length - 1)
                If splitArgs(i) <> Nothing Then
                    txtArray(i - 1).Text = splitArgs(i).ToLower
                    btnArray(i - 1).PerformClick()
                End If
            Next
        End If
    End Sub


    'Generate streams
    Sub streamButton_Clicked(sender As Object, e As EventArgs) Handles btnStream1Gen.Click, btnStream2Gen.Click, btnStream3Gen.Click, btnStream4Gen.Click

        Dim ctrlIndex = Integer.Parse(Regex.Replace(DirectCast(sender, Button).Name, "[^1-4]", ""))

        'Dim openWindow As Boolean
        Dim strWindowTitle As String = ""

        Select Case ctrlIndex
            Case 1
                strWindowTitle = "First"
            Case 2
                strWindowTitle = "Second"
            Case 3
                strWindowTitle = "Third"
            Case 4
                strWindowTitle = "Fourth"
        End Select

        If processChecker(sender:=btnArray(ctrlIndex - 1), ctrlIndex:=ctrlIndex) = False Then
            If txtArray(ctrlIndex - 1).Text <> "" Then
                Dim strSource As String = ""
                Dim strQuality As String = ""

                If trkbrArray(ctrlIndex - 1).Enabled = True Then
                    Select Case trkbrArray(ctrlIndex - 1).Value
                        Case 1
                            strQuality = " low "
                        Case 2
                            strQuality = " medium "
                        Case 3
                            strQuality = " high "
                        Case 4
                            strQuality = " source "
                    End Select
                ElseIf trkbrArray(ctrlIndex - 1).Enabled = False Then
                    strQuality = "/live best "
                End If

                If chkArray(ctrlIndex - 1).Checked = False Then
                    strSource = "livestreamer rtmp://rtmp.condorleague.tv/"
                Else
                    strSource = "livestreamer --http-header " + My.Settings.strTwitchClientID + " twitch.tv/"
                End If

                genStream(streamer:=txtArray(ctrlIndex - 1).Text.ToLower, quality:=strQuality, source:=strSource, windowTitle:=strWindowTitle, configFile:=ctrlIndex.ToString())
                writeNameToFile(streamer:=txtArray(ctrlIndex - 1).Text, file:=ctrlIndex.ToString())
                writeNameToAutocomplete(streamer:=txtArray(ctrlIndex - 1).Text.ToLower)
            End If
        End If

    End Sub

    Private Sub chkStream_CheckChanged(sender As Object, e As EventArgs) Handles chkStream1.CheckedChanged, chkStream2.CheckedChanged, chkStream3.CheckedChanged, chkStream4.CheckedChanged

        If DirectCast(sender, CheckBox).Checked = True Then
            Try
                Dim ctrlIndex = Integer.Parse(Regex.Replace(DirectCast(sender, CheckBox).Name, "[^1-4]", ""))
                trkbrArray(ctrlIndex - 1).Enabled = True
                chkArray(ctrlIndex - 1).BackColor = Color.FromArgb(100, 65, 165)
                chkArray(ctrlIndex - 1).Text = "Twitch"
            Catch ex As Exception
                MessageBox.Show(ex.Message + "  Handling set to Twitch")
            End Try

        ElseIf DirectCast(sender, CheckBox).Checked = False Then
            Try
                Dim ctrlIndex = Integer.Parse(Regex.Replace(DirectCast(sender, CheckBox).Name, "[^1-4]", ""))
                trkbrArray(ctrlIndex - 1).Enabled = False
                chkArray(ctrlIndex - 1).BackColor = Color.FromArgb(59, 123, 179)
                chkArray(ctrlIndex - 1).Text = "RTMP"
            Catch ex As Exception
                MessageBox.Show(ex.Message + "  Handling set to RTMP")
            End Try
        End If

    End Sub

    Private Sub InstallMacsgHandlerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstallMacsgHandlerToolStripMenuItem.Click

        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Dim isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)

        If isElevated = True Then

            Dim regMacSG As RegistryKey = Registry.ClassesRoot.CreateSubKey("macsg")
            regMacSG.SetValue("", "URL:MacSG Protocol")
            regMacSG.SetValue("URL Protocol", "")

            Dim regDefaultIcon As RegistryKey = regMacSG.CreateSubKey("DefaultIcon")
            regDefaultIcon.SetValue("", Path.GetFileName(Application.ExecutablePath))

            Dim regShell As RegistryKey = regMacSG.CreateSubKey("shell")
            Dim regOpen As RegistryKey = regShell.CreateSubKey("open")
            Dim regCommand As RegistryKey = regOpen.CreateSubKey("Command")
            regCommand.SetValue("", Application.ExecutablePath + " %1")

            MsgBox("To finish enabling the protocol, you must reboot your PC.")

        Else
            MsgBox("MacSG must be running with Administrator privileges to install the custom protocol.  Please relaunch MacSG as an Administrator.")
        End If

    End Sub


    Public Function processChecker(sender As Button, ctrlIndex As Integer) As Boolean

        Dim procProcesses() As Process = Process.GetProcesses
        Dim openWindow As Boolean
        Dim strWindowTitle As String = ""

        Select Case ctrlIndex
            Case 1
                strWindowTitle = "First"
            Case 2
                strWindowTitle = "Second"
            Case 3
                strWindowTitle = "Third"
            Case 4
                strWindowTitle = "Fourth"
        End Select

        For Each p As Process In procProcesses
            If p.MainWindowTitle.Contains(strWindowTitle) Then
                openWindow = True
                MsgBox("Already open")
                Exit For
            Else
                openWindow = False
            End If

        Next

        Return openWindow

    End Function

End Class

