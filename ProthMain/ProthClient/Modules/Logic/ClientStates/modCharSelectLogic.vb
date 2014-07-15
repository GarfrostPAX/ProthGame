Imports TGUI

Module modCharSelectLogic

    Public Sub HandleCharSelectCloseButton()
        ' Send a logout message!
        HandleLogout()
    End Sub

    Public Sub HandleCharSelectButton1(sender As Object, e As CallbackArgs)
        HandleCharSelectButton(1)
    End Sub

    Public Sub HandleCharSelectButton2(sender As Object, e As CallbackArgs)
        HandleCharSelectButton(2)
    End Sub

    Public Sub HandleCharSelectButton3(sender As Object, e As CallbackArgs)
        HandleCharSelectButton(3)
    End Sub

    Public Sub HandleCharSelectButton(ByVal CharSlot As Byte)

        ' Check if the selected slot has a character in it.
        If var_TempName(CharSlot).Length > 0 Then
            ' This slot is in use.. We're going to log in with it.
            ' TODO: Actually log in with it.

        Else
            ' This slot is unused! Let's save the slot number and get cracking on character creation.
            var_TempSlot = CharSlot

            ' Hide current window and switch the clientstate to character creation.
            win_CharSelect.Visible = False
            SetClientState(GameState.CharCreate)
        End If

    End Sub

End Module
