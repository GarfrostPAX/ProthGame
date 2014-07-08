Imports SFML.Window
Imports SFML.Graphics

Module modRenderMain

    Public Sub RenderMainView()

            ' Open our Rendering Sequence and clear our screen from old data.
            ' Wouldn't want it to just stack on eachother when something is removed.
            view_Main.DispatchEvents()
            view_Main.Clear(SFML.Graphics.Color.Black)


            ' Display our changes to the screen.
            view_Main.Display()

    End Sub

End Module
