Module modClientLogic

    Private var_ClientState

    Public Sub SetClientState(ByVal State As GameState)
        var_ClientState = State
    End Sub

    Public Function GetClientState() As GameState
        Return var_ClientState
    End Function

End Module
