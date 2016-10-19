Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports JCS

Public Class Form1
    Dim strColAutoCompleteList As New AutoCompleteStringCollection


    'Form load
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.strPathToStreamerFile = "" Then
            My.Settings.strPathToStreamerFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\streamerlist.conf"
        End If

        setupLivestreamerCheck()
        setupToggleSwitches()
        setupAutocompleteSources()
        setupTwitchOAuth()
    End Sub


    'Set up toggle sitch controls on Form1 
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

                For Each ctrl In Me.Controls
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
            For Each ctrl In Me.Controls
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



    'Stream generation buttons
    Private Sub btnStream1Gen_Click(sender As Object, e As EventArgs) Handles btnStream1Gen.Click
        If txtStream1.Text.ToLower <> "" Then

            Dim strSource1 As String = ""
            Dim strQuality1 As String = ""
            Dim intFileIndex As Integer = 1
            Dim strWindowTitle As String = "First"

            If trkbrStream1.Enabled = True Then
                Select Case trkbrStream1.Value
                    Case 1
                        strQuality1 = " low "
                    Case 2
                        strQuality1 = " medium "
                    Case 3
                        strQuality1 = " high "
                    Case 4
                        strQuality1 = " source "
                End Select

            ElseIf trkbrStream1.Enabled = False Then
                strQuality1 = "/live best "
            End If

            Select Case switchStream1.Checked
                Case True
                    strSource1 = "livestreamer rtmp://rtmp.condorleague.tv/"
                Case False
                    strSource1 = "livestreamer --twitch-oauth-token " & My.Settings.strTwitchOAuthKey & " twitch.tv/"
            End Select

            genStream(racer:=txtStream1.Text, quality:=strQuality1, source:=strSource1, windowTitle:=strWindowTitle, configFile:=intFileIndex)
            writeNameToFile(racer:=txtStream1.Text, file:=intFileIndex)
            writeNameToAutocomplete(racer:=txtStream1.Text)

        End If
    End Sub

    Private Sub btnStream2Gen_Click(sender As Object, e As EventArgs) Handles btnStream2Gen.Click
        If txtStream2.Text.ToLower <> "" Then

            Dim strSource2 As String = ""
            Dim strQuality2 As String = ""
            Dim intFileIndex As Integer = 2
            Dim strWindowTitle As String = "Second"

            If trkbrStream2.Enabled = True Then
                Select Case trkbrStream2.Value
                    Case 1
                        strQuality2 = " low "
                    Case 2
                        strQuality2 = " medium "
                    Case 3
                        strQuality2 = " high "
                    Case 4
                        strQuality2 = " source "
                End Select

            ElseIf trkbrStream2.Enabled = False Then
                strQuality2 = "/live best "
            End If

            Select Case switchStream2.Checked
                Case True
                    strSource2 = "livestreamer rtmp://rtmp.condorleague.tv/"
                Case False
                    strSource2 = "livestreamer --twitch-oauth-token " & My.Settings.strTwitchOAuthKey & " twitch.tv/"
            End Select

            genStream(racer:=txtStream2.Text, quality:=strQuality2, source:=strSource2, windowTitle:=strWindowTitle, configFile:=intFileIndex)
            writeNameToFile(racer:=txtStream2.Text, file:=intFileIndex)
            writeNameToAutocomplete(racer:=txtStream2.Text)
        End If
    End Sub

    Private Sub btnStream3Gen_Click(sender As Object, e As EventArgs) Handles btnStream3Gen.Click
        If txtStream3.Text.ToLower <> "" Then

            Dim strSource3 As String = ""
            Dim strQuality3 As String = ""
            Dim intFileIndex As Integer = 3
            Dim strWindowTitle As String = "Third"

            If trkbrStream3.Enabled = True Then
                Select Case trkbrStream3.Value
                    Case 1
                        strQuality3 = " low "
                    Case 2
                        strQuality3 = " medium "
                    Case 3
                        strQuality3 = " high "
                    Case 4
                        strQuality3 = " source "
                End Select

            ElseIf trkbrStream3.Enabled = False Then
                strQuality3 = "/live best "
            End If

            Select Case switchStream3.Checked
                Case True
                    strSource3 = "livestreamer rtmp://rtmp.condorleague.tv/"
                Case False
                    strSource3 = "livestreamer --twitch-oauth-token " & My.Settings.strTwitchOAuthKey & " twitch.tv/"
            End Select

            genStream(racer:=txtStream3.Text, quality:=strQuality3, source:=strSource3, windowTitle:=strWindowTitle, configFile:=intFileIndex)
            writeNameToFile(racer:=txtStream3.Text, file:=intFileIndex)
            writeNameToAutocomplete(racer:=txtStream3.Text)
        End If
    End Sub

    Private Sub btnStream4Gen_Click(sender As Object, e As EventArgs) Handles btnStream4Gen.Click
        If txtStream4.Text.ToLower <> "" Then

            Dim strSource4 As String = ""
            Dim strQuality4 As String = ""
            Dim intFileIndex As Integer = 4
            Dim strWindowTitle As String = "Fourth"

            If trkbrStream4.Enabled = True Then
                Select Case trkbrStream4.Value
                    Case 1
                        strQuality4 = " low "
                    Case 2
                        strQuality4 = " medium "
                    Case 3
                        strQuality4 = " high "
                    Case 4
                        strQuality4 = " source "
                End Select

            ElseIf trkbrStream4.Enabled = False Then
                strQuality4 = "/live best "
            End If

            Select Case switchStream4.Checked
                Case True
                    strSource4 = "livestreamer rtmp://rtmp.condorleague.tv/"
                Case False
                    strSource4 = "livestreamer --twitch-oauth-token " & My.Settings.strTwitchOAuthKey & " twitch.tv/"
            End Select

            genStream(racer:=txtStream4.Text, quality:=strQuality4, source:=strSource4, windowTitle:=strWindowTitle, configFile:=intFileIndex)
            writeNameToFile(racer:=txtStream4.Text, file:=intFileIndex)
            writeNameToAutocomplete(racer:=txtStream4.Text)
        End If
    End Sub



    'Move and resize all windows
    Private Sub moveResize_Click(sender As Object, e As EventArgs) Handles btnMoveResize.Click
        If My.Settings.strWindowSize = "" Then
            My.Settings.strWindowSize = InputBox("You must define a window size for VLC - the default (for 1920x1080 ) is already entered below.  Enter the resolution as ""width height"".", "Define window size...", "877 518")
            If My.Settings.strWindowSize Is "" Then My.Settings.strWindowSize = "877 518"
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

    'Generate all streams by calling the 4 subs
    Private Sub btnGenAll_Click(sender As Object, e As EventArgs) Handles btnGenAll.Click
        btnStream1Gen_Click(btnStream1Gen, New EventArgs)
        btnStream2Gen_Click(btnStream2Gen, New EventArgs)
        btnStream3Gen_Click(btnStream3Gen, New EventArgs)
        btnStream4Gen_Click(btnStream4Gen, New EventArgs)
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

            Call Form1_Load(Me, e)

            txtStream1.Text = ""
            txtStream2.Text = ""
            txtStream3.Text = ""
            txtStream4.Text = ""
        End If
    End Sub

    'About this program
    Private Sub tsmiAbout_Click(sender As Object, e As EventArgs) Handles tsmiAbout.Click
        MessageBox.Show("Version 0.5.1 - by MacKirby" & vbCrLf & vbCrLf & "This program is provided free of use for managing stream captures for tournaments on Twitch.  Got feedback?  Drop me an email - mac@mackirby.tv", "About MacSG", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'Change window size for CMDOW
    Private Sub tsmiChangeVLCWindowSize_Click(sender As Object, e As EventArgs) Handles tsmiChangeVLCWindowSize.Click
        My.Settings.strWindowSize = InputBox("Define window size for VLC - enter the resolution as ""width height"".  Recommended sizes:" & vbCrLf & "1920x1080: 882x520" & vbCrLf & "1440x900: 642x385", "Define window size...", "882 520")
    End Sub

    Public Sub tsmiEditAutocompleteFile_Click(sender As Object, e As EventArgs) Handles tsmiEditAutocompleteFile.Click
        Dim frmEditStreamerList As New Form2()
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



    'Write udStream control values to text files
    Function updControls_Changed(sender As Object, e As EventArgs) Handles updStream1.ValueChanged, updStream2.ValueChanged, updStream3.ValueChanged, updStream4.ValueChanged
        Dim updIndex As String = DirectCast(sender, Control).Name.Remove(0, 9)

        Using swScore As StreamWriter = New StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\score" & updIndex & ".txt")
            swScore.Write(DirectCast(sender, NumericUpDown).Value)
        End Using

        Return Nothing
    End Function



    'Functions
    Public Function genStream(racer As String, quality As String, source As String, windowTitle As String, configFile As Integer)

        Dim strLivestreamerProcess As New ProcessStartInfo("cmd.exe", "/k echo title " & windowTitle & " & " & source & racer & quality & "--player-args "" --config %AppData%\MacSG\" & configFile & " {filename}""")
        strLivestreamerProcess.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(strLivestreamerProcess)
        Return Nothing

    End Function

    Public Function writeNameToFile(racer As String, file As Integer)

        Dim strPathtoName As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\racer" & file & ".txt"
        Dim swRacer As System.IO.StreamWriter
        swRacer = My.Computer.FileSystem.OpenTextFileWriter(strPathtoName, False)
        swRacer.WriteLine(racer.ToLower)
        swRacer.Close()
        Return Nothing

    End Function

    Public Function writeNameToAutocomplete(racer As String)

        Dim listOfStrHash As List(Of String) = New List(Of String)(System.IO.File.ReadAllLines(My.Settings.strPathToStreamerFile))

        If Not listOfStrHash.Contains(racer.ToLower) Then
            Dim w As New StreamWriter(My.Settings.strPathToStreamerFile)
            w.WriteLine(racer.ToLower, True)
            w.Close()
        End If

        Call setupAutocompleteSources()
        Return Nothing

    End Function

End Class