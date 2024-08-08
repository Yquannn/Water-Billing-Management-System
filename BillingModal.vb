Imports System.Net
Imports MySql.Data.MySqlClient

Public Class BillingModal
    Dim connection As String = "server=127.0.0.1; user=root; database=water-billing; password="
    Dim Con As New MySqlConnection(connection)
    Public customer_id = ""
    Public reference_number = ""
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Hide()

    End Sub


    Public Sub fetchCubic()
        Dim query As String = "SELECT cubic FROM waterinfo WHERE id = 1"
        Try
            Con.Open()
            Using cmd As New MySqlCommand(query, Con)

                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing Then

                    cubic = result.ToString()
                Else
                    MsgBox("No data found.")
                End If
            End Using
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try
    End Sub


    Private Sub BillingModal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        readingDate.Format = DateTimePickerFormat.Custom
        readingDate.CustomFormat = "MM/dd/yyyy"
        dueDate.Format = DateTimePickerFormat.Custom
        dueDate.CustomFormat = "MM/dd/yyyy"
        Me.ShowInTaskbar = False
        fetchCubic()

    End Sub




    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MsgBox("You can now update the data")
        customerName.ReadOnly = False
        customerAge.ReadOnly = False
        customerContactNumber.ReadOnly = False
        customerAddress.ReadOnly = False
        previous.ReadOnly = False
        present.ReadOnly = False
        m3.ReadOnly = False
        totalAmount.ReadOnly = False

    End Sub
    Dim cubic As Double
    Private Sub previous_TextChanged(sender As Object, e As EventArgs) Handles previous.TextChanged

        Dim presentValue As Double
        Dim previousValue As Double

        Dim subTotal As Double
        Dim total As Double


        If Double.TryParse(present.Text, presentValue) AndAlso Double.TryParse(previous.Text, previousValue) Then
            subTotal = presentValue - previousValue
            total = subTotal * cubic
            m3.Text = subTotal
            totalAmount.Text = total

        End If

    End Sub

    Private Sub present_KeyPress(sender As Object, e As KeyPressEventArgs) Handles present.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            ' If not, set the Handled property to true to cancel the keypress
            e.Handled = True
        End If
    End Sub

    Private Sub previous_KeyPress(sender As Object, e As KeyPressEventArgs) Handles previous.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            ' If not, set the Handled property to true to cancel the keypress
            e.Handled = True
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Con.Close()
        Try
            Dim newForm2 As New Form2()
            Dim query As String = "UPDATE customers SET name = @name, age = @age, address = @address, contactNumber = @contactNumber, presentReading = @present_reading, readingDate = @readingDate, dueDate = @dueDate, previousReading = @previous_reading, m3 = @m3, totalAmount = @total_amount, remark = @remark, balance = @balance WHERE id = @customer_id"

            Con.Open()
            Using cmd As New MySqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@name", customerName.Text)
                cmd.Parameters.AddWithValue("@age", customerAge.Text.ToUpper())
                cmd.Parameters.AddWithValue("@address", customerAddress.Text.ToUpper())
                cmd.Parameters.AddWithValue("@contactNumber", customerContactNumber.Text)
                cmd.Parameters.AddWithValue("@present_reading", present.Text)
                cmd.Parameters.AddWithValue("@readingDate", readingDate.Text.ToUpper())
                cmd.Parameters.AddWithValue("@dueDate", dueDate.Text.ToUpper())
                cmd.Parameters.AddWithValue("@previous_reading", previous.Text)
                cmd.Parameters.AddWithValue("@m3", m3.Text.ToUpper())
                cmd.Parameters.AddWithValue("@total_amount", totalAmount.Text)
                cmd.Parameters.AddWithValue("@remark", remarks.Text.ToUpper())
                cmd.Parameters.AddWithValue("@balance", totalAmount.Text.ToUpper())

                ' Ensure customer_id is properly set
                If String.IsNullOrEmpty(customer_id) Then
                    MsgBox("Customer ID is not set.")
                    Return
                End If
                cmd.Parameters.AddWithValue("@customer_id", customer_id)

                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Data saved!")


            present.ReadOnly = True
            previous.ReadOnly = True
            m3.ReadOnly = True
            totalAmount.ReadOnly = True


            newForm2.populateCustomer()
            Me.Refresh()

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            Con.Close()
        End Try



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If totalAmount.Text = "0" Then
            MessageBox.Show("This customer has fully paid.", "Payment Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim payBills As New PaymentModal()
            Me.Hide()
            payBills.billerName.Text = customerName.Text
            payBills.billerAddress.Text = customerAddress.Text
            payBills.amout.Text = totalAmount.Text
            payBills.readingDate.Text = readingDate.Text
            payBills.dueDate.Text = dueDate.Text
            payBills.customer_ID = customer_id


            '' Generate a unique income_ID if it's empty
            'If String.IsNullOrEmpty(payBills.income_ID) Then
            '    Dim myId As Guid = Guid.NewGuid()
            '    payBills.income_ID = myId.ToString().Substring(0, 6)
            'End If


            payBills.Show()
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If customer_id = "" Then
                MsgBox("Please select customer to be deleted!")
            Else

                If Con.State = ConnectionState.Open Then
                    Con.Close()
                End If

                Con.Open()


                Dim deleteQuery As String = "DELETE FROM customers WHERE id = @Id"
                Using cmd As New MySqlCommand(deleteQuery, Con)
                    cmd.Parameters.AddWithValue("@Id", customer_id)
                    cmd.ExecuteNonQuery()
                    MsgBox("deleted Successfully")
                    Me.Hide()

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

    Private Sub present_TextChanged(sender As Object, e As EventArgs) Handles present.TextChanged

    End Sub


End Class