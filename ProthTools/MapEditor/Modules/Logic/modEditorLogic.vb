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
