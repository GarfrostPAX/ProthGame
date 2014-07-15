Imports System.Threading

Module modMain
    Private obj_RenderThread As Thread

    Public Sub Main()
        ' We're entering the main initialization section of the client.
        ' let's start out by initializing all the structures and global arrays.
        InitGlobals()

        ' Load game options from config file.
        LoadOptions()

        'Set out client state to loading.
        SetClientState(GameState.Loading)

        ' Load up our graphics!
        InitGraphics()

        ' Initialize Nading and start the connection to the server.
        InitClientTCP()

        ' Set our gamestate to the login screen.
        SetClientState(GameState.Login)

        ' Move on to the main game loop.
        ClientLoop()

    End Sub

    Public Sub DestroyWindow()
        SetClientState(GameState.Closing)
    End Sub

    Public Sub DestroyGame()
        ' A very simple sub where we tear down everything the game uses and does to make sure
        ' we exit out as cleanly as possible.

        ' First of we need to destroy out TCP system, this always comes first as we don't want to get any more information
        ' while we're killing our program.
        DestroyClientTCP()

        ' Destroy our graphics.
        DestroyGraphics()

        ' Now destroy our global variables and objects.
        DestroyGlobals()

        ' Finaly, exit out of the game entirely.
        End
    End Sub

End Module
