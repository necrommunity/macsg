Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports Microsoft.Win32
Imports System.Security.Principal
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Runtime.InteropServices

Public Class frmMain
    Dim strColAutoCompleteList As New AutoCompleteStringCollection

    Private txtArray As TextBox()
    Private pronounsArray As TextBox()
    Private switchArray As JCS.ToggleSwitch()
    Private trkbrArray As TrackBar()
    Private btnArray As Button()

    Dim appdataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\macsg"

    Public Event StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs)

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function SetWindowText(hWnd As IntPtr, lpString As String) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function MoveWindow(hWnd As IntPtr, X As Integer, Y As Integer, nWidth As Integer, nHeight As Integer, bRepaint As Boolean) As Boolean
    End Function

    Private Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Private Declare Auto Function PostMessage Lib "user32.dll" (ByVal hwnd As Integer, ByVal message As UInteger, ByVal wParam As Integer, ByVal lParam As Integer) As Boolean
    Dim WM_QUIT As UInteger = &H12
    Dim WM_CLOSE As UInteger = &H10

    'Form load
    Public Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.strPathToStreamerFile <> "*.conf" Then
            My.Settings.strPathToStreamerFile = appdataFolder + "\streamerlist.conf"
        End If

        Dim x As Integer = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
        Dim y As Integer = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        Location = New Point(x, y)

        setupLivestreamerCheck()

        setupAutocompleteSources()
        ControlArrayItems()

        Dim args As String() = Environment.GetCommandLineArgs
        If args.Length > 1 Then
            args(0) = args(1)
            cliStartup(args:=args)
        End If

        ToolStripStatusLabel1.Text = "Version " + [GetType].Assembly.GetName.Version.ToString

        tsmiCombineNamesPronouns.Checked = My.Settings.boolCombinedStreamerPronounFile

    End Sub

    Public Sub ControlArrayItems()
        txtArray = {txtStream1, txtStream2, txtStream3, txtStream4}
        pronounsArray = {txtPronouns1, txtPronouns2, txtPronouns3, txtPronouns4}
        trkbrArray = {trkbrStream1, trkbrStream2, trkbrStream3, trkbrStream4}
        btnArray = {btnStream1Gen, btnStream2Gen, btnStream3Gen, btnStream4Gen}
    End Sub

    'Check that livestreamer is installed in the Program Files (x86) or Program Files folder
    Public Sub setupLivestreamerCheck()

        If File.Exists("C:\Program Files (x86)\Streamlink\bin\streamlink.exe") Then
            My.Settings.streamlinkDir = "C:\Program Files (x86)\Streamlink\bin\streamlink.exe"
        ElseIf File.Exists("C:\Program Files\Streamlink\bin\streamlink.exe") Then
            My.Settings.streamlinkDir = "C:\Program Files\Streamlink\bin\streamlink.exe"
        End If

        If Not File.Exists(My.Settings.streamlinkDir) Then
            Dim boolStreamlink As Integer = MessageBox.Show("Streamlink was not found in its default directory.  Click Yes to download the latest version from GitHub, or No to specify streamlink.exe's location.", "Streamlink not found", MessageBoxButtons.YesNo)

            If boolStreamlink = DialogResult.Yes Then
                For Each ctrl As Control In Controls
                    ctrl.Enabled = False
                Next
                Dim client As New WebClient()
                AddHandler client.DownloadProgressChanged, AddressOf ShowDownloadProgress
                AddHandler client.DownloadFileCompleted, AddressOf DownloadFileCompleted

                client.DownloadFileAsync(New Uri("https://github.com/streamlink/windows-builds/releases/download/4.3.0-1/streamlink-4.3.0-1-py310-x86.exe"), Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\streamlink-1.1.1.exe")
            ElseIf boolStreamlink = DialogResult.No Then
                Dim fd As OpenFileDialog = New OpenFileDialog()

                fd.Title = "Select a file..."
                fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
                fd.Filter = "Streamlink executable (*.exe)|*.exe"
                fd.RestoreDirectory = True

                If fd.ShowDialog = DialogResult.OK Then
                    My.Settings.streamlinkDir = fd.FileName.ToString
                Else
                    For Each ctrl As Control In Controls
                        ctrl.Enabled = False
                    Next
                End If
            End If
        End If
    End Sub

    'Handler for Streamlink download progress bar
    Private Sub ShowDownloadProgress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        ProgressBar1.Visible = True
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    'Runs Streamlink after it has finished downloading; throws error if download fails.
    Public Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        If Not e.Cancelled AndAlso e.Error Is Nothing Then
            ProgressBar1.Visible = False
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\streamlink-1.1.1.exe")
            Me.Close()

        Else
            MessageBox.Show("There was an error downloading Streamlink.  Please try running the application as an Administrator and try again.")
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

    'Move and resize all windows
    Private Sub moveResize_Click(sender As Object, e As EventArgs) Handles btnMoveResize.Click

        If My.Settings.strWindowSize = "" Then
            My.Settings.strWindowSize = InputBox("You must define a window size for VLC - the default (for 1920x1080) is already entered below.  Enter the resolution as ""width height"".", "Define window size...", "882 520")
            If My.Settings.strWindowSize = "" Then My.Settings.strWindowSize = "882 520"
        End If

        Dim strXPos = My.Settings.strWindowSize.Split(" "c)(0)
        Dim strYPos = My.Settings.strWindowSize.Split(" "c)(1)

        Dim intXPos = Integer.Parse(strXPos) + 5
        Dim intYPos = Integer.Parse(strYPos) - 5
        Dim hWnd As IntPtr

        hWnd = FindWindow(Nothing, "First - VLC Media Player")
        MoveWindow(hWnd, 0, 0, CInt(strXPos), CInt(strYPos), True)

        hWnd = FindWindow(Nothing, "Second - VLC Media Player")
        MoveWindow(hWnd, intXPos, 0, CInt(strXPos), CInt(strYPos), True)

        hWnd = FindWindow(Nothing, "Third - VLC Media Player")
        MoveWindow(hWnd, 0, intYPos, CInt(strXPos), CInt(strYPos), True)

        hWnd = FindWindow(Nothing, "Fourth - VLC Media Player")
        MoveWindow(hWnd, intXPos, intYPos, CInt(strXPos), CInt(strYPos), True)

    End Sub

    'Close all VLC windows
    Private Sub vlcKill_Click(sender As Object, e As EventArgs) Handles btnKillVLC.Click

        Dim hWnd As IntPtr
        hWnd = FindWindow(Nothing, "First - VLC Media Player")
        PostMessage(CInt(hWnd), WM_CLOSE, 0, 0)

        hWnd = FindWindow(Nothing, "Second - VLC Media Player")
        PostMessage(CInt(hWnd), WM_CLOSE, 0, 0)

        hWnd = FindWindow(Nothing, "Third - VLC Media Player")
        PostMessage(CInt(hWnd), WM_CLOSE, 0, 0)

        hWnd = FindWindow(Nothing, "Fourth - VLC Media Player")
        PostMessage(CInt(hWnd), WM_CLOSE, 0, 0)

    End Sub

    'Generate all streams by "clicking" the 4 buttons
    Private Sub btnGenAll_Click(sender As Object, e As EventArgs) Handles btnGenAll.Click

        btnStream1Gen.PerformClick()
        btnStream2Gen.PerformClick()
        btnStream3Gen.PerformClick()
        btnStream4Gen.PerformClick()

        If My.Settings.strWindowSize <> "" Then
            btnMoveResize.PerformClick()
        End If
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

    'Change window size for CMDOW
    Private Sub tsmiChangeVLCWindowSize_Click(sender As Object, e As EventArgs) Handles tsmiChangeVLCWindowSize.Click
        My.Settings.strWindowSize = InputBox("Define window size for VLC - enter the resolution as ""width height"".  Recommended sizes:" & vbCrLf & "1920x1080: 882x520" & vbCrLf & "1440x900: 642x385", "Define window size...", "882 520")
    End Sub

    'Edit autcomplete file
    Public Sub tsmiEditAutocompleteFile_Click(sender As Object, e As EventArgs) Handles tsmiEditAutocompleteFile.Click
        Dim frmEditStreamerList As New frmEditStreamerList()
        frmEditStreamerList.Show()
    End Sub


    'Combined streamer name and pronouns file
    Public Sub tsmiFileConfigure_Click(sender As Object, e As EventArgs) Handles tsmiCombineNamesPronouns.Click
        My.Settings.boolCombinedStreamerPronounFile = tsmiCombineNamesPronouns.Checked
    End Sub


    'Unattached subs
    Public Sub genStream(streamer As String, quality As String, source As String, windowTitle As String, configFile As String, racerNumber As String)
        Dim runningProcess = "/c title " & windowTitle & " & " & source & "-a "" --config %AppData%\MacSG\vlcrc --width 877 --height 518 -"" " & " --title " & racerNumber & " --hls-live-edge 1 twitch.tv/" & streamer & quality
        Dim strLivestreamerProcess As New ProcessStartInfo("cmd.exe", runningProcess)

        strLivestreamerProcess.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(strLivestreamerProcess)

    End Sub

    Public Sub writeNameToFile(streamer As String, file As String)

        Dim strPathtoName As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\streamer" & file & ".txt"
        Dim swstreamer As System.IO.StreamWriter
        swstreamer = My.Computer.FileSystem.OpenTextFileWriter(strPathtoName, False)
        swstreamer.WriteLine(streamer)
        swstreamer.Close()

    End Sub
    Public Sub writePronounsToFile(pronouns As String, file As String)

        Dim strPathtoName As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\streamer-pronouns" & file & ".txt"
        Dim swstreamer As System.IO.StreamWriter
        swstreamer = My.Computer.FileSystem.OpenTextFileWriter(strPathtoName, False)
        swstreamer.WriteLine(pronouns)
        swstreamer.Close()

    End Sub

    Public Sub writeNameAndPronounsToFile(streamer As String, pronouns As String, file As String)

        Dim strPathtoName As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\streamer" & file & ".txt"


        Dim swstreamer As System.IO.StreamWriter
        swstreamer = My.Computer.FileSystem.OpenTextFileWriter(strPathtoName, False)
        If Not String.IsNullOrEmpty(pronouns) Then
            swstreamer.WriteLine(streamer + " (" + pronouns + ")")
        Else
            swstreamer.WriteLine(streamer)
        End If
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

            MsgBox(splitArgs(0).ToString)
            MsgBox(splitArgs(1).ToString)

            'DO NOT SUBMIT rework this completely?
            If splitArgs.Length > 4 Then
                ReDim Preserve splitArgs(3)
            End If

            For i = 0 To (splitArgs.Length - 1)
                If splitArgs(i) <> Nothing Then
                    Dim splitRacer As String() = splitArgs(i).Split(New Char() {";"c})
                    If splitRacer.Length = 2 Then
                        pronounsArray(i).Text = splitRacer(1)
                    ElseIf splitRacer.Length <> 1 Then
                        MsgBox("Invalid command line arguments, exiting...")
                        Application.Exit()
                        Exit Sub
                    End If
                    txtArray(i).Text = splitRacer(0)
                    btnArray(i).PerformClick()
                End If
            Next
        End If
    End Sub


    'Generate streams
    Sub streamButton_Clicked(sender As Object, e As EventArgs) Handles btnStream1Gen.Click, btnStream2Gen.Click, btnStream3Gen.Click, btnStream4Gen.Click

        Dim ctrlIndex = Integer.Parse(Regex.Replace(DirectCast(sender, Button).Name, "[^1-4]", ""))

        'Dim openWindow As Boolean
        Dim strWindowTitle As String = ""
        Dim vlcWindowTitle As String = ""

        Select Case ctrlIndex
            Case 1
                strWindowTitle = "FirstCMD"
                vlcWindowTitle = "First"
            Case 2
                strWindowTitle = "SecondCMD"
                vlcWindowTitle = "Second"
            Case 3
                strWindowTitle = "ThirdCMD"
                vlcWindowTitle = "Third"
            Case 4
                strWindowTitle = "FourthCMD"
                vlcWindowTitle = "Fourth"
        End Select

        If processChecker(sender:=btnArray(ctrlIndex - 1), ctrlIndex:=ctrlIndex) = False Then
            If txtArray(ctrlIndex - 1).Text <> "" Then
                Dim strSource As String = ""
                Dim strQuality As String = ""

                Select Case trkbrArray(ctrlIndex - 1).Value
                    Case 1
                        strQuality = " low "
                    Case 2
                        strQuality = " medium "
                    Case 3
                        strQuality = " high "
                    Case 4
                        strQuality = " best "
                End Select
                strSource = "streamlink "

                genStream(streamer:=txtArray(ctrlIndex - 1).Text.ToLower, quality:=strQuality, source:=strSource, windowTitle:=strWindowTitle, configFile:=ctrlIndex.ToString(), racerNumber:=vlcWindowTitle)
                writeNameToAutocomplete(streamer:=txtArray(ctrlIndex - 1).Text.ToLower)
                Dim pronouns As String = pronounsArray(ctrlIndex - 1).Text

                If Not String.IsNullOrEmpty(pronouns) Then
                    writePronounsToFile(pronouns:=pronouns, file:=ctrlIndex.ToString())
                Else
                    writePronounsToFile(pronouns:="", file:=ctrlIndex.ToString())
                End If


                If My.Settings.boolCombinedStreamerPronounFile Then
                    writeNameAndPronounsToFile(streamer:=txtArray(ctrlIndex - 1).Text, pronouns:=pronouns, file:=ctrlIndex.ToString())
                Else
                    writeNameToFile(streamer:=txtArray(ctrlIndex - 1).Text, file:=ctrlIndex.ToString())
                End If

            End If
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
                Exit For
            Else
                openWindow = False
            End If

        Next

        Return openWindow

    End Function

    Private Sub tsmiCondorSchedule_Click(sender As Object, e As EventArgs) Handles tsmiCondorSchedule.Click
        Process.Start("https://condor.live/schedule")
    End Sub

    Private Sub tsmiOpenAppData_Click(sender As Object, e As EventArgs) Handles tsmiOpenAppData.Click
        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG")
    End Sub

    Private Sub tsmiEditStreamlinkConfig_Click(sender As Object, e As EventArgs) Handles tsmiEditStreamlinkConfig.Click
        Process.Start("notepad.exe", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\streamlink\streamlinkrc")
    End Sub

    Private Sub ResetStreamlinkPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiResetStreamlinkPath.Click
        Dim boolResetStreamlinkPath As Integer = MessageBox.Show("Reset the path to Streamlink?  Current path: " + vbNewLine + My.Settings.streamlinkDir, "Reset Streamlink path", MessageBoxButtons.YesNo)

        If boolResetStreamlinkPath = DialogResult.Yes Then
            My.Settings.streamlinkDir = "Not set"
            setupLivestreamerCheck()
        End If
    End Sub

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        Dim githubApiUrl As String = "https://api.github.com/repos/necrommunity/macsg/releases/latest"
        Dim githubHeaders As String = "Accept:  application/vnd.github+json"
        Dim webClient As WebClient = New WebClient()
        webClient.Headers.Add(githubHeaders)

        Dim githubResponse As String

        Try
            githubResponse = webClient.DownloadString(New Uri(githubApiUrl))
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.ProtocolError AndAlso ex.Response IsNot Nothing Then
                Dim response = DirectCast(ex.Response, HttpWebResponse)
                If response.StatusCode = HttpStatusCode.NotFound Then
                    MsgBox("Error checking for latest MacSG releases")
                End If
            End If
            Throw
        End Try

        MsgBox(githubResponse)

    End Sub
End Class