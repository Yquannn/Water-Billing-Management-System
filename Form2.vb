Imports System.IO
Imports Guna.UI2.Native.WinApi
Imports System.Runtime.Intrinsics.X86
Imports MySql.Data.MySqlClient
Imports Mysqlx.Session
Imports Org.BouncyCastle.Pqc.Crypto.Lms
Imports System.Drawing.Printing

Public Class Form2
    Dim connection As String = "server=127.0.0.1; user=root; database=water-billing; password="
    Dim Con As New MySqlConnection(connection)
    Dim customer_Id = ""
    Dim employee_Id = ""

    Public Sub fetchCubic()
        Dim query As String = "SELECT cubic FROM waterinfo WHERE id = 1"
        Try
            Con.Open()
            Using cmd As New MySqlCommand(query, Con)

                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    ' Display the result in the TextBox
                    cubic.Text = result.ToString()
                    displayCubic.Text = result.ToString()
                Else
                    MsgBox("No data found.")
                End If
            End Using
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try
    End Sub



    Private lastCheckTime As DateTime = DateTime.MinValue ' Initialize the last check time

    Private Sub getMonthlyIncome()

        Dim dateOneDayAgo As DateTime = DateTime.Now.AddDays(-30)


        Dim query As String = "SELECT SUM(income) FROM income WHERE date >= @date"

        Con.Open()

        Using command As New MySqlCommand(query, Con)

            command.Parameters.AddWithValue("@date", dateOneDayAgo)

            Dim monthly As Decimal = 0
            Dim result = command.ExecuteScalar()


            If result IsNot DBNull.Value Then
                monthly = Convert.ToDecimal(result)
            End If

            monthlyIncome.Text = monthly.ToString("C2")


            lastCheckTime = DateTime.Now
        End Using

        Con.Close()
    End Sub

    Private Sub getAnnualIncome()

        Dim dateOneDayAgo As DateTime = DateTime.Now.AddDays(-365)


        Dim query As String = "SELECT SUM(income) FROM income WHERE date >= @date"

        Con.Open()

        Using command As New MySqlCommand(query, Con)

            command.Parameters.AddWithValue("@date", dateOneDayAgo)

            Dim Annual As Decimal = 0
            Dim result = command.ExecuteScalar()


            If result IsNot DBNull.Value Then
                Annual = Convert.ToDecimal(result)
            End If

            annualIncome.Text = Annual.ToString("C2") ' Format as currency


            lastCheckTime = DateTime.Now
        End Using

        Con.Close()
    End Sub


    Private Sub countOfCustomers()
        Dim query As String = "SELECT COUNT(*) FROM customers"
        Con.Open()

        Using command As New MySqlCommand(query, Con)
            Dim totalRecords As Integer = Convert.ToInt32(command.ExecuteScalar())
            NumberOFCustomer.Text = totalRecords.ToString()
        End Using
        Con.Close()

    End Sub


    Private Sub Clear()
        cashierUserName.Text = ""
        cashierAge.Text = ""
        cashierAddress.Text = ""
        cashierName.Text = ""
        cashierPassword.Text = ""
        cashierAddress.Text = ""
        customerName.Text = ""
        customerAge.Text = ""
        customerAddress.Text = ""
        customerContactNumber.Text = ""
        type.Text = ""
        contactNumber.Text = ""
        customer_Id = ""
        employee_Id = ""
        type.Text = ""
    End Sub

    Public Sub populateCustomer()
        Try
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            Con.Open()
            Dim sql As String = "SELECT * FROM customers"
            Dim cmd As New MySqlCommand(sql, Con)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim builder As New MySqlCommandBuilder(adapter)
            Dim ds As New DataSet()
            adapter.Fill(ds, "customers")
            CustomersDGV.DataSource = ds.Tables("customers")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Public Sub populateAccounts()
        Try
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            Con.Open()
            Dim sql As String = "SELECT * FROM account"
            Dim cmd As New MySqlCommand(sql, Con)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim builder As New MySqlCommandBuilder(adapter)
            Dim ds As New DataSet()
            adapter.Fill(ds, "cashier_account")
            cashierDGV.DataSource = ds.Tables("cashier_account")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub Guna2TextBox2_TextChanged(sender As Object, e As EventArgs) Handles customerName.TextChanged
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
    End Sub

    Private Sub Guna2HtmlLabel5_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel5.Click
    End Sub

    Private Sub Guna2TextBox3_TextChanged(sender As Object, e As EventArgs) Handles customerAge.TextChanged
    End Sub

    Private Sub Guna2HtmlLabel6_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel6.Click
    End Sub

    Private Sub Guna2TextBox4_TextChanged(sender As Object, e As EventArgs) Handles customerAddress.TextChanged
    End Sub

    Private Sub Guna2HtmlLabel7_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel7.Click
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If customer_Id = "" Then
            Dim myId As Guid = Guid.NewGuid()
            Dim myIdString = myId.ToString().Substring(0, 6)
            customer_Id = myIdString
        End If

        Try
            Dim query As String = "INSERT INTO customers (id, employeeName, name, age, address, contactNumber) VALUES (@id, @employeeName, @name, @age, @address, @contactNumber)"

            Con.Open()
            Using cmd As New MySqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@id", customer_Id)
                cmd.Parameters.AddWithValue("@employeeName", userName.Text)
                cmd.Parameters.AddWithValue("@name", customerName.Text.ToUpper)
                cmd.Parameters.AddWithValue("@age", customerAge.Text.ToUpper)
                cmd.Parameters.AddWithValue("@address", customerAddress.Text.ToUpper)
                cmd.Parameters.AddWithValue("@contactNumber", customerContactNumber.Text.ToUpper)




                cmd.ExecuteNonQuery()
            End Using
            MsgBox("Added successfully!")
            Con.Close()

            countOfCustomers()
            populateCustomer()
            Clear()


        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub


    Private Sub getStudentData(e)
        Dim billingModal As New BillingModal()

        Dim row As DataGridViewRow = Me.CustomersDGV.Rows(e.RowIndex)
        billingModal.customer_id = row.Cells("id").Value.ToString()
        billingModal.userAdd.Text = row.Cells("employeeName").Value.ToString()
        billingModal.customerName.Text = row.Cells("name").Value.ToString()
        billingModal.customerAge.Text = row.Cells("age").Value.ToString()
        billingModal.customerAddress.Text = row.Cells("address").Value.ToString()
        billingModal.customerContactNumber.Text = row.Cells("contactNumber").Value.ToString()
        billingModal.present.Text = row.Cells("presentReading").Value.ToString()
        billingModal.previous.Text = row.Cells("previousReading").Value.ToString()
        billingModal.readingDate.Text = row.Cells("readingDate").Value.ToString()
        billingModal.dueDate.Text = row.Cells("dueDate").Value.ToString()
        billingModal.m3.Text = row.Cells("m3").Value.ToString()
        billingModal.totalAmount.Text = row.Cells("balance").Value.ToString()

        billingModal.remarks.Text = row.Cells("remark").Value.ToString()
        billingModal.Show()
        populateCustomer()
        countOfCustomers()
    End Sub


    Private Sub CustomersDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles CustomersDGV.CellContentClick
        getStudentData(e)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Application.Exit()
    End Sub

    Private Sub Guna2CustomGradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles Guna2CustomGradientPanel2.Paint

    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles EmployeesBtn.Click

        If userType.Text = "CASHIER" Then
            MessageBox.Show("This module is not available", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            TabControl1.SelectedTab = TabPage4
        End If
    End Sub



    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        TabControl1.SelectedTab = TabPage2
        populateCustomer()
        getAnnualIncome()
        getMonthlyIncome()
    End Sub



    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        TabControl1.SelectedTab = TabPage6
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click

    End Sub





    Private Sub GeneratBillingStatement()
        ' Clear existing content in RichTextBox1
        RichTextBox1.Clear()

        ' Add receipt header
        RichTextBox1.AppendText("MAHALAGANG PAALALA" & vbCrLf)
        RichTextBox1.AppendText("*** Effective immediately, sa aming opisina/tanggapan lamang po magbayad " & vbCrLf)
        RichTextBox1.AppendText("ng inyong bill para maiwasan ang pagka putol ng servisyo ng inyong tubug.***" & vbCrLf)
        RichTextBox1.AppendText("                                                           " & vbCrLf)

        RichTextBox1.AppendText("• RECONNECTION FEE - Php750 + total outstanding" & vbCrLf)
        RichTextBox1.AppendText("(Kabuuang halaga na dapat bayaran)" & vbCrLf)
        RichTextBox1.AppendText("• STOP METER - Makipag-ugnayan sa aming opisina" & vbCrLf)
        RichTextBox1.AppendText("                                                           " & vbCrLf)
        RichTextBox1.AppendText("MANGYARING HUWAG IPAGWALANG BAHALA ANG IYONG BILL PARA MAIWASAN ANG LEGAL NA PANANAGUTAN" & vbCrLf)
        RichTextBox1.AppendText("PAALALA" & vbCrLf)
        RichTextBox1.AppendText("                                                           " & vbCrLf)

        RichTextBox1.AppendText("PROMISSIONARY NOTE" & vbCrLf)
        RichTextBox1.AppendText("                                                                 Date: " & DateTime.Now.ToString("MM/dd/yyyy") & vbCrLf)
        ' Add customer pledge
        RichTextBox1.AppendText("Ako si " & billingCustomerName.Text & " ay nangangakong huhulugan ang" & vbCrLf)
        RichTextBox1.AppendText("aking pagkakautang batay sa sumusunod na kasunduan ng pagbabayad:" & vbCrLf)
        RichTextBox1.AppendText("-----------------------------" & vbCrLf)

        ' Add schedule of payment header
        RichTextBox1.AppendText("SCHEDULE OF PAYMENT" & vbCrLf)
        RichTextBox1.AppendText("----------------------------------------" & vbCrLf)
        RichTextBox1.AppendText("Date               Amount               Outstanding Balance" & vbCrLf)
        RichTextBox1.AppendText("                                                           " & vbCrLf)
        RichTextBox1.AppendText("                                                           " & vbCrLf)
        RichTextBox1.AppendText("                                                           " & vbCrLf)
        RichTextBox1.AppendText("                                                           " & vbCrLf)
        RichTextBox1.AppendText("                                                           " & vbCrLf)
        RichTextBox1.AppendText("                                                           " & vbCrLf)

        RichTextBox1.AppendText("Signature/Lagda: ________________" & vbCrLf)
        RichTextBox1.AppendText("Name/Pangalan: ________________" & vbCrLf)
        RichTextBox1.AppendText("                                                           " & vbCrLf)
        RichTextBox1.AppendText("                                                           " & vbCrLf)
        RichTextBox1.AppendText("                                                           " & vbCrLf)


        RichTextBox1.AppendText("Bill/Notice Received by:                       Date" & DateTime.Now.ToString("MM/dd/yyyy") & vbCrLf)
        RichTextBox1.AppendText("                        " & vbCrLf)

        RichTextBox1.AppendText("Signature/Lagda: ________________" & vbCrLf)
        RichTextBox1.AppendText("Banay-Banay I, San Jose, Batangas, Philippines 4227" & vbCrLf)


        For i As Integer = 1 To 7
            RichTextBox1.AppendText("                                                           " & vbCrLf)
        Next


        Dim font As New Font("Arial", 10)
        RichTextBox1.SelectAll()
        RichTextBox1.SelectionFont = font


        RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
    End Sub


    Private Sub TabPage6_Click(sender As Object, e As EventArgs) Handles TabPage6.Click

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        GeneratBillingStatement()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populateCustomer()
        populateAccounts()
        getMonthlyIncome()
        getAnnualIncome()
        countOfCustomers()
        fetchCubic()

        If userType.Text = "Cashier" Then

            AddHandler EmployeesBtn.Click, AddressOf Guna2Button5_Click
        End If







    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles cashierDGV.CellContentClick
        Dim row As DataGridViewRow = Me.cashierDGV.Rows(e.RowIndex)
        employee_Id = row.Cells("id").Value.ToString()
        cashierUserName.Text = row.Cells("userName").Value.ToString()
        cashierPassword.Text = row.Cells("password").Value.ToString()
        type.Text = row.Cells("type").Value.ToString()
        cashierName.Text = row.Cells("name").Value.ToString()
        cashierAge.Text = row.Cells("age").Value.ToString()
        cashierAddress.Text = row.Cells("address").Value.ToString()
        contactNumber.Text = row.Cells("contactNo").Value.ToString()

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Form1.Show()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Clear()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim query As String = "UPDATE account SET userName = @userName, password = @password, type = @type, name = @name, age = @age, contactNo = @contactNo, address = @address WHERE id = @employee_id"

            Con.Open()
            Using cmd As New MySqlCommand(query, Con)

                cmd.Parameters.AddWithValue("@userName", cashierUserName.Text.ToUpper())
                cmd.Parameters.AddWithValue("@password", cashierPassword.Text.ToUpper())
                cmd.Parameters.AddWithValue("@type", type.Text.ToUpper())
                cmd.Parameters.AddWithValue("@name", cashierName.Text.ToUpper())
                cmd.Parameters.AddWithValue("@age", cashierAge.Text.ToUpper())
                cmd.Parameters.AddWithValue("@contactNo", contactNumber.Text.ToUpper())
                cmd.Parameters.AddWithValue("@address", cashierAddress.Text.ToUpper())
                cmd.Parameters.AddWithValue("@employee_id", employee_Id)


                cmd.ExecuteNonQuery()
            End Using
            MsgBox("Updated successfully!")
            populateAccounts()
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try

    End Sub

    'Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles amoutToPay.TextChanged

    'End Sub

    'Private Sub Guna2TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles amoutToPay.KeyPress
    '    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
    '        ' If not, set the Handled property to true to cancel the keypress
    '        e.Handled = True
    '    End If
    'End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If employee_Id = "" Then
                MsgBox("Please select employee to be deleted!")
            Else
                ' Ensure the connection is closed before opening it
                If Con.State = ConnectionState.Open Then
                    Con.Close()
                End If

                Con.Open()


                Dim deleteQuery As String = "DELETE FROM account WHERE id = @Id"
                Using cmd As New MySqlCommand(deleteQuery, Con)
                    cmd.Parameters.AddWithValue("@Id", employee_Id)
                    cmd.ExecuteNonQuery()
                    MsgBox("deleted Successfully")
                    populateAccounts()


                End Using

                Con.Close()
            End If
        Catch ex As Exception
            MsgBox("Error removing: " & ex.Message)
        Finally

            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RichTextBox1.Clear()
        billingCustomerName.Text = ""
    End Sub

    Private Sub searchBar_TextChanged(sender As Object, e As EventArgs) Handles searchBar.TextChanged
        Dim query As String = "SELECT * FROM customers WHERE name LIKE @name"

        If Con.State = ConnectionState.Closed Then
            Con.Open()
        End If

        Try
            Using cmd As New MySqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@name", "%" & searchBar.Text & "%")

                Using da As New MySqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then

                            CustomersDGV.DataSource = dt
                        Else
                            searchBar.Text = ""
                            MessageBox.Show("Customer not found!", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Generating id for employee
        If employee_Id = "" Then
            Dim myId As Guid = Guid.NewGuid()
            Dim myIdString = myId.ToString().Substring(0, 6)
            employee_Id = myIdString
        End If

        Dim query As String = "INSERT INTO account (id, userName, password, type, name, age, contactNo, address) VALUES (@id, @userName, @password, @type, @name, @age, @contactNo, @address)"
        Try
            Con.Open()
            Using cmd As New MySqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@id", employee_Id)
                cmd.Parameters.AddWithValue("@userName", cashierUserName.Text.ToUpper())
                cmd.Parameters.AddWithValue("@password", cashierPassword.Text.ToUpper())
                cmd.Parameters.AddWithValue("@type", type.Text.ToUpper())
                cmd.Parameters.AddWithValue("@name", cashierName.Text.ToUpper())
                cmd.Parameters.AddWithValue("@age", cashierAge.Text.ToUpper())
                cmd.Parameters.AddWithValue("@contactNo", contactNumber.Text.ToUpper())
                cmd.Parameters.AddWithValue("@address", cashierAddress.Text.ToUpper())
                cmd.ExecuteNonQuery()
            End Using
            MsgBox("Created account!")
            Clear()
            populateAccounts()
            populateCustomer()
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub Guna2TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cubicPerMeter.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            ' If not, set the Handled property to true to cancel the keypress
            e.Handled = True
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim query As String = "UPDATE waterinfo SET cubic = @cubic WHERE id = 1"

        Try
            Con.Open()
            Using cmd As New MySqlCommand(query, Con)
                ' Add parameter and its value
                cmd.Parameters.AddWithValue("@cubic", cubicPerMeter.Text)

                ' Execute the query
                cmd.ExecuteNonQuery()
            End Using
            MsgBox("Updated successfully!")

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            ' Ensure the connection is closed even if an error occurs
            If Con.State = ConnectionState.Open Then
                Con.Close()
                fetchCubic()
            End If
        End Try
    End Sub




    Dim printDoc As New PrintDocument
    Dim printFont As New Font("Arial", 12)
    Dim printBrush As New SolidBrush(Color.Black)
    Dim richText As RichTextBox
    Dim currentPageText As String
    Dim currentPageStartIndex As Integer = 0
    Dim pageHeight As Single

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        richText = RichTextBox1


        currentPageStartIndex = 0
        currentPageText = richText.Text


        AddHandler printDoc.PrintPage, AddressOf PrintDocument1_PrintPage
        PrintPreviewDialog1.Document = printDoc


        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim margins As New Margins(50, 50, 50, 50)
        Dim printArea As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height)


        pageHeight = e.MarginBounds.Height


        Dim format As New StringFormat()
        format.LineAlignment = StringAlignment.Near
        format.Alignment = StringAlignment.Near


        Dim charsFitted As Integer
        Dim linesFilled As Integer
        Dim textToPrint As String = currentPageText


        e.Graphics.MeasureString(textToPrint, printFont, New SizeF(printArea.Width, pageHeight), format, charsFitted, linesFilled)


        e.Graphics.DrawString(textToPrint.Substring(0, charsFitted), printFont, printBrush, printArea, format)


        currentPageText = textToPrint.Substring(charsFitted)
        If currentPageText.Length > 0 Then

            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub



    'Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
    '    GeneratePrintReceipt()
    'End Sub

    'Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

    'End Sub
End Class