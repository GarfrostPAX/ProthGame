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
                PlaceTile(var_CurrentLayer, var_MousePos.X, var_MousePos.Y, var_CurrentTileSet, var_CurrentTileSetX, var_CurrentTileSetY)
                Exit Sub
            Case MouseButtons.Right
                ' Remove a tile.
                PlaceTile(var_CurrentLayer, var_MousePos.X, var_MousePos.Y, 0, 0, 0)
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
                Exit Sub

            Case Keys.D
                ' Move the camera to the right.
                view_Main.Move(New SFML.Window.Vector2f(9, 0))
                render_Main.SetView(view_Main)
                Exit Sub

            Case Keys.W
                ' Move the camera up.
                view_Main.Move(New SFML.Window.Vector2f(0, -9))
                render_Main.SetView(view_Main)
                Exit Sub

            Case Keys.S
                ' Move the camera down.
                view_Main.Move(New SFML.Window.Vector2f(0, 9))
                render_Main.SetView(view_Main)
                Exit Sub

        End Select

    End Sub

    Public Sub HandleMouseWheel(ByVal ScrollDelta As Integer, ByVal X As Integer, ByVal Y As Integer)

        ' Convert the X and Y values to world values before we do anything with them.
        var_MousePos = render_Main.MapPixelToCoords(New SFML.Window.Vector2i(X, Y))

        ' Handle the Scrolling depending on whether the user scrolls up or down.
        If ScrollDelta > 0 Then

            ' Zoom In
            view_Main.Zoom(0.9)

            ' Center the mouse on the location that is pointed at.
            ' Only doing this when zooming in, it's really annoying otherwise.
            view_Main.Center = var_MousePos

        Else
            ' Zoom Out
            view_Main.Zoom(1.1)
        End If


        ' Apply changes to the screen.
        render_Main.SetView(view_Main)
    End Sub

End Module
