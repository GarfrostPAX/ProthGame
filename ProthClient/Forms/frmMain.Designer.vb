<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.PanelLogin = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.PanelCharacters = New System.Windows.Forms.Panel()
        Me.btnCharSlot3 = New System.Windows.Forms.Button()
        Me.btnCharSlot2 = New System.Windows.Forms.Button()
        Me.lblCharName3 = New System.Windows.Forms.Label()
        Me.lblCharName2 = New System.Windows.Forms.Label()
        Me.btnCharSlot1 = New System.Windows.Forms.Button()
        Me.lblCharName1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelLogin.SuspendLayout()
        Me.PanelCharacters.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(106, 91)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 6
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(106, 65)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtUsername.TabIndex = 5
        Me.txtUsername.Text = "Silvh"
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(131, 117)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 4
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'PanelLogin
        '
        Me.PanelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelLogin.Controls.Add(Me.PanelCharacters)
        Me.PanelLogin.Controls.Add(Me.lblStatus)
        Me.PanelLogin.Controls.Add(Me.txtUsername)
        Me.PanelLogin.Controls.Add(Me.btnLogin)
        Me.PanelLogin.Controls.Add(Me.txtPassword)
        Me.PanelLogin.Location = New System.Drawing.Point(237, 162)
        Me.PanelLogin.Name = "PanelLogin"
        Me.PanelLogin.Size = New System.Drawing.Size(320, 200)
        Me.PanelLogin.TabIndex = 7
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(65, 143)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(209, 17)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "Label1"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelCharacters
        '
        Me.PanelCharacters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelCharacters.Controls.Add(Me.btnCharSlot3)
        Me.PanelCharacters.Controls.Add(Me.btnCharSlot2)
        Me.PanelCharacters.Controls.Add(Me.lblCharName3)
        Me.PanelCharacters.Controls.Add(Me.lblCharName2)
        Me.PanelCharacters.Controls.Add(Me.btnCharSlot1)
        Me.PanelCharacters.Controls.Add(Me.lblCharName1)
        Me.PanelCharacters.Controls.Add(Me.Label1)
        Me.PanelCharacters.Location = New System.Drawing.Point(-1, -1)
        Me.PanelCharacters.Name = "PanelCharacters"
        Me.PanelCharacters.Size = New System.Drawing.Size(320, 200)
        Me.PanelCharacters.TabIndex = 8
        Me.PanelCharacters.Visible = False
        '
        'btnCharSlot3
        '
        Me.btnCharSlot3.Location = New System.Drawing.Point(225, 127)
        Me.btnCharSlot3.Name = "btnCharSlot3"
        Me.btnCharSlot3.Size = New System.Drawing.Size(75, 23)
        Me.btnCharSlot3.TabIndex = 6
        Me.btnCharSlot3.Text = "Button1"
        Me.btnCharSlot3.UseVisualStyleBackColor = True
        '
        'btnCharSlot2
        '
        Me.btnCharSlot2.Location = New System.Drawing.Point(122, 127)
        Me.btnCharSlot2.Name = "btnCharSlot2"
        Me.btnCharSlot2.Size = New System.Drawing.Size(75, 23)
        Me.btnCharSlot2.TabIndex = 5
        Me.btnCharSlot2.Text = "Button1"
        Me.btnCharSlot2.UseVisualStyleBackColor = True
        '
        'lblCharName3
        '
        Me.lblCharName3.AutoSize = True
        Me.lblCharName3.Location = New System.Drawing.Point(240, 94)
        Me.lblCharName3.Name = "lblCharName3"
        Me.lblCharName3.Size = New System.Drawing.Size(34, 13)
        Me.lblCharName3.TabIndex = 4
        Me.lblCharName3.Text = "Slot 3"
        '
        'lblCharName2
        '
        Me.lblCharName2.AutoSize = True
        Me.lblCharName2.Location = New System.Drawing.Point(142, 93)
        Me.lblCharName2.Name = "lblCharName2"
        Me.lblCharName2.Size = New System.Drawing.Size(34, 13)
        Me.lblCharName2.TabIndex = 3
        Me.lblCharName2.Text = "Slot 2"
        '
        'btnCharSlot1
        '
        Me.btnCharSlot1.Location = New System.Drawing.Point(20, 127)
        Me.btnCharSlot1.Name = "btnCharSlot1"
        Me.btnCharSlot1.Size = New System.Drawing.Size(75, 23)
        Me.btnCharSlot1.TabIndex = 2
        Me.btnCharSlot1.Text = "Button1"
        Me.btnCharSlot1.UseVisualStyleBackColor = True
        '
        'lblCharName1
        '
        Me.lblCharName1.AutoSize = True
        Me.lblCharName1.Location = New System.Drawing.Point(38, 91)
        Me.lblCharName1.Name = "lblCharName1"
        Me.lblCharName1.Size = New System.Drawing.Size(34, 13)
        Me.lblCharName1.TabIndex = 1
        Me.lblCharName1.Text = "Slot 1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(106, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Character Selection"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.PanelLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMain"
        Me.Text = "Prothesys"
        Me.PanelLogin.ResumeLayout(False)
        Me.PanelLogin.PerformLayout()
        Me.PanelCharacters.ResumeLayout(False)
        Me.PanelCharacters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents PanelLogin As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents PanelCharacters As System.Windows.Forms.Panel
    Friend WithEvents btnCharSlot3 As System.Windows.Forms.Button
    Friend WithEvents btnCharSlot2 As System.Windows.Forms.Button
    Friend WithEvents lblCharName3 As System.Windows.Forms.Label
    Friend WithEvents lblCharName2 As System.Windows.Forms.Label
    Friend WithEvents btnCharSlot1 As System.Windows.Forms.Button
    Friend WithEvents lblCharName1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
