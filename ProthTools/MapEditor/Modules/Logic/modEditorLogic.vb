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

                    ' Check to make sure that this tile didn't already exist in this location.
                    ' No point in placing a tile a second time and rendering a cycle over it.
                    If Map.Layers(Layer).Tiles(X + TempX, Y).TileSetID <> TileSet Or Map.Layers(Layer).Tiles(X + TempX, Y).TileSetX + TempX <> TileSetX + TempX Or Map.Layers(Layer).Tiles(X + TempX, Y).TileSetY <> TileSetY Then

                        ' Place the additional tile.
                        Map.Layers(Layer).Tiles(X + TempX, Y).TileSetID = TileSet
                        Map.Layers(Layer).Tiles(X + TempX, Y).TileSetX = TileSetX + TempX
                        Map.Layers(Layer).Tiles(X + TempX, Y).TileSetY = TileSetY

                        ' Let our render subs know this layer has changed.
                        var_LayerChanged(Layer) = True
                    End If
                End If
            Next

        ElseIf var_AdditionalTilesY > 0 And var_AdditionalTilesX < 1 Then
            ' Only place them on the Y axis.

            For TempY = 1 To var_AdditionalTilesY
                ' check if the position actually exists on our map before we place something down.
                If Y + TempY >= 0 And Y + TempY <= Map.SizeY And X >= 0 And X <= Map.SizeX And Layer >= 1 And Layer <= Map.LayerCount Then

                    ' Check to make sure that this tile didn't already exist in this location.
                    ' No point in placing a tile a second time and rendering a cycle over it.
                    If Map.Layers(Layer).Tiles(X, Y + TempY).TileSetID <> TileSet Or Map.Layers(Layer).Tiles(X, Y + TempY).TileSetX <> TileSetX Or Map.Layers(Layer).Tiles(X, Y + TempY).TileSetY + TempY <> TileSetY + TempY Then

                        ' Place the additional tile.
                        Map.Layers(Layer).Tiles(X, Y + TempY).TileSetID = TileSet
                        Map.Layers(Layer).Tiles(X, Y + TempY).TileSetX = TileSetX
                        Map.Layers(Layer).Tiles(X, Y + TempY).TileSetY = TileSetY + TempY

                        ' Let our render subs know this layer has changed.
                        var_LayerChanged(Layer) = True
                    End If
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
        frm_Layers.lst_Layers.Items.Clear()

        ' Add the new items to the list.
        For i = 1 To Map.LayerCount
            If Map.Layers(i).UnderPlayer Then
                frm_Main.cmb_Layers.Items.Add(i.ToString + ": " + Map.Layers(i).LayerName + " [LOWER]")
                frm_Layers.lst_Layers.Items.Add(i.ToString + ": " + Map.Layers(i).LayerName + " [LOWER]")
            Else
                frm_Main.cmb_Layers.Items.Add(i.ToString + ": " + Map.Layers(i).LayerName + " [UPPER]")
                frm_Layers.lst_Layers.Items.Add(i.ToString + ": " + Map.Layers(i).LayerName + " [UPPER]")
            End If
            
        Next

        ' Select the first entry.
        frm_Main.cmb_Layers.SelectedIndex = 0
        frm_Layers.lst_Layers.Items(0).Selected = True

    End Sub

    Public Sub HandleSaveMap(Optional ByVal SaveAs As Boolean = False)
        Dim Dialog As Windows.Forms.SaveFileDialog
        Dim Result As Windows.Forms.DialogResult

        If SaveAs = True Or var_LastSavedMap = "" Then
            ' Get our dialog created.
            ' We want to know WHERE our user is saving the map after all.
            Dialog = New Windows.Forms.SaveFileDialog

            ' Set some default settings for our lovely window.
            Dialog.InitialDirectory = var_AppPath + DIR_DATA + DIR_MAPS
            Dialog.Filter = "Map Info (*.minf)|*.minf"
            Dialog.Title = "Save Map.."

            ' Run the dialog and get a return value.
            Result = Dialog.ShowDialog()

            ' Make sure the dialog actually returned a sensible value.
            If Result = Windows.Forms.DialogResult.Cancel Then
                ' The user has decided to not save the map.
                Exit Sub
            Else
                ' Save the map!
                ' But make sure you take off the extension that the dialog adds..
                SaveMap(Left(Dialog.FileName, Len(Dialog.FileName) - Len(MAPINF_EXT)))
            End If
        Else
            SaveMap(var_LastSavedMap)
        End If

    End Sub

    Public Sub HandleLoadMap()
        Dim Dialog As Windows.Forms.OpenFileDialog
        Dim Result As Windows.Forms.DialogResult

        ' Get our dialog created.
        ' We want to know WHERE our user is saving the map after all.
        Dialog = New Windows.Forms.OpenFileDialog

        ' Set some default settings for our lovely window.
        Dialog.InitialDirectory = var_AppPath + DIR_DATA + DIR_MAPS
        Dialog.Filter = "Map Info (*.minf)|*.minf"
        Dialog.Title = "Save Map.."

        ' Run the dialog and get a return value.
        Result = Dialog.ShowDialog()

        ' Make sure the dialog actually returned a sensible value.
        If Result = Windows.Forms.DialogResult.Cancel Then
            ' The user has decided to not save the map.
            Exit Sub
        Else
            ' Load the map!
            ' But make sure you take off the extension that the dialog adds..
            LoadMap(Left(Dialog.FileName, Len(Dialog.FileName) - Len(MAPINF_EXT)))
        End If

    End Sub

    Public Sub HandleNewMap()
        Dim Result As New Microsoft.VisualBasic.MsgBoxResult

        ' Make sure the user wants to make a new map.
        Result = MsgBox("Creating a new map will wipe all data currently on-screen." + vbNewLine + vbNewLine + "Are you sure you want to continue?", MsgBoxStyle.YesNo, "New Map")

        ' If so, do as they say!
        If Result = MsgBoxResult.Yes Then
            NewMap(MAP_DEFAULT_LAYERS, MAP_DEFAULT_X, MAP_DEFAULT_Y)
        End If

        ' Clear object.
        Result = Nothing
    End Sub

    Public Sub FocusMain()

        ' Make sure we do not do this when another window is open.
        If var_LayersOpen = False Then
            frm_Main.Focus()
        End If

    End Sub

    Public Sub StatusMessage(ByVal Msg As String)
        frm_Main.lbl_Status.Text = Msg
    End Sub

    Public Sub FillLayer(Optional ByVal Clear As Boolean = False)
        Dim x As Integer, y As Integer, TileSet As Integer, TileX As Integer, TileY As Integer

        ' If we do not need to clear our layer out, set the values.
        If Not Clear Then
            TileSet = var_CurrentTileSet
            TileX = var_CurrentTileSetX
            TileY = var_CurrentTileSetY
        End If

        ' Fill the entire layer with the correct selected tile.
        For x = 0 To Map.SizeX
            For y = 0 To Map.SizeY
                Map.Layers(var_CurrentLayer).Tiles(x, y).TileSetID = TileSet
                Map.Layers(var_CurrentLayer).Tiles(x, y).TileSetX = TileX
                Map.Layers(var_CurrentLayer).Tiles(x, y).TileSetY = TileY
            Next
        Next

        ' Update our texture and our window.
        var_LayerChanged(var_CurrentLayer) = True
        var_MainChanged = True

    End Sub

    Public Sub PlaceAttribute(ByVal X As Integer, ByVal Y As Integer, Optional ByVal Clear As Boolean = False)

        X = X / (TILE_X / 2)
        Y = Y / (TILE_Y / 2)

        ' Exit out of the value is impossible.
        If X < 0 Or X > Map.AttributesX Or Y < 0 Or Y > Map.AttributesY Then Exit Sub

        If Not Clear Then
            ' Place an attribute!
            If frm_Main.rd_Blocked.Checked Then Map.Attributes(X, Y).AttributeID = MapAttributes.Blocked
            If frm_Main.rd_Warp.Checked Then Map.Attributes(X, Y).AttributeID = MapAttributes.Warp
            If frm_Main.rd_NPCSPawn.Checked Then Map.Attributes(X, Y).AttributeID = MapAttributes.NPCSpawn

            ' Set the attribute data.
            Map.Attributes(X, Y).Data1 = CInt(frm_Main.txt_Data1.Text)
            Map.Attributes(X, Y).Data2 = CInt(frm_Main.txt_Data2.Text)
            Map.Attributes(X, Y).Data3 = CInt(frm_Main.txt_Data3.Text)
        Else
            ' Clear all the data.
            Map.Attributes(X, Y).AttributeID = MapAttributes.None
            Map.Attributes(X, Y).Data1 = 0
            Map.Attributes(X, Y).Data2 = 0
            Map.Attributes(X, Y).Data3 = 0
        End If

    End Sub

End Module
