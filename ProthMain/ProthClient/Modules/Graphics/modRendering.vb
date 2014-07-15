Module modRendering

    

    Private RenderState As Byte

    Public Sub RenderGame()

        ' This lovely sub is used to render our game in.
        ' But we won't be rendering every window at the same time, only the one in use.
        ' This is why the ClientState subs exist!

        ' Clear our window of old data before continueing.
        obj_GameWindow.Clear(SFML.Graphics.Color.Black)

        ' The following part will handle which render sub we'll be using in this loop.
        ' It's pretty straightforward honestly, we'll push into one of the RenderStates files from here.
        Select Case GetClientState()

            Case GameState.Loading
                RenderLoading()

            Case GameState.Login
                RenderLogin()

            Case GameState.CharSelect
                RenderCharSelect()

        End Select

        ' Render the screen!
        obj_GameWindow.Display()

    End Sub

End Module
