Module modHandleData

    Public Sub HandleIncomingPacket(ByVal PacketType As Byte, ByVal Packet As String)
        ' This is where we'll keep a list of all PacketTypes and where to pass on our data to.
        ' It's a really basic lazy system, but it works. (TODO: Possible future change: AddressOf pointers?)
        Select Case PacketType

            Case ServerPackets.SendVersion
                HandleSendVersion(Packet)
                Exit Sub

            Case ServerPackets.SendPING
                ' TODO: Add a Ping calculation.
                Exit Sub

            Case ServerPackets.SendSystemMessage
                HandleSendSystemMessage(Packet)
                Exit Sub

            Case ServerPackets.SendClientSlot
                HandleSendClientSlot(Packet)
                Exit Sub

            Case ServerPackets.SendLoginFailure
                HandleSendLoginFailure(Packet)
                Exit Sub

            Case ServerPackets.SendLoginOK
                HandleSendLoginOK(Packet)
                Exit Sub

        End Select
    End Sub

    Private Sub HandleSendVersion(ByVal Packet As String)
        ' Since this packet only contains a single item, the version we will not need to pull it apart.
        ' Now then, time to check if the Server and Client version are the exact same.
        If LCase(VERSION) <> LCase(Packet) Then
            ' Not the same! Notify the user and close the program.
            MsgBox("Your client is outdated! Please make sure you have the latest version installed.", MsgBoxStyle.Critical, "Version Mismatch")
            DestroyGame()
        End If
    End Sub

    Private Sub HandleSendSystemMessage(ByVal Packet As String)
        Dim PacketContent() As String
        ' Time to figure out what our glorious server overlord is about to tell us.

        ' Before we do anything, we'll need to tear apart our packet string.
        PacketContent = Split(Packet, SEP_SYMBOL)

        Select Case CByte(PacketContent(0))

            Case SystemMessages.MsgError
                ' An error message.
                MsgBox(PacketContent(1), MsgBoxStyle.Critical, PacketContent(2))
                DestroyGame()

            Case SystemMessages.MsgInfo
                ' An info message.
                MsgBox(PacketContent(1), MsgBoxStyle.Information, PacketContent(2))
                DestroyGame()

            Case SystemMessages.MsgWarning
                ' A warning message.
                MsgBox(PacketContent(1), MsgBoxStyle.Exclamation, PacketContent(2))
                DestroyGame()
        End Select

    End Sub

    Private Sub HandleSendClientSlot(ByVal Packet As String)
        ' A very important packet, it will tell us which Slot we're on in the server Arrays.
        ' We'll be using this for a lot of packets we'll send out.
        ' Just one item in this packet, so no need to tear it apart.

        ' Convert the packet info to an Integer.
        var_MySlot = CInt(Packet)

        ' Now continue to request the client version.
        SendRequestVersion()
    End Sub

    Private Sub HandleSendLoginFailure(ByVal Packet As String)
        ' This packet contains no data, so we don't have to take it apart.
        ' Since this is a failure, all we need to do is notify the user and set our form back to a state that can be used again.

        ' Set the logging in state to a failure.
        var_LoggingIn = LoginStates.Rejected
        
    End Sub

    Private Sub HandleSendLoginOK(ByVal Packet As String)
        Dim PacketContent() As String

        ' This packet contains basic character data. We should parse this.
        PacketContent = Split(Packet, SEP_SYMBOL)

        ' Throw our data into our temporary arrays.
        ' TODO: Clean this up, it looks terrible.
        var_TempName(1) = PacketContent(0)
        var_TempJob(1) = CByte(PacketContent(1))
        var_TempLevel(1) = CByte(PacketContent(2))
        var_TempName(2) = PacketContent(3)
        var_TempJob(2) = CByte(PacketContent(4))
        var_TempLevel(2) = CByte(PacketContent(5))
        var_TempName(3) = PacketContent(6)
        var_TempJob(3) = CByte(PacketContent(7))
        var_TempLevel(3) = CByte(PacketContent(8))

        ' All our data should be parsed now, and we're ready for the character select screen.
        ' time to move on!
        ' Set the logging in state to accepted.
        var_LoggingIn = LoginStates.Accepted

    End Sub

End Module
