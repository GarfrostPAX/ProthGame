Imports SFML.Window
Imports SFML.Graphics

Module modRenderMain

    Public Sub RenderMainView()

        ' Open our Rendering Sequence and clear our screen from old data.
        ' Wouldn't want it to just stack on eachother when something is removed.
        view_Main.DispatchEvents()
        view_Main.Clear(SFML.Graphics.Color.Black)

        Dim sprite As New Sprite(tex_TileSet(1))
        sprite.Position = New Vector2f(0, OFFSETY)
        view_Main.Draw(sprite)


        ' Display our changes to the screen.
        view_Main.Display()

    End Sub

End Module
