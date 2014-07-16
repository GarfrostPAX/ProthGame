Imports TGUI

Module modCharCreateLogic

    Public Sub HandleCharCreateCloseButton(sender As Object, e As CallbackArgs)

        ' Close the window and go back to char selection.
        CloseAllWindows()
        win_CharSelect.Visible = True
        SetClientState(GameState.CharSelect)

    End Sub

    Public Sub HandleCharCreateButton(sender As Object, e As CallbackArgs)
        ' Pass on our request to the server.
        SendRequestCreateChar()
    End Sub

End Module
