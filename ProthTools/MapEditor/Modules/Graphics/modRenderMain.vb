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

        ' Render our selection thingymabob.
        RenderCurrentSelection()

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
        Dim l As Byte
        ' This sub will render the entire map to the screen.
        ' Note that the UnderPlayer modifier you pass into this equals the same boolean value as 
        ' your layers will. It will only render those layers that equal the value you pass.

        ' Start looping through our layers.
        For l = 1 To Map.LayerCount

            ' Check if this layer should be rendered on this pass.
            If Map.Layers(l).UnderPlayer = UnderPlayer Then
                ' Render the layer.
                RenderLayer(l)
            End If

        Next

    End Sub

    Private Sub RenderLayer(ByVal Layer As Byte)
        Dim x As Byte, y As Byte
        Dim tempSpr As SFML.Graphics.Sprite

        ' So before we assume we can simply render our textured layer, we'll need to see if anything changed
        ' since last loop.
        ' If it did, we'll need to re-render the texture before we render it to the screen.
        If var_LayerChanged(Layer) Then

            ' First we'll be clearing out this texture's content. We don't need to keep old data on it.
            ' Go with a transparent background, or it won't layer well.
            tex_Layer(Layer).Clear(SFML.Graphics.Color.Transparent)

            ' Now loop through the X/Y values of this layer to render this thing.
            ' We start at 0 here, this means we don't need to mess with more blasted offset values than we do already.
            ' Also means that this is an array that doesn't have a blank entry in it for once!
            For x = 0 To Map.SizeX
                For y = 0 To Map.SizeY
                    ' Render the actual tile.
                    RenderTile(Layer, x, y)
                Next
            Next

            ' Make sure the changes to the texture gets displayed properly.
            tex_Layer(Layer).Display()

            ' Now make sure we let the next loop know the texture has been rendered.
            var_LayerChanged(Layer) = False
        End If

        ' Throw the layer texture onto the display!
        ' Let's create a sprite of it.
        tempSpr = New SFML.Graphics.Sprite(tex_Layer(Layer).Texture)

        ' Set the sprite to be somewhat transparent if it's not on our current layer.
        ' This way we can tell what we're editing even if it's below something else.
        If var_CurrentLayer <> Layer Then
            tempSpr.Color = New SFML.Graphics.Color(255, 255, 255, 128)
        End If

        ' Push the sprite to the screen.
        render_Main.Draw(tempSpr)

        ' Dump the object.
        tempSpr = Nothing

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
            .Left = Map.Layers(Layer).Tiles(X, Y).TileSetX * TILE_X
            .Top = Map.Layers(Layer).Tiles(X, Y).TileSetY * TILE_Y
            .Width = TILE_X
            .Height = TILE_Y
        End With

        ' Make a Temporary sprite to dump our image in.
        tempSpr = New Sprite(tex_TileSet(Map.Layers(Layer).Tiles(X, Y).TileSetID), tempRec)

        ' Position our sprite in the right location.
        tempSpr.Position = New Vector2f(X * TILE_X, Y * TILE_Y)

        ' Now draw it to the screen!
        tex_Layer(Layer).Draw(tempSpr)

        ' Clear out our values so we don't hoard memory.
        tempRec = Nothing
        tempSpr = Nothing
    End Sub

    Private Sub RenderCurrentSelection()
        Dim tempSpr As SFML.Graphics.Sprite
        Dim tempX As Integer, tempY As Integer

        tempX = (var_MousePos.X - 16) / TILE_X
        tempY = (var_MousePos.Y - 16) / TILE_Y

        ' Check if we actually need to render more than one tile or not.
        If var_AdditionalTilesX < 1 And var_AdditionalTilesY < 1 Then
            ' Just one, so grab the single picture and get going.

            ' Grab the full sprite.
            tempSpr = New SFML.Graphics.Sprite(tex_Select)

            ' Set the color to be rather vibrant, makes it easier to see.
            tempSpr.Color = New SFML.Graphics.Color(255, 0, 255)

            ' Set the location.
            tempSpr.Position = New SFML.Window.Vector2f(tempX * TILE_X, tempY * TILE_Y)

            ' Draw it to the screen!
            render_Main.Draw(tempSpr)
        Else
            ' We're going to have to do this bit by bit. So first let's start with the top and bottom.
            ' Let's chop off a piece of this image.
            tempSpr = New SFML.Graphics.Sprite(tex_Select, New SFML.Graphics.IntRect(0, 0, TILE_X, 2))

            ' Set the color to be rather vibrant, makes it easier to see.
            tempSpr.Color = New SFML.Graphics.Color(255, 0, 255)

            ' We've got the top and bottom piece, let's stretch it out.
            tempSpr.Scale = New SFML.Window.Vector2f(var_AdditionalTilesX + 1, 1)

            ' Now position and draw it twice, once at the top and once at the bottom of the selection.
            tempSpr.Position = New SFML.Window.Vector2f(tempX * TILE_X, tempY * TILE_Y)
            render_Main.Draw(tempSpr)
            tempSpr.Position = New SFML.Window.Vector2f(tempX * TILE_X, (tempY + 1 + var_AdditionalTilesY) * TILE_Y - 2)
            render_Main.Draw(tempSpr)

            ' Now let's start with the sides!
            ' Let's chop off a piece of this image.
            tempSpr = New SFML.Graphics.Sprite(tex_Select, New SFML.Graphics.IntRect(0, 0, 2, TILE_Y))

            ' Set the color to be rather vibrant, makes it easier to see.
            tempSpr.Color = New SFML.Graphics.Color(255, 0, 255)

            ' We've got the top and bottom piece, let's stretch it out.
            tempSpr.Scale = New SFML.Window.Vector2f(1, var_AdditionalTilesY + 1)

            ' Now position and draw it twice, once at the top and once at the bottom of the selection.
            tempSpr.Position = New SFML.Window.Vector2f(tempX * TILE_X, tempY * TILE_Y)
            render_Main.Draw(tempSpr)
            tempSpr.Position = New SFML.Window.Vector2f((tempX + 1 + var_AdditionalTilesX) * TILE_X - 2, tempY * TILE_Y)
            render_Main.Draw(tempSpr)

            ' Dispose of the object.
            tempSpr = Nothing
        End If

    End Sub

End Module
