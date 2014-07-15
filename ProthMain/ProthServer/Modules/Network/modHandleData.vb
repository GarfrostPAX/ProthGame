Imports System.Threading

Module modHandleData

    Public Sub HandleIncomingPacket(ByVal Client As Guid, ByVal Slot As Integer, ByVal PacketType As Byte, ByVal Packet As String)
        ' This is where we'll keep a list of all PacketTypes and where to pass on our data to.
        ' It's a really basic lazy system, but it works. (Possible future change: AddressOf pointers?)
        Select Case PacketType

            Case ClientPackets.RequestVersion
                HandleRequestVersion(Client, Slot, Packet)
                Exit Sub

            Case ClientPackets.RequestPING
                ' TODO: Write Ping System
                Exit Sub

            Case ClientPackets.RequestLogin
                HandleRequestLogin(Client, Slot, Packet)
                Exit Sub

            Case ClientPackets.RequestLogout
                HandleRequestLogout(Client, Slot, Packet)
                Exit Sub

        End Select
    End Sub

    Private Sub HandleRequestVersion(ByVal Client As Guid, ByVal Slot As Integer, ByVal Packet As String)
        ' No need to tear apart the packet string. It's a simple request.
        ' Just respond to the client with the version number.
        SendDataTo(Client, ServerPackets.SendVersion, VERSION)
    End Sub

    Private Sub HandleRequestLogin(ByVal Client As Guid, ByVal Slot As Integer, ByVal Packet As String)
        Dim PacketContent() As String, i As Integer

        ' Tear the packet apart so we can get the information we need out of it.
        PacketContent = Split(Packet, SEP_SYMBOL)

        ' Dump our known information into our player stucture.
        obj_TempPlayer(Slot).Username = PacketContent(1)
        obj_TempPlayer(Slot).Password = PacketContent(2)

        ' Before we continue, we should see if another user is already logged in or logging in with this username.
        ' If so, kick that user and let this login session pass on.
        ' This session could exist for various reasons, be it a bug in the server or a client left on on a different machine.
        For i = 1 To var_PlayerHighIndex
            ' Make sure we're not looking at the same slot as the current user is on.
            If i <> Slot Then
                ' Check if the username is the same.
                If obj_TempPlayer(i).Username = obj_TempPlayer(Slot).Username Then
                    ' It is, we should kill this connection and save the player's data.

                    ' First save his/her data to make sure nothing is lost.
                    SavePlayer(i)

                    ' Set the state of the player to no longer be in-game, so they don't receive updated information.
                    obj_TempPlayer(i).InGame = False

                    ' Send a system message to kick him/her off of the server.
                    SendSystemMessage(obj_TempPlayer(i).ServerGUID, SystemMessages.MsgWarning, "This account is being used to log in from another location." + vbNewLine + "Please make sure your password is safe.", "Double Login")

                    ' Debug Info
                    WriteToConsole("Double Login detected on Slot: " + i.ToString + " and Slot: " + Slot.ToString)
                End If
            End If
        Next

        ' Let's make sure our login status is set to waiting. 
        ' The client will not receive their final OK until this is set to either verified or rejected.
        ' This sub itself will no longer process information on the user. A seperate thread will constantly be checking for new ''waiting'' clients.
        obj_TempPlayer(Slot).LoginStatus = LoginStatus.Waiting

    End Sub

    Private Sub HandleRequestLogout(ByVal Client As Guid, ByVal Slot As Integer, ByVal Packet As String)
        Dim tempGUID As Guid

        ' This user wants to log out! Fair enough.
        ' Before we do anything else we should save their data though.
        SavePlayer(Slot)

        ' Now we should make a backup of the GUID before clearing out the player.
        tempGUID = obj_TempPlayer(Slot).ServerGUID

        ' Clear out the player data.
        ClearPlayer(Slot)

        ' Set our GUID back to where it belongs so we still recognize him/her.
        obj_TempPlayer(Slot).ServerGUID = tempGUID

        ' Debug Info
        WriteToConsole("GUID: " + tempGUID.ToString + " has logged out on Slot: " + Slot.ToString)

    End Sub

End Module
