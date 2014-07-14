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

        ' Get our game window up as soon as possible.
        ' We'll want to tell our users we're loading stuff!
        ' We're keeping all our graphics in a seperate thread though.
        ' Don't want to have it interfere with anything else should VSync kick in.
        obj_RenderThread = New Thread(AddressOf InitGraphics)
        obj_RenderThread.Start()

        ' Initialize Nading and start the connection to the server.
        InitClientTCP()

    End Sub

    Public Sub DestroyGame()
        ' A very simple sub where we tear down everything the game uses and does to make sure
        ' we exit out as cleanly as possible.

        ' Set our status to destroying game.
        SetClientState(GameState.Closing)

        ' First of we need to destroy out TCP system, this always comes first as we don't want to get any more information
        ' while we're killing our program.
        DestroyClientTCP()

        ' Now destroy our global variables and objects.
        DestroyGlobals()

        ' Finaly, exit out of the game entirely.
        End
    End Sub

End Module
