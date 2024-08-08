<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentModal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(PaymentModal))
        RichTextBox2 = New RichTextBox()
        Button12 = New Button()
        Button11 = New Button()
        Guna2HtmlLabel30 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        amoutToPay = New Guna.UI2.WinForms.Guna2TextBox()
        Guna2HtmlLabel29 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel28 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel26 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel25 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel24 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        dueDate = New Guna.UI2.WinForms.Guna2HtmlLabel()
        readingDate = New Guna.UI2.WinForms.Guna2HtmlLabel()
        amout = New Guna.UI2.WinForms.Guna2HtmlLabel()
        billerAddress = New Guna.UI2.WinForms.Guna2HtmlLabel()
        billerName = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Guna2CustomGradientPanel1 = New Guna.UI2.WinForms.Guna2CustomGradientPanel()
        Button9 = New Button()
        balance = New Guna.UI2.WinForms.Guna2HtmlLabel()
        PrintDocument1 = New Printing.PrintDocument()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        Guna2CustomGradientPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        RichTextBox2.Location = New Point(382, 73)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.Size = New Size(399, 356)
        RichTextBox2.TabIndex = 90
        RichTextBox2.Text = ""
        ' 
        ' Button12
        ' 
        Button12.BackColor = Color.Aquamarine
        Button12.Location = New Point(205, 448)
        Button12.Name = "Button12"
        Button12.Size = New Size(85, 36)
        Button12.TabIndex = 89
        Button12.Text = "PrintReceipt"
        Button12.UseVisualStyleBackColor = False
        ' 
        ' Button11
        ' 
        Button11.BackColor = Color.Lime
        Button11.Location = New Point(74, 448)
        Button11.Name = "Button11"
        Button11.Size = New Size(88, 36)
        Button11.TabIndex = 88
        Button11.Text = "Pay Now"
        Button11.UseVisualStyleBackColor = False
        ' 
        ' Guna2HtmlLabel30
        ' 
        Guna2HtmlLabel30.BackColor = Color.Transparent
        Guna2HtmlLabel30.Font = New Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2HtmlLabel30.ForeColor = Color.Gray
        Guna2HtmlLabel30.Location = New Point(0, 306)
        Guna2HtmlLabel30.Name = "Guna2HtmlLabel30"
        Guna2HtmlLabel30.Size = New Size(145, 26)
        Guna2HtmlLabel30.TabIndex = 87
        Guna2HtmlLabel30.Text = "Amout to pay:"
        ' 
        ' amoutToPay
        ' 
        amoutToPay.CustomizableEdges = CustomizableEdges5
        amoutToPay.DefaultText = ""
        amoutToPay.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        amoutToPay.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        amoutToPay.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        amoutToPay.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        amoutToPay.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        amoutToPay.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        amoutToPay.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        amoutToPay.Location = New Point(151, 296)
        amoutToPay.Name = "amoutToPay"
        amoutToPay.PasswordChar = ChrW(0)
        amoutToPay.PlaceholderText = "Amout to pay"
        amoutToPay.SelectedText = ""
        amoutToPay.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        amoutToPay.Size = New Size(118, 45)
        amoutToPay.TabIndex = 86
        ' 
        ' Guna2HtmlLabel29
        ' 
        Guna2HtmlLabel29.BackColor = Color.Transparent
        Guna2HtmlLabel29.Font = New Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2HtmlLabel29.ForeColor = Color.Gray
        Guna2HtmlLabel29.Location = New Point(2, 207)
        Guna2HtmlLabel29.Name = "Guna2HtmlLabel29"
        Guna2HtmlLabel29.Size = New Size(100, 26)
        Guna2HtmlLabel29.TabIndex = 85
        Guna2HtmlLabel29.Text = "Due date:"
        ' 
        ' Guna2HtmlLabel28
        ' 
        Guna2HtmlLabel28.BackColor = Color.Transparent
        Guna2HtmlLabel28.Font = New Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2HtmlLabel28.ForeColor = Color.Gray
        Guna2HtmlLabel28.Location = New Point(2, 156)
        Guna2HtmlLabel28.Name = "Guna2HtmlLabel28"
        Guna2HtmlLabel28.Size = New Size(143, 26)
        Guna2HtmlLabel28.TabIndex = 84
        Guna2HtmlLabel28.Text = "Reading date:"
        ' 
        ' Guna2HtmlLabel26
        ' 
        Guna2HtmlLabel26.BackColor = Color.Transparent
        Guna2HtmlLabel26.Font = New Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2HtmlLabel26.ForeColor = Color.Gray
        Guna2HtmlLabel26.Location = New Point(2, 256)
        Guna2HtmlLabel26.Name = "Guna2HtmlLabel26"
        Guna2HtmlLabel26.Size = New Size(77, 26)
        Guna2HtmlLabel26.TabIndex = 82
        Guna2HtmlLabel26.Text = "Amout:"
        ' 
        ' Guna2HtmlLabel25
        ' 
        Guna2HtmlLabel25.BackColor = Color.Transparent
        Guna2HtmlLabel25.Font = New Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2HtmlLabel25.ForeColor = Color.Gray
        Guna2HtmlLabel25.Location = New Point(2, 111)
        Guna2HtmlLabel25.Name = "Guna2HtmlLabel25"
        Guna2HtmlLabel25.Size = New Size(95, 26)
        Guna2HtmlLabel25.TabIndex = 81
        Guna2HtmlLabel25.Text = "Address:"
        ' 
        ' Guna2HtmlLabel24
        ' 
        Guna2HtmlLabel24.BackColor = Color.Transparent
        Guna2HtmlLabel24.Font = New Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2HtmlLabel24.ForeColor = Color.Gray
        Guna2HtmlLabel24.Location = New Point(2, 73)
        Guna2HtmlLabel24.Name = "Guna2HtmlLabel24"
        Guna2HtmlLabel24.Size = New Size(122, 26)
        Guna2HtmlLabel24.TabIndex = 80
        Guna2HtmlLabel24.Text = "Biller name:"
        ' 
        ' dueDate
        ' 
        dueDate.BackColor = Color.Transparent
        dueDate.Font = New Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        dueDate.Location = New Point(147, 204)
        dueDate.Name = "dueDate"
        dueDate.Size = New Size(80, 24)
        dueDate.TabIndex = 79
        dueDate.Text = "Due date"
        ' 
        ' readingDate
        ' 
        readingDate.BackColor = Color.Transparent
        readingDate.Font = New Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        readingDate.Location = New Point(147, 156)
        readingDate.Name = "readingDate"
        readingDate.Size = New Size(116, 24)
        readingDate.TabIndex = 78
        readingDate.Text = "Reading date"
        ' 
        ' amout
        ' 
        amout.BackColor = Color.Transparent
        amout.Font = New Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        amout.Location = New Point(147, 251)
        amout.Name = "amout"
        amout.Size = New Size(58, 24)
        amout.TabIndex = 76
        amout.Text = "Amout"
        ' 
        ' billerAddress
        ' 
        billerAddress.BackColor = Color.Transparent
        billerAddress.Font = New Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        billerAddress.Location = New Point(147, 108)
        billerAddress.Name = "billerAddress"
        billerAddress.Size = New Size(75, 24)
        billerAddress.TabIndex = 75
        billerAddress.Text = "Address"
        ' 
        ' billerName
        ' 
        billerName.BackColor = Color.Transparent
        billerName.Font = New Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        billerName.Location = New Point(147, 73)
        billerName.Name = "billerName"
        billerName.Size = New Size(53, 24)
        billerName.TabIndex = 74
        billerName.Text = "Name"
        ' 
        ' Guna2HtmlLabel1
        ' 
        Guna2HtmlLabel1.BackColor = Color.Transparent
        Guna2HtmlLabel1.Font = New Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Guna2HtmlLabel1.ForeColor = Color.Gray
        Guna2HtmlLabel1.Location = New Point(-2, 357)
        Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Guna2HtmlLabel1.Size = New Size(91, 26)
        Guna2HtmlLabel1.TabIndex = 92
        Guna2HtmlLabel1.Text = "Balance:"
        ' 
        ' Guna2CustomGradientPanel1
        ' 
        Guna2CustomGradientPanel1.Controls.Add(Button9)
        Guna2CustomGradientPanel1.CustomizableEdges = CustomizableEdges7
        Guna2CustomGradientPanel1.FillColor = Color.OliveDrab
        Guna2CustomGradientPanel1.Location = New Point(-12, 1)
        Guna2CustomGradientPanel1.Name = "Guna2CustomGradientPanel1"
        Guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Guna2CustomGradientPanel1.Size = New Size(810, 43)
        Guna2CustomGradientPanel1.TabIndex = 93
        ' 
        ' Button9
        ' 
        Button9.BackColor = Color.Transparent
        Button9.BackgroundImageLayout = ImageLayout.Center
        Button9.FlatAppearance.BorderSize = 0
        Button9.FlatStyle = FlatStyle.Flat
        Button9.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        Button9.Location = New Point(730, 3)
        Button9.Name = "Button9"
        Button9.Size = New Size(63, 37)
        Button9.TabIndex = 6
        Button9.Text = "X"
        Button9.UseVisualStyleBackColor = False
        ' 
        ' balance
        ' 
        balance.BackColor = Color.Transparent
        balance.Font = New Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        balance.Location = New Point(147, 360)
        balance.Name = "balance"
        balance.Size = New Size(14, 24)
        balance.TabIndex = 94
        balance.Text = "0"
        ' 
        ' PrintDocument1
        ' 
        ' 
        ' PrintPreviewDialog1
        ' 
        PrintPreviewDialog1.AutoScrollMargin = New Size(0, 0)
        PrintPreviewDialog1.AutoScrollMinSize = New Size(0, 0)
        PrintPreviewDialog1.ClientSize = New Size(400, 300)
        PrintPreviewDialog1.Enabled = True
        PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Icon)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintPreviewDialog1.Visible = False
        ' 
        ' PaymentModal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(793, 511)
        Controls.Add(balance)
        Controls.Add(Guna2CustomGradientPanel1)
        Controls.Add(Guna2HtmlLabel1)
        Controls.Add(RichTextBox2)
        Controls.Add(Button12)
        Controls.Add(Button11)
        Controls.Add(Guna2HtmlLabel30)
        Controls.Add(amoutToPay)
        Controls.Add(Guna2HtmlLabel29)
        Controls.Add(Guna2HtmlLabel28)
        Controls.Add(Guna2HtmlLabel26)
        Controls.Add(Guna2HtmlLabel25)
        Controls.Add(Guna2HtmlLabel24)
        Controls.Add(dueDate)
        Controls.Add(readingDate)
        Controls.Add(amout)
        Controls.Add(billerAddress)
        Controls.Add(billerName)
        FormBorderStyle = FormBorderStyle.None
        Name = "PaymentModal"
        StartPosition = FormStartPosition.CenterScreen
        Text = "PaymentModal"
        Guna2CustomGradientPanel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents Button12 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Guna2HtmlLabel30 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents amoutToPay As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2HtmlLabel29 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel28 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel26 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel25 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel24 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dueDate As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents readingDate As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents amout As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents billerAddress As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents billerName As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2CustomGradientPanel1 As Guna.UI2.WinForms.Guna2CustomGradientPanel
    Friend WithEvents balance As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents Button9 As Button
End Class
