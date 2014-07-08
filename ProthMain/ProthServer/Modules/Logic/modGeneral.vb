Module modGeneral

    Public Sub CalculateHighIndex()
        Dim i As Integer, result As Integer

        ' Set our default result to 0.
        result = 0

        ' Loop through all our slots
        For i = 1 To MAX_PLAYERS
            ' Set our result to the latest one that's not empty.
            If obj_TempPlayer(i).ServerGUID <> Guid.Empty Then result = i
        Next

        ' Assign our new HighIndex value.
        var_PlayerHighIndex = result
    End Sub

    Public Function FileExist(ByVal File As String) As Boolean
        Return System.IO.File.Exists(var_AppPath + File)
    End Function

End Module
