Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports ClosedXML.Excel

Public Class ReportForm
    Private Sub ReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoginForm.Sqlconnection.Open()
        Dim query As String = "SELECT * FROM tugboat"
        Using command As New SqlCommand(query, LoginForm.Sqlconnection)
            Try

                Dim sda As SqlDataAdapter = New SqlDataAdapter(command)
                sda.Fill(dtTugboat)

                DataGridView1.DataSource = dtTugboat

                ' Set the AutoSizeColumnsMode to resize the columns based on content
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "MIS DEPARTMENT", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            End Try
        End Using

        cboReport.Items.Clear()
        cboReport.Items.Add("History Of Repairs & Maintenance")
        cboReport.SelectedIndex = 0


        Try


            ' SQL query to fetch data from a table, adjust this query based on your needs
            Dim query2 As String = "SELECT * FROM tugboat"
            Dim command As New SqlCommand(query, LoginForm.Sqlconnection)

            ' Execute the query and read data into a SqlDataReader
            Dim reader As SqlDataReader = command.ExecuteReader()

            ' Clear the existing items in the ComboBox
            cboTugboat.Items.Clear()

            ' Add "ALL" as the first item in the ComboBox
            cboTugboat.Items.Add("ALL")

            ' Loop through the data and add it to the ComboBox
            While reader.Read()
                cboTugboat.Items.Add(reader("number").ToString())
            End While

            ' Close the reader and connection
            reader.Close()
            cboTugboat.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            LoginForm.Sqlconnection.Close()
        End Try



        LoginForm.Sqlconnection.Close()



    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTugboat.SelectedIndexChanged
        If cboTugboat.SelectedIndex <> -1 Then
            Dim selectedTugboatNumber As String = cboTugboat.SelectedItem.ToString()

            If selectedTugboatNumber = "ALL" Then
                ' Call a method or write code here to display all tugboat names from the database
                ' You can also refresh your data if needed
                txtName.Text = "All tugboats"
            Else
                ' Fetch the corresponding tugboat name based on the selected tugboat number
                Dim tugboatName As String = GetTugboatName(selectedTugboatNumber)

                ' Display the retrieved tugboat name in the txtName TextBox
                txtName.Text = tugboatName
            End If
        End If

    End Sub

    Private Function GetTugboatName(tugboatNumber As String) As String
        Dim tugboatName As String = String.Empty

        ' Establish connection to SQL Server
        Try
            LoginForm.Sqlconnection.Open()

            ' SQL query to fetch the tugboat name based on the selected tugboat number
            Dim query As String = "SELECT name FROM tugboat WHERE number = @tugboatNumber"
            Dim command As New SqlCommand(query, LoginForm.Sqlconnection)
            command.Parameters.AddWithValue("@tugboatNumber", tugboatNumber)

            ' Execute the query and read the data
            Dim result As Object = command.ExecuteScalar()

            ' Check if the result is not null and convert it to a string
            If result IsNot Nothing Then
                tugboatName = result.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            LoginForm.Sqlconnection.Close()
        End Try
        LoginForm.Sqlconnection.Close()

        Return tugboatName
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click




        Try
            If cboTugboat.SelectedIndex <> -1 Then
                Dim selectedTugboatNumber As String = cboTugboat.SelectedItem.ToString()
                If cboTugboat.SelectedIndex = 0 Then
                    ' Call the function to get the data
                    Dim dataTable As DataTable = GetTugboatReport()

                    '' Check if there are records and display a message box if there are none
                    'If curreport.Rows.Count = 0 Then
                    '    MessageBox.Show("Nothing to generate.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Return
                    'End If

                    '' Now you can use the 'curreport' object to display or work with the retrieved data as needed
                    'DataGridView1.DataSource = curreport

                    ' Export the DataTable to Excel
                    'ExportAll(curreport)

                    If dataTable.Rows.Count = 0 Then
                        MessageBox.Show("Nothing to generate.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    Using workbook As New XLWorkbook()
                        Dim i As Integer = 0

                        For Each row As DataRow In dataTable.Rows
                            i += 1
                            Dim worksheet As IXLWorksheet = Nothing
                            Dim name As String = row("name").ToString().Trim()
                            Dim worksheetName As String = CleanWorksheetName(name)

                            ' If the cleaned worksheet name is empty after removing special characters, use a default name like "SheetX"
                            If String.IsNullOrWhiteSpace(worksheetName) Then
                                worksheetName = "Sheet" & i
                            End If

                            ' Check if the worksheet with the cleaned name already exists, and if not, add it to the workbook
                            worksheet = workbook.Worksheets.FirstOrDefault(Function(ws) ws.Name = worksheetName)
                            If worksheet Is Nothing Then
                                worksheet = workbook.Worksheets.Add(worksheetName)
                            End If

                            ' Format the worksheet
                            worksheet.Columns("A").Width = 10
                            worksheet.Columns("B").Width = 10
                            worksheet.Columns("C").Width = 16
                            worksheet.Columns("D").Width = 30
                            worksheet.Columns("E").Width = 12
                            worksheet.Columns("F").Width = 12
                            worksheet.Columns("G").Width = 60

                            worksheet.Cell(2, 1).Value = "HISTORY OF REPAIRS & MAINTENANCE"
                            worksheet.Cell(2, 1).Style.Font.Bold = True
                            worksheet.Range(worksheet.Cell(2, 1), worksheet.Cell(2, 7)).Merge()
                            worksheet.Range(worksheet.Cell(2, 1), worksheet.Cell(2, 7)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                            worksheet.Range(worksheet.Cell(2, 1), worksheet.Cell(2, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Thin

                            worksheet.Cell(3, 1).Value = "TUGBOAT:"
                            worksheet.Cell(3, 1).Style.Font.Bold = True
                            worksheet.Cell(4, 1).Value = "ACQUIRED:"
                            worksheet.Cell(5, 1).Value = "FROM:"
                            worksheet.Cell(6, 1).Value = "COST:"
                            worksheet.Range(worksheet.Cell(6, 1), worksheet.Cell(6, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Thin

                            worksheet.Range(worksheet.Cell(8, 1), worksheet.Cell(8, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                            worksheet.Cell(9, 1).Value = "DATE"
                            worksheet.Cell(9, 2).Value = "REF AR #"
                            worksheet.Cell(9, 3).Value = "SUPPLIER / PERFORMED BY"
                            worksheet.Cell(9, 4).Value = "PARTICULARS"
                            worksheet.Cell(9, 5).Value = "AMOUNT"
                            worksheet.Cell(9, 6).Value = "CUMULATIVE"
                            worksheet.Cell(9, 7).Value = "REMARKS"

                            worksheet.Range(worksheet.Cell(9, 1), worksheet.Cell(9, 7)).Style.Alignment.WrapText = True
                            worksheet.Range(worksheet.Cell(9, 1), worksheet.Cell(9, 7)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                            worksheet.Range(worksheet.Cell(9, 1), worksheet.Cell(9, 7)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
                            worksheet.Range(worksheet.Cell(9, 1), worksheet.Cell(9, 7)).Style.Font.Bold = True
                            worksheet.Range(worksheet.Cell(9, 1), worksheet.Cell(9, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Thin

                            Dim nRow As Integer = 10 ' Initialize nRow for each sheet
                            Dim nDtlCtr As Integer = 0 ' Initialize nDtlCtr for each sheet

                            worksheet.Cell(3, 3).Value = name
                            worksheet.Cell(3, 3).Style.Font.Bold = True
                            Dim acquireddate As DateTime = If(row.IsNull("acquireddate"), DateTime.MinValue, Convert.ToDateTime(row("acquireddate")))
                            Dim acquiredfrom As String = If(row.IsNull("acquiredfrom"), "", row("acquiredfrom").ToString().Trim())
                            Dim cost As Decimal = If(row.IsNull("cost"), 0, Convert.ToDecimal(row("cost")))

                            If Not acquireddate = DateTime.MinValue Then
                                worksheet.Cell(4, 3).Value = acquireddate.ToString("MMMM yyyy").ToUpper()
                            End If

                            worksheet.Cell(5, 3).Value = acquiredfrom

                            If cost > 0 Then
                                worksheet.Cell(6, 3).Value = cost / 1000000 & " M"
                            End If

                            For Each rowDetail As DataRow In dataTable.Rows
                                If name = rowDetail("name").ToString().Trim() Then
                                    Dim [date] As DateTime = If(rowDetail.IsNull("date"), DateTime.MinValue, Convert.ToDateTime(rowDetail("date")))
                                    Dim reference As String = If(rowDetail.IsNull("reference"), "", rowDetail("reference").ToString().Trim())
                                    Dim supplier As String = If(rowDetail.IsNull("supplier"), "", rowDetail("supplier").ToString().Trim())
                                    Dim particular As String = If(rowDetail.IsNull("particular"), "", rowDetail("particular").ToString().Trim())
                                    Dim amount As Decimal = If(rowDetail.IsNull("amount"), 0, Convert.ToDecimal(rowDetail("amount")))
                                    Dim remarks As String = If(rowDetail.IsNull("remarks"), "", rowDetail("remarks").ToString().Trim())

                                    worksheet.Cell(nRow, 1).Value = [date]
                                    worksheet.Cell(nRow, 1).Style.NumberFormat.Format = "mm/dd/yyyy;@"
                                    worksheet.Cell(nRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

                                    worksheet.Cell(nRow, 2).Value = "'" & reference
                                    worksheet.Cell(nRow, 3).Value = supplier
                                    worksheet.Cell(nRow, 4).Value = particular

                                    worksheet.Cell(nRow, 5).Value = amount
                                    worksheet.Cell(nRow, 5).Style.NumberFormat.Format = "#,##0.00_);-#,##0.00;"

                                    If nRow = 10 Then
                                        worksheet.Cell(nRow, 6).FormulaR1C1 = "=RC[-1]"
                                    Else
                                        worksheet.Cell(nRow, 6).FormulaR1C1 = "=R[-1]C+RC[-1]"
                                    End If

                                    worksheet.Cell(nRow, 6).Style.NumberFormat.Format = "#,##0.00_);-#,##0.00;"
                                    worksheet.Cell(nRow, 7).Value = remarks
                                    worksheet.Cell(nRow, 7).Style.Alignment.WrapText = True
                                    worksheet.Cell(nRow, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top

                                    nDtlCtr += 1
                                    nRow += 1
                                End If
                            Next

                            ' Update the total expenses row
                            nRow -= 1
                            worksheet.Range(worksheet.Cell(nRow, 1), worksheet.Cell(nRow, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                            nRow += 1

                            worksheet.Cell(nRow, 3).Value = "TOTAL EXPENSES TO DATE"
                            worksheet.Cell(nRow, 6).FormulaR1C1 = "=R[-1]C"
                            worksheet.Cell(nRow, 6).Style.NumberFormat.Format = "#,##0.00_);-#,##0.00;"
                            worksheet.Range(worksheet.Cell(nRow, 3), worksheet.Cell(nRow, 6)).Style.Font.Bold = True
                            worksheet.Range(worksheet.Cell(nRow, 1), worksheet.Cell(nRow, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Medium

                            nRow += 2
                            worksheet.Cell(nRow, 1).Value = "Prepared by:"
                            worksheet.Cell(nRow, 5).Value = "Noted by:"

                            ' Uncomment the following line to freeze panes (optional)
                            ' worksheet.SheetView.FreezeRows(1)
                        Next

                        ' Option to save or open the Excel file
                        Dim result As DialogResult = MessageBox.Show("Do you want to save the Excel file?", "Save Excel File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                        If result = DialogResult.Yes Then
                            ' Save the workbook
                            Dim saveFileDialog As New SaveFileDialog()
                            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*"
                            saveFileDialog.FileName = "TugboatReport_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"

                            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                                workbook.SaveAs(saveFileDialog.FileName)
                                MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        ElseIf result = DialogResult.No Then
                            ' Save the workbook temporarily to a MemoryStream
                            Using stream As New MemoryStream()
                                workbook.SaveAs(stream)

                                ' Load the Excel file from the MemoryStream using ClosedXML
                                Using excelWorkbook As New XLWorkbook(stream)
                                    ' Save it temporarily to disk
                                    Dim tempFilePath As String = "Excel\TugboatReport_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
                                    excelWorkbook.SaveAs(tempFilePath)

                                    ' Open the file using the default program associated with .xlsx files
                                    Process.Start(New ProcessStartInfo With {
                                                                            .FileName = tempFilePath,
                                                                            .UseShellExecute = True
                                                                        })

                                    ' Inform the user to manually save if they make changes
                                    MessageBox.Show("Please save the file manually if you make any changes.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End Using
                            End Using
                        End If

                    End Using

                Else

                    ' Call the function to get the data
                    Dim dataTable As DataTable = GetTugboatData(selectedTugboatNumber)

                    ExportOne(dataTable)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub

    ' Function to remove special characters from the worksheet name
    Function CleanWorksheetName(name As String) As String
        Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" ' Add any additional allowed characters here
        Return New String(name.Where(Function(c) allowedChars.Contains(c)).ToArray())
    End Function

    Private Sub ExportOne(dataTable As DataTable)
        If dataTable.Rows.Count = 0 Then
            MessageBox.Show("Nothing to generate.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' Now you can use the 'dataTable' object to display or work with the retrieved data as needed
            Dim workbook As New XLWorkbook()
            Dim worksheet As IXLWorksheet
            Dim nDtlCtr As Integer
            Dim nRow As Integer

            ' Create the worksheet
            workbook.Worksheets.Add("Sheet1")
            worksheet = workbook.Worksheet("Sheet1")

            ' Format the worksheet
            worksheet.Columns("A").Width = 10
            worksheet.Columns("B").Width = 10
            worksheet.Columns("C").Width = 16
            worksheet.Columns("D").Width = 30
            worksheet.Columns("E").Width = 12
            worksheet.Columns("F").Width = 12
            worksheet.Columns("G").Width = 60

            worksheet.Cell(2, 1).Value = "HISTORY OF REPAIRS & MAINTENANCE"
            worksheet.Cell(2, 1).Style.Font.Bold = True
            worksheet.Range(worksheet.Cell(2, 1), worksheet.Cell(2, 7)).Merge()
            worksheet.Range(worksheet.Cell(2, 1), worksheet.Cell(2, 7)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            worksheet.Range(worksheet.Cell(2, 1), worksheet.Cell(2, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Thin

            worksheet.Cell(3, 1).Value = "TUGBOAT:"
            worksheet.Cell(3, 1).Style.Font.Bold = True
            worksheet.Cell(4, 1).Value = "ACQUIRED:"
            worksheet.Cell(5, 1).Value = "FROM:"
            worksheet.Cell(6, 1).Value = "COST:"
            worksheet.Range(worksheet.Cell(6, 1), worksheet.Cell(6, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Thin

            worksheet.Range(worksheet.Cell(8, 1), worksheet.Cell(8, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Thin
            worksheet.Cell(9, 1).Value = "DATE"
            worksheet.Cell(9, 2).Value = "REF AR #"
            worksheet.Cell(9, 3).Value = "SUPPLIER / PERFORMED BY"
            worksheet.Cell(9, 4).Value = "PARTICULARS"
            worksheet.Cell(9, 5).Value = "AMOUNT"
            worksheet.Cell(9, 6).Value = "CUMULATIVE"
            worksheet.Cell(9, 7).Value = "REMARKS"

            worksheet.Range(worksheet.Cell(9, 1), worksheet.Cell(9, 7)).Style.Alignment.WrapText = True
            worksheet.Range(worksheet.Cell(9, 1), worksheet.Cell(9, 7)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            worksheet.Range(worksheet.Cell(9, 1), worksheet.Cell(9, 7)).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top
            worksheet.Range(worksheet.Cell(9, 1), worksheet.Cell(9, 7)).Style.Font.Bold = True
            worksheet.Range(worksheet.Cell(9, 1), worksheet.Cell(9, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Thin

            ' ... (continued code)

            ' Populate the worksheet with data
            nDtlCtr = 0
            nRow = 10
            Dim name As String = dataTable.Rows(0)("name")
            worksheet.Cell(3, 3).Value = name
            worksheet.Cell(3, 3).Style.Font.Bold = True
            Dim acquireddate As DateTime = dataTable.Rows(0)("acquireddate")
            Dim acquiredfrom As String = dataTable.Rows(0)("acquiredfrom")
            Dim cost As Decimal = dataTable.Rows(0)("cost")


            If Not String.IsNullOrEmpty(acquireddate) Then
                worksheet.Cell(4, 3).Value = acquireddate.ToString("MMMM yyyy").ToUpper()
            End If

            worksheet.Cell(5, 3).Value = acquiredfrom

            If cost > 0 Then
                worksheet.Cell(6, 3).Value = cost / 1000000 & " M"
            End If

            For Each row As DataRow In dataTable.Rows
                Dim [date] As DateTime = Convert.ToDateTime(row("date"))
                Dim reference As String = row("reference").ToString()
                Dim supplier As String = row("supplier").ToString()
                Dim particular As String = row("particular").ToString()
                Dim amount As Decimal

                If Not dataTable.Rows(0).IsNull("amount") Then
                    amount = Convert.ToDecimal(dataTable.Rows(0)("amount"))
                Else
                    ' If the "amount" column is DBNull, you can set a default value or handle it as needed.
                    ' For example, you can set "amount" to 0:
                    amount = 0
                End If
                Dim remarks As String = row("remarks").ToString()

                worksheet.Cell(nRow, 1).Value = [date]
                worksheet.Cell(nRow, 1).Style.NumberFormat.Format = "mm/dd/yyyy;@"
                worksheet.Cell(nRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

                worksheet.Cell(nRow, 2).Value = "'" & reference
                worksheet.Cell(nRow, 3).Value = supplier
                worksheet.Cell(nRow, 4).Value = particular

                worksheet.Cell(nRow, 5).Value = amount
                worksheet.Cell(nRow, 5).Style.NumberFormat.Format = "#,##0.00_);-#,##0.00;"

                If nRow = 10 Then
                    worksheet.Cell(nRow, 6).FormulaR1C1 = "=RC[-1]"
                Else
                    worksheet.Cell(nRow, 6).FormulaR1C1 = "=R[-1]C+RC[-1]"
                End If

                worksheet.Cell(nRow, 6).Style.NumberFormat.Format = "#,##0.00_);-#,##0.00;"
                worksheet.Cell(nRow, 7).Value = remarks
                worksheet.Cell(nRow, 7).Style.Alignment.WrapText = True
                worksheet.Cell(nRow, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Top

                nDtlCtr += 1
                nRow += 1
            Next

            nRow -= 1
            worksheet.Range(worksheet.Cell(nRow, 1), worksheet.Cell(nRow, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Thin
            nRow += 1

            worksheet.Cell(nRow, 3).Value = "TOTAL EXPENSES TO DATE"
            worksheet.Cell(nRow, 5).FormulaR1C1 = "=SUM(R[-" & nDtlCtr & "]C:R[-1]C)"
            worksheet.Cell(nRow, 5).Style.NumberFormat.Format = "#,##0.00_);-#,##0.00;"
            worksheet.Cell(nRow, 6).FormulaR1C1 = "R[-1]C"
            worksheet.Cell(nRow, 6).Style.NumberFormat.Format = "#,##0.00_);-#,##0.00;"
            worksheet.Range(worksheet.Cell(nRow, 3), worksheet.Cell(nRow, 6)).Style.Font.Bold = True
            worksheet.Range(worksheet.Cell(nRow, 1), worksheet.Cell(nRow, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Medium

            nRow += 2
            worksheet.Cell(nRow, 1).Value = "Prepared by:"
            worksheet.Cell(nRow, 5).Value = "Noted by:"

            worksheet.Range("A1").Select()

            ' Uncomment the following line to freeze panes (optional)
            ' worksheet.SheetView.FreezeRows(1)

            ' Option to save or open the Excel file
            Dim result As DialogResult = MessageBox.Show("Do you want to save the Excel file?", "Save Excel File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                ' Save the workbook
                Dim saveFileDialog As New SaveFileDialog()
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*"
                saveFileDialog.FileName = CleanWorksheetName(name).Trim() & DateTime.Now.ToString("_yyyyMMdd_HHmmtt") + ".xlsx"

                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    workbook.SaveAs(saveFileDialog.FileName)
                    MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf result = DialogResult.No Then
                ' Save the workbook temporarily to a MemoryStream
                ' Inform the user to manually save if they make changes
                MessageBox.Show("Please save the file manually if you make any changes.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Using stream As New MemoryStream()
                    workbook.SaveAs(stream)

                    ' Load the Excel file from the MemoryStream using ClosedXML
                    Using excelWorkbook As New XLWorkbook(stream)
                        ' Save it temporarily to disk
                        Dim tempFilePath As String = CleanWorksheetName(name).Trim() & DateTime.Now.ToString("_yyyyMMdd_HHmmtt") + ".xlsx"
                        excelWorkbook.SaveAs(tempFilePath)

                        ' Open the file using the default program associated with .xlsx files
                        Process.Start(New ProcessStartInfo With {
                                                                .FileName = tempFilePath,
                                                                .UseShellExecute = True
                                                            })

                    End Using
                End Using
            End If

        End If
    End Sub



    Public Function GetTugboatData(ByVal tugboatNumber As Integer) As DataTable
        Dim dataTable As New DataTable()

        Try
            MessageBox.Show("Please wait, preparing data...", "Please Wait", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim query As String = "SELECT a.number, a.name, a.acquireddate, a.acquiredfrom, a.cost, " &
                                      "b.date, b.reference, b.supplier, b.particular, b.remarks, " &
                                      "c.amount " &
                                      "FROM tugboat AS a " &
                                      "JOIN repair_dtl AS b ON a.number = b.tugboat " &
                                      "LEFT JOIN voucher_dtl AS c ON b.recid = c.refid " &
                                      "WHERE a.number = @tugboatNumber " &
                                      "ORDER BY 6"

            Using command As New SqlCommand(query, LoginForm.Sqlconnection)
                command.Parameters.AddWithValue("@tugboatNumber", tugboatNumber)

                LoginForm.Sqlconnection.Open()

                Using dataAdapter As New SqlDataAdapter(command)
                    dataAdapter.Fill(dataTable)
                End Using
            End Using
        Catch ex As Exception
            ' Handle any exceptions or errors here
            MessageBox.Show("Error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LoginForm.Sqlconnection.Close()
        End Try
        LoginForm.Sqlconnection.Close()
        Return dataTable
    End Function



    Private Sub ExportAll(dataTable As DataTable)
        ' Call the function to get the data

        If dataTable.Rows.Count = 0 Then
            MessageBox.Show("Nothing to generate.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using workbook As New XLWorkbook()
            ' Initialize sheet counter
            Dim i As Integer = 0

            ' Iterate through the DataTable rows
            For Each row As DataRow In dataTable.Rows
                Dim number As Integer = Convert.ToInt32(row("number"))
                Dim name As String = row("name").ToString().Trim()
                Dim acquireddate As DateTime? = If(row.IsNull("acquireddate"), Nothing, Convert.ToDateTime(row("acquireddate")))
                Dim acquiredfrom As String = If(row.IsNull("acquiredfrom"), "", row("acquiredfrom").ToString().Trim())
                Dim cost As Decimal = If(row.IsNull("cost"), 0, Convert.ToDecimal(row("cost")))
                Dim dateValue As DateTime = If(row.IsNull("date"), DateTime.MinValue, Convert.ToDateTime(row("date")))
                Dim reference As String = If(row.IsNull("reference"), "", row("reference").ToString().Trim())
                Dim supplier As String = If(row.IsNull("supplier"), "", row("supplier").ToString().Trim())
                Dim particular As String = If(row.IsNull("particular"), "", row("particular").ToString().Trim())
                Dim amount As Decimal = If(row.IsNull("amount"), 0, Convert.ToDecimal(row("amount")))
                Dim remarks As String = If(row.IsNull("remarks"), "", row("remarks").ToString().Trim())

                i += 1

                ' Create a new worksheet for each iteration
                Dim worksheet As IXLWorksheet = workbook.Worksheets.Add("Sheet" & i)

                ' Format the worksheet
                worksheet.Columns("A").Width = 10
                worksheet.Columns("B").Width = 10
                worksheet.Columns("C").Width = 16
                worksheet.Columns("D").Width = 30
                worksheet.Columns("E").Width = 12
                worksheet.Columns("F").Width = 12
                worksheet.Columns("G").Width = 60

                worksheet.Cell(2, 1).Value = "HISTORY OF REPAIRS & MAINTENANCE"
                worksheet.Cell(2, 1).Style.Font.Bold = True
                worksheet.Range(worksheet.Cell(2, 1), worksheet.Cell(2, 7)).Merge()
                worksheet.Range(worksheet.Cell(2, 1), worksheet.Cell(2, 7)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                worksheet.Range(worksheet.Cell(2, 1), worksheet.Cell(2, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Thin

                ' ... (continued formatting code, same as before)

                Dim nRow As Integer = 10 ' Initialize nRow for each sheet
                Dim nDtlCtr As Integer = 0 ' Initialize nDtlCtr for each sheet
                ' ... (continued code)

                ' Update the total expenses row
                nRow -= 1
                worksheet.Range(worksheet.Cell(nRow, 1), worksheet.Cell(nRow, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Thin
                nRow += 1

                worksheet.Cell(nRow, 3).Value = "TOTAL EXPENSES TO DATE"
                worksheet.Cell(nRow, 5).FormulaA1 = "=SUM(R[-" & nDtlCtr & "]C:R[-1]C)"
                worksheet.Cell(nRow, 6).FormulaA1 = "R[-1]C"
                worksheet.Range(worksheet.Cell(nRow, 3), worksheet.Cell(nRow, 6)).Style.Font.Bold = True
                worksheet.Range(worksheet.Cell(nRow, 1), worksheet.Cell(nRow, 7)).Style.Border.BottomBorder = XLBorderStyleValues.Medium

                nRow += 2
                worksheet.Cell(nRow, 1).Value = "Prepared by:"
                worksheet.Cell(nRow, 5).Value = "Noted by:"

                worksheet.Range("A1").Select()

                ' Uncomment the following line to freeze panes (optional)
                ' worksheet.SheetView.FreezeRows(1)

                ' Rename the worksheet based on the "name" value
                Dim shtName As String = ""
                For Each c As Char In name
                    If Char.IsLetterOrDigit(c) Then
                        shtName += c
                    End If
                Next
                worksheet.Name = shtName
            Next

            ' Save the workbook
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*"
            saveFileDialog.FileName = "TugboatReport_" + DateTime.Now.ToString("yyyyMMdd_HH:mmtt") + ".xlsx"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                workbook.SaveAs(saveFileDialog.FileName)
                MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Public Function GetTugboatReport() As DataTable
        Dim dataTable As New DataTable()

        Try
            ' Show "Please wait" message using MessageBox
            MessageBox.Show("Please wait, preparing data...", "Please Wait", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Assuming you have a connection string to your database
            Dim query As String = "SELECT a.number, a.name, a.acquireddate, a.acquiredfrom, a.cost, " &
                                      "b.date, b.reference, b.supplier, b.particular, b.remarks, " &
                                      "c.amount " &
                                      "FROM tugboat AS a " &
                                      "JOIN repair_dtl AS b ON a.number = b.tugboat " &
                                      "LEFT JOIN voucher_dtl AS c ON b.recid = c.refid " &
                                      "ORDER BY 1, 6"

            Using command As New SqlCommand(query, LoginForm.Sqlconnection)
                LoginForm.Sqlconnection.Open()

                Using dataAdapter As New SqlDataAdapter(command)
                    dataAdapter.Fill(dataTable)
                End Using
            End Using
        Catch ex As Exception
            ' Handle any exceptions or errors here
            MessageBox.Show("Error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LoginForm.Sqlconnection.Close()
        End Try
        LoginForm.Sqlconnection.Close()
        Return dataTable
    End Function

    Private Sub ReportForm_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        MainForm.Show()
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        PrintPreviewDialog1.Document = PrintDocument1
        ' Set the PrintDocument properties, including the orientation.
        PrintDocument1.DefaultPageSettings.Landscape = False ' Set to False for portrait.
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()



    End Sub

    Private mRow As Integer = 0
    Private newPage As Boolean = True
    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim format As New StringFormat
        format.Alignment = StringAlignment.Center
        e.Graphics.DrawString("Tugboat List", New Font("Century Gothic", 20, FontStyle.Bold),
                               Brushes.Black, New Point(400, 20), format)

        Dim fmt As StringFormat = New StringFormat(StringFormatFlags.NoWrap)
        fmt.LineAlignment = StringAlignment.Center
        fmt.Trimming = StringTrimming.EllipsisCharacter
        fmt.Alignment = StringAlignment.Center

        Dim y As Integer = 100
        Dim x As Integer = 150
        Dim h As Integer = 0
        Dim rc As Rectangle
        Dim row As DataGridViewRow


        If newPage Then
            row = DataGridView1.Rows(mRow)
            x = 27
            For Each cell As DataGridViewCell In row.Cells
                If cell.Visible Then
                    rc = New Rectangle(x, y, cell.Size.Width, cell.Size.Height)
                    e.Graphics.FillRectangle(Brushes.LightGray, rc)
                    e.Graphics.DrawRectangle(Pens.Black, rc)

                    e.Graphics.DrawString(DataGridView1.Columns(cell.ColumnIndex).HeaderText, DataGridView1.Font, Brushes.Black, rc, fmt)

                    x += rc.Width
                    h = Math.Max(h, rc.Height)

                End If
            Next
            y += h
        End If

        'newPage = False
        Dim displayNow As Integer
        For displayNow = mRow To DataGridView1.RowCount - 1
            row = DataGridView1.Rows(displayNow)
            x = 27
            h = 0

            For Each cell As DataGridViewCell In row.Cells
                If cell.Visible Then
                    rc = New Rectangle(x, y, cell.Size.Width, cell.Size.Height)
                    e.Graphics.DrawRectangle(Pens.Black, rc)

                    fmt.Alignment = StringAlignment.Near
                    rc.Offset(5, 0)

                    e.Graphics.DrawString(cell.FormattedValue.ToString(), DataGridView1.Font, Brushes.Black, rc, fmt)

                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                End If
            Next
            y += h

        Next

    End Sub
End Class