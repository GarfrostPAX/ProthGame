Imports SFML.Window

Module modLoginLogic

    Public Sub HandleLoginButton()

        ' Make sure our user has actually entered something.
        If Len(Trim(txt_Username.Text)) < 1 Or Len(Trim(txt_Password.Text)) < 1 Then
            ' They haven't, let's notify them and then exit this sub.
            lbl_LoginStatus.TextColor = New SFML.Graphics.Color(255, 0, 0)
            lbl_LoginStatus.Text = "Please enter your login details."
            Exit Sub
        End If

        ' Seems like the user has entered some information, we should send a login request.
        SendRequestLogin(txt_Username.Text.Trim, txt_Password.Text.Trim)

        ' Notify our user we're authenticating.
        lbl_LoginStatus.TextColor = New SFML.Graphics.Color(255, 140, 0)
        lbl_LoginStatus.Text = "Authenticating.."

        ' Wait for an answer.
        Do While var_LoggingIn = LoginStates.Processing
            ' Still need to process the form.
            Application.DoEvents()
        Loop

        ' Handle our response accordingly!
        If var_LoggingIn = LoginStates.Rejected Then
            ' Notify our user that their username/password is incorrect.
            lbl_LoginStatus.TextColor = New SFML.Graphics.Color(255, 0, 0)
            lbl_LoginStatus.Text = "Incorrect Username/Password"

            ' Set the loginstate back to nothing.
            var_LoggingIn = LoginStates.None

        ElseIf var_LoggingIn = LoginStates.Accepted Then
            ' We've been accepted and have receive our required data for our lovely character selection screen!
            ' Let's set the data to appear on there before continuing on.
            UpdateCharSelectGraphics()

            ' Hide our current window as to not cause any issues.
            ' Not doing this results in the window physically being there, but not visually.
            CloseAllWindows()
            win_CharSelect.Visible = True

            ' Clear out our user data.
            ' We don't want to store the person's password in memory.
            txt_Password.Text = ""

            ' Move on to the character selection screen!
            SetClientState(GameState.CharSelect)
        End If

    End Sub

    Public Sub HandleLoginCloseButton()
        ' Set our gamestate to closing.
        ' Our loop will handle the rest.
        SetClientState(GameState.Closing)
    End Sub

    Public Sub HandleLoginKeyPressed(sender As Object, Code As Keyboard.Key, Shift As Boolean, Control As Boolean, Alt As Boolean)

        ' Pick which key is being pressed.
        Select Case Code

            Case Keyboard.Key.Return
                HandleLoginButton()
                Exit Sub

        End Select

    End Sub

End Module
