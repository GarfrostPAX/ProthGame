Module modEditorLogic

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

        X = X / TILE_X
        Y = Y / TILE_Y

        ' Make sure we don't crash the program first by checking if the position we're editing is valid or not.
        If X < 0 Or X > Map.SizeX Or Y < 0 Or Y > Map.SizeY Or Layer < 1 Or Layer > Map.LayerCount Then
            Exit Sub
        End If

        ' Assign our values to the thingermajick.
        Map.Layers(Layer).Tiles(X, Y).TileSetID = TileSet
        Map.Layers(Layer).Tiles(X, Y).TileSetX = TileSetX
        Map.Layers(Layer).Tiles(X, Y).TileSetY = TileSetY

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

End Module
