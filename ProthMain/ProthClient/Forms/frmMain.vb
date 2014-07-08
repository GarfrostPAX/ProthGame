Public Class frmMain

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Time to run some checks here.
        ' let's see if the text entered is above 0.
        If txtUsername.Text.Length > 0 And txtPassword.Text.Length > 0 Then
            
            ' Make sure they can't click it a second time.
            btnLogin.Enabled = False
            txtUsername.Enabled = False
            txtPassword.Enabled = False

            ' Set the variable state of loggingin to true.
            var_LoggingIn = LoginStates.Processing

            ' Set the status label to "Logging In"
            lblStatus.Text = "Logging In.."

            ' That all checks out, we can send our login request.
            SendRequestLogin(txtUsername.Text.Trim, txtPassword.Text.Trim)

            ' Wait for an answer.
            Do While var_LoggingIn = LoginStates.Processing
                ' Still need to process the form.
                Application.DoEvents()
            Loop

            ' Handle the form depending on the state of our login.
            If var_LoggingIn = LoginStates.Rejected Then
                ' We've been rejected.
                ' Set our form back to normal.
                btnLogin.Enabled = True
                txtUsername.Enabled = True
                txtPassword.Enabled = True
                lblStatus.Text = "Login Failed"
                var_LoggingIn = LoginStates.None

                ' Notify our user that their username/password may be incorrect.
                MsgBox("Could not authenticate with the server." + vbNewLine + "Make sure your Username and Password are entered correctly.", MsgBoxStyle.Critical, "Could not Login")
            ElseIf var_LoggingIn = LoginStates.Accepted Then
                ' Accepted, we should move on to character selection!
                ' First, reset the login window.
                btnLogin.Enabled = True
                txtUsername.Enabled = True
                txtPassword.Enabled = True
                lblStatus.Text = "Connected"

                ' Now make sure the labels and buttons are set up properly.
                ' That is, on the character selection screen.
                If var_TempName(1) <> "" Then
                    lblCharName1.Text = var_TempName(1) + " Lv." + var_TempLevel(1).ToString
                    btnCharSlot1.Text = "Play"
                Else
                    lblCharName1.Text = "Empty"
                    btnCharSlot1.Text = "Create"
                End If
                If var_TempName(2) <> "" Then
                    lblCharName2.Text = var_TempName(2) + " Lv." + var_TempLevel(2).ToString
                    btnCharSlot2.Text = "Play"
                Else
                    lblCharName2.Text = "Empty"
                    btnCharSlot2.Text = "Create"
                End If
                If var_TempName(3) <> "" Then
                    lblCharName3.Text = var_TempName(3) + " Lv." + var_TempLevel(3).ToString
                    btnCharSlot3.Text = "Play"
                Else
                    lblCharName3.Text = "Empty"
                    btnCharSlot3.Text = "Create"
                End If

                ' Now hide the login window and show the character selection window.
                PanelLogin.Visible = False
                PanelCharacters.Visible = True
            End If
        Else
            ' It isn't. Silly people.
            MsgBox("Please enter something before attempting to log in!")
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main()
    End Sub
End Class
