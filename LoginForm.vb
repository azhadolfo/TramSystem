Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Public Class LoginForm
    Public Shared connectionString As String = "Provider=VFPOLEDB; Data Source=\\192.168.0.251\OTC System\_Tramsystem\FoxData\"
    Public Shared connectionsString As String = "Data Source=WIN-IU3ACLEQUUI;Initial Catalog=vb_crud;Persist Security Info=True;User ID=user3;Password=twainc."
    Public Shared Vfpconnection As New OleDbConnection(connectionString)
    Public Shared Sqlconnection As SqlConnection = New SqlConnection(connectionsString)

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        '    LoginForm.Vfpconnection.Open()
        '    LoginForm.Sqlconnection.Open()

        '    'Retrieve Data from sumpay table into cursumpay DataTable
        '    Dim sumpay_cmd As New OleDbCommand("Select * From sumpay Where !EMPTY(voucher_no) And !EMPTY(gl_posted) And !cancel", LoginForm.Vfpconnection)
        '    Dim sumpay_reader As OleDbDataReader = sumpay_cmd.ExecuteReader()
        '    sumpay_cmd.CommandTimeout = 60 ' Set the timeout value in seconds
        '    Dim cursumpay As New DataTable()
        '    cursumpay.Load(sumpay_reader)
        '    'DataGridView1.DataSource = cursumpay

        '    'Retrieve Data from apledger table into curapledger DataTable
        '    Dim tempapledger_cmd As New OleDbCommand("Select * From apledger WHERE trn_date >= CTOD('1753-01-01')", LoginForm.Vfpconnection)
        '    Dim tempapledger_reader As OleDbDataReader = tempapledger_cmd.ExecuteReader()
        '    tempapledger_cmd.CommandTimeout = 60 ' Set the timeout value in seconds
        '    Dim tempapledger As New DataTable()
        '    tempapledger.Load(tempapledger_reader)
        '    ' DataGridView1.DataSource = curapledger



        '    ' Retrieve data from chracct table into curchracct DataTable
        '    Dim chracct_cmd As New OleDbCommand("Select * From chracct", LoginForm.Vfpconnection)
        '    Dim chracct_reader As OleDbDataReader = chracct_cmd.ExecuteReader()
        '    chracct_cmd.CommandTimeout = 60 ' Set the timeout value in seconds
        '    Dim curchracct As New DataTable()
        '    curchracct.Load(chracct_reader)
        '    'DataGridView1.DataSource = curchracct

        '    ' Check if the destination table exists in SQL Server
        '    Dim tableExistsSumPay As Boolean = CheckIfTableExists("tblsumpay", LoginForm.Sqlconnection)
        '    Dim tableExistsTempApLedger As Boolean = CheckIfTableExists("curapledger", LoginForm.Sqlconnection)

        '    Dim tableExistsChrAcct As Boolean = CheckIfTableExists("tblchracct", LoginForm.Sqlconnection)

        '    ' Create or replace the destination table in SQL Server
        '    If Not tableExistsSumPay Then
        '        CreateDestinationTable(cursumpay, "tblsumpay", LoginForm.Sqlconnection)
        '    End If
        '    If Not tableExistsTempApLedger Then
        '        CreateDestinationTable(tempapledger, "curapledger", LoginForm.Sqlconnection)
        '    End If
        '    If Not tableExistsChrAcct Then
        '        CreateDestinationTable(curchracct, "tblchracct", LoginForm.Sqlconnection)
        '    End If


        '    'Use SqlBulkCopy to send sumpay DataTable to SQL Server
        '    Using bulkCopy As New SqlBulkCopy(LoginForm.Sqlconnection)
        '        bulkCopy.DestinationTableName = "tblsumpay"
        '        MapColumns(cursumpay, bulkCopy)
        '        bulkCopy.WriteToServer(cursumpay)
        '    End Using

        '    'Use SqlBulkCopy to send apledger DataTable to SQL Server
        '    Using bulkCopy As New SqlBulkCopy(LoginForm.Sqlconnection)
        '        bulkCopy.DestinationTableName = "curapledger"
        '        MapColumns(tempapledger, bulkCopy)
        '        bulkCopy.WriteToServer(tempapledger)
        '    End Using

        '    ' Use SqlBulkCopy to send curchracct DataTable to SQL Server
        '    Using bulkCopy As New SqlBulkCopy(LoginForm.Sqlconnection)
        '        bulkCopy.DestinationTableName = "tblchracct"
        '        MapColumns(curchracct, bulkCopy)
        '        bulkCopy.WriteToServer(curchracct)
        '    End Using

        '    ' Close the readers if they were opened
        '    sumpay_reader.Close()
        '    tempapledger_reader.Close()
        '    chracct_reader.Close()
        'Catch ex As Exception
        '    MessageBox.Show("Error: " & ex.Message)

        'Finally
        '    ' Close the connection if it was opened
        '    If LoginForm.Sqlconnection.State = ConnectionState.Open Then
        '        LoginForm.Sqlconnection.Close()
        '    End If

        '    If LoginForm.Vfpconnection.State = ConnectionState.Open Then
        '        LoginForm.Vfpconnection.Close()
        '    End If
        'End Try
    End Sub


    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click

        '-------Sql Connection-----------'
        'This is the Connection to Sql Server'

        'This is the command to sql'

        Dim password As String = txtPassword.Text
        Dim hashedPassword As String = HashPassword(password)

        Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM tblemployee WHERE userid=@userid AND password=@password", Sqlconnection)
        cmd.Parameters.AddWithValue("@userid", txtUsername.Text)
        cmd.Parameters.AddWithValue("@password", hashedPassword)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)

        'Conditional check'
        If dt.Rows.Count > 0 Then
            username = txtUsername.Text
            admin = dt.Rows(0)("admin")
            allowGetdata = dt.Rows(0)("allowgetdata")
            allowEdit = dt.Rows(0)("allowedit")
            allowReport = dt.Rows(0)("allowreport")
            allowUser = dt.Rows(0)("allowuserfile")
            allowTugboat = dt.Rows(0)("allowtugboat")
            MessageBox.Show("Successfully Login", "Information", MessageBoxButtons.OK)
            MainForm.ShowDialog()
            Me.Close()
        Else
            MessageBox.Show("Invalid password and username", "Information", MessageBoxButtons.OK)
        End If
        '------- End of Sql Connection-----------'
    End Sub
    'Public Function GenerateCreateTableQuery(dataTable As DataTable, tableName As String) As String
    '    Dim sb As New StringBuilder()
    '    sb.AppendLine($"IF OBJECT_ID('{tableName}', 'U') IS NOT NULL")
    '    sb.AppendLine($"    DROP TABLE {tableName}")
    '    sb.AppendLine($"CREATE TABLE {tableName} (")

    '    For Each column As DataColumn In dataTable.Columns
    '        Dim columnName As String = column.ColumnName
    '        Dim columnType As String = "NVARCHAR(MAX)" ' Change to the appropriate default type
    '        sb.AppendLine($"[{columnName}] {columnType},")
    '    Next

    '    sb.Length -= 3 ' Remove the trailing comma and newline
    '    sb.AppendLine()
    '    sb.AppendLine(")")

    '    Return sb.ToString()
    'End Function

    'Private Function CheckIfTableExists(tableName As String, connection As SqlConnection) As Boolean
    '    Dim query As String = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'"
    '    Using command As New SqlCommand(query, connection)
    '        Dim count As Integer = CInt(command.ExecuteScalar())
    '        Return count > 0
    '    End Using
    'End Function

    'Private Sub CreateDestinationTable(dataTable As DataTable, tableName As String, connection As SqlConnection)
    '    Dim createTableQuery As String = GenerateCreateTableQuery(dataTable, tableName)
    '    Using createTableCmd As New SqlCommand(createTableQuery, connection)
    '        createTableCmd.ExecuteNonQuery()
    '    End Using
    'End Sub
    'Private Sub MapColumns(dataTable As DataTable, bulkCopy As SqlBulkCopy)
    '    For Each column As DataColumn In dataTable.Columns
    '        bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName)
    '    Next
    'End Sub

    'Private Function GetColumnType(dataType As Type) As String
    '    If dataType Is GetType(String) Then
    '        Return "NVARCHAR(MAX)"
    '    ElseIf dataType Is GetType(Integer) Then
    '        Return "INT"
    '    ElseIf dataType Is GetType(Decimal) Then
    '        Return "DECIMAL(18, 2)"
    '    ElseIf dataType Is GetType(Date) Then
    '        Return "DATE"
    '    ElseIf dataType Is GetType(DateTime) Then
    '        Return "DATETIME"
    '    Else
    '        ' Handle any other data types here '
    '        Return "NCHAR(MAX)"
    '    End If
    'End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        StartForm.Close()
    End Sub
End Class