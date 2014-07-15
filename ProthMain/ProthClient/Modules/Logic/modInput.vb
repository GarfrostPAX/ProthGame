Imports SFML.Window

Module modInput
    Public Sub HandleMouseClick(sender As Object, e As MouseButtonEventArgs)

        ' Handle these cases depending on what state we're in.
        Select Case GetClientState()

        End Select

    End Sub

    Public Sub HandleKeyPressed(sender As Object, e As KeyEventArgs)
        
        ' Handle these cases depending on what state we're in.
        Select Case GetClientState()

            Case GameState.Login
                HandleLoginKeyPressed(sender, e.Code, e.Shift, e.Control, e.Alt)

        End Select

    End Sub

End Module
