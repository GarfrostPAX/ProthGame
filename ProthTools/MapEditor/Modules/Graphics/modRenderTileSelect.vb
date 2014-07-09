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

        ' Render the tile selection display.
        RenderCurrentSelection()

        RenderMouseLocation()

        ' Display our changes to the screen.
        render_TileSelect.Display()

    End Sub

    Private Sub RenderTileSet()
        Dim tempSpr As SFML.Graphics.Sprite

        ' Grab our tileset.
        tempSpr = New SFML.Graphics.Sprite(tex_TileSet(var_CurrentTileSet))

        ' Paste it on-screen.
        render_TileSelect.Draw(tempSpr)

    End Sub

    Private Sub RenderTileSetBackdrop()
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

    Private Sub RenderCurrentSelection()
        Dim tempSpr As SFML.Graphics.Sprite

        ' Check if we actually need to render more than one tile or not.
        If var_AdditionalTilesX < 1 And var_AdditionalTilesY < 1 Then
            ' Just one, so grab the single picture and get going.

            ' Grab the full sprite.
            tempSpr = New SFML.Graphics.Sprite(tex_Select)

            ' Set the color to be rather vibrant, makes it easier to see.
            tempSpr.Color = New SFML.Graphics.Color(255, 0, 255)

            ' Set the location.
            tempSpr.Position = New SFML.Window.Vector2f(var_CurrentTileSetX * TILE_X, var_CurrentTileSetY * TILE_Y)

            ' Draw it to the screen!
            render_TileSelect.Draw(tempSpr)
        Else
            ' We're going to have to do this bit by bit. So first let's start with the top and bottom.
            ' Let's chop off a piece of this image.
            tempSpr = New SFML.Graphics.Sprite(tex_Select, New SFML.Graphics.IntRect(0, 0, TILE_X, 2))

            ' Set the color to be rather vibrant, makes it easier to see.
            tempSpr.Color = New SFML.Graphics.Color(255, 0, 255)

            ' We've got the top and bottom piece, let's stretch it out.
            tempSpr.Scale = New SFML.Window.Vector2f(var_AdditionalTilesX + 1, 1)

            ' Now position and draw it twice, once at the top and once at the bottom of the selection.
            tempSpr.Position = New SFML.Window.Vector2f(var_CurrentTileSetX * TILE_X, var_CurrentTileSetY * TILE_Y)
            render_TileSelect.Draw(tempSpr)
            tempSpr.Position = New SFML.Window.Vector2f(var_CurrentTileSetX * TILE_X, (var_CurrentTileSetY + 1 + var_AdditionalTilesY) * TILE_Y - 2)
            render_TileSelect.Draw(tempSpr)

            ' Now let's start with the sides!
            ' Let's chop off a piece of this image.
            tempSpr = New SFML.Graphics.Sprite(tex_Select, New SFML.Graphics.IntRect(0, 0, 2, TILE_Y))

            ' Set the color to be rather vibrant, makes it easier to see.
            tempSpr.Color = New SFML.Graphics.Color(255, 0, 255)

            ' We've got the top and bottom piece, let's stretch it out.
            tempSpr.Scale = New SFML.Window.Vector2f(1, var_AdditionalTilesY + 1)

            ' Now position and draw it twice, once at the top and once at the bottom of the selection.
            tempSpr.Position = New SFML.Window.Vector2f(var_CurrentTileSetX * TILE_X, var_CurrentTileSetY * TILE_Y)
            render_TileSelect.Draw(tempSpr)
            tempSpr.Position = New SFML.Window.Vector2f((var_CurrentTileSetX + 1 + var_AdditionalTilesX) * TILE_X - 2, var_CurrentTileSetY * TILE_Y)
            render_TileSelect.Draw(tempSpr)
        End If

    End Sub

    Public Sub RenderMouseLocation()
        Dim tempX As Integer, tempY As Integer
        Dim tempSpr As SFML.Graphics.Sprite

        ' Make some quick calculations
        tempX = (var_TileSelectPos.X / TILE_X)
        tempY = (var_TileSelectPos.Y / TILE_Y)

        ' Grab the full sprite.
        tempSpr = New SFML.Graphics.Sprite(tex_Select)

        ' Set the color to be rather vibrant, makes it easier to see.
        tempSpr.Color = New SFML.Graphics.Color(0, 0, 255)

        ' Set the location.
        tempSpr.Position = New SFML.Window.Vector2f(tempX * TILE_X, tempY * TILE_Y)

        ' Draw it to the screen!
        render_TileSelect.Draw(tempSpr)
    End Sub

End Module
