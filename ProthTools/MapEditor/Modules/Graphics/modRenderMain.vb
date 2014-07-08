Imports SFML.Window
Imports SFML.Graphics

Module modRenderMain

    Public Sub RenderMainView()

        ' Open our Rendering Sequence and clear our screen from old data.
        ' Wouldn't want it to just stack on eachother when something is removed.
        render_Main.DispatchEvents()
        render_Main.Clear(SFML.Graphics.Color.Black)

        ' Render the fancy map backdrop.
        RenderBackdrop()

        ' Render all the tiles that would normally appear UNDER the player.
        RenderMap(True)

        ' Render all the tiles that would normally appear ABOVE the player.
        RenderMap(False)

        ' Display our changes to the screen.
        render_Main.Display()

    End Sub

    Private Sub RenderBackdrop()
        Dim tempSpr As SFML.Graphics.Sprite
        Dim x As Integer, y As Integer

        tempSpr = New Sprite(tex_BackDrop)

        ' Loop through all the tiles we know of.
        For x = 0 To Map.SizeX
            For y = 0 To Map.SizeY

                ' Render the graphic to the right location.
                tempSpr.Position = New Vector2f(x * TILE_X, y * TILE_Y)
                render_Main.Draw(tempSpr)

            Next
        Next

    End Sub

    Private Sub RenderMap(ByVal UnderPlayer As Boolean)
        Dim l As Byte, x As Byte, y As Byte
        ' This sub will render the entire map to the screen.
        ' Note that the UnderPlayer modifier you pass into this equals the same boolean value as 
        ' your layers will. It will only render those layers that equal the value you pass.

        ' Start looping through our layers.
        For l = 1 To Map.LayerCount

            ' Check if this layer should be rendered on this pass.
            If Map.Layers(l).UnderPlayer = UnderPlayer Then

                ' Now loop through the X/Y values of this layer to render this thing.
                ' We start at 0 here, this means we don't need to mess with more blasted offset values than we do already.
                ' Also means that this is an array that doesn't have a blank entry in it for once!
                For x = 0 To Map.SizeX
                    For y = 0 To Map.SizeY
                        ' Render the actual tile.
                        RenderTile(l, x, y)
                    Next
                Next
            End If

        Next

    End Sub

    Private Sub RenderTile(ByVal Layer As Byte, ByVal X As Integer, ByVal Y As Integer)
        Dim tempSpr As SFML.Graphics.Sprite, tempRec As SFML.Graphics.IntRect

        ' Before we do anything, make sure this tile actually has a valid tileset linked to it.
        ' if not, just exit out. No point in trying to render it.
        If Map.Layers(Layer).Tiles(X, Y).TileSetID <= 0 Or Map.Layers(Layer).Tiles(X, Y).TileSetID > var_NumTileSets Then
            Exit Sub
        End If

        ' create a rect with the right coordinated to pick our desired tile from.
        ' saves creating a sprite from an entire tilesheet.
        With tempRec
            .Left = Map.Layers(Layer).Tiles(X, Y).TileSetX
            .Top = Map.Layers(Layer).Tiles(X, Y).TileSetY
            .Width = TILE_X
            .Height = TILE_Y
        End With

        ' Make a Temporary sprite to dump our image in.
        tempSpr = New Sprite(tex_TileSet(Map.Layers(Layer).Tiles(X, Y).TileSetID), tempRec)

        ' Position our sprite in the right location.
        tempSpr.Position = New Vector2f(X * TILE_X, Y * TILE_Y)

        ' Now draw it to the screen!
        render_Main.Draw(tempSpr)

        ' Clear out our values so we don't hoard memory.
        tempRec = Nothing
        tempSpr = Nothing
    End Sub

End Module
