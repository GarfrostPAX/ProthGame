Module modClientLoop

    Public Sub ClientLoop()

        Do While GetClientState() <> GameState.Closing

            ' Handle the game rendering.
            RenderGame()

            ' Make sure all events related to the application are actually handled.
            obj_GameWindow.DispatchEvents()
            Application.DoEvents()

            ' Put the thread to sleep for a little while
            Threading.Thread.Sleep(1)

        Loop

        ' We're outside of the loop, time to destroy the game.
        DestroyGame()

    End Sub

End Module
