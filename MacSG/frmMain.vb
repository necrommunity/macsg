Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports JCS
Imports System.Text.RegularExpressions

Public Class frmMain
    Dim strColAutoCompleteList As New AutoCompleteStringCollection

    Private txtArray As TextBox()
    Private switchArray As JCS.ToggleSwitch()
    Private trkbrArray As TrackBar()

    Public Sub ControlArrayItems()
        txtArray = {txtStream1, txtStream2, txtStream3, txtStream4}
        switchArray = {switchStream1, switchStream2, switchStream3, switchStream4}
        trkbrArray = {trkbrStream1, trkbrStream2, trkbrStream3, trkbrStream4}
    End Sub

    'Form load
    Public Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.strPathToStreamerFile <> "*.conf" Then
            My.Settings.strPathToStreamerFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\streamerlist.conf"
        End If

        setupLivestreamerCheck()
        setupToggleSwitches()
        setupAutocompleteSources()
        setupTwitchOAuth()
        ControlArrayItems()

        If Environment.GetCommandLineArgs.Length > 1 Then

            Dim strArgs As String = Environment.GetCommandLineArgs(1).Remove(0, 6)
            Dim cliArgs() As String = strArgs.Split(New Char() {","c})

            If cliArgs.Length > 5 Then
                ReDim Preserve cliArgs(4)
            End If

            If cliArgs(0) = "rtmp" Then
                For i = 0 To (cliArgs.Length - 2)
                    switchArray(i).Checked = True
                Next

            ElseIf cliArgs(0) = "twitch" Then

            ElseIf cliArgs(0) <> "rtmp" AndAlso cliArgs(0) <> "twitch" Then
                MsgBox("Invalid command line arguments, exiting...")
                Application.Exit()
                Exit Sub
            End If

            For i = 1 To (cliArgs.Length - 1)
                If cliArgs(i) <> Nothing Then
                    txtArray(i - 1).Text = cliArgs(i)
                End If
            Next
            btnGenAll_Click(sender, e)
        End If

    End Sub

    'Set up toggle switch controls on Form1 
    Private Sub setupToggleSwitches()
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

    'Runs Livestreamer after it has fniished downloading; throws error if download fails.
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
        If My.Settings.strTwitchOAuthKey = "" Then
            Dim resOAuth As DialogResult = MessageBox.Show("Due to Twitch API changes, you are required to generate an OAuth key to watch Twitch streams through Livestreamer.  Click ""OK"" to open up a web page where you can create an OAuth key.", "Twitch OAuth key required", MessageBoxButtons.OKCancel)
            Dim strOAuthURL As String = "https://twitchapps.com/tmi/"

            If resOAuth = DialogResult.OK Then
                Process.Start(strOAuthURL)
                My.Settings.strTwitchOAuthKey = InputBox("Enter Twitch OAuth code, without the leading ""oauth:""", "Input Twitch OAuth key").ToString
            Else
                MsgBox("You will be unable to watch Twitch streams unless you generate an OAuth key.  You may enter an OAuth key at any time via ""File"" > ""Change Twitch OAuth key...""")
            End If

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

    'CLose all VLC windows
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
        MessageBox.Show("Version 0.6 - by MacKirby" & vbCrLf & vbCrLf & "This program is provided free of use for managing stream captures for tournaments on Twitch.  Got feedback?  Drop me an email - mac@mackirby.tv", "About MacSG", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'Change window size for CMDOW
    Private Sub tsmiChangeVLCWindowSize_Click(sender As Object, e As EventArgs) Handles tsmiChangeVLCWindowSize.Click
        My.Settings.strWindowSize = InputBox("Define window size for VLC - enter the resolution as ""width height"".  Recommended sizes:" & vbCrLf & "1920x1080: 882x520" & vbCrLf & "1440x900: 642x385", "Define window size...", "882 520")
    End Sub

    Public Sub tsmiEditAutocompleteFile_Click(sender As Object, e As EventArgs) Handles tsmiEditAutocompleteFile.Click
        Dim frmEditStreamerList As New frmEditStreamerList()
        frmEditStreamerList.Show()
    End Sub

    Private Sub tsmiChangeTwitchOAuthKey_Click(sender As Object, e As EventArgs) Handles tsmiChangeTwitchOAuthKey.Click
        Dim resOAuth As DialogResult = MessageBox.Show("Due to Twitch API changes, you require an OAuth key to watch Twitch streams through Livestreamer.  Click ""Yes"" to open up a web page where you can create an OAuth token.  If you already have a token, click ""No""", "Twitch OAuth key required", MessageBoxButtons.YesNoCancel
                                                       )
        Dim strOAuthURL As String = "https://twitchapps.com/tmi/"

        If resOAuth = DialogResult.Yes Then
            Process.Start(strOAuthURL)
            My.Settings.strTwitchOAuthKey = InputBox("Enter Twitch OAuth key, without the leading ""oauth:""", "Input Twitch OAuth key").ToString
        ElseIf resOAuth = DialogResult.No Then
            My.Settings.strTwitchOAuthKey = InputBox("Enter Twitch OAuth key, without the leading ""oauth:""", "Input Twitch OAuth key", "Current key - " + My.Settings.strTwitchOAuthKey + "").ToString
        End If
    End Sub



    'Functions
    Public Sub genStream(streamer As String, quality As String, source As String, windowTitle As String, configFile As String)

        Dim strLivestreamerProcess As New ProcessStartInfo("cmd.exe", "/k title " & windowTitle & " & " & source & streamer & quality & "--player-args "" --config %AppData%\MacSG\" & configFile & " {filename}"" > %AppData%\MacSG\" + configFile + ".log")
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

    'Generate streams
    Sub streamButton_Clicked(sender As Object, e As EventArgs) Handles btnStream1Gen.Click, btnStream2Gen.Click, btnStream3Gen.Click, btnStream4Gen.Click
        Dim ctrlIndex = Integer.Parse(Regex.Replace(DirectCast(sender, Button).Name, "[^1-4]", ""))

        If txtArray(ctrlIndex - 1).Text <> "" Then

            Dim strSource As String = ""
            Dim strQuality As String = ""
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

            If switchArray(ctrlIndex - 1).Checked Then
                strSource = "livestreamer rtmp://rtmp.condorleague.tv/"
            Else
                strSource = "livestreamer --twitch-oauth-token " & My.Settings.strTwitchOAuthKey & " twitch.tv/"
            End If

            genStream(streamer:=txtArray(ctrlIndex - 1).Text, quality:=strQuality, source:=strSource, windowTitle:=strWindowTitle, configFile:=ctrlIndex.ToString())
            writeNameToFile(streamer:=txtArray(ctrlIndex - 1).Text, file:=ctrlIndex.ToString())
            writeNameToAutocomplete(streamer:=txtArray(ctrlIndex - 1).Text)

        End If
    End Sub

    Private Sub switchStream_Checked(sender As Object, e As EventArgs) Handles switchStream1.CheckedChanged, switchStream2.CheckedChanged, switchStream3.CheckedChanged, switchStream4.CheckedChanged

        If DirectCast(sender, JCS.ToggleSwitch).Checked = True Then
            Dim ctrlIndex = Integer.Parse(Regex.Replace(DirectCast(sender, JCS.ToggleSwitch).Name, "[^1-4]", ""))
            trkbrArray(ctrlIndex - 1).Enabled = False

        ElseIf DirectCast(sender, JCS.ToggleSwitch).Checked = False Then
            Dim ctrlIndex = Integer.Parse(Regex.Replace(DirectCast(sender, JCS.ToggleSwitch).Name, "[^1-4]", ""))
            trkbrArray(ctrlIndex - 1).Enabled = True
        End If

    End Sub
End Class

