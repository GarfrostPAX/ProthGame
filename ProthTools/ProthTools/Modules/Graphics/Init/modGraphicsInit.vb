Imports System
Imports System.IO

Module modGraphicsInit

    Public Sub InitGraphics()
        ' A larger sub used to initialize graphics for the project. 
        ' We'll be calling smaller segmented init subs in here for everything.

        ' Load our TileSets.
        InitTileSets()

    End Sub

    Private Sub InitTileSets()
        Dim fileEntries As String() = Directory.GetFiles(var_AppPath + DIR_DATA + DIR_TILESETS)
        Dim FileName As String, numTileSets As Integer, Count As Integer

        ' Get the amount of tilesets found.
        numTileSets = UBound(fileEntries)

        ' Make sure we actually found some tilesets.
        If numTileSets > 0 Then
            ' Resize the array to accompany for all our tilesets.
            ' We're using + 1 because it looks cleaner to use 1,2,3,4,5 rather than 0,1,2,3,4
            ReDim tex_TileSet(numTileSets + 1)

            ' Set our Counter to 0.
            Count = 0

            ' Loop through all the files found earlier.
            For Each FileName In fileEntries
                If Right(FileName, 4).ToLower = GFX_EXT Then

                    ' Increase our Counter's value.
                    Count = Count + 1

                    ' Set our object to be a texture and load in the graphic we found.
                    tex_TileSet(Count) = New SFML.Graphics.Texture(FileName)

                End If
            Next FileName
        Else
            ' We didn't find any. Strange.
            ' Let's notify our user and exit out.
            MsgBox("Unable to locate any tilesets.", MsgBoxStyle.Critical, "Error")
            End
        End If
    End Sub
End Module
