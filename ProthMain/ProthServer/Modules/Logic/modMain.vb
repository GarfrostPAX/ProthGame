Imports System.Threading

Module modMain

    Sub Main()
        Dim obj_CheckForWaiting As Thread
        ' We've gotten into the application right now.
        ' There's nothing going on yet, so we should probably set the basics up before we continue.

        ' Set the Console Title.
        WriteToConsole("Setting console title..")
        Console.Title = "Prothesys Server"

        ' Initialize Globals
        WriteToConsole("Initializing global values..")
        InitGlobals()

        ' Load server options.
        WriteToConsole("Loading server options..")
        LoadOptions()

        ' Load Maps.
        WriteToConsole("Loading maps..")
        LoadMaps()

        ' Start the SQL Connection
        WriteToConsole("Starting MySQL connector..")
        InitMySQL()

        ' Start the TCP Listener.
        WriteToConsole("Starting TCP listener..")
        InitServerTCP()

        ' Everything appears to be in order, time to start processing the game data!
        ' Fire up the engines!
        Dim obj_ServerLoop As New Thread(AddressOf ServerLoop)
        obj_ServerLoop.Start()

        ' Start checking for new clients that are awaiting authentication
        obj_CheckForWaiting = New Thread(AddressOf CheckWaitingAuthentication)
        obj_CheckForWaiting.Start()

    End Sub

    Public Sub WriteToConsole(ByVal Data As String)
        Console.WriteLine("[" + Format(Now(), "HH:mm:ss") + "] " + Data)
    End Sub

End Module
