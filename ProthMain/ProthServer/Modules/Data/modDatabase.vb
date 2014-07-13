Imports MySql.Data.MySqlClient
Imports System.Threading

Module modDatabase

    ' Set our lovely connection object that's to be used throughout the module.
    ' Note that this one is only to be used for the connection to MyBB.
    Private obj_ConnectorMyBB As MySqlConnection
    Private obj_CommandMyBB As New MySqlCommand
    Private obj_ReaderMyBB As New MySqlDataAdapter
    Private obj_DataTableMyBB As New DataTable


    Public Sub ClearPlayer(ByVal ID As Integer)
        Dim i As Integer
        ' Time to clear out every value in this player array ID so we can re-use it.
        With obj_Player(ID)

            For i = 1 To MAX_CHARACTERS
                With .Character(i)
                    .Name = ""
                    .Job = 0
                    .Level = 0
                    .Experience = 0

                    .Map = 0
                    .X = 0
                    .Y = 0
                    .Direction = Directions.Down
                End With
            Next

        End With

        ' And clear out the temporary data
        With obj_TempPlayer(ID)
            ' Generic Information
            .Username = ""
            .Password = ""
            .DBPassword = ""
            .Salt = ""

            ' GUID data
            .ServerGUID = Guid.Empty
            .DataGUID = 0

            ' State Data
            .LoginStatus = LoginStatus.None
            .InGame = False

        End With

    End Sub

    Public Sub LoadMaps()
        Dim fStream As System.IO.FileStream
        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim MapNames() As String, i As Integer, Data() As String, tempStr As String, tempDat() As String, n As Integer

        ' Check if the map list exists.
        If FileExist(DATA_ROOT + DATA_MAPS + "maplist.dat") Then
            ' Read out all the lines in the file.
            MapNames = System.IO.File.ReadAllLines(var_AppPath + DATA_ROOT + DATA_MAPS + "maplist.dat")

            ' Set our Max_Maps value.
            MAX_MAPS = UBound(MapNames) + 1

            ' Let's redim our maps array to fit the amount of maps we're getting.
            ' +1 because I hate starting at 0 with these things.
            ReDim obj_Map(MAX_MAPS)

            ' Now loop through the array.
            For i = 0 To UBound(MapNames)
                ' Split the string up so we can get our map name.
                Data = Split(MapNames(i), "=")

                ' First let's read the basic map info we need to load it up again.
                tempStr = System.IO.File.ReadAllText(var_AppPath + DATA_ROOT + DATA_MAPS + Trim(Data(1)) + MAPINF_EXT)

                ' Split it up.
                tempDat = Split(tempStr, ",")

                ' Now to make sure we set the right size of the map!
                obj_Map(i + 1).LayerCount = tempDat(0)
                obj_Map(i + 1).SizeX = tempDat(1)
                obj_Map(i + 1).SizeY = tempDat(2)
                obj_Map(i + 1).AttributesX = (obj_Map(i + 1).SizeX * 2) + 1 ' + 1 to make sure we actually get the full amount since we start at 0.
                obj_Map(i + 1).AttributesY = (obj_Map(i + 1).SizeY * 2) + 1

                ' Time to start allocating this map's size.
                ReDim obj_Map(i + 1).Layers(obj_Map(i + 1).LayerCount)
                ReDim obj_Map(i + 1).Attributes(obj_Map(i + 1).AttributesX, obj_Map(i + 1).AttributesY)

                For n = 1 To obj_Map(i + 1).LayerCount
                    ReDim obj_Map(i + 1).Layers(n).Tiles(obj_Map(i + 1).SizeX, obj_Map(i + 1).SizeY)
                Next

                ' Now let's read our map data!
                ' Open a new filestream.
                fStream = New System.IO.FileStream(var_AppPath + DATA_ROOT + DATA_MAPS + Trim(Data(1)) + MAPDAT_EXT, System.IO.FileMode.OpenOrCreate)

                ' Dump the Array into the file.
                bf.AssemblyFormat = Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
                obj_Map(i + 1) = bf.Deserialize(fStream)

                ' Close the filestream.
                fStream.Close()
            Next

        Else
            ' Doesn't exist for some reason.
            ' Can't continue without it, so let's close the server.
            WriteToConsole("Could not locate maplist data.")
            WriteToConsole("Press any key to close server.")
            tempStr = Console.ReadLine
            End
        End If
    End Sub

    Public Sub SavePlayer(ByVal ID As Integer)
        Dim FileName As String
        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

        ' Check if this user is even logged in. No point in saving his data if there's bugger all to save.
        If obj_TempPlayer(ID).LoginStatus <> LoginStatus.Verified Then Exit Sub

        ' Set the filename that we need to save to.
        FileName = var_AppPath + DATA_ROOT + DATA_PLAYERS + obj_TempPlayer(ID).DataGUID.ToString + ".dat"

        ' Open a new filestream.
        Dim fStream As New System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate)

        ' Dump the Array into the file.
        bf.Serialize(fStream, obj_Player(ID))

        ' Close the filestream.
        fStream.Close()
    End Sub

    Public Sub LoadPlayer(ByVal ID As Integer)
        Dim FileName As String
        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

        ' Set the filename that we need to load from.
        FileName = var_AppPath + DATA_ROOT + DATA_PLAYERS + obj_TempPlayer(ID).DataGUID.ToString + ".dat"

        ' Open a new filestream.
        Dim fStream As New System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate)

        ' Load our data from the file.
        obj_Player(ID) = bf.Deserialize(fStream)

        ' Close the filestream.
        fStream.Close()
    End Sub

    Public Sub LoadOptions()
        ' define and assign the XDocument reader.
        Dim xml = XDocument.Load(var_AppPath + "\config.xml")

        ' Server Bind Options
        obj_Options.ServerBindAddress = xml.<config>.<serverbinding>.<bindaddress>.Value
        obj_Options.ServerBindPort = CInt(xml.<config>.<serverbinding>.<bindport>.Value)

        ' MySQL Options
        obj_Options.MySQLServer = xml.<config>.<mysql>.<server>.Value
        obj_Options.MySQLPort = CInt(xml.<config>.<mysql>.<port>.Value)
        obj_Options.MySQLUsername = xml.<config>.<mysql>.<username>.Value
        obj_Options.MySQLPassword = xml.<config>.<mysql>.<password>.Value
        obj_Options.MySQLDatabase = xml.<config>.<mysql>.<database>.Value

        ' Regular Server Options
        obj_Options.CapCPS = CByte(xml.<config>.<generic>.<capcps>.Value)

        ' Clear out the object's memory.
        xml = Nothing
    End Sub

    Public Sub PingDatabase()
        ' Do this to keep the connection open even if no connection is required right now.
        ' Don't want to keep having to re-open it.
        obj_ConnectorMyBB.Ping()
    End Sub

    Public Sub CheckWaitingAuthentication()
        Dim i As Integer, Query As String, PassHash As String
        ' This sub will be ran on a seperate thread, constantly checking if there's new players awaiting authentication in the background.
        ' It's completely seperate from the other loops and shouldn't interfere with them as such.

        Do While obj_Server.ServerRunning = True
            ' Loop through all currently connected userslots to check for waiting authentications.
            ' If the value goes over the max amount of connected players simply set it to the first again.
            i = i + 1
            If i > var_PlayerHighIndex Then i = 1

            If obj_TempPlayer(i).LoginStatus = LoginStatus.Waiting Then
                ' We've found one! Let's set their status to processing so a different thread can't pick it up by accident.
                obj_TempPlayer(i).LoginStatus = LoginStatus.Processing

                ' Debug Info
                WriteToConsole("Processing User Login with Username: " + obj_TempPlayer(i).Username + " on Slot: " + i.ToString)

                ' Now let's write our Query so we can start retrieving information required to Authenticate.
                Query = "SELECT uid, password, salt FROM mybb_users WHERE username = '" + obj_TempPlayer(i).Username + "' LIMIT 1"

                ' Make our Command object and assign our connection and query to it.
                ' This sytem is really awkward, we get our data and through a few passes assign it to a table.
                ' Not sure how else to do this.. ADODB is much easier.
                obj_CommandMyBB.Connection = obj_ConnectorMyBB
                obj_CommandMyBB.CommandText = Query
                obj_ReaderMyBB.SelectCommand = obj_CommandMyBB
                obj_ReaderMyBB.Fill(obj_DataTableMyBB)

                ' Check if there's anything in the data we just retrieved.
                If obj_DataTableMyBB.Rows.Count > 0 Then
                    ' There's data in these fields. Nice! Now we can process it.

                    ' Fill up our empty data fields we just retrieved.
                    obj_TempPlayer(i).DataGUID = obj_DataTableMyBB.Rows(0).Item("uid")
                    obj_TempPlayer(i).DBPassword = obj_DataTableMyBB.Rows(0).Item("password")
                    obj_TempPlayer(i).Salt = obj_DataTableMyBB.Rows(0).Item("salt")

                    ' Retrieve the salted hash based on the password the user entered.
                    ' This is done in the same way MyBB hashes its passwords and should always return a similar password hash
                    ' if entered correctly.
                    PassHash = Crypto.StringMD5Hash(Crypto.StringMD5Hash(obj_TempPlayer(i).Salt) + obj_TempPlayer(i).Password)

                    ' Now it's time to compare our efforts and see if the entered password matches the password on file.
                    If PassHash = obj_TempPlayer(i).DBPassword Then
                        ' It matches! Set the state of our user to Verified. Another thread will pick this up and sort him out.
                        obj_TempPlayer(i).LoginStatus = LoginStatus.Verified

                        ' But we still need to load the user's data before he gets sent his information.
                        ' So let's do this!
                        ' First check if the user has a data file saved on the server.
                        If FileExist(DATA_ROOT + DATA_PLAYERS + obj_TempPlayer(i).DataGUID.ToString + ".dat") Then
                            ' File exists, the user has been on the server before.
                            ' Time to load his/her data to send them!
                            LoadPlayer(i)
                        Else
                            ' No data on file. Let's save our empty data down into a file to make sure it's there for later.
                            SavePlayer(i)
                        End If

                        ' Debug Info
                        WriteToConsole("User: " + obj_TempPlayer(i).Username + " has been Verified on Slot: " + i.ToString)
                    Else
                        ' It doesn't match, set it to rejected and another thread will scold our user.
                        obj_TempPlayer(i).LoginStatus = LoginStatus.Rejected

                        ' Debug Info
                        WriteToConsole("User: " + obj_TempPlayer(i).Username + " has been Rejected on Slot: " + i.ToString)
                    End If
                Else
                    ' There's no data, this means the user does not exist.
                    ' Reject them right away.

                    ' It doesn't match, set it to rejected and another thread will scold our user.
                    obj_TempPlayer(i).LoginStatus = LoginStatus.Rejected

                    ' Debug Info
                    WriteToConsole("User: " + obj_TempPlayer(i).Username + " has been Rejected on Slot: " + i.ToString + " ACCOUNT DOES NOT EXIST!")
                End If

                ' Empty out our data table.
                ' Not doing this would mean the table would retain its entries at all times, only adding onto it rather than replacing it.
                ' This single line of code caused a good amount of frustration early on with authentication issues.
                ' Don't remove it.
                obj_DataTableMyBB.Clear()

                ' Send our user the final result.
                SendLoginResult(i)
            End If

            ' We don't want to overburden the system's CPU, so let's keep the thread asleep for 1ms every cycle.
            ' That is, if the options allow us to.
            If obj_Options.CapCPS = 1 Then Thread.Sleep(1)
        Loop

    End Sub

    Public Sub InitMySQL()
        ' Initialize the connector.
        obj_ConnectorMyBB = New MySqlConnection()

        ' Set up the connection string to use.
        obj_ConnectorMyBB.ConnectionString = "server=" + obj_Options.MySQLServer + ";" _
        + "port=" + CStr(obj_Options.MySQLPort) + ";" _
        + "user id=" + obj_Options.MySQLUsername + ";" _
        + "password=" + obj_Options.MySQLPassword + ";" _
        + "database=" + obj_Options.MySQLDatabase

        ' Attempt to open the connection to the database and retrieve our data.
        Try
            obj_ConnectorMyBB.Open()
        Catch ex As Exception
            ' Write our error message to the console and close once a key is hit.
            WriteToConsole(ex.Message)
            WriteToConsole("Press any key to close server.")
            Dim temp As String = Console.ReadLine()
            End
        End Try

    End Sub

End Module
