Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmSchedule

    Private Sub frmSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim frmMainLocation As Point = frmMain.Location
        Me.Location = New Point((frmMainLocation.X - (Me.Width - frmMain.Width)), (frmMainLocation.Y))

        Me.AcceptButton = btnFilter
        txtFilter.Select()
        sqlCall()

    End Sub

    Public Sub sqlCall()

        Dim sqlDataAdapter As New MySqlDataAdapter
        Dim dt As New DataTable
        Dim bSource As New BindingSource

        Dim sqlconn = New MySqlConnection("server=condor.host;userid=necrobot-read;password=necrobot-read;database=necrobot;")
        Dim filterText As String = txtFilter.Text

        Try
            sqlconn.Open()
            Dim query As String
            query = "call current_event_schedule(""" + filterText + """);"

            Dim sqlcommand = New MySqlCommand(query, sqlconn)
            sqlcommand.Parameters.Add("@filter", MySqlDbType.VarChar).Value = filterText
            sqlDataAdapter.SelectCommand = sqlcommand
            sqlDataAdapter.Fill(dt)
            bSource.DataSource = dt
            dgvSchedule.Columns(0).DataPropertyName = "Time"
            dgvSchedule.Columns(1).DataPropertyName = "Racer 1"
            dgvSchedule.Columns(2).DataPropertyName = "Racer 2"

            dgvSchedule.AutoGenerateColumns = False
            sqlDataAdapter.Update(dt)

            sqlconn.Close()
            dgvSchedule.DataSource = bSource

            dgvSchedule.Sort(timestamp, System.ComponentModel.ListSortDirection.Ascending)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlconn.Dispose()
        End Try

    End Sub

    Private Sub dgvScheduleRowClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvSchedule.CellMouseDoubleClick
        Dim index As Integer = e.RowIndex
        Dim selectedRow As DataGridViewRow = dgvSchedule.Rows(index)

        frmMain.chkStream1.Checked = False
        frmMain.chkStream2.Checked = False
        frmMain.txtStream1.Text = selectedRow.Cells(1).Value.ToString
        frmMain.txtStream2.Text = selectedRow.Cells(2).Value.ToString

        frmMain.btnGenAll.PerformClick()

        Me.Close()

    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click

        sqlCall()

    End Sub

End Class