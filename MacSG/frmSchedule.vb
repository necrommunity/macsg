Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class frmSchedule
    Dim epoch As New DateTime(1970, 1, 1)
    Dim week1Start As New DateTime(2017, 2, 25, 23, 0, 0)
    Dim week2Start As New DateTime(2017, 3, 4, 23, 0, 0)
    Dim week3Start As New DateTime(2017, 3, 11, 23, 0, 0)
    Dim week4Start As New DateTime(2017, 3, 18, 23, 0, 0)
    Dim week5Start As New DateTime(2017, 3, 25, 23, 0, 0)
    Dim weekCurrent As DateTime = DateTime.UtcNow
    Dim weekNumber As Integer

    Private Sub frmSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        sqlCall()

    End Sub

    Public Sub sqlCall()

        Select Case weekCurrent
            Case Is < week2Start
                weekNumber = 1
            Case Is < week3Start
                weekNumber = 2
            Case Is < week4Start
                weekNumber = 3
            Case Is < week5Start
                weekNumber = 4
            Case Is < (week5Start.AddDays(7))
                weekNumber = 5
        End Select

        Dim sqlDataAdapter As New MySqlDataAdapter
        Dim dt As New DataTable
        Dim bSource As New BindingSource

        Dim sqlconn = New MySqlConnection("server=condor.host;userid=necrobot-read;password=necrobot-read;database=condor_s5;")

        Try
            sqlconn.Open()
            Dim query As String
            If txtFilter.Text = "" Then
                query = "SELECT FROM_UNIXTIME(timestamp, '%d/%m/%y %T') AS timestamp, a.rtmp_name AS racer_1_rtmp_name, b.rtmp_name AS racer_2_rtmp_name, CASE WHEN league = 1 THEN ""Blood"" WHEN league = 2 THEN ""Titanium"" WHEN league = 3 THEN ""Obsidian"" WHEN league = 4 THEN ""Crystal"" WHEN league = 0 THEN ""Playoffs"" END AS league FROM condor_s5.match_data JOIN condor_s5.user_data a ON a.racer_id=racer_1_id JOIN condor_s5.user_data b ON b.racer_id=racer_2_id WHERE week_number = @weekNumber AND flags & 8 !=0 AND flags & 16 != 0;"
            Else
                query = "SELECT FROM_UNIXTIME(timestamp, '%d/%m/%y %T') AS timestamp, a.rtmp_name AS racer_1_rtmp_name, b.rtmp_name AS racer_2_rtmp_name, CASE WHEN league = 1 THEN ""Blood"" WHEN league = 2 THEN ""Titanium"" WHEN league = 3 THEN ""Obsidian"" WHEN league = 4 THEN ""Crystal"" WHEN league = 0 THEN ""Playoffs"" END AS league FROM condor_s5.match_data JOIN condor_s5.user_data a ON a.racer_id=racer_1_id JOIN condor_s5.user_data b ON b.racer_id=racer_2_id WHERE week_number = @weekNumber AND (a.rtmp_name = @filter OR b.rtmp_name = @filter OR league = @filter) AND flags & 8 !=0 AND flags & 16 != 0;"
            End If

            Dim sqlcommand = New MySqlCommand(query, sqlconn)
            sqlcommand.Parameters.Add("@weekNumber", MySqlDbType.Int16).Value = weekNumber
            sqlcommand.Parameters.Add("@filter", MySqlDbType.VarChar).Value = txtFilter.Text
            sqlDataAdapter.SelectCommand = sqlcommand
            sqlDataAdapter.Fill(dt)
            bSource.DataSource = dt
            dgvSchedule.Columns(0).DataPropertyName = "timestamp"
            dgvSchedule.Columns(1).DataPropertyName = "racer_1_rtmp_name"
            dgvSchedule.Columns(2).DataPropertyName = "racer_2_rtmp_name"
            dgvSchedule.Columns(3).DataPropertyName = "league"

            dgvSchedule.AutoGenerateColumns = False
            sqlDataAdapter.Update(dt)

            sqlconn.Close()
            dgvSchedule.DataSource = bSource

            dgvSchedule.Sort(timestamp, System.ComponentModel.ListSortDirection.Descending)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlconn.Dispose()
        End Try

    End Sub

    Private Sub dgvScheduleRowClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSchedule.CellMouseDoubleClick
        Dim index As Integer = e.RowIndex
        Dim selectedRow As DataGridViewRow = dgvSchedule.Rows(index)

        frmMain.txtStream1.Text = selectedRow.Cells(1).Value.ToString
        frmMain.txtStream2.Text = selectedRow.Cells(2).Value.ToString

        frmMain.btnGenAll.PerformClick()

    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click

        sqlCall()

    End Sub

    Private Sub colourRows() Handles dgvSchedule.Sorted
        For Each row As DataGridViewRow In dgvSchedule.Rows
            If row.Cells("league").Value.Equals("Blood") Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(234, 153, 153)
            ElseIf row.Cells("league").Value.Equals("Titanium") Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(243, 243, 243)
            ElseIf row.Cells("league").Value.Equals("Obsidian") Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(217, 210, 233)
            ElseIf row.Cells("league").Value.Equals("Crystal") Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(207, 226, 243)
            ElseIf row.Cells("league").Value.Equals("Playoffs") Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 229, 153)
            End If
        Next
    End Sub

End Class