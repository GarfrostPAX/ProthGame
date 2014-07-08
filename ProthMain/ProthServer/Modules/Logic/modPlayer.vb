Module modPlayer

    Public Function FindEmptySlot() As Integer
        Dim i As Integer

        ' Loop through all the player slots.
        For i = 1 To MAX_PLAYERS
            ' Check if the slot is in use.
            If obj_TempPlayer(i).ServerGUID = Guid.Empty Then
                ' This slot is not in use, return it as usable!
                Return i
                Exit Function
            End If
        Next

        ' No slot found, return 0
        Return 0
    End Function

    Public Function FindPlayerByGUID(ByVal PlayerGUID As Guid) As Integer
        Dim i As Integer

        ' Check if there's any players actually logged on before looping this.
        If var_PlayerHighIndex > 0 And var_PlayerHighIndex <= 500 Then
            ' Loop through all the player slots that might be in use to find our GUID.
            For i = 1 To var_PlayerHighIndex
                If obj_TempPlayer(i).ServerGUID = PlayerGUID Then
                    ' We found our GUID, set the result and exit the function. No need to loop any further.
                    Return i
                    Exit Function
                End If
            Next
        End If

        ' Nothing found, return 0
        Return 0
    End Function

    Public Function GetPlayerGUID(ByVal Slot As Integer) As Guid
        If Slot > 0 And Slot < MAX_PLAYERS Then
            Return obj_TempPlayer(Slot).ServerGUID
        Else
            Return Guid.Empty
        End If
    End Function

End Module
