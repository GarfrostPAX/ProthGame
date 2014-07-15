Module modClientLogic

    Private var_ClientState

    Public Sub SetClientState(ByVal State As GameState)
        var_ClientState = State
    End Sub

    Public Function GetClientState() As GameState
        Return var_ClientState
    End Function

    Public Sub HandleLogout()

        ' Send our logout packet.
        ' We're not going to wait for a response to this and just act on it locally.
        SendRequestLogout()

        ' Before we set the states back to login, let's set every other menu to invisible and login to visible.
        win_Login.Visible = True
        win_CharSelect.Visible = False

        ' Set our label to logged out.
        lbl_LoginStatus.Text = "Logged out"
        lbl_LoginStatus.TextColor = SFML.Graphics.Color.White

        ' Set the gamestate back to logging in.
        SetClientState(GameState.Login)
    End Sub

End Module
