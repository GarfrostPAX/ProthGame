Imports System
Imports System.IO

Module modGraphicsInit

    Public Sub InitGraphics()
        ' A larger sub used to initialize graphics for the project. 
        ' We'll be calling smaller segmented init subs in here for everything.

        ' Load our TileSets.
        InitTileSets()

        ' Load Generic Items.
        InitGenericGraphics()

    End Sub

    Private Sub InitTileSets()
        Dim fileEntries As String() = Directory.GetFiles(var_AppPath + DIR_DATA + DIR_TILESETS)
        Dim FileName As String, Count As Integer

        ' Get the amount of tilesets found.
        var_NumTileSets = UBound(fileEntries)

        ' Make sure we actually found some tilesets.
        If fileEntries.Length > 0 Then
            ' Resize the array to accompany for all our tilesets.
            ' We're using + 1 because it looks cleaner to use 1,2,3,4,5 rather than 0,1,2,3,4
            ReDim tex_TileSet(var_NumTileSets + 1)
            ReDim var_TileSetName(var_NumTileSets + 1)

            ' Set our Counter to 0.
            Count = 0

            ' Loop through all the files found earlier.
            For Each FileName In fileEntries
                If Right(FileName, 4).ToLower = GFX_EXT Then

                    ' Increase our Counter's value.
                    Count = Count + 1

                    ' Set our object to be a texture and load in the graphic we found.
                    tex_TileSet(Count) = New SFML.Graphics.Texture(FileName)
                    tex_TileSet(Count).Smooth = False

                    ' Time to parse out our single file name.
                    var_TileSetName(Count) = Right(FileName, Len(FileName) - Len(var_AppPath + DIR_DATA + DIR_TILESETS))

                End If
            Next FileName

            ' Without adding one here we'll be getting some issues later on with offsets.
            var_NumTileSets = var_NumTileSets + 1

        Else
            ' We didn't find any. Strange.
            ' Let's notify our user and exit out.
            MsgBox("Unable to locate any tilesets.", MsgBoxStyle.Critical, "Error")
            End
        End If
    End Sub

    Public Sub InitGenericGraphics()

        ' Check if the backdrop image exists before we continue.
        If File.Exists(var_AppPath + DIR_DATA + DIR_GENERIC + "backdrop" + GFX_EXT) Then
            tex_BackDrop = New SFML.Graphics.Texture(var_AppPath + DIR_DATA + DIR_GENERIC + "backdrop" + GFX_EXT)
            tex_BackDrop.Smooth = False
        Else
            MsgBox("Unable to locate backdrop" + GFX_EXT, MsgBoxStyle.Critical, "Error")
            End
        End If

        ' Check if the select image exists before we continue.
        If File.Exists(var_AppPath + DIR_DATA + DIR_GENERIC + "select" + GFX_EXT) Then
            tex_Select = New SFML.Graphics.Texture(var_AppPath + DIR_DATA + DIR_GENERIC + "select" + GFX_EXT)
            tex_Select.Smooth = False
        Else
            MsgBox("Unable to locate select" + GFX_EXT, MsgBoxStyle.Critical, "Error")
            End
        End If

    End Sub
End Module
