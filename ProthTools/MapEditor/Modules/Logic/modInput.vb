Imports System.Windows.Forms
Imports SFML.Window.Keyboard

Module modInput

    Public Sub HandleMainMouse(ByVal mButton As MouseButtons, ByVal X As Integer, ByVal Y As Integer)

        ' Convert the X and Y values to world values before we do anything with them.
        var_MousePos = render_Main.MapPixelToCoords(New SFML.Window.Vector2i(X, Y))

        ' Let's check what mousebutton is being pressed and act accordingly.
        Select Case mButton

            Case MouseButtons.Left
                ' Place a tile.
                PlaceTile(var_CurrentLayer, var_MousePos.X - (TILE_X / 2), var_MousePos.Y - (TILE_Y / 2), var_CurrentTileSet, var_CurrentTileSetX, var_CurrentTileSetY)
                Exit Sub
            Case MouseButtons.Right
                ' Remove a tile.
                PlaceTile(var_CurrentLayer, var_MousePos.X - (TILE_X / 2), var_MousePos.Y - (TILE_Y / 2), 0, 0, 0)
                Exit Sub

        End Select

    End Sub

    Public Sub HandleTileSelectMouse(ByVal mButton As MouseButtons, ByVal X As Integer, ByVal Y As Integer)

        ' Convert the X and Y values to world values before we do anything with them.
        var_TileSelectPos = render_TileSelect.MapPixelToCoords(New SFML.Window.Vector2i(X - 16, Y - 16))

        ' Let's check what mousebutton is being pressed and act accordingly.
        Select Case mButton

            Case MouseButtons.Left
                ' Select the tile.
                var_CurrentTileSetX = var_TileSelectPos.X / TILE_X
                var_CurrentTileSetY = var_TileSelectPos.Y / TILE_Y
                var_AdditionalTilesX = 0
                var_AdditionalTilesY = 0
                Exit Sub

        End Select

    End Sub

    Public Sub HandleTileSelectMouseMove(ByVal mButton As MouseButtons, ByVal X As Integer, ByVal Y As Integer)

        ' Convert the X and Y values to world values before we do anything with them.
        var_TileSelectPos = render_TileSelect.MapPixelToCoords(New SFML.Window.Vector2i(X - (TILE_X / 2), Y - (TILE_Y / 2)))

        ' Let's check what mousebutton is being pressed and act accordingly.
        Select Case mButton

            Case MouseButtons.Left
                ' Let's see if we can figure out whether or not the user is dragging more tiles into our selection.

                ' Horizontal
                If CInt(var_TileSelectPos.X / TILE_X) > var_CurrentTileSetX + var_AdditionalTilesX Then
                    ' We're draggin an additional tile into it to the right side!
                    var_AdditionalTilesX = var_AdditionalTilesX + 1
                ElseIf CInt(var_TileSelectPos.X / TILE_X) < var_CurrentTileSetX + var_AdditionalTilesX And var_AdditionalTilesX > 0 Then
                    ' We're dragging an additional tile back again.
                    var_AdditionalTilesX = var_AdditionalTilesX - 1
                End If


                ' Vertical
                If CInt(var_TileSelectPos.Y / TILE_Y) > var_CurrentTileSetY + var_AdditionalTilesY Then
                    ' We're draggin an additional tile into it to the right side!
                    var_AdditionalTilesY = var_AdditionalTilesY + 1
                ElseIf CInt(var_TileSelectPos.Y / TILE_Y) < var_CurrentTileSetY + var_AdditionalTilesY And var_AdditionalTilesY > 0 Then
                    ' We're dragging an additional tile back again.
                    var_AdditionalTilesY = var_AdditionalTilesY - 1
                End If

                Exit Sub

        End Select

    End Sub


    Public Sub HandleKeyBoard(ByVal Alt As Boolean, ByVal Control As Boolean, ByVal Shift As Boolean, ByVal InKey As System.Windows.Forms.Keys)

        ' Let's see what key(s) are pressed and acr accordingly.
        Select Case InKey

            Case Keys.A
                ' Move the camera to the left.
                view_Main.Move(New SFML.Window.Vector2f(-9, 0))
                render_Main.SetView(view_Main)
                var_MainChanged = True
                Exit Sub

            Case Keys.D
                ' Move the camera to the right.
                view_Main.Move(New SFML.Window.Vector2f(9, 0))
                render_Main.SetView(view_Main)
                var_MainChanged = True
                Exit Sub

            Case Keys.W
                ' Move the camera up.
                view_Main.Move(New SFML.Window.Vector2f(0, -9))
                render_Main.SetView(view_Main)
                var_MainChanged = True
                Exit Sub

            Case Keys.S
                ' Move the camera down.
                view_Main.Move(New SFML.Window.Vector2f(0, 9))
                render_Main.SetView(view_Main)
                var_MainChanged = True
                Exit Sub

            Case Keys.Add, Keys.E
                ' Zoom in
                MapEditorZoom(False)
                var_MainChanged = True
                Exit Sub

            Case Keys.Subtract, Keys.Q
                MapEditorZoom(True)
                var_MainChanged = True
                Exit Sub

        End Select

    End Sub

End Module
