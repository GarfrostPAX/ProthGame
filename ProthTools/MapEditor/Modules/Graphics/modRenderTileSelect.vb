Imports SFML.Window
Imports SFML.Graphics

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
        Dim tempSpr As SFML.Graphics.Sprite
        Dim x As Integer, y As Integer

        ' We need to do this and add one to make sure the sprite has the right size.
        x = tex_TileSet(var_CurrentTileSet).Size.X
        y = tex_TileSet(var_CurrentTileSet).Size.Y + 32 ' Makes sure that it also looks decent on screens where the viewwindow isn't perfectly scaled to 32px tiles.

        ' Create a new sprite the size of the tileset.
        ' Since our texture is set to repeat, it'll handle the tiles on its own.
        tempSpr = New Sprite(tex_BackDrop, New SFML.Graphics.IntRect(0, 0, x, y))

        ' Render it to the screen.
        render_TileSelect.Draw(tempSpr)
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
