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

End Module
