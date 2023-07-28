Imports System.Security.Cryptography
Imports System.Text

Module rootVariables
    Public username As String
    Public admin As Boolean
    Public allowGetdata As Boolean
    Public allowEdit As Boolean
    Public allowReport As Boolean
    Public allowUser As Boolean
    Public allowTugboat As Boolean
    Public lAdd As Boolean
    Public dtTugboat As New DataTable

    Public Function HashPassword(ByVal password As String) As String
        Using sha256Hash As SHA256 = SHA256.Create()
            ' Convert the password string to a byte array
            Dim data As Byte() = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password))

            ' Use a StringBuilder to collect the bytes into a string
            Dim builder As New StringBuilder()

            For i As Integer = 0 To data.Length - 1
                builder.Append(data(i).ToString("x2")) ' Convert each byte to a hexadecimal string representation
            Next

            Return builder.ToString() ' Return the hashed password as a string
        End Using
    End Function



End Module
