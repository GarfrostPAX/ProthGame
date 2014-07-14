Module modRendering

    

    Private RenderState As Byte

    Public Sub RenderGame()

        ' This lovely sub is used to render our game in.
        ' But we won't be rendering every window at the same time, only the one in use.
        ' This is why the ClientState subs exist!

        Do While GetClientState() <> GameState.Closing

            ' Clear our window of old data before continueing.
            obj_GameWindow.Clear(SFML.Graphics.Color.Black)


            ' Make sure all events related to the application are actually handled.
            obj_GameWindow.DispatchEvents()
            Application.DoEvents()

            ' Render the screen!
            obj_GameWindow.Display()
        Loop

    End Sub

End Module
