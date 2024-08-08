Imports MySql.Data.MySqlClient
Imports Mysqlx.Session

Public Class PaymentModal
    Dim connection As String = "server=127.0.0.1; user=root; database=water-billing; password="
    Dim Con As New MySqlConnection(connection)
    Public customer_ID = ""
    Dim reference_Number = ""
    'Public income_ID As String = ""

    Private Sub PaymentModal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ShowInTaskbar = False
    End Sub

    Private Sub GenerateRefNumber()
        If reference_Number = "" Then
            Dim myId As Guid = Guid.NewGuid()
            Dim myIdString = myId.ToString().Substring(0, 6)
            reference_Number = myIdString
        End If
    End Sub






    Private Sub GeneratePrintReceipt()
        GenerateRefNumber()
        ' Clear existing content in RichTextBox2
        RichTextBox2.Clear()

        ' Add receipt header
        RichTextBox2.AppendText("------ R.R. MAGWAS WATERWORKS ------" & vbCrLf)
        RichTextBox2.AppendText("Billing Receipt" & vbCrLf)
        RichTextBox2.AppendText("Billing issue: " & DateTime.Now.ToString("MM/dd/yyyy") & vbCrLf)
        RichTextBox2.AppendText("-----------------------------" & vbCrLf)

        ' Add billing details
        RichTextBox2.AppendText("Ref          : " & reference_Number & vbCrLf)
        RichTextBox2.AppendText("Biller name  : " & billerName.Text & vbCrLf)
        RichTextBox2.AppendText("Address      : " & billerAddress.Text & vbCrLf)
        RichTextBox2.AppendText("Reading date : " & readingDate.Text & vbCrLf)
        RichTextBox2.AppendText("Due date     : " & dueDate.Text & vbCrLf)
        RichTextBox2.AppendText("Total Amount : " & amout.Text & vbCrLf)
        RichTextBox2.AppendText("Amount to pay: " & amoutToPay.Text & vbCrLf)
        RichTextBox2.AppendText("Balance      : " & balance.Text & vbCrLf)
        RichTextBox2.AppendText("-----------------------------" & vbCrLf)

        ' Add footer with empty lines for spacing
        For i As Integer = 1 To 6
            RichTextBox2.AppendText("                                                           " & vbCrLf)
        Next

        ' Set font size and style for the entire receipt
        Dim font As New Font("Arial", 12)
        RichTextBox2.SelectAll()
        RichTextBox2.SelectionFont = font

        ' Optionally adjust alignment and other formatting as needed
        RichTextBox2.SelectionAlignment = HorizontalAlignment.Center
    End Sub


    Dim g, mg As Graphics
    Dim bmp As Bitmap

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        bmp = New Bitmap(RichTextBox2.Width, RichTextBox2.Height)

        mg = Graphics.FromImage(bmp)

        RichTextBox2.DrawToBitmap(bmp, New Rectangle(0, 0, RichTextBox2.Width, RichTextBox2.Height))

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click




        Try
            ' Define the queries
            Dim updateQuery As String = "UPDATE customers SET balance = @balance WHERE id = @customer_id"
            Dim insertQuery As String = "INSERT INTO income (income, date) VALUES (@income, @date)"

            ' Open the connection
            Con.Open()

            ' Insert the income record
            Using insertCmd As New MySqlCommand(insertQuery, Con)

                insertCmd.Parameters.AddWithValue("@income", Convert.ToDecimal(amoutToPay.Text)) ' Ensure amountToPay is converted to decimal if necessary
                insertCmd.Parameters.AddWithValue("@date", DateTime.Now)
                insertCmd.ExecuteNonQuery()
            End Using

            ' Update the customer's balance
            Using updateCmd As New MySqlCommand(updateQuery, Con)
                updateCmd.Parameters.AddWithValue("@balance", Convert.ToDecimal(balance.Text)) ' Ensure balance is converted to decimal if necessary
                updateCmd.Parameters.AddWithValue("@customer_id", customer_ID)
                updateCmd.ExecuteNonQuery()
            End Using

            MsgBox("Payment success")

            ' Clear the fields
            customer_ID = ""
            reference_Number = ""
            GeneratePrintReceipt()

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            ' Ensure the connection is closed
            Con.Close()
        End Try

    End Sub
    Public Sub CalculateBalance()
        Dim totAmount As Double
        Dim payAmount As Double
        Dim total As Double

        ' Convert the text inputs to double
        If Not Double.TryParse(amout.Text, totAmount) Then

            Return
        End If

        If Not Double.TryParse(amoutToPay.Text, payAmount) Then

            Return
        End If

        ' Perform the subtraction
        total = totAmount - payAmount

        ' Assign the result to the balance text box as a string
        balance.Text = total.ToString()
    End Sub



    Private Sub amoutToPay_TextChanged(sender As Object, e As EventArgs) Handles amoutToPay.TextChanged

        CalculateBalance()

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(bmp, 0, 0)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Hide()
    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Private Sub RichTextBox2_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox2.TextChanged

    End Sub
End Class