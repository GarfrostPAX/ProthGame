Module modEditorLogic

    Public Sub UpdateStatusLabel()
        frm_Main.lbl_Location.Text = Map.Title _
        + " (Layer: " _
        + var_CurrentLayer.ToString + " X: " _
        + CInt((var_MousePos.X / TILE_X)).ToString + " Y: " _
        + CInt((var_MousePos.Y / TILE_Y)).ToString
    End Sub

    Public Sub CenterCameraOnMap()
        Dim x As Integer, y As Integer

        ' Dumping this here.
        ' For some reason not doing this but putting the calculation in one line causes it
        ' to go haywire. Fuck you Microsoft.
        x = Map.SizeX
        y = Map.SizeY

        ' Calculate the map center.
        x = (x * TILE_X) / 2
        y = (y * TILE_Y) / 2

        ' Set the center.
        view_Main.Center = New SFML.Window.Vector2f(x, y)

        ' Apply it to our current view.
        render_Main.SetView(view_Main)
    End Sub

    Public Sub PlaceTile(ByVal Layer As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal TileSet As Integer, ByVal TileSetX As Integer, ByVal TileSetY As Integer)
        Dim TempX As Integer, TempY As Integer

        X = X / TILE_X
        Y = Y / TILE_Y

        ' Make sure we don't crash the program first by checking if the position we're editing is valid or not.
        If X >= 0 And X <= Map.SizeX And Y >= 0 And Y <= Map.SizeY And Layer >= 1 And Layer <= Map.LayerCount Then

            ' Check to make sure that this tile didn't already exist in this location.
            ' No point in placing a tile a second time and rendering a cycle over it.
            If Map.Layers(Layer).Tiles(X, Y).TileSetID <> TileSet Or Map.Layers(Layer).Tiles(X, Y).TileSetX <> TileSetX Or Map.Layers(Layer).Tiles(X, Y).TileSetY <> TileSetY Then

                ' Assign our values to the thingermajick.
                Map.Layers(Layer).Tiles(X, Y).TileSetID = TileSet
                Map.Layers(Layer).Tiles(X, Y).TileSetX = TileSetX
                Map.Layers(Layer).Tiles(X, Y).TileSetY = TileSetY

                ' Let our render subs know this layer has changed.
                var_LayerChanged(Layer) = True
            End If
        End If

        ' Now that we've attempted to placed the MAIN tile, let's place down some additional ones.

        ' After we figure out how to place them..
        If var_AdditionalTilesX > 0 And var_AdditionalTilesY > 0 Then
            ' Place them both X and Y directions! Fancy.

            For TempX = 0 To var_AdditionalTilesX
                For TempY = 0 To var_AdditionalTilesY
                    ' check if the position actually exists on our map before we place something down.
                    If X + TempX >= 0 And X + TempX <= Map.SizeX And Y + TempY >= 0 And Y + TempY <= Map.SizeY And Layer >= 1 And Layer <= Map.LayerCount Then

                        ' Check to make sure that this tile didn't already exist in this location.
                        ' No point in placing a tile a second time and rendering a cycle over it.
                        If Map.Layers(Layer).Tiles(X + TempX, Y + TempY).TileSetID <> TileSet Or Map.Layers(Layer).Tiles(X + TempX, Y + TempY).TileSetX + TempX <> TileSetX + TempX Or Map.Layers(Layer).Tiles(X + TempX, Y + TempY).TileSetY + TempY <> TileSetY + TempY Then

                            ' Place the additional tile.
                            Map.Layers(Layer).Tiles(X + TempX, Y + TempY).TileSetID = TileSet
                            Map.Layers(Layer).Tiles(X + TempX, Y + TempY).TileSetX = TileSetX + TempX
                            Map.Layers(Layer).Tiles(X + TempX, Y + TempY).TileSetY = TileSetY + TempY

                            ' Let our render subs know this layer has changed.
                            var_LayerChanged(Layer) = True
                        End If
                    End If
                Next
            Next

        ElseIf var_AdditionalTilesX > 0 And var_AdditionalTilesY < 1 Then
            ' Only place them on the X axis.

            For TempX = 1 To var_AdditionalTilesX
                ' check if the position actually exists on our map before we place something down.
                If X + TempX >= 0 And X + TempX <= Map.SizeX And Y >= 0 And Y <= Map.SizeY And Layer >= 1 And Layer <= Map.LayerCount Then
                    ' Place the additional tile.
                    Map.Layers(Layer).Tiles(X + TempX, Y).TileSetID = TileSet
                    Map.Layers(Layer).Tiles(X + TempX, Y).TileSetX = TileSetX + TempX
                    Map.Layers(Layer).Tiles(X + TempX, Y).TileSetY = TileSetY
                End If
            Next

        ElseIf var_AdditionalTilesY > 0 And var_AdditionalTilesX < 1 Then
            ' Only place them on the Y axis.

            For TempY = 1 To var_AdditionalTilesY
                ' check if the position actually exists on our map before we place something down.
                If Y + TempY >= 0 And Y + TempY <= Map.SizeY And X >= 0 And X <= Map.SizeX And Layer >= 1 And Layer <= Map.LayerCount Then
                    ' Place the additional tile.
                    Map.Layers(Layer).Tiles(X, Y + TempY).TileSetID = TileSet
                    Map.Layers(Layer).Tiles(X, Y + TempY).TileSetX = TileSetX
                    Map.Layers(Layer).Tiles(X, Y + TempY).TileSetY = TileSetY + TempY
                End If
            Next
        End If


    End Sub

    Public Sub PopulateTileSetList()
        Dim i As Integer

        ' First up clean the old data out of the list.
        frm_Main.cmb_TileSets.Items.Clear()

        ' Add the new items to the list.
        For i = 1 To var_NumTileSets
            frm_Main.cmb_TileSets.Items.Add(i.ToString + ": " + var_TileSetName(i))
        Next

        ' Select the first entry.
        frm_Main.cmb_TileSets.SelectedIndex = 0
    End Sub

    Public Sub MapEditorZoom(ByVal Out As Boolean)
        
        ' Handle the Scrolling
        If Not Out Then
            ' Zoom In
            view_Main.Zoom(0.9)
        Else
            ' Zoom Out
            view_Main.Zoom(1.1)
        End If


        ' Apply changes to the screen.
        render_Main.SetView(view_Main)
    End Sub

    Public Sub PopulateLayerList()
        Dim i As Integer

        ' First up clean the old data out of the list.
        frm_Main.cmb_Layers.Items.Clear()

        ' Add the new items to the list.
        For i = 1 To Map.LayerCount
            frm_Main.cmb_Layers.Items.Add(i.ToString + ": " + Map.Layers(i).LayerName)
        Next

        ' Select the first entry.
        frm_Main.cmb_Layers.SelectedIndex = 0

    End Sub

    Public Sub StatusMessage(ByVal Msg As String)
        frm_Main.lbl_Status.Text = Msg
    End Sub

End Module
