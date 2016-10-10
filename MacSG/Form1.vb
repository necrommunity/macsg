Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports JCS

Public Class Form1
    Dim strColAutoCompleteList As New AutoCompleteStringCollection
    Dim strLiveStreamer1 As String = "livestreamer --twitch-oauth-token " + My.Settings.strTwitchOAuthKey + " --hls-segment-threads 4 twitch.tv/"
    Dim strLiveStreamer2 As String = "livestreamer --twitch-oauth-token " + My.Settings.strTwitchOAuthKey + " --hls-segment-threads 4 twitch.tv/"
    Dim strLiveStreamer3 As String = "livestreamer --twitch-oauth-token " + My.Settings.strTwitchOAuthKey + " --hls-segment-threads 4 twitch.tv/"
    Dim strLiveStreamer4 As String = "livestreamer --twitch-oauth-token " + My.Settings.strTwitchOAuthKey + " --hls-segment-threads 4 twitch.tv/"
    Dim strLivestreamerInstaller As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\livestreamer-v1.12.2-win32-setup.exe"

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

        If My.Settings.strPathToStreamerFile = "" Then
            My.Settings.strPathToStreamerFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\MacSG\streamerlist.conf"
        End If

        setupLivestreamerCheck()
        setupToggleSwitches()
        setupAutocompleteSources()
        setupTwitchOAuth()
    End Sub

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

    Public Sub setupLivestreamerCheck()
        If Not File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) & "\Livestreamer\livestreamer.exe") Then
            Dim boolLivestreamerInstall As Integer = MessageBox.Show("Livestreamer is not installed, and is necessary for this program to run.  Would you like to download and install Livestreamer now?", "No Livestreamer installation detected", MessageBoxButtons.YesNoCancel)

            If boolLivestreamerInstall = DialogResult.No Or boolLivestreamerInstall = DialogResult.Cancel Then
                Close()

            ElseIf boolLivestreamerInstall = DialogResult.Yes Then
                Dim client As New WebClient()
                AddHandler client.DownloadProgressChanged, AddressOf ShowDownloadProgress
                AddHandler client.DownloadFileCompleted, AddressOf DownloadFileCompleted

                client.DownloadFileAsync(New Uri("https://github.com/chrippa/livestreamer/releases/download/v1.12.2/livestreamer-v1.12.2-win32-setup.exe"), strLivestreamerInstaller)

                For Each ctrl In Me.Controls
                    ctrl.Enabled = False
                Next

            End If
        End If

    End Sub

    Private Sub ShowDownloadProgress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        ProgressBar1.Visible = True
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Public Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        If Not e.Cancelled AndAlso e.Error Is Nothing Then
            ProgressBar1.Visible = False
            Process.Start(strLivestreamerInstaller)
            For Each ctrl In Me.Controls
                ctrl.Enabled = True
            Next

        Else
            MessageBox.Show("Fucked")
            ProgressBar1.Visible = False
        End If
    End Sub

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

    'Trackbar values
    Private Sub stream1Trackbar_Scroll(sender As Object, e As EventArgs) Handles trkbrStream1.Scroll

        strQuality1 = trkbrStream1.Value

        Select Case strQuality1
            Case 1
                strQuality1 = " low "
            Case 2
                strQuality1 = " medium "
            Case 3
                strQuality1 = " high "
            Case 4
                strQuality1 = " source "
        End Select
    End Sub

    Private Sub stream2Trackbar_Scroll(sender As Object, e As EventArgs) Handles trkbrStream2.Scroll
        strQuality2 = trkbrStream1.Value

        Select Case strQuality2
            Case 1
                strQuality2 = " low "
            Case 2
                strQuality2 = " medium "
            Case 3
                strQuality2 = " high "
            Case 4
                strQuality2 = " source "
        End Select
    End Sub

    Private Sub stream3Trackbar_Scroll(sender As Object, e As EventArgs) Handles trkbrStream3.Scroll
        strQuality3 = trkbrStream1.Value

        Select Case strQuality3
            Case 1
                strQuality3 = " low "
            Case 2
                strQuality3 = " medium "
            Case 3
                strQuality3 = " high "
            Case 4
                strQuality3 = " source "
        End Select
    End Sub

    Private Sub stream4Trackbar_Scroll(sender As Object, e As EventArgs) Handles trkbrStream4.Scroll
        strQuality4 = trkbrStream1.Value

        Select Case strQuality4
            Case 1
                strQuality4 = " low "
            Case 2
                strQuality4 = " medium "
            Case 3
                strQuality4 = " high "
            Case 4
                strQuality4 = " source "
        End Select
    End Sub


    'Stream generation buttons
    Private Sub btnStream1Gen_Click(sender As Object, e As EventArgs) Handles btnStream1Gen.Click

        If txtStream1.Text.ToLower <> "" Then

            'Checks if VLC window with same title exists - does nothing if it does, continues if it does not
            On Error Resume Next
            AppActivate("First - VLC Media Player")
            If Err.Number <> 0 Then

                'Create and start Livestreamer process
                Dim strLivestreamerProcess As New ProcessStartInfo("cmd.exe", "/c title FirstCMD &" & strLiveStreamer1 + txtStream1.Text.ToLower + strQuality1 + "--player-args " + Chr(34) + "--config %AppData%\MacSG\1 {filename}" + Chr(34))
                strLivestreamerProcess.WindowStyle = ProcessWindowStyle.Hidden
                Process.Start(strLivestreamerProcess)

                btnStream1Gen.Enabled = False

                'Write racer name to file if it doesn't exist in file already
                Dim swRacer1 As System.IO.StreamWriter
                swRacer1 = My.Computer.FileSystem.OpenTextFileWriter(strPathtoName1, False)
                swRacer1.WriteLine(txtStream1.Text.ToLower)
                swRacer1.Close()

                Dim listOfStrHash As List(Of String) = New List(Of String)(System.IO.File.ReadAllLines(My.Settings.strPathToStreamerFile))

                If Not listOfStrHash.Contains(txtStream1.Text.ToLower) Then
                    Dim w As New IO.StreamWriter(My.Settings.strPathToStreamerFile, True)
                    w.WriteLine(txtStream1.Text.ToLower, True)
                    w.Close()

                    System.Threading.Thread.Sleep(1000)
                    btnStream1Gen.Enabled = True
                End If

                btnStream1Gen.Enabled = True
                Call setupAutocompleteSources()

            End If
        End If
    End Sub

    Private Sub btnStream2Gen_Click(sender As Object, e As EventArgs) Handles btnStream2Gen.Click
        If txtStream2.Text.ToLower <> "" Then
            On Error Resume Next
            AppActivate("Second - VLC Media Player")

            If Err.Number <> 0 Then

                Dim strLivestreamerProcess As New ProcessStartInfo("cmd.exe", "/c title SecondCMD &" & strLiveStreamer2 + txtStream2.Text.ToLower + strQuality2 + "--player-args " + Chr(34) + "--config %AppData%\MacSG\2 {filename}" + Chr(34))
                strLivestreamerProcess.WindowStyle = ProcessWindowStyle.Hidden
                Process.Start(strLivestreamerProcess)

                btnStream2Gen.Enabled = False

                Dim swRacer2 As System.IO.StreamWriter
                swRacer2 = My.Computer.FileSystem.OpenTextFileWriter(strPathtoName2, False)
                swRacer2.WriteLine(txtStream2.Text.ToLower)
                swRacer2.Close()

                Dim listOfStrHash As List(Of String) = New List(Of String)(System.IO.File.ReadAllLines(My.Settings.strPathToStreamerFile))

                If Not listOfStrHash.Contains(txtStream2.Text.ToLower) Then
                    Dim w As New IO.StreamWriter(My.Settings.strPathToStreamerFile, True)
                    w.WriteLine(txtStream2.Text.ToLower, True)
                    w.Close()

                    System.Threading.Thread.Sleep(1000)
                    btnStream2Gen.Enabled = True
                End If
                btnStream2Gen.Enabled = True
                Call Form1_Load(Me, e)
            End If
        End If
    End Sub

    Private Sub btnStream3Gen_Click(sender As Object, e As EventArgs) Handles btnStream3Gen.Click
        If txtStream3.Text.ToLower <> "" Then
            On Error Resume Next
            AppActivate("Third - VLC Media Player")

            If Err.Number <> 0 Then

                Dim strLivestreamerProcess As New ProcessStartInfo("cmd.exe", "/c title ThirdCMD &" & strLiveStreamer3 + txtStream3.Text.ToLower + strQuality3 + "--player-args " + Chr(34) + "--config %AppData%\MacSG\3 {filename}" + Chr(34))
                strLivestreamerProcess.WindowStyle = ProcessWindowStyle.Hidden
                Process.Start(strLivestreamerProcess)

                btnStream3Gen.Enabled = False

                Dim swRacer3 As System.IO.StreamWriter
                swRacer3 = My.Computer.FileSystem.OpenTextFileWriter(strPathtoName3, False)
                swRacer3.WriteLine(txtStream3.Text.ToLower)
                swRacer3.Close()

                Dim listOfStrHash As List(Of String) = New List(Of String)(System.IO.File.ReadAllLines(My.Settings.strPathToStreamerFile))

                If Not listOfStrHash.Contains(txtStream3.Text.ToLower) Then
                    Dim w As New IO.StreamWriter(My.Settings.strPathToStreamerFile, True)
                    w.WriteLine(txtStream3.Text.ToLower, True)
                    w.Close()

                    System.Threading.Thread.Sleep(1000)
                    btnStream3Gen.Enabled = True
                End If
                btnStream3Gen.Enabled = True
                Call Form1_Load(Me, e)
            End If
        End If
    End Sub

    Private Sub btnStream4Gen_Click(sender As Object, e As EventArgs) Handles btnStream4Gen.Click
        If txtStream4.Text.ToLower <> "" Then
            On Error Resume Next
            AppActivate("Fourth - VLC Media Player")

            If Err.Number <> 0 Then
                Dim strLivestreamerProcess As New ProcessStartInfo("cmd.exe", "/c title FourthCMD &" & strLiveStreamer4 + txtStream4.Text.ToLower + strQuality4 + "--player-args " + Chr(34) + "--config %AppData%\MacSG\4 {filename}" + Chr(34))
                strLivestreamerProcess.WindowStyle = ProcessWindowStyle.Hidden
                Process.Start(strLivestreamerProcess)

                btnStream4Gen.Enabled = False

                Dim swRacer4 As System.IO.StreamWriter
                swRacer4 = My.Computer.FileSystem.OpenTextFileWriter(strPathtoName4, False)
                swRacer4.WriteLine(txtStream4.Text.ToLower)
                swRacer4.Close()

                Dim listOfStrHash As List(Of String) = New List(Of String)(System.IO.File.ReadAllLines(My.Settings.strPathToStreamerFile))

                If Not listOfStrHash.Contains(txtStream4.Text.ToLower) Then
                    Dim w As New IO.StreamWriter(My.Settings.strPathToStreamerFile, True)
                    w.WriteLine(txtStream4.Text.ToLower, True)
                    w.Close()

                    System.Threading.Thread.Sleep(1000)
                    btnStream4Gen.Enabled = True
                End If
                btnStream4Gen.Enabled = True
                Call Form1_Load(Me, e)
            End If
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

    'Select file to use as autocomplete source
    Private Sub selectAutocompleteFile_Click(sender As Object, e As EventArgs) Handles selectAutocompleteFile.Click

        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Select a file..."
        fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData + "\MacSG")
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
    Private Sub aboutCoNDORSGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles aboutCoNDORSGToolStripMenuItem.Click
        MessageBox.Show("Version 0.5.1 - by MacKirby" & vbCrLf & vbCrLf & "This program is provided free of use for managing stream captures for tournaments on Twitch.  Got feedback?  Drop me an email - mac@mackirby.tv", "About MacSG", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ChangeWindowSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeWindowSizeToolStripMenuItem.Click
        My.Settings.strWindowSize = InputBox("Define window size for VLC - enter the resolution as ""width height"".  Recommended sizes:" & vbCrLf & "1920x1080: 882x520" & vbCrLf & "1440x900: 642x385", "Define window size...", "882 520")
    End Sub

    Private Sub updStream1_ValueChanged(sender As Object, e As EventArgs) Handles updStream1.ValueChanged
        Dim swScore1 As System.IO.StreamWriter
        swScore1 = My.Computer.FileSystem.OpenTextFileWriter(strPathToScore1, False)
        swScore1.WriteLine(updStream1.Value)
        swScore1.Close()
    End Sub

    Private Sub updStream2_ValueChanged(sender As Object, e As EventArgs) Handles updStream2.ValueChanged
        Dim swScore2 As System.IO.StreamWriter
        swScore2 = My.Computer.FileSystem.OpenTextFileWriter(strPathToScore2, False)
        swScore2.WriteLine(updStream2.Value)
        swScore2.Close()
    End Sub

    Private Sub updStream3_ValueChanged(sender As Object, e As EventArgs) Handles updStream3.ValueChanged
        Dim swScore3 As System.IO.StreamWriter
        swScore3 = My.Computer.FileSystem.OpenTextFileWriter(strPathToScore3, False)
        swScore3.WriteLine(updStream3.Value)
        swScore3.Close()
    End Sub

    Private Sub updStream4_ValueChanged(sender As Object, e As EventArgs) Handles updStream4.ValueChanged
        Dim swScore4 As System.IO.StreamWriter
        swScore4 = My.Computer.FileSystem.OpenTextFileWriter(strPathToScore4, False)
        swScore4.WriteLine(updStream4.Value)
        swScore4.Close()
    End Sub

    Private Sub btnGenAll_Click(sender As Object, e As EventArgs) Handles btnGenAll.Click
        btnStream1Gen_Click(btnStream1Gen, New EventArgs)
        btnStream2Gen_Click(btnStream2Gen, New EventArgs)
        btnStream3Gen_Click(btnStream3Gen, New EventArgs)
        btnStream4Gen_Click(btnStream4Gen, New EventArgs)
    End Sub

    Private Sub ToggleSwitch1_CheckedChanged_1(sender As Object, e As EventArgs) Handles switchStream1.CheckedChanged
        If switchStream1.Checked = True Then
            strQuality1 = "/live best "

            trkbrStream1.Enabled = False

            strLiveStreamer1 = "livestreamer rtmp://rtmp.condorleague.tv/"
        Else
            strQuality1 = " source "

            trkbrStream1.Enabled = True

            strLiveStreamer1 = "livestreamer --hls-segment-threads 4 twitch.tv/"
        End If
    End Sub

    Private Sub ToggleSwitch2_CheckedChanged_1(sender As Object, e As EventArgs) Handles switchStream2.CheckedChanged
        If switchStream2.Checked = True Then
            strQuality2 = "/live best "

            trkbrStream2.Enabled = False

            strLiveStreamer2 = "livestreamer rtmp://rtmp.condorleague.tv/"
        Else
            strQuality2 = " source "

            trkbrStream2.Enabled = True

            strLiveStreamer2 = "livestreamer --hls-segment-threads 4 twitch.tv/"
        End If
    End Sub

    Private Sub ToggleSwitch3_CheckedChanged_1(sender As Object, e As EventArgs) Handles switchStream3.CheckedChanged
        If switchStream3.Checked = True Then
            strQuality3 = "/live best "

            trkbrStream3.Enabled = False

            strLiveStreamer3 = "livestreamer rtmp://rtmp.condorleague.tv/"
        Else
            strQuality3 = " source "

            trkbrStream3.Enabled = True

            strLiveStreamer3 = "livestreamer --hls-segment-threads 4 twitch.tv/"
        End If
    End Sub

    Private Sub ToggleSwitch4_CheckedChanged_1(sender As Object, e As EventArgs) Handles switchStream4.CheckedChanged
        If switchStream4.Checked = True Then
            strQuality4 = "/live best "

            trkbrStream4.Enabled = False

            strLiveStreamer4 = "livestreamer rtmp://rtmp.condorleague.tv/"
        Else
            strQuality4 = " source "

            trkbrStream4.Enabled = True

            strLiveStreamer4 = "livestreamer --hls-segment-threads 4 twitch.tv/"
        End If
    End Sub

    Public Sub EditAutocompleteFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditAutocompleteFileToolStripMenuItem.Click
        Dim frmEditStreamerList As New Form2()
        frmEditStreamerList.Show()
    End Sub

    Private Sub ChangeTwitchOAuthKeyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeTwitchOAuthKeyToolStripMenuItem.Click
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
End Class