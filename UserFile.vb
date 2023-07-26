Imports System.Collections.ObjectModel
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class UserFile
    Private Sub UserFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoginForm.Sqlconnection.Open()

        Dim cmd As New SqlCommand("Select userid, username From tblemployee", LoginForm.Sqlconnection)
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        cmd.CommandTimeout = 60 ' Set the timeout value in seconds
        Dim userfile As New DataTable()
        userfile.Load(reader)
        DataGridView1.DataSource = userfile

        LoginForm.Sqlconnection.Close()
    End Sub
End Class