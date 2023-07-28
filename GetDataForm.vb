Imports System.Data.SqlClient
Imports System.Text

Public Class GetDataForm
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoginForm.Sqlconnection.Open()
        'Dim apledger_cmd As New SqlCommand("SELECT * FROM curapledger WHERE trans_no IN (SELECT DISTINCT trans_no FROM tblsumpay)", LoginForm.Sqlconnection)
        'apledger_cmd.CommandTimeout = 300 ' Set the timeout value in seconds
        'Dim apledger_adapter As New SqlDataAdapter(apledger_cmd)
        'Dim curapledger As New DataTable()
        'apledger_adapter.Fill(curapledger)

        'Dim tableExistsApLedger As Boolean = CheckIfTableExists("tblapledger", LoginForm.Sqlconnection)


        'If Not tableExistsApLedger Then
        '    CreateDestinationTable(curapledger, "tblapledger", LoginForm.Sqlconnection)
        'End If

        'Using bulkCopy As New SqlBulkCopy(LoginForm.Sqlconnection)
        '    bulkCopy.DestinationTableName = "tblapledger"
        '    MapColumns(curapledger, bulkCopy)
        '    bulkCopy.WriteToServer(curapledger)
        'End Using

        ' Drop the temporary table in SQL Server '
        Dim tableName As String = "atrail"
        Dim dropTableQuery As String = $"DELETE FROM {tableName}"
        Dim dropTableCommand As New SqlCommand(dropTableQuery, LoginForm.Sqlconnection)
        dropTableCommand.ExecuteNonQuery()



        LoginForm.Sqlconnection.Close()
    End Sub
    Public Function GenerateCreateTableQuery(dataTable As DataTable, tableName As String) As String
        Dim sb As New StringBuilder()
        sb.AppendLine($"IF OBJECT_ID('{tableName}', 'U') IS NOT NULL")
        sb.AppendLine($"    DROP TABLE {tableName}")
        sb.AppendLine($"CREATE TABLE {tableName} (")

        For Each column As DataColumn In dataTable.Columns
            Dim columnName As String = column.ColumnName
            Dim columnType As String = "NVARCHAR(MAX)" ' Change to the appropriate default type
            sb.AppendLine($"[{columnName}] {columnType},")
        Next

        sb.Length -= 3 ' Remove the trailing comma and newline
        sb.AppendLine()
        sb.AppendLine(")")

        Return sb.ToString()
    End Function
    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        Try

            Dim applicationPath As String = "C:\DCRSystem\dcr.exe" ' Replace with the path to your application

            ' Start the application
            Process.Start(applicationPath)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "CONTACT MIS DEPARTMENT")
            LoginForm.Sqlconnection.Close()
        End Try

        ''Getting the dated pick by user'
        'Dim dFrom As Date = dtDateFrom.Value.Date
        'Dim dTo As Date = dtDateTo.Value.Date
        ''loadingForm.Show()
        'LoginForm.Sqlconnection.Open()

        'Dim command As New SqlCommand("SELECT voucher_no, vch_date, payee, amount, particular, checkno, chkdate, bank, trans_no
        '                   FROM tblsumpay
        '                   WHERE vch_date >= @dFrom AND vch_date <= @dTo AND trans_no IN
        '                   (
        '                       SELECT DISTINCT trans_no
        '                       FROM tblapledger
        '                       WHERE acct_no IN ('520027', '520035', '210080010') AND  vch_date  >= @dFrom AND vch_date  <= @dTo
        '                   )
        '                   ORDER BY vch_date, voucher_no", LoginForm.Sqlconnection)

        'command.Parameters.AddWithValue("@dFrom", dFrom)
        'command.Parameters.AddWithValue("@dTo", dTo)

        'Dim curheader_adapter As New SqlDataAdapter(command)
        'command.CommandTimeout = 60
        'Dim curheader As New DataTable()
        'curheader_adapter.Fill(curheader)

        'Dim tableExistsCurheader As Boolean = CheckIfTableExists("curheader", LoginForm.Sqlconnection)

        'If Not tableExistsCurheader Then
        '    CreateDestinationTable(curheader, "curheader", LoginForm.Sqlconnection)
        'End If

        'Using bulkCopy As New SqlBulkCopy(LoginForm.Sqlconnection)
        '    bulkCopy.DestinationTableName = "curheader"
        '    MapColumns(curheader, bulkCopy)
        '    bulkCopy.WriteToServer(curheader)
        'End Using

        'If curheader.Rows.Count = 0 Then
        '    MessageBox.Show("No data found. Please try again.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    LoginForm.Sqlconnection.Close()
        '    Return
        'End If

        '' Create a dictionary to store the counts of data field values
        'Dim dataCounts As New Dictionary(Of String, Integer)()

        '' Iterate over each row in the stored DataTable
        'For Each row As DataRow In curheader.Rows
        '    Dim voucher_no As String = row("voucher_no").ToString()

        '    ' Check if the data field value already exists in the dictionary
        '    If dataCounts.ContainsKey(voucher_no) Then
        '        ' Increment the count for existing value
        '        dataCounts(voucher_no) += 1
        '    Else
        '        ' Add the data field value to the dictionary with an initial count of 1
        '        dataCounts.Add(voucher_no, 1)
        '    End If
        'Next

        '' Check for duplicate values in the dictionary
        'Dim hasDuplicates As Boolean = False

        'For Each kvp As KeyValuePair(Of String, Integer) In dataCounts
        '    Dim voucher_no As String = kvp.Key
        '    Dim count As Integer = kvp.Value

        '    ' Check if the count is greater than 1
        '    If count > 1 Then
        '        hasDuplicates = True
        '        Dim message As String = "Duplicate records found: " + vbCrLf +
        '                    "Please check CV# " + voucher_no
        '        MessageBox.Show(message, "Duplicate Records", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Else
        '        MsgBox("Downloaded " & count & " record(s).", 64, "System Message")
        '    End If
        'Next
        'LoginForm.Sqlconnection.Close()

        ''CREATING TABLE CURCHECK'
        'LoginForm.Sqlconnection.Open()
        'Dim curcheck_cmd As String = "SELECT voucher_no, COUNT(*) AS ctr FROM curheader GROUP BY voucher_no ORDER BY COUNT(*) DESC"
        'Dim curcheck_adapter As New SqlDataAdapter(curcheck_cmd, LoginForm.Sqlconnection)
        'Dim curcheck As New DataTable()
        'curcheck_adapter.Fill(curcheck)

        'Dim tableExistsCurcheck As Boolean = CheckIfTableExists("curcheck", LoginForm.Sqlconnection)


        'If Not tableExistsCurcheck Then
        '    CreateDestinationTable(curcheck, "curcheck", LoginForm.Sqlconnection)
        'End If

        'Using bulkCopy As New SqlBulkCopy(LoginForm.Sqlconnection)
        '    bulkCopy.DestinationTableName = "curcheck"
        '    MapColumns(curcheck, bulkCopy)
        '    bulkCopy.WriteToServer(curcheck)
        'End Using
        'LoginForm.Sqlconnection.Close()

        ''CREATING TABLE CURDETAIL'
        'LoginForm.Sqlconnection.Open()

        'Dim curdetail_cmd As New SqlCommand("SELECT a.trn_date, a.acct_no, b.acct_name, a.[desc], a.particular, a.debit, a.credit, a.trans_no " &
        '                              "FROM tblapledger AS a LEFT JOIN tblchracct AS b ON a.acct_no = b.acct_no " &
        '                              "WHERE a.trn_date >= @dFrom AND a.trn_date <= @dTo AND a.trans_no IN (SELECT DISTINCT trans_no FROM curheader) " &
        '                              "ORDER BY a.trn_date", LoginForm.Sqlconnection)
        'Dim curdetail_adapter As New SqlDataAdapter(curdetail_cmd)
        'curdetail_cmd.Parameters.AddWithValue("@dFrom", dFrom)
        'curdetail_cmd.Parameters.AddWithValue("@dTo", dTo)
        'Dim curdetail As New DataTable()
        'curdetail_adapter.Fill(curdetail)

        'Dim tableExistsCurdetail As Boolean = CheckIfTableExists("curdetail", LoginForm.Sqlconnection)


        'If Not tableExistsCurdetail Then
        '    CreateDestinationTable(curdetail, "curdetail", LoginForm.Sqlconnection)
        'End If

        'Using bulkCopy As New SqlBulkCopy(LoginForm.Sqlconnection)
        '    bulkCopy.DestinationTableName = "curdetail"
        '    MapColumns(curdetail, bulkCopy)
        '    bulkCopy.WriteToServer(curdetail)
        'End Using
        'LoginForm.Sqlconnection.Close()

        ''CHECKING IF THE VOUCHER EXIST OR NOT IF EXIST CHECK THE CHANGES AND UPDATE'
        'LoginForm.Sqlconnection.Open()
        'Dim nAddctr As Integer = 0

        'Dim cmd As New SqlCommand("SELECT * FROM curheader", LoginForm.Sqlconnection)
        'Dim reader As SqlDataReader = cmd.ExecuteReader()

        'Do While Not reader.IsClosed AndAlso reader.Read()
        '    Dim seekvar = reader("voucher_no").ToString()
        '    Dim m As New Dictionary(Of String, Object)()

        '    ' Assign values to m dictionary
        '    m("trans_no") = reader("trans_no")
        '    m("voucher_no") = reader("voucher_no")
        '    m("vch_date") = reader("vch_date")
        '    m("payee") = reader("payee")
        '    m("particular") = reader("particular")
        '    m("checkno") = reader("checkno")
        '    m("chkdate") = reader("chkdate")
        '    m("bank") = reader("bank")
        '    m("amount") = reader("amount")

        '    reader.Close()


        '    ' Check if voucher_no exists in voucher_hdr table
        '    Using voucher_hdr_cmd As New SqlCommand("SELECT * FROM voucher_hdr WHERE cvno = @seekvar", LoginForm.Sqlconnection)
        '        voucher_hdr_cmd.Parameters.AddWithValue("@seekvar", seekvar)
        '        Using seekReader As SqlDataReader = voucher_hdr_cmd.ExecuteReader()

        '            If Not seekReader.HasRows Then

        '                seekReader.Close()
        '                ' Insert new record into voucher_hdr table
        '                Using insertCommand As New SqlCommand("INSERT INTO voucher_hdr (transno, cvno, cvdate, payee, particular, checkno, checkdate, bank, amount, downloadedby, downloadeddate) " &
        '                                                      "VALUES (@transno, @cvno, @cvdate, @payee, @particular, @checkno, @checkdate, @bank, @amount, @downloadedby, @downloadeddate)", LoginForm.Sqlconnection)
        '                    ' Set parameter values for insertCommand
        '                    insertCommand.Parameters.AddWithValue("@transno", m("trans_no"))
        '                    insertCommand.Parameters.AddWithValue("@cvno", m("voucher_no"))
        '                    insertCommand.Parameters.AddWithValue("@cvdate", m("vch_date"))
        '                    insertCommand.Parameters.AddWithValue("@payee", m("payee"))
        '                    insertCommand.Parameters.AddWithValue("@particular", m("particular"))
        '                    insertCommand.Parameters.AddWithValue("@checkno", m("checkno"))
        '                    insertCommand.Parameters.AddWithValue("@checkdate", m("chkdate"))
        '                    insertCommand.Parameters.AddWithValue("@bank", m("bank"))
        '                    insertCommand.Parameters.AddWithValue("@amount", m("amount"))
        '                    Dim gcUserid As String = Environment.UserName
        '                    insertCommand.Parameters.AddWithValue("@downloadedby", gcUserid)
        '                    insertCommand.Parameters.AddWithValue("@downloadeddate", DateTime.Now)

        '                    insertCommand.ExecuteNonQuery()
        '                    nAddctr += 1
        '                End Using

        '            Else
        '                seekReader.Read()

        '                Dim lIschanged As Boolean = False

        '                ' Retrieve the values of the existing record in voucher_hdr table
        '                Dim nRecid As Integer = seekReader("recid")
        '                Dim cTransno As String = seekReader("transno").ToString()
        '                Dim cCvno As String = seekReader("cvno").ToString()
        '                Dim old_cvdate As DateTime = Convert.ToDateTime(seekReader("cvdate"))
        '                Dim old_payee As String = seekReader("payee").ToString()
        '                Dim old_particular As String = seekReader("particular").ToString()
        '                Dim old_checkno As String = seekReader("checkno").ToString()
        '                Dim dChkdate As DateTime = Convert.ToDateTime(seekReader("checkdate"))
        '                Dim cBank As String = seekReader("bank").ToString()
        '                Dim old_amount As Decimal = Convert.ToDecimal(seekReader("amount"))
        '                Dim dDldate As DateTime = Convert.ToDateTime(seekReader("downloadeddate"))
        '                Dim dDlby As String = seekReader("downloadedby").ToString()
        '                Dim lChanged As Boolean = Convert.ToBoolean(seekReader("ischanged"))
        '                Dim dChangeddate As DateTime = Convert.ToDateTime(seekReader("changeddate"))

        '                ' Compare the values with the new record
        '                If old_cvdate <> m("vch_date") Then
        '                    seekReader.Close()
        '                    lIschanged = True
        '                    old_cvdate = m("vch_date")
        '                End If

        '                If old_payee <> m("payee") Then
        '                    seekReader.Close()
        '                    lIschanged = True
        '                    old_payee = m("payee")
        '                End If

        '                If old_particular <> m("particular") Then
        '                    seekReader.Close()
        '                    lIschanged = True
        '                    old_particular = m("particular")
        '                End If

        '                If old_checkno <> m("checkno") Then
        '                    seekReader.Close()
        '                    lIschanged = True
        '                    old_checkno = m("checkno")
        '                End If

        '                If old_amount <> m("amount") Then
        '                    seekReader.Close()
        '                    lIschanged = True
        '                    old_amount = m("amount")
        '                End If

        '                If lIschanged Then
        '                    ' Update the existing record in voucher_hdr table
        '                    Using updateCommand As New SqlCommand("UPDATE voucher_hdr SET cvdate = @cvdate, payee = @payee, particular = @particular, checkno = @checkno, amount = @amount, ischanged = @ischanged, changeddate = @changeddate WHERE cvno = @seekvar", LoginForm.Sqlconnection)
        '                        ' Set parameter values for updateCommand
        '                        updateCommand.Parameters.AddWithValue("@cvdate", old_cvdate)
        '                        updateCommand.Parameters.AddWithValue("@payee", old_payee)
        '                        updateCommand.Parameters.AddWithValue("@particular", old_particular)
        '                        updateCommand.Parameters.AddWithValue("@checkno", old_checkno)
        '                        updateCommand.Parameters.AddWithValue("@amount", old_amount)
        '                        updateCommand.Parameters.AddWithValue("@ischanged", True)
        '                        updateCommand.Parameters.AddWithValue("@changeddate", DateTime.Now)
        '                        updateCommand.Parameters.AddWithValue("@seekvar", seekvar)

        '                        updateCommand.ExecuteNonQuery()
        '                    End Using




        '                End If

        '            End If
        '        End Using


        '    End Using

        '    ' Move to the next record in curheader table
        '    reader.NextResult()
        'Loop
        'MessageBox.Show("allg odwa")
        'Return
        'LoginForm.Sqlconnection.Close()


        ' Insert the previous record into xvoucher_hdr table    
        'Using insertXvoucherCommand As New SqlCommand("INSERT INTO xvoucher_hdr (recid, transno, cvno, cvdate, payee, particular, checkno, checkdate, bank, amount, downloadedby, downloadeddate, ischanged, changeddate, userid) " &
        '                                                                       "VALUES (@recid, @transno, @cvno, @cvdate, @payee, @particular, @checkno, @checkdate, @bank, @amount, @downloadedby, @downloadeddate, @ischanged, @changeddate, @userid)", LoginForm.Sqlconnection)
        '    ' Set parameter values for insertXvoucherCommand
        '    insertXvoucherCommand.Parameters.AddWithValue("@recid", nRecid)
        '    insertXvoucherCommand.Parameters.AddWithValue("@transno", cTransno)
        '    insertXvoucherCommand.Parameters.AddWithValue("@cvno", cCvno)
        '    insertXvoucherCommand.Parameters.AddWithValue("@cvdate", old_cvdate)
        '    insertXvoucherCommand.Parameters.AddWithValue("@payee", old_payee)
        '    insertXvoucherCommand.Parameters.AddWithValue("@particular", old_particular)
        '    insertXvoucherCommand.Parameters.AddWithValue("@checkno", old_checkno)
        '    insertXvoucherCommand.Parameters.AddWithValue("@checkdate", dChkdate)
        '    insertXvoucherCommand.Parameters.AddWithValue("@bank", cBank)
        '    insertXvoucherCommand.Parameters.AddWithValue("@amount", old_amount)
        '    insertXvoucherCommand.Parameters.AddWithValue("@downloadedby", dDlby)
        '    insertXvoucherCommand.Parameters.AddWithValue("@downloadeddate", dDldate)
        '    insertXvoucherCommand.Parameters.AddWithValue("@ischanged", lChanged)
        '    insertXvoucherCommand.Parameters.AddWithValue("@changeddate", dChangeddate)
        '    Dim gcUserid As String = Environment.UserName
        '    insertXvoucherCommand.Parameters.AddWithValue("@userid", gcUserid)

        '    insertXvoucherCommand.ExecuteNonQuery()
        'End Using


        'BACKUPOPPPPPPPP'

        'LoginForm.Sqlconnection.Open()
        'Dim nAddctr As Integer = 0

        'Dim cmd As New SqlCommand("SELECT * FROM curheader", LoginForm.Sqlconnection)
        'Dim reader As SqlDataReader = cmd.ExecuteReader()

        'Dim voucherHdrQuery As String = "SELECT * FROM voucher_hdr WHERE cvno = @seekvar"

        'While reader.Read()
        '    Dim seekvar As String = reader("voucher_no").ToString()
        '    Dim m As New Dictionary(Of String, Object)()

        '    For i As Integer = 0 To reader.FieldCount - 1
        '        Dim key As String = reader.GetName(i)
        '        Dim value As Object = reader(i)
        '        m.Add(key, value)
        '    Next
        '    reader.Close()

        '    Using dmd As New SqlCommand(voucherHdrQuery, LoginForm.Sqlconnection)
        '        dmd.Parameters.AddWithValue("@seekvar", seekvar)
        '        Using voucher_hdr As SqlDataReader = dmd.ExecuteReader()
        '            If Not voucher_hdr.HasRows Then
        '                ' Append new record to voucher_hdr


        '                Using insertCommand As New SqlCommand("INSERT INTO voucher_hdr (transno, cvno, cvdate, payee, particular, checkno, checkdate, bank, amount, downloadedby, downloadeddate) " &
        '                                              "VALUES (@transno, @cvno, @cvdate, @payee, @particular, @checkno, @checkdate, @bank, @amount, @downloadedby, @downloadeddate)", LoginForm.Sqlconnection)
        '                    insertCommand.Parameters.AddWithValue("@transno", m("trans_no"))
        '                    insertCommand.Parameters.AddWithValue("@cvno", m("voucher_no"))
        '                    insertCommand.Parameters.AddWithValue("@cvdate", m("vch_date"))
        '                    insertCommand.Parameters.AddWithValue("@payee", m("payee"))
        '                    insertCommand.Parameters.AddWithValue("@particular", m("particular"))
        '                    insertCommand.Parameters.AddWithValue("@checkno", m("checkno"))
        '                    insertCommand.Parameters.AddWithValue("@checkdate", m("chkdate"))
        '                    insertCommand.Parameters.AddWithValue("@bank", m("bank"))
        '                    insertCommand.Parameters.AddWithValue("@amount", m("amount"))
        '                    Dim gcUserid As String = Environment.UserName
        '                    insertCommand.Parameters.AddWithValue("@downloadedby", gcUserid)
        '                    insertCommand.Parameters.AddWithValue("@downloadeddate", DateTime.Now)

        '                    insertCommand.ExecuteNonQuery()
        '                    nAddctr += 1
        '                End Using

        '            Else

        '                ' Check if any data has changed
        '                Dim lIschanged As Boolean = False

        '                While voucher_hdr.Read()
        '                    Dim voucherHdrRow As New Dictionary(Of String, Object)()

        '                    For i As Integer = 0 To voucher_hdr.FieldCount - 1
        '                        Dim key As String = voucher_hdr.GetName(i)
        '                        Dim value As Object = voucher_hdr(i)
        '                        voucherHdrRow.Add(key, value)
        '                    Next



        '                    If Not voucherHdrRow.ContainsKey("cvdate") OrElse Not voucherHdrRow.ContainsKey("payee") OrElse Not voucherHdrRow.ContainsKey("particular") _
        '                        OrElse Not voucherHdrRow.ContainsKey("checkno") OrElse Not voucherHdrRow.ContainsKey("amount") Then
        '                        Exit While
        '                    End If

        '                    If m("vch_date") IsNot voucherHdrRow("cvdate") Then
        '                        lIschanged = True
        '                        voucherHdrRow("cvdate") = m("vch_date")
        '                    End If

        '                    If m("payee") IsNot voucherHdrRow("payee") Then
        '                        lIschanged = True
        '                        voucherHdrRow("payee") = m("payee")
        '                    End If

        '                    If m("particular") IsNot voucherHdrRow("particular") Then
        '                        lIschanged = True
        '                        voucherHdrRow("particular") = m("particular")
        '                    End If

        '                    If m("checkno") IsNot voucherHdrRow("checkno") Then
        '                        lIschanged = True
        '                        voucherHdrRow("checkno") = m("checkno")
        '                    End If

        '                    If m("amount") IsNot voucherHdrRow("amount") Then
        '                        lIschanged = True
        '                        voucherHdrRow("amount") = m("amount")
        '                    End If

        '                    If lIschanged Then
        '                        voucherHdrRow("ischanged") = True
        '                        voucherHdrRow("changeddate") = DateTime.Now



        '                        Using updateCommand As New SqlCommand("UPDATE voucher_hdr SET cvdate = @cvdate, payee = @payee, particular = @particular, checkno = @checkno, amount = @amount, ischanged = @ischanged, changeddate = @changeddate WHERE cvno = @seekvar", LoginForm.Sqlconnection)
        '                            updateCommand.Parameters.AddWithValue("@cvdate", voucherHdrRow("cvdate"))
        '                            updateCommand.Parameters.AddWithValue("@payee", voucherHdrRow("payee"))
        '                            updateCommand.Parameters.AddWithValue("@particular", voucherHdrRow("particular"))
        '                            updateCommand.Parameters.AddWithValue("@checkno", voucherHdrRow("checkno"))
        '                            updateCommand.Parameters.AddWithValue("@amount", voucherHdrRow("amount"))
        '                            updateCommand.Parameters.AddWithValue("@ischanged", voucherHdrRow("ischanged"))
        '                            updateCommand.Parameters.AddWithValue("@changeddate", voucherHdrRow("changeddate"))
        '                            updateCommand.Parameters.AddWithValue("@seekvar", seekvar)

        '                            updateCommand.ExecuteNonQuery()
        '                        End Using
        '                    End If



        '                End While
        '                MessageBox.Show("all goods")
        '                Return

        '            End If
        '        End Using
        '    End Using
        '    reader.NextResult()
        'End While

        'LoginForm.Sqlconnection.Close()


        '' Drop the temporary table in SQL Server '
        'LoginForm.Sqlconnection.Open()
        'Dim tableName As String = "curheader"
        'Dim dropTableQuery As String = $"DROP TABLE {tableName}"
        'Dim dropTableCommand As New SqlCommand(dropTableQuery, LoginForm.Sqlconnection)
        'dropTableCommand.ExecuteNonQuery()
        'LoginForm.Sqlconnection.Close()

    End Sub

    Private Function CheckIfTableExists(tableName As String, connection As SqlConnection) As Boolean
        Dim query As String = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'"
        Using command As New SqlCommand(query, connection)
            Dim count As Integer = CInt(command.ExecuteScalar())
            Return count > 0
        End Using
    End Function

    Private Sub CreateDestinationTable(dataTable As DataTable, tableName As String, connection As SqlConnection)
        Dim createTableQuery As String = GenerateCreateTableQuery(dataTable, tableName)
        Using createTableCmd As New SqlCommand(createTableQuery, connection)
            createTableCmd.ExecuteNonQuery()
        End Using
    End Sub
    Private Sub MapColumns(dataTable As DataTable, bulkCopy As SqlBulkCopy)
        For Each column As DataColumn In dataTable.Columns
            bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName)
        Next
    End Sub

    Private Function GetColumnType(dataType As Type) As String
        If dataType Is GetType(String) Then
            Return "NVARCHAR(MAX)"
        ElseIf dataType Is GetType(Integer) Then
            Return "INT"
        ElseIf dataType Is GetType(Decimal) Then
            Return "DECIMAL(18, 2)"
        ElseIf dataType Is GetType(Date) Then
            Return "DATE"
        ElseIf dataType Is GetType(DateTime) Then
            Return "DATETIME"
        Else
            ' Handle any other data types here '
            Return "NCHAR(MAX)"
        End If
    End Function
End Class
