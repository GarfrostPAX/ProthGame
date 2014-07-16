Module modServerTCP
    Public obj_Server As Nading.Network.Server.clsServer

    Public Sub InitServerTCP()

        ' Declare the new object to make sure we can make use of it in the project.
        obj_Server = New Nading.Network.Server.clsServer

        ' Add event handlers to the Server Object that will determine what will happen in specific events.
        AddHandler obj_Server.ServerStarted, AddressOf OnServerStarted
        AddHandler obj_Server.ServerStopped, AddressOf OnServerStopped
        AddHandler obj_Server.ClientConnected, AddressOf OnClientConnected
        AddHandler obj_Server.ClientDisconnected, AddressOf OnClientDisconnected
        AddHandler obj_Server.ClientPacketReceived, AddressOf OnClientPacketReceived

        ' Set the server's bind Address and Port to listen on. (passed on through the main initialization sub)
        obj_Server.ServerBindIPAdress = obj_Options.ServerBindAddress
        obj_Server.ServerBindPort = obj_Options.ServerBindPort

        ' Start the server listener. Make sure you don't turn on packet queues or the above event triggers will no longer work.
        obj_Server.StartServer(False)
    End Sub

    Friend Sub OnServerStarted()
        WriteToConsole("Server succesfully started!")
    End Sub

    Friend Sub OnServerStopped()
        WriteToConsole("Server succesfully stopped!")
    End Sub

    Friend Sub OnClientConnected(ByVal Client As Guid)
        Dim Slot As Integer

        ' Debug Info
        WriteToConsole("Received connection on GUID: " + Client.ToString)

        ' Try to find an empty slot for this new user.
        Slot = FindEmptySlot()

        ' Check if there was an open slot, 0 means no.
        If Slot <> 0 Then
            ' We have a slot available, let's set the ServerGUID.
            obj_TempPlayer(Slot).ServerGUID = Client

            ' Now pass on the slot to the player themselves.
            SendClientSlot(Client, Slot)

            ' Check to see if this is above our current HighIndex. If so, set our new index to the current slot.
            If Slot > var_PlayerHighIndex Then var_PlayerHighIndex = Slot

            ' Debug Info
            WriteToConsole("GUID: " + Client.ToString + " assigned to Slot: " + Slot.ToString)
        Else
            ' We'll need to disconnect our new friend. No slots available.
            ' First we'll notify them of this however.
            SendSystemMessage(Client, SystemMessages.MsgError, "The server is full, please try again later!", "Server Full")

            ' No need to forcibly disconnect them. The client will kill its own connection since we sent an error message.

            ' Debug Info
            WriteToConsole("GUID: " + Client.ToString() + " dropped, no more Slots.")
        End If
    End Sub

    Friend Sub OnClientPacketReceived(ByVal Client As Guid, ByVal PacketType As Byte, ByVal Packet As String)
        Dim Slot As Integer, PacketContent() As String

        ' Since our packet is encrypted, we should decrypt it before it all goes to hell.
        Packet = Crypto.Decrypt(Packet, CRYPTO_KEY)

        ' Retrieve the slot info.
        PacketContent = Split(Packet, SEP_SYMBOL)
        Slot = PacketContent(0)

        ' Pass on the packet to our handler sub.
        HandleIncomingPacket(Client, Slot, PacketType, Packet)

        ' Debug Info
        WriteToConsole("Received PacketType: " + PacketType.ToString + " from Slot: " + Slot.ToString)
    End Sub

    Friend Sub OnClientDisconnected(ByVal Client As Guid)
        Dim Slot As Integer
        ' We've lost connection to this player, so we'll save their changes to our database and clear the slot to be used by someone else.
        ' First we need to figure out the player slot though.
        Slot = FindPlayerByGUID(Client)

        ' if the slot is non-existant then there's no need to clear it.
        If Slot <> 0 Then
            ' We have a slot to save and clear.
            ' So let's get to saving their data!
            SavePlayer(Slot)

            ' Clear out our slot for future use.
            ClearPlayer(Slot)

            ' See if we need to recalculate our HighIndex.
            If Slot = var_PlayerHighIndex Then
                ' Our HighIndex has left the game! Recalculate.
                CalculateHighIndex()
            End If
        End If

        ' Debug Info
        WriteToConsole("Lost connection on GUID: " + Client.ToString + " with Slot: " + Slot.ToString)
    End Sub

    Public Sub SendDataTo(ByVal Client As Guid, ByVal PacketType As Byte, ByVal Packet As String)
        ' Encrypt our data before we send it off.
        Packet = Crypto.Encrypt(Packet, CRYPTO_KEY)

        ' Easy peasy, just pass on the data.
        obj_Server.SendPacketToClient(Client, PacketType, Packet)

        ' Debug Info
        WriteToConsole("Sent PacketType: " + PacketType.ToString + " to Slot: " + CStr(FindPlayerByGUID(Client)))
    End Sub

    Public Sub SendDataToAll(ByVal PacketType As Byte, ByVal Packet As String)
        ' Encrypt our data before we send it off.
        Packet = Crypto.Encrypt(Packet, CRYPTO_KEY)

        ' Nading supports this by default, so no need to loop through stuff. :)
        obj_Server.SendPacketToAllClients(PacketType, Packet)

        ' Debug Info
        WriteToConsole("Sent PacketType: " + PacketType.ToString + " to All")
    End Sub

    Public Sub SendClientSlot(ByVal Client As Guid, ByVal Slot As Integer)
        ' This is a simple one, all we need to do is pass on the player slot to the client.
        ' There's a simple reason for this, instead of constantly figuring out what GUID belongs to which Array slot
        ' the player client will simply pass on their ID along with other data.
        SendDataTo(Client, ServerPackets.SendClientSlot, Slot.ToString)
    End Sub

    Public Sub SendSystemMessage(ByVal Client As Guid, ByVal MessageType As Byte, ByVal Message As String, ByVal MessageTitle As String)
        Dim Packet As String
        ' We'll be sending a system message to a client. It's fairly simple stuff.
        ' First let's build the packet though.
        Packet = MessageType.ToString + SEP_SYMBOL + Message + SEP_SYMBOL + MessageTitle

        ' Now let's send it to our player.
        SendDataTo(Client, ServerPackets.SendSystemMessage, Packet)
    End Sub

    Public Sub SendLoginResult(ByVal Slot As Integer)
        Dim Packet As String

        ' Is the user verified or rejected?
        If obj_TempPlayer(Slot).LoginStatus = LoginStatus.Verified Then
            ' Verified. This means we can send them the ol' "it's OK to move on" packet. 
            ' Which also contains all the user's character data.

            ' Time to build up our packet. We'll be throwing in basic character data.
            ' This is going to be used in the character selection screen which is triggered from this
            ' message.
            ' TODO: Clean this up, it looks terrible.
            With obj_Player(Slot)
                Packet = .Character(1).Name _
                    + SEP_SYMBOL + .Character(1).Job.ToString _
                    + SEP_SYMBOL + .Character(1).Level.ToString _
                    + SEP_SYMBOL + .Character(2).Name _
                    + SEP_SYMBOL + .Character(2).Job.ToString _
                    + SEP_SYMBOL + .Character(2).Level.ToString _
                    + SEP_SYMBOL + .Character(3).Name _
                    + SEP_SYMBOL + .Character(3).Job.ToString _
                    + SEP_SYMBOL + .Character(3).Level.ToString
            End With

            ' The packet has been constructed, we can send it over now.
            SendDataTo(obj_TempPlayer(Slot).ServerGUID, ServerPackets.SendLoginOK, Packet)

        ElseIf obj_TempPlayer(Slot).LoginStatus = LoginStatus.Rejected Then
            ' Rejected, we should let them know.
            ' The message is client-side, and generic.

            ' No data needed here.
            Packet = ""

            ' Send it off!
            SendDataTo(obj_TempPlayer(Slot).ServerGUID, ServerPackets.SendLoginFailure, Packet)
        End If

    End Sub

    Public Sub SendCreateCharResult(ByVal Slot As Integer)
        Dim Packet As String

        ' Time to build up our packet. We'll be throwing in basic character data.
        ' This is going to be used in the character selection screen which is triggered from this
        ' message.
        ' TODO: Clean this up, it looks terrible.
        With obj_Player(Slot)
            Packet = .Character(1).Name _
                + SEP_SYMBOL + .Character(1).Job.ToString _
                + SEP_SYMBOL + .Character(1).Level.ToString _
                + SEP_SYMBOL + .Character(2).Name _
                + SEP_SYMBOL + .Character(2).Job.ToString _
                + SEP_SYMBOL + .Character(2).Level.ToString _
                + SEP_SYMBOL + .Character(3).Name _
                + SEP_SYMBOL + .Character(3).Job.ToString _
                + SEP_SYMBOL + .Character(3).Level.ToString
        End With

        ' Send data off!
        SendDataTo(obj_TempPlayer(Slot).ServerGUID, ServerPackets.SendCreateCharResult, Packet)

    End Sub

End Module
