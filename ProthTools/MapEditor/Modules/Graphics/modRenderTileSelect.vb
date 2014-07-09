Module modRenderTileSelect

    Public Sub RenderTileSelect()

        ' Open our Rendering Sequence and clear our screen from old data.
        ' Wouldn't want it to just stack on eachother when something is removed.
        render_TileSelect.DispatchEvents()
        render_TileSelect.Clear(SFML.Graphics.Color.Black)

        ' Render tileset backdrop.
        RenderTileSetBackdrop()

        ' Render the actual tileset.
        RenderTileSet()

        ' Display our changes to the screen.
        render_TileSelect.Display()

    End Sub

    Public Sub RenderTileSet()
        Dim tempSpr As SFML.Graphics.Sprite

        ' Grab our tileset.
        tempSpr = New SFML.Graphics.Sprite(tex_TileSet(var_CurrentTileSet))

        ' Paste it on-screen.
        render_TileSelect.Draw(tempSpr)

    End Sub

    Public Sub RenderTileSetBackdrop()
        Dim X As Integer, Y As Integer, Width As Integer, Height As Integer
        Dim tempSpr As SFML.Graphics.Sprite

        ' Let's check if the tileset is larger than the visible area, and if so adjust.
        If tex_TileSet(var_CurrentTileSet).Size.X > render_TileSelect.Size.X Then
            Width = tex_TileSet(var_CurrentTileSet).Size.X / TILE_X
        Else
            Width = render_TileSelect.Size.X / TILE_X
        End If
        If tex_TileSet(var_CurrentTileSet).Size.Y > render_TileSelect.Size.Y Then
            Height = tex_TileSet(var_CurrentTileSet).Size.Y / TILE_Y
        Else
            Height = render_TileSelect.Size.Y / TILE_Y
        End If

        ' Grab our tileset.
        tempSpr = New SFML.Graphics.Sprite(tex_BackDrop)

        For X = 0 To Width
            For Y = 0 To Height

                ' Set location
                tempSpr.Position = New SFML.Window.Vector2f(X * TILE_X, Y * TILE_Y)

                ' Paste it on-screen.
                render_TileSelect.Draw(tempSpr)

            Next
        Next
    End Sub

End Module
